using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.



namespace WcfServiceLibrary2
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet]
        string UploadFile(Stream fileContents);
        [OperationContract]
        [WebGet]
        string TestFunction(string testcont);

        // TODO: Добавьте здесь операции служб
    }


    // TODO: Добавьте здесь операции служб
}

// Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
// В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "WcfServiceLibrary2.ContractType".

