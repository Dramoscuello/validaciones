<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="ValidacionesSalud._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Validador</h1>
    </div>
    <div class="row">
        <asp:Label ID="Label1" runat="server" Text="Archivo"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Guardar" ToolTip="Guardar en la base de datos..." CssClass="btn btn-success" />
        <asp:Button ID="Button3" runat="server" Text="Validar" CssClass="btn btn-success" />
        <asp:Button ID="Button2" runat="server" Text="Descargar" CssClass="btn btn-success" />
        <br />
        <asp:Label ID="Label2" runat="server" CssClass="lead" ForeColor="Red"></asp:Label>
    </div>

</asp:Content>
