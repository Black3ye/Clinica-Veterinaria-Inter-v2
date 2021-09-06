<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Clinica_Veterinaria_Inter_v2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Login</title>
    <style type="text/css">
        #form1{
            text-align:center;
            display:inline-block;
            width: 1287px;
            height: 485px;
        }
        #txtusername {
            width: 245px;
            height: 36px;
            background: none;
            outline:none;
            color:#002633;
            border-color:transparent;
            border-bottom:1px#002633 solid;
            font-family: 'Baloo Thambi 2', cursive;
        }
        #txtPassword1 {
            width: 245px;
            height: 36px;
            background: none;
            outline:none;
            margin-left: 7px;
            margin-top: 0px;
            color:#002633;
            border-color:transparent;
            border-bottom:1px#002633 solid;
            font-family: 'Baloo Thambi 2', cursive;
        }
        #txtusername:focus::-webkit-input-placeholder {
            opacity:0;
            font-family: 'Baloo Thambi 2', cursive;
        }
        #txtPassword1:focus::-webkit-input-placeholder {
            opacity:0;
            font-family: 'Baloo Thambi 2', cursive;
        }
        #Button1:hover{
            width:300px;
            height:50px;
            background-color:#405C66;
        }
        #Button2:hover{
            width:300px;
            height:50px;
            background-color:#405C66;
        }
        #Button1{
            border-radius:3px;
            background: #002633;
            outline:none;
            color:White;
            border-color:transparent;
            text-transform:uppercase;
        }
        #Button2{
            border-radius:3px;
            background:#002633;
            outline:none;
            color:White;
            border-color:transparent;
            text-transform:uppercase;
        }
        #Buttom1:focus {
            background-color:#99ff99;
        }
        #Buttom2:focus {
            background-color:#99ff99;
        }
        .auto-style2 {
            height: 330px;
            width: 354px;
            margin-top: 45px;
        }
        .auto-style3 {
            margin-top: 0px;
        }
    </style>
</head>
<body style="background-color:#002633; align-self:center;font-family: 'Baloo Thambi 2', cursive;">
    <form id="form1" runat="server">
        <div style="margin-left: 480px; background-color:white; border-radius:6px;" class="auto-style2">
            <asp:Image ID ="logo" runat="server" src="Resources/logo.png" Height="37px" Width="39px"  />
            <h2 style=" color:#002633;text-align:center;"  class="auto-style3">Clinica Veterinaria Inter</h2>
            <asp:TextBox ID="txtusername" runat="server" type="text" placeholder="Username"  autocomplete="off"  required="required" Title="Enter your Username"></asp:TextBox>
            <br /><br />
            <asp:TextBox ID="txtPassword1" runat="server" TextMode="Password" placeholder="Password" autocomplete="off" required="required" Title="Enter your Password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Height="35px" style=" margin-top: 35px" Text="Login" Width="245px"/>
            <asp:Button ID="Button2" runat="server" Height="35px" style=" margin-top: 14px" Text="Cancel" Width="245px" />
         </div>
    </form>
</body>
</html>
