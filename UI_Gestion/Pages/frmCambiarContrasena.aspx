<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCambiarContrasena.aspx.cs" Inherits="UI_Gestion.Pages.frmCambiarContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="lbContrasenaActual" runat="server" Text="Contraseña Actual:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContrasenaActual" runat="server" Width="200" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbContrasenaNueva" runat="server" Text="Contraseña Nueva:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContrasenaNueva" runat="server" Width="200" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbConfirmarContrasenaNueva" runat="server" Text="Confirmar Contraseña Nueva:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtConfirmarContrasenaNueva" runat="server" Width="200" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
