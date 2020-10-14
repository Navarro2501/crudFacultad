<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_u.aspx.cs" Inherits="Escuela.Facultad.facultad_u" %>
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
               <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
           </td>
       </tr>
        <tr>
           <td>Nombre</td>
           <td>
               <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
           </td>
       </tr>
       <tr>
           <td>Fecha de Creación</td>
           <td>
               <asp:TextBox ID="txtFechaCreacion" runat="server"></asp:TextBox>
           </td>
       </tr>
       <tr>
           <td>Universidad</td>
           <td>
               <asp:DropDownList ID="ddlUniversidades" runat="server"></asp:DropDownList>
           </td>
       </tr>
        <tr>
            <td>Estado: </td>
            <td><asp:DropDownList ID="ddlEstado" CssClass="lista" runat="server" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Ciudad: </td>
            <td><asp:DropDownList ID="ddlCiudad" CssClass="lista" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td>Materias: </td>
            <td>
                <asp:ListBox ID="listBoxMaterias" SelectionMode="Multiple" CssClass="lista" Width="150px" runat="server"></asp:ListBox>
            </td>
        </tr>
       <tr>
           <td></td>
           <td>
               <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="Button1_Click" />
           </td>
       </tr>
   </table>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtFechaCreacion").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1960:2008",
                dateFormat: "dd-mm-yy"
            });

            $('.lista').chosen();
        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {
            $("#MainContent_txtFechaCreacion").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1960:2008",
                dateFormat: "dd-mm-yy"
            });

            $('.lista').chosen();
        });

    </script>
</asp:Content>
