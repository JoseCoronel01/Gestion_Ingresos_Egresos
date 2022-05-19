<%@ Page Title="Listados" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListado.aspx.cs" Inherits="UI_Gestion.Pages.frmListado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <asp:DropDownList ID="ddlListados" 
                    runat="server" 
                    DataValueField="value" 
                    DataTextField="text" 
                    CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:Button ID="btnPreliminar" 
                    runat="server" 
                    CssClass="btn btn-primary" 
                    Text="Preliminar" 
                    OnClick="btnPreliminar_Click" />
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
        </div>
    </div>

</asp:Content>
