using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentWebService
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void getStudent_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDebugConnectionString"].ToString());
            SqlCommand cmd = new SqlCommand("SELECT_STUDENTS_BY_ID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", txtStudentId.Text);
            //Student student = new Student();
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtFirstName.Text = reader["FirstName"].ToString();
                txtLastName.Text = reader["LastName"].ToString();
                txtGender.Text = reader["Gender"].ToString();
                txtAge.Text = reader["Age"].ToString();
                
            }

            reader.Close();
            conn.Close();

            //return student;
        }

        //public Student GetStudentById(int id)
        //{
        //    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLDebugConnectionString"].ToString());
        //    SqlCommand cmd = new SqlCommand("SELECT_STUDENTS_BY_ID", conn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@id", id);
        //    Student student = new Student();
        //    conn.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        student.id = Convert.ToInt32(reader["id"]);
        //        student.firstname = reader["FirstName"].ToString();
        //        student.lastname = reader["LastName"].ToString();
        //        student.Gender = reader["Gender"].ToString();
        //        student.Age = Convert.ToInt32(reader["Age"]);
        //    }

        //    reader.Close();
        //    conn.Close();

        //    return student;
        //}
        
    }
}