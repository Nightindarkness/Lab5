using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        private static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|lab7.mdf;Integrated Security=True");
        private static SqlCommand com = new SqlCommand();
        private SqlDataReader re;

       


        public string AddWord(string lang1, string lang2, string word1, string word2)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "insert into dictionary (lang1, lang2, word1, word2) values ('" + lang1 + "','" + lang2 + "','" + word1 + "','" + word2 + "')";
            com.ExecuteNonQuery();
            com.Clone();
            con.Close();
            
            return string.Format("You sucessfully your words to the database");

        }

        public string ChangeWord(string word1, string word2)
        {
            throw new NotImplementedException();
        }

        public string DeleteWord(string word1, string word2)
        {
            throw new NotImplementedException();
        }

        public List<string> getDictionary()
        {
            //List<string> words = new List<string>();
            List<string> toWords = new List<string>();
            com.Connection = con; 
            con.Open();
            com.CommandText = "select * from dictionary";
            re = com.ExecuteReader();
            int i = 0;
            if (re.HasRows)
            {
                while (re.Read())
                {

                    toWords.Add(re["lang1"].ToString()+" to "+re["lang2"].ToString()+" :"+re["word1"].ToString()+":"+re["word2"].ToString());
                    i++;
                }
            }

            con.Close();

            return toWords;
        }

        public List<List<string>> getUsers()
        {
            com.Connection = con; 
            con.Open();
            com.CommandText = "select userId from users";
            re = com.ExecuteReader();
            List<string> userId = new List<string>();
            List<string> userName = new List<string>();
            List<string> native = new List<string>();
             if (re.HasRows)
            {
                while (re.Read())
                {

                     userId.Add(re["userId"].ToString());
                     userName.Add(re["name"].ToString());
                     native.Add(re["nativeLang"].ToString());
                }
            }

             List<List<string>> users = new List<List<string>>();
             users.Add(userId);
             users.Add(userName);
             users.Add(native);
             con.Close();
             return users;
        }

        public string setQuiz(string userId, string questionW)
        {
            throw new NotImplementedException();
        }

        public string getAnswers(string userId)
        {
            throw new NotImplementedException();
        }

        public string SetGrade(string grade)
        {
            throw new NotImplementedException();
        }


        public string Register(string name, string nativelang, string learntlang)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "insert into users (name, nativeLang, learntLang) values ('" + name + "','" + nativelang + "','" + learntlang + "')";
            com.ExecuteNonQuery();
            com.Clone();
            con.Close();
            return string.Format("You have sucessfully registered");
            
        }

        public List<string> getUser(string user)
        {
            
            com.Connection = con;
            con.Open();
            com.CommandText = "select userId from users where name = '"+user+"'";
            re=com.ExecuteReader();
            List<string> userid = new List<string>();
            while (re.Read())
            {

               userid.Add(re["userId"].ToString());

            }
            
            con.Close();
            return userid;
        }


        public List<string> getQuiz(int id)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "select question from quiz where userId= '"+id+"'";
            re = com.ExecuteReader();
            List<string> question = new List<string>();
            
          
            //if (re.HasRows)
            //{
                while (re.Read())
                {

                    question.Add(re["question"].ToString());
                    
                }
            //}
            con.Close();

            return question;
        }


        public string sendQuiz(int id, string answer)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "update quiz set answer= '"+answer+"' where userId= '"+id+"'";
            com.ExecuteNonQuery();
            com.Clone();
            con.Close();
            
            return string.Format("UPDATE");
        }
    }
}
