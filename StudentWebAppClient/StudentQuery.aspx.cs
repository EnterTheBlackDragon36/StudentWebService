using StudentWebAppClient.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using StudentInterface;


namespace StudentWebAppClient
{
    public partial class StudentQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            //CalculatorService.CalculatorWebServiceSoapClient client = new CalculatorService.CalculatorWebServiceSoapClient();
            //int result = client.Add(Convert.ToInt32(txtFirstNumber.Text), Convert.ToInt32(txtSecondNumber.Text));
            //lblResult.Text = result.ToString();

            //gvCalculations.DataSource = client.GetCalculations();
            //gvCalculations.DataBind();
        }

        protected void getStudent_Click(object sender, EventArgs e)
        {
            string nullErrorMsg = "Please Enter in a Student Id to search for a Student.";
            if (txtStudentId.Text != null)
            {
                try
                {
                    StudentService.StudentServiceSoapClient client = new StudentService.StudentServiceSoapClient();
                    int studentID = Convert.ToInt32(txtStudentId.Text);
                    Student student = (Student)client.GetStudentById(studentID);

                    txtFirstName.Text = student.firstname;
                    txtLastName.Text = student.lastname;
                    txtAge.Text = student.Age.ToString();
                    txtGender.Text = student.Gender;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                lblErrorMsg.Text = nullErrorMsg;
                lblErrorMsg.Visible = true;
            }
        }

        protected void getStudentAuthentication_Click(object sender, EventArgs e)
        {
            string nullErrorMsg = "Please Enter in a Student Id to search for a Student.";
            if (txtStudentId.Text != null)
            {

                try
                {
                    StudentService.StudentServiceSoapClient client = new StudentService.StudentServiceSoapClient();
                    int studentID = Convert.ToInt32(txtStudentId.Text);
                    string studentLastName = txtLastName.Text.ToString();
                    ResponseMessage responseMessage = (ResponseMessage)client.GetStudentAuthentication(studentID, studentLastName);
                    lblResponse.Text = responseMessage.response.ToString();
                    lblMessageId.Text = responseMessage.messageId.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                lblErrorMsg.Text = nullErrorMsg;
                lblErrorMsg.Visible = true;
            }
        }



    }
}