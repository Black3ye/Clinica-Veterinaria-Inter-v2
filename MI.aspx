<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MI.aspx.vb" Inherits="Clinica_Veterinaria_Inter_v2.MI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manejo de Inventario</title>
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

        }
        .lblMTN{
            color:white;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .button:hover{
            background-color:#405C66;
        }
         .auto-style29 {
             width: 189px;
             height: 27px;
         }

         .auto-style30 {
             margin-left: 75px;
             width: 144px;
         }
         .auto-style31 {
             width: 308px;
             margin-left: 144px;
         }

         .auto-style32 {
             Height: 30px;
             border-radius: 3px;
             margin-left: 0px;
         }
         .hr{
            width:1324px;
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
            background-image:url('Resources/export.png');
            background-repeat: no-repeat ;
            background-size:100%;
            
        }
        
        .btnlo:hover{
            background-color:#405C66;
        }
        .h2{
            color:white;
            text-align:center;
            width: 454px;
            margin-left:445px;
            font-family: 'Baloo Thambi 2', cursive;
        }
        #Bien{
            margin-left:75%;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .option{
            Height:32px; 
            Width:33px;
            margin-left:100%;
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
            margin-left:100%;
            font-family: 'Baloo Thambi 2', cursive;
       }
       .rep:hover{
           background-color:#405C66;
       }
         </style>
</head>
<body style="background-color:#002633; width: 1200px; height: 500px;">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Bien" runat="server" Text="Bienvenido:  " ForeColor="white"></asp:Label><asp:Label ID="Nameuser" runat="server" ForeColor="white" font-family="'Baloo Thambi 2', cursive"></asp:Label><span title="Log Out" ><asp:Button ID="btnlo" runat="server" Text=" " CssClass="btnlo"/></span>
        </div>
        <div>
            <h2 class="h2">MANEJO DE INVENTARIO</h2>
            <asp:Button ID="btnback" runat="server" Text=" "  />
            <asp:Button ID="option" runat="server" Text=" " Cssclass="option"/>
            <asp:Button ID="Report" runat="server" Text="Generate Report" Visible="False" CssClass ="rep"/>
            <hr class="hr"/>
        </div>
        <div>
         <asp:DropDownList ID="select1" runat="server" CssClass="auto-style22">
                    <asp:ListItem>Seleccione una opcion</asp:ListItem>
                    <asp:ListItem Value="ID">Product ID</asp:ListItem>
                    <asp:ListItem Value="Type">Product Type</asp:ListItem>
                    <asp:ListItem Value="Code">Product Code</asp:ListItem>
                    <asp:ListItem Value="Description">Product Description</asp:ListItem>

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
    <table class="auto-style31">
        <tr>
            <td class="auto-style29"><asp:Label ID="lblID" runat="server" Text="Product ID:" CssClass="lblMTN" ></asp:Label></td>
            <td><asp:Label ID="lbldesc" runat="server" Text ="Description:" CssClass="lblMTN"/></td>
            <td class="auto-style30"><asp:Label ID="lbltype" runat="server" Text="Type:" CssClass="lblMTN"></asp:Label></td>
            <td><asp:Label ID="lblcat" runat="server" Text ="Category:" CssClass="lblMTN"/></td>
            <td><asp:Label ID="lblupc" runat="server" Text ="UPC:" CssClass="lblMTN"/></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="txtid" runat="server" CssClass="txt" Width="100px" Enabled="False" MaxLength="6"></asp:TextBox></td>
            <td><asp:TextBox ID="txtdes" runat="server" CssClass="txt" Width="255px" Enabled="False"  MaxLength="50"></asp:TextBox></td>
            <td ><asp:TextBox ID="txttype" runat="server" CssClass="txt" Width="100px" Enabled="False"  MaxLength="2"></asp:TextBox></td>
            <td><asp:TextBox ID="txtcat" runat="server" CssClass="txt" Width="150px" Enabled="False"  MaxLength="50"></asp:TextBox></td>
            <td><asp:TextBox ID="txtupc" runat="server" CssClass="txt" Width="150px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblcode" runat="server" Text ="Product Code:" CssClass="lblMTN"/></td>
            <td><asp:Label ID="lblamount" runat="server" Text ="Amount:" CssClass="lblMTN"/></td>
            <td><asp:Label ID="lblprice" runat="server" Text ="Price:" CssClass="lblMTN"/></td>
            <td><asp:Label ID="lblreorder" runat="server" Text ="Reorder:" CssClass="lblMTN"/></td>
            <td><asp:Label ID="lblmax" runat="server" Text ="Max:" CssClass="lblMTN"/></td>
        </tr>
        <tr>
            <td><asp:TextBox ID="txtcode" runat="server" CssClass="txt" Width="100px" Enabled="False"  MaxLength="6"></asp:TextBox></td>
            <td><asp:TextBox ID="txtamount" runat="server" CssClass="txt" Width="130px" Enabled="False"  ></asp:TextBox></td>
            <td><asp:TextBox ID="txtprice" runat="server" CssClass="auto-style32" Width="130px" Enabled="false" MaxLength="21"></asp:TextBox></td>
            <td><asp:TextBox ID="txtreorder" runat="server" CssClass="txt" Width="60px" Enabled="False" ></asp:TextBox></td>
            <td><asp:TextBox ID="txtmax" runat="server" CssClass="txt" Width="100px" Enabled="False"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="lbltax" runat="server" Text ="Taxable:" CssClass="lblMTN"/></td>
            <td><asp:Label ID="lblostock" runat="server" Text ="Out of Stock:" CssClass="lblMTN"/></td>
            <td><asp:Label ID="lblstatus" runat="server" Text ="Status:" CssClass="lblMTN"/></td>
            <td><asp:Label ID="lblrestock" runat="server" Text ="Restock Date:" CssClass="lblMTN"/></td>
        </tr>
        <tr>
            <td><asp:CheckBox ID="ChTaxable" runat="server" text="Active" CssClass="lblMTN" /></td>
            <td><asp:TextBox ID="txtostock" runat="server" CssClass="txt" Enabled="False" Width="255px" MaxLength="50"></asp:TextBox></td>
            <td><asp:CheckBox ID="Chstatus" runat="server" Text="Active" CssClass="lblMTN"/></td>
            <td><asp:TextBox ID="txtrestock" runat="server" CssClass="auto-style32" Width="130px"  type="date" Enabled="False"></asp:TextBox></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    </form>
</body>
</html>
