using System;
using System.IO;

namespace WcfServiceLibrary1
{
   
    public class Service1 : IService1
    {
        public string UploadFile(Stream fileContents)
        {
            byte[] buffer = new byte[1073741824];
            int bytesRead, totalBytesRead = 0;
            do
            {
                bytesRead = fileContents.Read(buffer, 0, buffer.Length);
                totalBytesRead += bytesRead;
            } while (bytesRead > 0);
            return "Service: Received file with bytes" + totalBytesRead;
        }
    }
}
