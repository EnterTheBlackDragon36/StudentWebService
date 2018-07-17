<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentQuery.aspx.cs" Inherits="StudentWebAppClient.StudentQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

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
<asp:Label ID="lblErrorMsg" ForeColor="Red" runat="server" Visible="false" />
    

</td>
    </tr>
       <tr>
           <td>
               
           </td>
       </tr>
    </table>
        <%-- <input type="button" id="getStudents" value="Get Student" onclick="GetStudentById()" />--%>
           <asp:Button ID="getStudent" Text="Get Student" runat="server" OnClick="getStudent_Click" /> 
        <asp:Button ID="getStudentAuthentication" Text="Authenticate Student" runat="server" OnClick="getStudentAuthentication_Click"  />
        
        <asp:Panel ID="pnlServiceResponse" runat="server" >
            <asp:Table ID="tblResponseMsg" runat="server" >
                <asp:TableHeaderRow>
                    <asp:TableCell>
                        <asp:Label ID="lblheader" runat="server" Text="Web Service Response" />
                    </asp:TableCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblresponseMsg" runat="server" Text="Response:" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="lblResponse" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                     <asp:TableCell>
                        <asp:Label ID="lblmessage" Text="Message ID:" runat="server" />
                    </asp:TableCell>
                     <asp:TableCell>
                        <asp:Label ID="lblMessageId" runat="server" />
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </asp:Panel>

    </form>
</body>
</html>
