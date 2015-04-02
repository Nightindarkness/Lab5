using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string AddWord(string lang1, string lang2, string word1, string word2);

        [OperationContract]
        string ChangeWord(string column,string columnData, string word);

        [OperationContract]
        string DeleteWord(string lang, string word);

        [OperationContract]
        List<string> getDictionary(string studentId);

        [OperationContract]
        List<string> getUsers();

        [OperationContract]
        void setQuiz(string userId, string questionW);

        [OperationContract]
        List<string> getAnswers(string userId);

        [OperationContract]
        string SetGrade(string grade, string userId);

        [OperationContract]
        List<string> getAdminDictionary();
    }


    
}
