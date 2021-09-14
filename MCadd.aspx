<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MC.Master" CodeBehind="MCadd.aspx.vb" Inherits="Clinica_Veterinaria_Inter_v2.MCadd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .txt {
            Height:30px; 
            border-radius:3px;

        }
        .lbl{
            font-family: 'Baloo Thambi 2', cursive;
            color:white;
        }
        .auto-style21 {
            margin-left: 251px;
            margin-top: 57px;
        }
        .btn1{
            height:30px;
            width:100px;
            background-color:transparent;
            color:white;
            border-color:transparent;
            outline:none;
            font-family: 'Baloo Thambi 2', cursive;
        }
        .btn1:hover{
            background-color:#405C66;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div style="text-align:center;">
       <h2 style="color:white; font-family: 'Baloo Thambi 2', cursive;">Nuevo Registro</h2>
        <table class="auto-style21">
            <tr>
                <td><asp:Label runat="server" Text="Purchase ID:" CssClass="lbl"></asp:Label></td>
                <td> <asp:Label runat="server" Text="Supplier ID:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Supplier Name:" CssClass="lbl"></asp:Label> </td>
                <td><asp:Label runat="server" Text="Purchase Number:" CssClass="lbl"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox runat="server" Id="txtpuid" CssClass="txt"></asp:TextBox></td>
                <td><asp:DropDownList runat="server" ID="ddlsupid" CssClass="txt" AutoPostBack="True" ></asp:DropDownList></td>
                <td><asp:TextBox runat="server" ID="txtsuname" CssClass="txt" Enabled ="False"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtpunum" CssClass="txt"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Purchase Date:" CssClass="lbl"></asp:Label></td>
                <td> <asp:Label runat="server" Text="Purchase Taxes:" CssClass="lbl"></asp:Label> </td>
                <td><asp:Label runat="server" Text="Purchases Total:" CssClass="lbl"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox runat="server" ID="txtpudate" TextMode="Date" CssClass="txt"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtputaxes" CssClass="txt"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtputotal" CssClass="txt"></asp:TextBox></td>
            </tr>
            
        </table>
       
    </div>
    <br />
    <br />
    <br />
    <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn1" /><asp:Button ID="Save" runat="server" Text="Guardar" CssClass="btn1" />
</asp:Content>