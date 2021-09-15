<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Edit.aspx.vb" Inherits="Clinica_Veterinaria_Inter_v2.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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
            Width:150px;
            border-radius:3px;
        }
        .button:hover{
            background-color:#405C66;
        }
       
        .style25 {
            align-self:center;
        }
        .label{
            text-align:left;
        }
       
       
        .auto-style24 {
            border-radius: 3px;
        }
        .auto-style25 {
            border-radius: 3px;
            margin-right: 115px;
        }

       
        .downlist {
            margin-right: 5px;
            border-radius: 3px;
        }
        
        .auto-style26 {
            width: 655px;
            margin-left: 32%;
        }
        .auto-style28 {
        margin-left: 25%;
    }
        
    </style>
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
<br />
<div class="auto-style28">
 <table>
    <tr>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="Añadir" CssClass="button"/>
        </td>
        <td>
            <asp:Button ID="btnMod" runat="server" Text="Modificar"  CssClass="button"/>
        </td>
        <td>
            <asp:Button ID="btnSave" runat="server" Text="Guardar"  CssClass="button"/>
        </td>
        <td>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar"   CssClass="button"/>
        </td>
        <td>
            <asp:Button ID="btnSalir" runat="server" Text="Salir" CssClass="button"/>
            <asp:Button ID="btnReload" runat="server" Text="Actualizar" CssClass="button"/>
        </td>

    </tr>
    </table>
</div>
<div>
    <table class="auto-style26">
    <tr>
        <td class="label">
            <asp:Label ID="Label4" runat="server" Text="UserID: " ForeColor="white"/>
        </td>
        <td class="label">
            <asp:Label ID="Label5" runat="server" Text="DeptID: " Width="140px" ForeColor="white" CssClass="label"/>
        </td>
    </tr>
    <tr>
        <td class="txt">
            <asp:TextBox ID="txtUser_ID" runat="server" CssClass="txt" MaxLength ="20" Enabled="false" autocomplete="false"/>
        </td>
        <td class="auto-style30">
            <asp:DropDownList ID="ddlDept_ID" runat="server" Height="35px" Width="150px" MaxLength ="15" CssClass="downlist" Enabled="false">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="label">
            <asp:Label ID="Label106" runat="server" Text="Apellido Paterno: " ForeColor="white"/>
        </td>
        <td class="label">
            <asp:Label ID="Label107" runat="server" Text="Apellido Materno: " Width="140px" ForeColor="white" CssClass="auto-style24"/>
        </td>
        <td class="label">
            <asp:Label ID="Label108" runat="server" Text="Nombre: " ForeColor="white"/>
        
        </td>
        <td class="label">
            <asp:Label ID="Label109" runat="server" Text="Inicial: " ForeColor="white"/>
        </td>
    </tr>
    <tr>
        <td class="txt">
            <asp:TextBox ID="txtUserLName1" runat="server" CssClass="txt" MaxLength ="20" Enabled="false" autocomplete="false"/>
        </td>
        <td class="txt">
            <asp:TextBox ID="txtUserLname2" runat="server" CssClass="txt" MaxLength ="20" Enabled="false" autocomplete="false"/>
        </td>
        <td class="txt">
            <asp:TextBox ID="txtUserFName" runat="server" CssClass="txt" MaxLength ="15" Enabled="false" autocomplete="false"/>
        </td>
        <td class="txt">
            <asp:TextBox ID="txtUserMName" runat="server" CssClass="auto-style25" MaxLength ="15" Height="30px" Width="33px" Enabled="false" autocomplete="false"/>
        </td>

    </tr>
    <tr>
        <td class="label">
            <asp:Label ID="Label110" runat="server" Text="Username:" ForeColor="white"/>
        </td>
        <td class="label">
            <asp:Label ID="Label111" runat="server" Text="Password:" ForeColor="white"/>
        </td>
        <td class="label">
            <asp:Label ID="Label1" runat="server" Text="Estatus:" ForeColor="white" />  
        </td>
    </tr>
    <tr>
        <td class="txt">
            <asp:TextBox ID="txtusername" runat="server" CssClass="txt" MaxLength ="10" Enabled="false" autocomplete="false"/>
        </td>
        <td class="txt">
            <asp:TextBox ID="txtpassword" runat="server" CssClass="txt" MaxLength ="10" Enabled="false" autocomplete="false"/>
        </td>
        <td class="auto-style25">
            <asp:CheckBox ID="ckbActive_Flag" runat="server" Text="Activo" AutoPostBack="True" Width="150px" ForeColor="white"   Enabled="false" />
        </td>
    </tr>
    <tr>
        <td class="label">
            <asp:Label ID="Label2" runat="server" Text="Role:" ForeColor="white"/>
        </td>
        <td class="label">
            <asp:Label ID="Label3" runat="server" Text="Especialización:" ForeColor="white"/>
        </td>
    </tr>
    <tr>
            <td>
            <asp:DropDownList ID="ddlRole" runat="server" Height="35px" Width="150px" MaxLength ="15" CssClass="downlist" Enabled="false">
                <asp:ListItem Value="Regular">Regular</asp:ListItem>
                <asp:ListItem Value="Administrator">Administrator</asp:ListItem></asp:DropDownList>
        </td>
            <td>
            <asp:DropDownList ID="ddlSpecialization" runat="server" CssClass="downlist" Height="35px" Width="150px" MaxLength ="15"  Enabled="false">
                <asp:ListItem Value="test11">test11</asp:ListItem>
                <asp:ListItem Value="test12">test12</asp:ListItem></asp:DropDownList>
        </td>
    </tr>
 </table>
</div>
</asp:Content>
