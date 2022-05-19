<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="UI_Gestion.Pages.frmReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-3">
                <asp:DropDownList ID="ddlTipoReporte" runat="server" CssClass="form-control"
                    DataValueField="value" DataTextField="text"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlTipoReporte_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlTipo" runat="server" DataValueField="Clave" 
                    DataTextField="Nombre" AutoPostBack="true" 
                    OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlEstatus" runat="server" CssClass="form-control"
                    DataValueField="value" DataTextField="text">
                </asp:DropDownList>
            </div>
            <div class="col-md-3">
                <asp:CheckBox ID="chBoxImpuesto" runat="server" Text="Con Impuesto" CssClass="form-control" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlSubTipo" runat="server" DataValueField="Clave" 
                    DataTextField="Nombre" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-3"></div>
            <div class="col-md-3">
                <asp:Button ID="btnPreliminar" runat="server" Text="Preliminar"
                    CssClass="btn btn-primary" OnClick="btnPreliminar_Click" Width="100%" />
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-3">
                <div>
                    <asp:CheckBox ID="chBoxTipoReporte" runat="server"
                        Text="Mostrar tipo de reporte listado" CssClass="form-control" />
                </div>
                <div>
                    <asp:DropDownList ID="ddlListado" runat="server" CssClass="form-control"
                        DataValueField="value" DataTextField="text">
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:Label runat="server" Text="De la fecha"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtDelafecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
                <div>
                    <asp:Label runat="server" Text="A la fecha"></asp:Label>
                </div>
                <div>
                    <asp:TextBox ID="txtAlaFecha" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-3">
            </div>
        </div>
    </div>

</asp:Content>
