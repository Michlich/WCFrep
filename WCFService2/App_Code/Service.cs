using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени класса "Service" в коде, SVC-файле и файле конфигурации.
public class Service : IService
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
    public string TestFunction(string testcont)
    {
        return testcont + "123";
    }
}
