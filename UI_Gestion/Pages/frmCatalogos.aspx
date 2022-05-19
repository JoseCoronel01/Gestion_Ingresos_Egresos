<%@ Page Title="Catálogos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCatalogos.aspx.cs" Inherits="UI_Gestion.Pages.frmCatalogos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-3">
            <ul>
                <li>
                    <asp:Button ID="btnBanco" runat="server" Text="Banco" CssClass="btn btn-default" OnClick="btnBanco_Click" />
                </li>
                <li>
                    <asp:Button ID="btnConcepto" runat="server" Text="Concepto" CssClass="btn btn-default" OnClick="btnConcepto_Click" />
                </li>
                <li>
                    <asp:Button ID="btnImpuesto" runat="server" Text="Impuesto" CssClass="btn btn-default" OnClick="btnImpuesto_Click" />
                </li>
                <li>
                    <asp:Button ID="btnRecibo" runat="server" Text="Recibo" CssClass="btn btn-default" OnClick="btnRecibo_Click" />
                </li>
                <li>
                    <asp:Button ID="btnTipo" runat="server" Text="Tipos" CssClass="btn btn-default" OnClick="btnTipo_Click" />
                </li>
                <li>
                    <asp:Button ID="btnSubtipo" runat="server" Text="Sub Tipos" CssClass="btn btn-default" OnClick="btnSubtipo_Click" />
                </li>
                <li>
                    <asp:Button ID="btnCliente" runat="server" Text="Cliente" CssClass="btn btn-default" OnClick="btnCliente_Click" />
                </li>
                <li>
                    <asp:Button ID="btnProveedor" runat="server" Text="Proveedor" CssClass="btn btn-default" OnClick="btnProveedor_Click" />
                </li>
                <li>
                    <asp:Button ID="btnContacto" runat="server" Text="Contacto" CssClass="btn btn-default" OnClick="btnContacto_Click" />
                </li>
                <li>
                    <asp:Button ID="btnTipoRef" runat="server" Text="Tipo de referencia" CssClass="btn btn-default" OnClick="btnTipoRef_Click" />
                </li>
                <li>
                    <asp:Button ID="btnRef" runat="server" Text="Referencia" CssClass="btn btn-default" OnClick="btnRef_Click" />
                </li>
                <li>
                    <asp:Button ID="btnUsuarioSis" runat="server" Text="Usuario sistema" CssClass="btn btn-default" OnClick="btnUsuarioSis_Click" />
                </li>
            </ul>
        </div>
        <div class="col-md-9">
            <iframe id="frmLoad" runat="server" width="900" height="1000"></iframe>
        </div>
    </div>

</asp:Content>
