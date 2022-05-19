<%@ Page Title="Presupuesto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmPresupuesto.aspx.cs" Inherits="UI_Gestion.Pages.frmPresupuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-3">
            <asp:RadioButton ID="rbIngreso" 
                AutoPostBack="true" Text="Ingreso" 
                GroupName="tipo" runat="server" OnCheckedChanged="rbIngreso_CheckedChanged" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:RadioButton ID="rbEgreso" 
                AutoPostBack="true" Text="Egreso" 
                GroupName="tipo" runat="server" OnCheckedChanged="rbEgreso_CheckedChanged" />
        </div>
        <div class="col-md-9">
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <asp:GridView ID="gvPresupuesto" runat="server" 
                AutoGenerateColumns="false" CssClass="table" AutoGenerateSelectButton="true"
                OnSelectedIndexChanged="gvPresupuesto_SelectedIndexChanged">
                <Columns>                    
                    <asp:BoundField HeaderText="Clave" DataField="Clave" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
                    <asp:BoundField HeaderText="Sub Tipo" DataField="SubTipo" />
                    <asp:BoundField HeaderText="Año" DataField="Anio" />
                    <asp:BoundField HeaderText="Meses" DataField="Meses" />
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Label runat="server" Text="Clave"></asp:Label>
            <asp:TextBox ID="txtClave" runat="server" Width="200" CssClass="form-control" MaxLength="20"></asp:TextBox>
        </div>
        <div class="col-md-9">
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Label runat="server" Text="Tipo"></asp:Label>
            <asp:DropDownList ID="ddlTipo" runat="server" AutoPostBack="true" CssClass="form-control"
                DataValueField="Clave" DataTextField="Nombre" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="col-md-9">
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Label runat="server" Text="Sub Tipo"></asp:Label>
            <asp:DropDownList ID="ddlSubTipo" runat="server" AutoPostBack="true" CssClass="form-control"
                DataValueField="Clave" DataTextField="Nombre" OnSelectedIndexChanged="ddlSubTipo_SelectedIndexChanged">
            </asp:DropDownList>
        </div>
        <div class="col-md-9">
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Label runat="server" Text="Año"></asp:Label>
            <asp:TextBox ID="txtAnio" runat="server" Width="200" CssClass="form-control" TextMode="Number"></asp:TextBox>
        </div>
        <div class="col-md-9">
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <div>
                <div style="display: flex;">
                    <div>
                        <asp:Label runat="server" Text="Enero"></asp:Label>
                        <asp:TextBox ID="txt01" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Febrero"></asp:Label>
                        <asp:TextBox ID="txt02" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Marzo"></asp:Label>
                        <asp:TextBox ID="txt03" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div style="display: flex;">
                    <div>
                        <asp:Label runat="server" Text="Abril"></asp:Label>
                        <asp:TextBox ID="txt04" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Mayo"></asp:Label>
                        <asp:TextBox ID="txt05" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Junio"></asp:Label>
                        <asp:TextBox ID="txt06" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div style="display: flex;">
                    <div>
                        <asp:Label runat="server" Text="Julio"></asp:Label>
                        <asp:TextBox ID="txt07" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Agosto"></asp:Label>
                        <asp:TextBox ID="txt08" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Septiembre"></asp:Label>
                        <asp:TextBox ID="txt09" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
                <div style="display: flex;">
                    <div>
                        <asp:Label runat="server" Text="Octubre"></asp:Label>
                        <asp:TextBox ID="txt10" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Noviembre"></asp:Label>
                        <asp:TextBox ID="txt11" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label runat="server" Text="Diciembre"></asp:Label>
                        <asp:TextBox ID="txt12" runat="server" Width="100" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-9">
        </div>
    </div>

    <div class="row">
        <div class="col-md-3">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
        </div>
        <div class="col-md-9">
        </div>
    </div>

</asp:Content>
