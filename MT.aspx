<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MT.aspx.vb" Inherits="Clinica_Veterinaria_Inter_v2.MT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manejo de Tipo de Inventario</title>
    <style type="text/css">

        .auto-style11 {
            width: 825px;
            height: 300px;
            margin-top: 24px;
            margin-left: 250px;
            background-color:#405C66;
        }
        .select1 {
            margin-left:500px;
            border-radius:3px;
            width: 139px;
            height: 39px;
            margin-left: 0px;
            font-family: 'Baloo Thambi 2', cursive;
        }
        
        .txtSearch {
            Height:38px; 
            Width:351px;
            font-family: 'Baloo Thambi 2', cursive;
            border-radius:2px;
        }
        .txtSearch:focus::-webkit-input-placeholder {
            opacity:0;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .auto-style14 {
            margin-left:550px;
            height: 61px;
            width: 429px;
            color:white;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .btnsearch{
            height:39px;
            width:80px;
            border-radius:4px;
        }
        .auto-style21 {
            height: 39px;
            width: 80px;
            border-radius: 4px;
            margin-top: 0px;
            border-color:transparent;
            background-color:transparent;
            background-image:url('Resources/search.png');
            background-repeat: no-repeat ;
            background-size:45%;
            background-position-x:center;
        }
        .auto-style21:hover{
            border-color:#405C66;
            background-color:#405C66;
        }
        .auto-style22 {
            margin-left: 500px;
            border-radius: 3px;
            width: 139px;
            height: 39px;
            margin-left: 370px;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .auto-style28 {
            margin-left: 170px;
        }
        .button {
            color:white;
            border-color:transparent;
            background-color:#002633;
            Width:150px;
            height:42px;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .txt {
            Height:30px; 
            border-radius:3px;
            margin-left:150px;
        }
        .lblMT {
          color:white;
          font-family: 'Baloo Thambi 2', cursive;
          margin-left:150px;
        }
        .lblMTN{
            color:white;
            font-family: 'Baloo Thambi 2', cursive;
            margin-left:250px;
        }
        .button:hover{
            background-color:#405C66;
        }
         .hr{
            width:99%;
            background-color:aqua;
        }
          #btnback {
            Height:44px; 
            Width:41px;
            margin-left: 58px;
            margin-top: 0px;
            background-color:transparent;
            background-image:url('Resources/prev.png');
            background-repeat: no-repeat ;
            background-size:100%;
            background-position-x:center;
            border-color:transparent;
          }
        #btnback:hover{
            background-color:#405C66;
        }

        .btnlo {
            Height:32px; 
            Width:33px;
            background-color:transparent;
            border-color:transparent;
            background-image:url('export.png');
            background-size:100%;
        }
        
        .btnlo:hover{
            background-color:#405C66;
        }
        .h2{
            color:white;
            text-align:center;
            width: 454px;
            margin-left:40%;
            font-family: 'Baloo Thambi 2', cursive;
        }
        #Bien{
            margin-left:930px;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .option{
            Height:32px; 
            Width:33px;
            margin-left:87%;
            background-color:transparent;
            border-color:transparent;
            background-image:url('Resources/report.png');
            background-repeat: no-repeat ;
            background-size:100%;
            background-position-x:center;
            border-color:transparent;
        }
        .option:hover{
            background-color:#405C66;
        }
       .rep{
            height:32px;
            color:white;
            background-color:#101010;
            border-color:transparent;
            margin-left:92%;
            font-family: 'Baloo Thambi 2', cursive;
       }
       .rep:hover{
           background-color:#405C66;
       }
        </style>
</head>
<body style="background-color:#002633; width: 99%; height:99%;">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Bien" runat="server" Text="Bienvenido:  " ForeColor="white"></asp:Label><asp:Label ID="Nameuser" runat="server" ForeColor="white" font-family="'Baloo Thambi 2', cursive"></asp:Label>
            <span title="Log Out" >
                <asp:Button ID="btnlo" runat="server" Text=" " CssClass="btnlo"/></span>
        </div>
        <div>
            <h2 class="h2">MANEJO DE TIPO DE INVENTARIO</h2>
            <asp:Button ID="btnback" runat="server" Text=" "  />
            <asp:Button ID="option" runat="server" Text=" " Cssclass="option"/>
            <asp:Button ID="Report" runat="server" Text="Generate Report" Visible="False" CssClass ="rep"/>
            <hr class="hr"/>
        </div>
        <div>
         <asp:DropDownList ID="select1" runat="server" CssClass="auto-style22">
                    <asp:ListItem>Seleccione una opcion</asp:ListItem>
                    <asp:ListItem Value="Type ID">Product Type ID</asp:ListItem>
                    <asp:ListItem Value="Type Name">Product Type Name</asp:ListItem>
                    <asp:ListItem Value="stamp userid">Stamp UserID</asp:ListItem>

         </asp:DropDownList><asp:TextBox ID="txtSearch"  runat="server" placeholder="Search" type="Search" autocomplete="off" CssClass="txtSearch" Wrap="False" Enabled="true"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" CssClass="auto-style21"  Text=" " Enabled="true"/>
    </div>
    <div>
        <asp:Label ID="Label1" runat="server" class="auto-style14" Text="Cantidad Total de Records:"></asp:Label><asp:Label ID="lbTotal" runat="server" ForeColor="white" background-color="transparent" font-family="'Baloo Thambi 2', cursive"></asp:Label>
    </div>
    <div>
         <asp:Panel ID="Panel1" runat="server" CssClass="auto-style11" ScrollBars="Horizontal">
                           <center>
                                <asp:GridView ID="GVSearch" runat="server" pagesize = "5" AllowPaging="False" 
                                    AllowSorting="True" AutoGenerateSelectButton="True" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None" Width="808px" Height="319px">
                                    <FooterStyle BackColor="#BDC3C7" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <PagerStyle BackColor="#BDC3C7" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#BDC3C7 " Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                           </center>
                            </asp:Panel>
    </div>
    <br/>
    <br/>
    <br/>
    <br/>

    <div class="auto-style28">
        <table>
         <tr>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="Añadir" CssClass="button"/>
            </td>
            <td>
               <asp:Button ID="btnMod" runat="server" Text="Modificar" Enabled="false" CssClass="button"/>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Guardar" Enabled="false" CssClass="button"/>
            </td>
            <td>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Enabled="false"  CssClass="button"/>
            </td>
            <td>
                <asp:Button ID="btnSalir" runat="server" Text="Salir" CssClass="button"/>
                <asp:Button ID="btnReload" runat="server" Text="Actualizar" CssClass="button"/>
            </td>

        </tr>
      </table>
    </div>
    <br />
    <br />
    <br />
    <div>
        <asp:Label ID="lblID" runat="server" Text="Type ID:" CssClass="lblMT" margin-left="150px"></asp:Label><asp:Label ID="lblTN" runat="server" Text="Type Name:" CssClass="lblMTN"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" CssClass="txt" Width="163px" Enabled="False"></asp:TextBox><asp:TextBox ID="TextBox2" runat="server" CssClass="txt" Width="255px" Enabled="False"></asp:TextBox>
    </div>
    <br />
    <br />
    <br />
    <br />
    </form>
</body>
</html>
