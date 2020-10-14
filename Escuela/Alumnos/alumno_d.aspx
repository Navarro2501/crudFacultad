<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_d.aspx.cs" Inherits="Escuela.Alumnos.alumno_d" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table>
       <tr>
           <td>Matrícula</td>
           <td>
               <asp:Label ID="lblMatricula" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>Nombre</td>
           <td>
               <asp:Label ID="lblNombre" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>Fecha de Nacimiento:</td>
           <td>
               <asp:Label ID="lblFechaNacimiento" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>Semestre</td>
           <td>
               <asp:Label ID="lblSemestre" runat="server"></asp:Label>
           </td>
       </tr>
       <tr>
           <td>Facultad</td>
           <td>
               <asp:DropDownList ID="ddlFacultad" runat="server"></asp:DropDownList>
           </td>
       </tr>
       <tr>
           <td></td>
           <td>
               <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
           </td>
       </tr>
   </table>
</asp:Content>
