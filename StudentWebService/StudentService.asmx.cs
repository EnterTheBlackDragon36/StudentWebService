using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using StudentInterface;

namespace StudentWebService
{
    /// <summary>
    /// Summary description for StudentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.None)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StudentService : System.Web.Services.WebService
    {

        public enum decision
        {
            ALLOW,
            DENY,
            NOTAPPLICABLE
        }

        [WebMethod]
        public Student GetStudentById(int id)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDebugConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT_STUDENTS_BY_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            Student student = new Student();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                student.id = Convert.ToInt32(reader["id"]);
                student.firstname = reader["FirstName"].ToString();
                student.lastname = reader["LastName"].ToString();
                student.Gender = reader["Gender"].ToString();
                student.Age = Convert.ToInt32(reader["Age"]);
            }

            reader.Close();
            conn.Close();

            return student;
        }


        [WebMethod]
        public Student GetStudentByPersonId(int id, string lastName)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDebugConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT_STUDENTS_BY_PERSON_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            Student student = new Student();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                student.id = Convert.ToInt32(reader["id"]);
                student.firstname = reader["FirstName"].ToString();
                student.lastname = reader["LastName"].ToString();
                student.Gender = reader["Gender"].ToString();
                student.Age = Convert.ToInt32(reader["Age"]);
            }

            reader.Close();
            conn.Close();

            return student;
        }

        [WebMethod]
        public ResponseMessage GetStudentAuthentication(int id, string lastName)
        {
            ResponseMessage responseMessage = new ResponseMessage();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDebugConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT_STUDENTS_BY_PERSON_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@lastName", lastName);
            Student student = new Student();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                student.id = Convert.ToInt32(reader["id"]);
                student.firstname = reader["FirstName"].ToString();
                student.lastname = reader["LastName"].ToString();
                student.Gender = reader["Gender"].ToString();
                student.Age = Convert.ToInt32(reader["Age"]);

                if (student.id == (Convert.ToInt32(reader["id"])) && (student.lastname == reader["LastName"].ToString()))
                {
                    responseMessage.response = decision.ALLOW.ToString();
                    responseMessage.messageId = 25411535;
                }
                else if (student.id != (Convert.ToInt32(reader["id"])) || student.lastname != reader["LastName"].ToString())
                {
                    responseMessage.response = decision.DENY.ToString();
                    responseMessage.messageId = 0;
                }
                //else if (student.id != (Convert.ToInt32(reader["id"])) || student.lastname != reader["LastName"].ToString())
                //{
                //    responseMessage.response = decision.DENY.ToString();
                //    responseMessage.messageId = 0;
                //}
            }

            reader.Close();
            conn.Close();

            return (ResponseMessage)responseMessage;
        }

        public class ResponseMessage
        {
            public string response { get; set; }
            public int messageId { get; set; }
        }


    }
}
