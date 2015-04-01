﻿using System;
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
        string ChangeWord(string word1, string word2);

        [OperationContract]
        string DeleteWord(string word1, string word2);

        [OperationContract]
        List<string> getDictionary();

        [OperationContract]
        List<List<string>> getUsers();

        [OperationContract]
        string setQuiz(string userId, string questionW);

        [OperationContract]
        string getAnswers(string userId);

        [OperationContract]
        string SetGrade(string grade);

        [OperationContract]
        string Register(string name, string nativelang, string learntlang);

        [OperationContract]
        List<string> getUser(string user);

        [OperationContract]
        List<string> getQuiz(int id);

        [OperationContract]
        string sendQuiz(int id, string answer);
    }


    
}
