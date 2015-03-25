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

        private static SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=G:\Visual studio projekt\QUIZLANG\WCFServiceWebRole1\App_Data\lab7.mdf;Integrated Security=True");
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
    }
}
