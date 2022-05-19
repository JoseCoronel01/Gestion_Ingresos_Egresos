<%@ Page Title="Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMenu.aspx.cs" Inherits="UI_Gestion.Pages.WF.frmMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-primary" OnClick="btnNuevo_Click" Text="Iniciar" />
            </div>
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>

</asp:Content>
