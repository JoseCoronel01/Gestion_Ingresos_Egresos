<%@ Page Title="Egresos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEgresos.aspx.cs" Inherits="UI_Gestion.Pages.frmEgresos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-3">
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-default" OnClick="btnNuevo_Click" />
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-12">
                <asp:GridView ID="gvEgresos" runat="server" AutoGenerateColumns="false" AutoGenerateSelectButton="true"
                    OnSelectedIndexChanged="gvEgresos_SelectedIndexChanged" CssClass="table">
                    <Columns>
                        <asp:BoundField HeaderText="Id" DataField="Id" />
                        <asp:BoundField HeaderText="No Cheque" DataField="NoCheque" />
                        <asp:BoundField HeaderText="Banco" DataField="CtaBanco" />
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" />
                        <asp:BoundField HeaderText="Subtotal" DataField="Subtotal" />
                        <asp:BoundField HeaderText="Impuesto" DataField="Impuesto" />
                        <asp:BoundField HeaderText="Total" DataField="Total" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="No. Cheque:"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtNoCheque" runat="server" Text="" Width="200" ToolTip="No cheque" placehlder="No Cheque" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="Tipo:"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlTipo" runat="server" DataValueField="Clave" DataTextField="Nombre" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="Concepto:"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlConcepto" runat="server" DataValueField="Clave" DataTextField="Descripcion" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="Banco:"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlBanco" runat="server" DataValueField="value" DataTextField="text" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="Subtipo:"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlSubTipo" runat="server" DataValueField="Clave" DataTextField="Nombre" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="Proveedor:"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlProveedor" runat="server" DataValueField="value" DataTextField="text" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="Subtotal:"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtSubtotal" AutoPostBack="true" runat="server" Width="200" CssClass="form-control" OnTextChanged="txtSubtotal_TextChanged"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="Impuesto:"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlImpuesto" runat="server" DataValueField="Clave" DataTextField="Tasa" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlImpuesto_SelectedIndexChanged"></asp:DropDownList>
                </div>
            </div>
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="Total:"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtTotal" runat="server" Width="200" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-3">
            </div>
        </div>
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-12">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Width="100%" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click" Width="100%" />
            </div>
        </div>
    </div>

</asp:Content>
