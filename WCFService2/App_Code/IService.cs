﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Реструктуризация" можно использовать для одновременного изменения имени интерфейса "IService" в коде и файле конфигурации.
[ServiceContract]
public interface IService
{

    [OperationContract]
    [WebGet]
    string UploadFile(Stream fileContents);
    [OperationContract]
    [WebGet]
    string TestFunction(string testcont);

    // TODO: Добавьте здесь операции служб
}

// Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.

