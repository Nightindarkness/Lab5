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

        public string blaha()
        {
            return "FUCKOFFANDDIE";
        }


        public string AddWord(string lang1, string lang2, string word1, string word2)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "insert into dictionary (lang1, lang2, word1, word2) values ('" + lang1 + "','" + lang2 + "','" + word1 + "','" + word2 + "')";
            com.ExecuteNonQuery();
            com.Clone();
            con.Close();
            //return string.Format("You entered: {0}", value);
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

        public List<string> getDictionary(string studentId)
        {
            //List<string> words = new List<string>();
            com.Connection = con;
            con.Open();
            com.CommandText = "select nativeLang, learntLang from users "+"where userId="+studentId;
            re = com.ExecuteReader();
            string nativeLang ="";
            string learnLang="";
            List<string> toWords = new List<string>();
            if (re.HasRows)
            {
                while (re.Read())
                {
                    
                       
                    
                    nativeLang = re["nativeLang"].ToString();
                    learnLang = re["learntLang"].ToString();
                    toWords.Add(nativeLang + " to " + learnLang);
                }
            }
            con.Close();
            com.Connection = con;
            con.Open();
            
            
            com.CommandText = "select * from dictionary";
            re = com.ExecuteReader();
            int i = 0;
           
            if (re.HasRows)
            {
                while (re.Read())
                {
                    

                    if (re["lang1"].ToString().Equals(nativeLang) && re["lang2"].ToString().Equals(learnLang))
                    {
                    toWords.Add(re["word1"].ToString()+":"+re["word2"].ToString());
                    i++;
                    }
                }
            }

            con.Close();

            return toWords;
        }

        public List<string> getUsers()
        {
            com.Connection = con; 
            con.Open();
            com.CommandText = "select * from users";
            re = com.ExecuteReader();
            List<string> users = new List<string>();
            
             if (re.HasRows)
            {
                while (re.Read())
                {

                     users.Add(re["userId"].ToString()+":"+re["name"].ToString());
                     
                }
            }

             
             con.Close();
             return users;
        }

        public void setQuiz(string userId, string questionW)
        {

            com.Connection = con;
            con.Open();
            com.CommandText = "insert into quiz (userId, question) values ('" + userId + "','" + questionW + "')";
            com.ExecuteNonQuery();
            
            con.Close();
            
        }

        public List<string> getAnswers(string userId)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "select question, answer from quiz "+"where userId="+userId;
            re = com.ExecuteReader();
            List<string> answers = new List<string>();

            if (re.HasRows)
            {
                while (re.Read())
                {

                    answers.Add(re["question"].ToString() + ":" + re["answer"].ToString());

                }
            }


            con.Close();
            return answers;
        }

        public string SetGrade(string grade)
        {
            throw new NotImplementedException();
        }
    }
}
