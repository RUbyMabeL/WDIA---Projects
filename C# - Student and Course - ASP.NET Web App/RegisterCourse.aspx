<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Course Registeration</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css"/>
    <style>
        body 
        {
            line-height: 5vh;
            font-size: 20px;
        }
        h1
        {
            font-size: 30px;
        }
        #enroll 
        {
            font-size: 25px;
        }
        .input 
        {
            width: 300px;
            height: 25px;
        }
        #error, #error3 
        {
            font-size: 18px;
        }
        #error3
        {
            color: red;
        }
        #submit 
        {
            font-size: 18px;
            margin-top: 15px;
        }
        .input {
            width: 300px;
            height: 25px;
        }
    </style>

</head>
<body>
    <h1>Registrations</h1>
    <form id="form1" runat="server">
        <div>
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>Student:</asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="selectStudent">
                            <asp:ListItem runat="server" Value ="-1" Text="Select ..." CssClass="input"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell><asp:Label runat="server" ID="error3"></asp:Label></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            
            <asp:Label ID="error" runat="server"></asp:Label>
            <h3>Following courses are currently available for registration</h3>
            <asp:CheckBoxList ID="course" runat="server" />

            <asp:Button ID="submit" runat="server" Text="Save" CssClass="button" OnClick="Submit_Click" />
        </div>
    </form>

    <a href="AddStudent.aspx">Add Student</a>
</body>
</html>