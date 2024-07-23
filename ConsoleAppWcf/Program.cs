using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.IO;
using System.Diagnostics;
using ConsoleAppWcf.ServiceReference1;

//using ServiceReference1;

namespace WcfServiceLibrary1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string baseAddress = "http://" + Environment.MachineName + ":8733/Service1";     //Базовый адрес службы
            ServiceHost host = new ServiceHost(typeof(Service1), new Uri(baseAddress));     //Создание хоста
            host.AddServiceEndpoint(typeof(IService1), new WebHttpBinding(), "Soap").Behaviors.Add(new WebHttpBehavior());  //Добавление конечной точки SOAP*/
            Stopwatch stopwatch = new Stopwatch();  //Переменная для таймера
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.TransferMode = TransferMode.Streamed;
            EndpointAddress address = new EndpointAddress("http://localhost:8733/Service1");
            Service1Client client = new Service1Client(binding, address);
            client.Open();    //Открытие хоста
                              //using (ChannelFactory<IService1> wcf = new ChannelFactory<IService1>(new WebHttpBinding(), baseAddress + "/Soap"))
                              //{
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
            Console.WriteLine(client.UploadFile(Cont));
            stopwatch.Stop();
            Console.WriteLine("Time: {0}", stopwatch.ElapsedMilliseconds);
                Console.Write("Press ENTER to close the host");
                Console.ReadLine();
                client.Close();
            //}
        }
    }
}