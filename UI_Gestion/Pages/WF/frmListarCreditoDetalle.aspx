<%@ Page Title="Listar Crédito Detalle" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmListarCreditoDetalle.aspx.cs" Inherits="UI_Gestion.Pages.WF.frmListarCreditoDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <asp:GridView ID="gvCreditoDetalle" runat="server" AutoGenerateColumns="false"
                    CssClass="table">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" />
                        <asp:BoundField HeaderText="Crédito" DataField="Credito" />
                        <asp:BoundField HeaderText="Capital" DataField="Capital" />
                        <asp:BoundField HeaderText="Interés" DataField="Interes" />
                        <asp:BoundField HeaderText="Saldo" DataField="Saldo" />
                        <asp:BoundField HeaderText="Estatus" DataField="Estatus" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-4">
                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Finalizar" OnClick="btnGuardar_Click" />
            </div>
            <div class="col-md-4">
            </div>
        </div>
    </div>

</asp:Content>
