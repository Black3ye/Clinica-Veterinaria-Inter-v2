<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Search.aspx.vb" Inherits="Clinica_Veterinaria_Inter_v2.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 100%;
            height: 388px;
        }
        .auto-style9 {
            width: 580px;
        }
        .auto-style11 {
            width: 1149px;
            height: 320px;
            margin-top: 24px;
            margin-left: 20%;
            background-color:#405C66;
        }
        .select1 {
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
            height: 61px;
            width: 580px;
            color:white;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .btnsearch{
            height:39px;
            width:80px;
            border-radius:4px;
            border-color:transparent;
            background-color:transparent;
            background-image:url('Resources/search.png');
            background-repeat: no-repeat ;
            background-size:45%;
            background-position-x:center;
        }
        .cbox{
            font-family: 'Baloo Thambi 2', cursive;
            color:white;
            border-radius:2px;
        }
        .auto-style20 {
            width: 580px;
            height: 69px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style6">
        <tr>
            <td class="auto-style20">
                <asp:DropDownList ID="select1" runat="server" CssClass="select1">
                    <asp:ListItem>Seleccione una opcion</asp:ListItem>
                    <asp:ListItem Value="Username">Username</asp:ListItem>
                    <asp:ListItem Value="Nombre">Nombre</asp:ListItem>
                    <asp:ListItem Value="Apellido Paterno">Apellido Paterno</asp:ListItem>
                    <asp:ListItem Value="I.D. Departamento">I.D. Departamento</asp:ListItem>
                    <asp:ListItem Value="Rol">Rol</asp:ListItem>
                    <asp:ListItem Value="Estatus">Estatus</asp:ListItem>
             
                </asp:DropDownList><asp:TextBox ID="txtSearch"  runat="server" placeholder="Search" type="Search" autocomplete="off" CssClass="txtSearch" Wrap="False" Enabled="true"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" CssClass="btnsearch"  Text=" " Enabled="true"/>
                <asp:CheckBox ID="scheckbox" runat="server" Text="Activo" CssClass="cbox" />
            </td>
        </tr>
        <tr>
            <td class="auto-style14">Cantidad Total de Records: <asp:Label runat="server" ID="lbTotal"/></td>

        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Panel ID="Panel1" runat="server" CssClass="auto-style11" ScrollBars="Horizontal">
                                <asp:GridView ID="GVSearch" runat="server" pagesize = "5" AllowPaging="False" 
                                    AllowSorting="True" AutoGenerateSelectButton="True" CellPadding="4" 
                                    ForeColor="#333333" GridLines="None" Width="805px" Height="319px">
                                    <FooterStyle BackColor="#BDC3C7" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <PagerStyle BackColor="#BDC3C7" ForeColor="White" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#BDC3C7" Font-Bold="True" ForeColor="White" />
                                    <EditRowStyle BackColor="#999999" />
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                </asp:GridView>
                            </asp:Panel>
            </td>

        </tr>
    </table>
</asp:Content>
