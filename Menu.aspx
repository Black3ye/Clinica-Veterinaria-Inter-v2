<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Menu.aspx.vb" Inherits="Clinica_Veterinaria_Inter_v2.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu</title>
    <style type="text/css">
        .Button{
            width:300px;
            height:50px;
            margin-left: 15%;
            background-color:#002633;
            border-color:transparent;
            color:white;
            margin-top: 5px;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .Button:hover{
            background-color:#405C66;
        }
        .auto-style3 {
            width: 100%;
            height: 100%;
            font-family: 'Baloo Thambi 2', cursive;
        }

        .auto-style5 {
            width: 20%;
            height: 340px;
            background:white;
            border-radius:4px;
            align-content:center;
            margin-top:10%;
            margin-left:42%;
        }
        #Bien {
            color:white;
            margin-left:85%;
        }
        .auto-style6 {
            width:100%;
            margin-top:1%;
        }
        .btnlo {
            Height:32px; 
            Width:33px;
            background-color:transparent;
            border-color:transparent;
            background-image:url('Resources/export.png');
            background-repeat: no-repeat ;
            background-size:100%;
        }
        
        .btnlo:hover{
            background-color:#405C66;
        }
    </style>
    
</head>

<body style="height: 100%; width: 99%; background-color:#002633; font-family: 'Baloo Thambi 2', cursive;">

    <form id="form1" runat="server" class="auto-style3">
        <div class="auto-style6">
            <asp:Label ID="Bien" runat="server" Text="Bienvenido:  "></asp:Label><asp:Label ID="Nameuser" runat="server" ForeColor="white"></asp:Label>
            <span title="Log Out" >
                <asp:Button ID="Button2" runat="server" Text=" " CssClass="btnlo" /></span>
        </div>
        <div class="auto-style5">
            <h3 style="color:#002633; text-align:center;">MENU PRINCIPAL</h3>
            <asp:Button ID="MU" runat="server"  Text="Manejo de Usuario" CssClass="Button" />
            <asp:Button ID="MT" runat="server" Text="Manejo de Tipos" CssClass="Button"/>
            <asp:Button ID="MI" runat="server" Text="Manejo de Inventario" CssClass="Button"/>
            <asp:Button ID="MC" runat="server" Text="Manejo de Compras" CssClass="Button"/>
            <asp:Button ID="MV" runat="server" Text="Manejo de Ventas" CssClass="Button"/>
        </div>
        <br />
    </form>
</body>
</html>

