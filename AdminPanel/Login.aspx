<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="AdminPanel_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/Css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container-fluid">
        <div class="row">
            <div class ="col-md-6">
                <h2 class="text-center ">Login For Existing User</h2>
                <table class="table table-secondary">
                    <tr>
                        <td colspan="3" class="text-center">
                            <asp:Label ID="lblMessageLogin" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><h4>UserName</h4></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtUserNameLogin" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><h4>Password</h4></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtPasswordLogin" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="text-center">
                            <asp:Button runat="server" ID="btnLogin" Text="Login" CssClass="btn btn-success" OnClick="btnLogin_Click" />
                        </td>
                    </tr>
                </table>
            </div>


            <div class ="col-md-6">
                <h2 class="text-center ">Sign UP For New User</h2>
                <table class="table table-secondary">
                    <tr>
                        <td colspan="3" class="text-center">
                            <asp:Label ID="lblMessageSignup" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td><h4>UserName</h4></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtUsernameSignup" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><h4>Password</h4></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtPasswordSignup" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><h4>ContactNo</h4></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtContactnoSignup" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><h4>Enter DisplayName</h4></td>
                        <td>:</td>
                        <td>
                            <asp:TextBox ID="txtDisplayNameSignup" runat="server" CssClass="form-control"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td colspan="3" class="text-center">
                            <asp:Button runat="server" ID="btnSignup" Text="Sign Up" CssClass="btn btn-primary" OnClick="btnSignup_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
