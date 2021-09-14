<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MV.Master" CodeBehind="MVadd.aspx.vb" Inherits="Clinica_Veterinaria_Inter_v2.MVadd" %>
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
            margin-left:150px;
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
                <td><asp:Label runat="server" Text="Invoice ID:" CssClass="lbl"></asp:Label></td>
                <td> <asp:Label runat="server" Text="Stable ID:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Stable Name:" CssClass="lbl"></asp:Label> </td>
                <td><asp:Label runat="server" Text="Horse ID:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Horse Name:" CssClass="lbl"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox runat="server" Id="txtinid" CssClass="txt"></asp:TextBox></td>
                <td><asp:DropDownList runat="server" CssClass="txt"  ID="ddlstid" AutoPostBack="True"></asp:DropDownList></td>
                <td><asp:TextBox runat="server" ID="txtstname" CssClass="txt" Enabled ="False"></asp:TextBox></td>
                <td><asp:DropDownList runat="server" CssClass="txt" ID="ddlhoid" AutoPostBack="True"></asp:DropDownList></td>
                <td><asp:TextBox runat="server" ID="txthoname" CssClass="txt" Enabled ="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Invoice Date:" CssClass="lbl"></asp:Label></td>
                <td> <asp:Label runat="server" Text="Total in Medicaments:" CssClass="lbl"></asp:Label> </td>
                <td><asp:Label runat="server" Text="Total in Materials:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Total in Services:" CssClass="lbl"></asp:Label></td>
                <td><asp:Label runat="server" Text="Taxes:" CssClass="lbl"></asp:Label></td>
                
            </tr>
            <tr>
                <td><asp:TextBox runat="server" ID="txtindate" TextMode="Date" CssClass="txt"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtmedto" CssClass="txt"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtmatto" CssClass="txt"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txtservto" CssClass="txt"></asp:TextBox></td>
                <td><asp:TextBox runat="server" ID="txttax" CssClass="txt" AutoPostBack="True"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label runat="server" Text="Total Invoice:" CssClass="lbl" Enabled ="False"></asp:Label></td>
            </tr>
            <tr>
                <td><asp:TextBox runat="server" ID="txtinto" CssClass="txt" Enabled ="False"></asp:TextBox></td>
            </tr>
            
        </table>
       
    </div>
    <br />
    <br />
    <br />
    <asp:Button ID="Cancel" runat="server" Text="Cancel" CssClass="btn1" /><asp:Button ID="Save" runat="server" Text="Guardar" CssClass="btn1" />
</asp:Content>
