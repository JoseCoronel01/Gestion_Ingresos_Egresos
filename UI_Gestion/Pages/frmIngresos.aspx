<%@ Page Title="Ingresos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmIngresos.aspx.cs" Inherits="UI_Gestion.Pages.frmIngresos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-6">
                <div style="display: flex;">
                    <div>
                    <asp:RadioButton ID="rbEmitido" runat="server" Text="Emisión" GroupName="ing" CssClass="form-control" AutoPostBack="true" OnCheckedChanged="rbEmitido_CheckedChanged" Checked="true" />
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <div>
                    <asp:RadioButton ID="rbPagado" runat="server" Text="Pagar" GroupName="ing" CssClass="form-control" AutoPostBack="true" OnCheckedChanged="rbPagado_CheckedChanged" />
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <div>
                    <asp:RadioButton ID="rbCancelado" runat="server" Text="Cancelar" GroupName="ing" CssClass="form-control" AutoPostBack="true" OnCheckedChanged="rbCancelado_CheckedChanged" />
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                </div>
            </div>
            <div class="col-md-6"></div>
        </div>
        <asp:Panel ID="pnlPagado" runat="server" Visible="false">
            <div class="row" style="margin-bottom: 10px;">
                <div class="col-md-12">
                    <div>
                    <asp:DropDownList ID="ddlIngresos" runat="server" CssClass="form-control" DataValueField="Id"
                        DataTextField="Folio" AutoPostBack="true" OnSelectedIndexChanged="ddlIngresos_SelectedIndexChanged">
                    </asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label ID="lbConceptoDesc" runat="server" Font-Bold="true" Font-Size="12pt"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox ID="txtFechaPago" runat="server" Width="200" CssClass="form-control" 
                        TextMode="Date">
                    </asp:TextBox>
                </div>
                <div class="col-md-3">
                    <asp:Button ID="btnPagar" runat="server" Text="Pagar" CssClass="btn btn-primary" 
                        OnClick="btnPagar_Click" />
                </div>
                <div class="col-md-3">
                </div>
                <div class="col-md-3">
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlEmision" runat="server" Visible="false">
        <div class="row" style="margin-bottom: 10px;">
            <div class="col-md-3">
                <div>
                    <asp:Label runat="server" Text="Serie:"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlSerie" runat="server" DataValueField="Serie" DataTextField="Serie" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlSerie_SelectedIndexChanged"></asp:DropDownList>
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
                    <asp:Label runat="server" Text="Folio:"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlFolio" runat="server" CssClass="form-control"></asp:DropDownList>
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
                    <asp:Label runat="server" Text="Cliente:"></asp:Label>
                </div>
                <div>
                    <asp:DropDownList ID="ddlCliente" runat="server" DataValueField="value" DataTextField="text" CssClass="form-control"></asp:DropDownList>
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
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" Width="100%" />
            </div>
        </div>
        </asp:Panel>
    </div>

</asp:Content>
