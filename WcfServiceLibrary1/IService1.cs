using System.IO;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet]
        string UploadFile(Stream fileContents);

    }
    
}
