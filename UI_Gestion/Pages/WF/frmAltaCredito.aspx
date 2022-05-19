<%@ Page Title="Alta de Créditos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmAltaCredito.aspx.cs" Inherits="UI_Gestion.Pages.WF.frmAltaCredito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div>
                    <asp:Label runat="server" Text="Emision"></asp:Label>
                    <asp:TextBox ID="txtEmision" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="Vencimiento"></asp:Label>
                    <asp:TextBox ID="txtVencimiento" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="Capital"></asp:Label>
                    <asp:TextBox ID="txtCapital" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="Interés"></asp:Label>
                    <asp:TextBox ID="txtInteres" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="Periodicidad"></asp:Label>
                    <asp:DropDownList ID="ddlPeriodicidad" runat="server" 
                        CssClass="form-control" DataValueField="Id" DataTextField="Periodicidad"></asp:DropDownList>
                </div>
                <div>
                    <asp:Button ID="btnGuardar"
                        runat="server" Text="Siguiente" OnClick="btnGuardar_Click" CssClass="btn btn-primary" />
                </div>
            </div>
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>

</asp:Content>
