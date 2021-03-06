﻿using System;
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
            con.Close();
            
            return string.Format("You sucessfully your words to the database");

        }

        public string ChangeWord(string column,string columnData, string word)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "update dictionary set " +column+"= '" + columnData + "' where word1= '" + word + "'";
            com.ExecuteNonQuery();
            con.Close();
            return string.Format("You have sucessfully changed "+column +" to "+ columnData);
        }

        public string DeleteWord(string lang, string word)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "delete from dictionary where lang1='" + lang + "' and word1='" + word +"'";
            com.ExecuteNonQuery();
            con.Close();
            return string.Format("You have now deleted the row for the word "+word);
        }

        public List<string> getDictionary(string studentId)
        {
            //List<List<string>> words = new List<string>();
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

        public string SetGrade(string grade, string userId)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "update users set grade= '" + grade + "' where userId= '" + userId + "'";
            com.ExecuteNonQuery();
            con.Close();


            com.Connection = con;
            con.Open();
            com.CommandText = "delete from quiz where userId= '" + userId + "'";
            com.ExecuteNonQuery();
            con.Close();

            return string.Format("You have set the grade to "+ grade +" and sucessfully deleted the quiz for this user.");
        }


        public string Register(string name, string nativelang, string learntlang)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "insert into users (name, nativeLang, learntLang) values ('" + name + "','" + nativelang + "','" + learntlang + "')";
            com.ExecuteNonQuery();
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


        public string sendQuiz(string id,string question , string answer)
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "update quiz set answer= '"+answer+"' where userId= '"+id+"' and question='"+question+"'";
            com.ExecuteNonQuery();
            con.Close();
            
            return string.Format("UPDATE");
        }


        public List<string> getAdminDictionary()
        {
            com.Connection = con;
            con.Open();
            com.CommandText = "select * from dictionary";
            re = com.ExecuteReader();
            List<string> words = new List<string>();

            if (re.HasRows)
            {
                while (re.Read())
                {

                    words.Add(re[0].ToString());

                }
            }


            con.Close();
            return words;
        }
    }
}
