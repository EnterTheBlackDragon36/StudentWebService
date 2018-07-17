<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="StudentWebService.Students" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript" >
        function GetStudentById() {
            var id = document.getElementByID("txtStudentId").value;
            StudentWebService.StudentService.GetStudentById(id, GetStudentByIdSuccessCallback);
            
        }

        function GetStudentByIdSuccessCallback(result) {
            document.getElementById("txtFirstName").value = result["FirstName"];
            document.getElementById("txtLastName").value = result["LastName"];
            document.getElementById("txtGender").value = result["Gender"];
            document.getElementById("txtAge").value = result["Age"];
        }

        function GetStudentByIdFailedCallback(errors) {
            alert(errors.get_message());
        }
</script>
</head>
<body>
    <form id="form1" runat="server">

        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/StudentService.asmx" />
            </Services>
        </asp:ScriptManager>

        <table style="font-family:Arial">
            <tr>
<td>
<b>Student Id</b>
</td>
<td>
<asp:TextBox ID="txtStudentId" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<b>First Name</b>
</td>
<td>
<asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<b>Last Name</b>
</td>
<td>
<asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<b>Gender</b>
</td>
<td>
<asp:TextBox ID="txtGender" runat="server" />
</td>
</tr>
<tr>
<td>
<b>Age</b>
</td>
<td>
<asp:TextBox ID="txtAge" runat="server" />
</td>
</tr>

<tr>
<td>

    

 
</td>
    </tr>
       <tr>
           <td>
               
           </td>
       </tr>
    </table>
        <%-- <input type="button" id="getStudents" value="Get Student" onclick="GetStudentById()" />--%>
           <asp:Button ID="getStudent" Text="Get Student" runat="server" OnClick="getStudent_Click" /> 

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLDebugConnectionString %>" SelectCommand="SELECT_ALL_STUDENTS" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
    </form>
</body>
</html>
