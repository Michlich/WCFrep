using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;
using ConsoleApp1.ServiceReference1;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Transport;
            myBinding.Security.Transport.ClientCredentialType =
               HttpClientCredentialType.Certificate;

            // Create the endpoint address. Note that the machine name
            // must match the subject or DNS field of the X.509 certificate  
            // used to authenticate the service.
            var ea = new
               EndpointAddress("https://127.0.0.1/App_Code/Service.cs");

            // Create the client. The code for the calculator
            // client is not shown here. See the sample applications  
            // for examples of the calculator code.  
            var cc = new ServiceClient(myBinding, ea);

            // The client must specify a certificate trusted by the server.  
            cc.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "localhost");

            // Begin using the client.  
            Console.WriteLine(cc.TestFunction("1111"));
            //...  
            cc.Close();
        }
    }
}
