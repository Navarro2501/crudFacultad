<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_d.aspx.cs" Inherits="Escuela.Facultad.facultad_d" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
       <tr>
           <td>ID</td>
           <td>
               <asp:Label ID="lblID" runat="server"></asp:Label>
           </td>
       </tr>
        <tr>
           <td>Código</td>
           <td>
               <asp:Label ID="txtCodigo" runat="server"></asp:Label>
           </td>
       </tr>
        <tr>
           <td>Nombre</td>
           <td>
               <asp:Label ID="txtNombre" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>Fecha de Creación</td>
           <td>
               <asp:Label ID="txtFechaCreacion" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>Universidad</td>
           <td>
               <asp:DropDownList ID="ddlUniversidades" runat="server"></asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td></td>
           <td>
               <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="Button1_Click" />
           </td>
       </tr>
   </table>
</asp:Content>
