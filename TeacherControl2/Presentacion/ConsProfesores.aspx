<%@ Page Title="" Language="C#" MasterPageFile="~/BasePage.Master" AutoEventWireup="true" CodeBehind="ConsProfesores.aspx.cs" Inherits="RegEstudiantes.Presentacion.ConsProfesores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        &nbsp;<asp:DropDownList ID="ProfesoresDropDownList" runat="server" AutoPostBack="False">
        <asp:ListItem>Elija una opcion</asp:ListItem>
        <asp:ListItem>Nombre</asp:ListItem>
        <asp:ListItem>Apellido</asp:ListItem>
    </asp:DropDownList>
    <asp:TextBox ID="BuscarTextBox" runat="server"></asp:TextBox>
    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
    <asp:GridView ID="DatosGridView" runat="server">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="IdProfesor" DataNavigateUrlFormatString="~/Presentacion/RegProfesores.aspx?ProfesorId={0}" Text="Editar" />
        </Columns>
    </asp:GridView>
</asp:Content>
