<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MV.Master" CodeBehind="MVDV.aspx.vb" Inherits="Clinica_Veterinaria_Inter_v2.MVDV" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Manejo de Inventario</title>
     <style type="text/css">
        .auto-style11 {
            width: 825px;
            height: 300px;
            margin-top: 24px;
            margin-left: 150px;
            background-color:#405C66;
        }
        .select1 {
            border-radius: 3px;
            width: 139px;
            height: 39px;
            margin-left: 50px;
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
        .txt {
            Height:30px; 
            border-radius:3px;

        }
        .lbl{
            font-family: 'Baloo Thambi 2', cursive;
            color:white;
        }
        .auto-style21 {
            margin-top: 57px;
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
        .auto-style28 {
            margin-left: 117px;
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
            border-color:transparent;
        }
        .lblMTN{
            color:white;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .button:hover{
            background-color:#405C66;
        }
        auto-style34 {
            width: 510px;
            margin-left: 450px;
            text-align:center;
        } 
        .button {
            color:white;
            border-color:transparent;
            background-color:#002633;
            Width:150px;
            height:42px;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .button:hover{
            background-color:#405C66;
        }
         .auto-style29 {
             width: 790px;
             margin-left: 122px;
         }
         </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="text-align:center;"><h2 style="color:white; font-family: 'Baloo Thambi 2', cursive;">Detalles de Venta</h2></div>
     <div>
         <asp:DropDownList ID="select1" runat="server" Cssclass="select1">
                    <asp:ListItem>Seleccione una opcion</asp:ListItem>
                    <asp:ListItem Value="ID">Detail ID</asp:ListItem>
                    <asp:ListItem Value="in ID">Invoice ID</asp:ListItem>
                    <asp:ListItem Value="P ID">Product ID</asp:ListItem>
                    <asp:ListItem Value="P type">Product Type</asp:ListItem>
                    <asp:ListItem Value="user">Por Usuario</asp:ListItem>
                    

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
            </td>
        </tr>
      </table>
    </div>
    <br />
    <br />
       <div class="auto-style29">
         <table >
            <tr>
                <td> <asp:Label runat="server" Text="Detail ID:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Invoice ID:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Invoice Date:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Product ID:" CssClass="lbl"></asp:Label> </td>
                <td><asp:Label runat="server" Text="Product Description:" CssClass="lbl"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox runat="server" ID="txtdeid" CssClass="txt" autocomplete="off" Enabled ="False"></asp:TextBox></td>
                <td><asp:DropDownList ID="ddliid" runat="server"  CssClass="txt" AutoPostBack="True" ></asp:DropDownList></td>
                <td><asp:TextBox runat="server" Id="txtindate" CssClass="txt" autocomplete="off" Enabled ="False" TextMode="DateTime"></asp:TextBox></td>
                <td><asp:DropDownList ID="ddlproduct" runat="server" CssClass="txt" AutoPostBack="True"></asp:DropDownList></td>
                <td><asp:TextBox runat="server" ID="txtpcd" CssClass="txt" autocomplete="off" Enabled ="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Product Type:" CssClass="lbl"></asp:Label></td>
                <td> <asp:Label runat="server" Text="Product Category:" CssClass="lbl"></asp:Label> </td>
                <td><asp:Label runat="server" Text="Product Unit:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Product Price:" CssClass="lbl"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox runat="server" ID="txtpctype" CssClass="txt" autocomplete="off" Enabled ="False"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtpccat" CssClass="txt" autocomplete="off" Enabled ="False"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtpcunit" CssClass="txt" autocomplete="off" Enabled ="False" AutoPostBack="True"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtpcprice" CssClass="txt" autocomplete="off" Enabled ="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Detail Total:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Personal ID:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Taxable" CssClass="lbl"></asp:Label></td>
            </tr>
             <tr>
                <td><asp:TextBox runat="server" ID="txtdtotal" CssClass="txt" autocomplete="off" Enabled ="False" AutoPostBack="True"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtpeid" CssClass="txt" autocomplete="off" Enabled ="False"/></td>
                <td><asp:CheckBox ID="cbtax" runat="server" Text="Active" CssClass="lbl"/></td>
            </tr>
         </table>
        </div>
        <br />
        <br />
        <br />
        <br />
</asp:Content>
