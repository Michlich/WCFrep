using ConsoleApp1.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            NetTcpBinding myBinding = new NetTcpBinding();
            //myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.TransferMode = TransferMode.Streamed;
            myBinding.Security.Transport.ClientCredentialType = TcpClientCredentialType.None;
            // Create the endpoint address. Note that the machine name
            // must match the subject or DNS field of the X.509 certificate  
            // used to authenticate the service.
            var ea = new EndpointAddress("net.tcp://localhost:9000/streamserver");

            // Create the client. The code for the calculator
            // client is not shown here. See the sample applications  
            // for examples of the calculator code.  
            var cc = new Service1Client(myBinding, ea);
            // The client must specify a certificate trusted by the server.  
            cc.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.LocalMachine, StoreName.My,
                X509FindType.FindByThumbprint,
                "76637e1ffc82bc8f31cd17d4f0a5004d86214872");
            cc.Open();
            FileInfo fileInfo = new FileInfo("1GB.txt");
            long chunkSize = fileInfo.Length;
            byte[] bytes = new byte[chunkSize];
            Console.WriteLine(chunkSize);
            using (var stream = fileInfo.OpenRead())
            {
                int count = stream.Read(bytes, 0, bytes.Length);
            }
            fileInfo = null;
            Stream Cont = new MemoryStream(bytes);


            //IService1 service1 = wcf.CreateChannel();
            //Service1 service1 = new Service1;
            Console.WriteLine("Create channel");
            stopwatch.Start();
            Console.WriteLine(cc.UploadFile(Cont));
            stopwatch.Stop();
            // Begin using the client.
            Console.WriteLine(stopwatch.Elapsed);
            Console.ReadLine();
            //...  
            cc.Close();
        }
    }
}
