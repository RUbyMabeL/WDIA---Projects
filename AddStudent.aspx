<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="Lab7.AddStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css"/>
    <style>
        body {
            line-height: 5vh;
            font-size: 20px;
        }
        .input {
            width: 300px;
            height: 25px;
        }
        #type {
            height: 30px;
            width: 308px;
        }
        #submit {
            font-size: 18px;
            margin-top: 15px;
        }
        .error {
            font-size: 18px;
            color: red;
        }
    </style>
    <title></title>
</head>
<body>
    <h1>Student</h1>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td><label>Student Name: </label></td>
                    <td><asp:TextBox ID="studentname" runat="server" CssClass="input" /></td>
                    <td><asp:Label runat="server" ID="error1" CssClass="error"></asp:Label></td>
                 </tr>
                <tr>
                    <td><label>Student Type: </label></td>
                    <td>
                        <asp:DropDownList ID="type" runat="server" CssClass="input">
                            <asp:ListItem runat="server" Value ="-1" Text="Select ..." CssClass="input"></asp:ListItem>
                            <asp:ListItem runat="server" Value ="0" Text="Full Time Student" CssClass="input"></asp:ListItem>
                            <asp:ListItem runat="server" Value ="1" Text="Part Time Student" CssClass="input"></asp:ListItem>
                            <asp:ListItem runat="server" Value ="2" Text="Coop Student" CssClass="input"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td><asp:Label runat="server" ID="error2" CssClass="error"></asp:Label></td>
                </tr>
            </table>
            <asp:Button ID="submit" runat="server" Text="Add" CssClass="button" OnClick="NewStudent" />
        </div>
    </form>
    <asp:Table runat="server" ID="result" CssClass="table">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell>ID</asp:TableHeaderCell>
            <asp:TableHeaderCell>Name</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
    <a href="RegisterCourse.aspx">Register Courses</a>
</body>
</html>