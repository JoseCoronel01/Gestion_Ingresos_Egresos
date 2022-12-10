<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="UI_Gestion.Inicio" %>

<!doctype html>
<html lang="es">
  <head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <title></title>

    <!-- Bootstrap core CSS -->
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <style>
      .bd-placeholder-img {
        font-size: 1.125rem;
        text-anchor: middle;
        -webkit-user-select: none;
        -moz-user-select: none;
        -ms-user-select: none;
        user-select: none;
      }

      @media (min-width: 768px) {
        .bd-placeholder-img-lg {
          font-size: 3.5rem;
        }
      }
    </style>

    <!-- Custom styles for this template -->
    <link href="Content/signin.css" rel="stylesheet" />

  </head>
  <body class="text-center">
    <form class="form-signin" runat="server">

      <img class="mb-4" src="/img/sis1.jpg" alt="" width="120" height="120"><br />

      <asp:Label for="txtUserName" runat="server" Text="Nombre de usuario:" Font-Bold="true"></asp:Label>
      <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control"></asp:TextBox>

      <asp:Label for="txtPassword" runat="server" Text="Contraseña:" Font-Bold="true"></asp:Label>
      <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

      <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" CssClass="btn btn-lg btn-primary btn-block" />
      <footer class="mt-5 mb-3"><p>&copy; <%: DateTime.Now.Year %></p></footer>
    </form>
  </body>
</html>
