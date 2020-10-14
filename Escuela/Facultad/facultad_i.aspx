<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_i.aspx.cs" Inherits="Escuela.Facultad.facultad_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--Todos los campos deben ser requeridos (código, nombre, fecha de creación y universidad).--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
           <tr>
               <td>Código</td>
               <td>
                   <asp:TextBox ID="txtCodigo" MaxLength="6" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfv_codigo" ControlToValidate="txtCodigo" Display="Dynamic"
                       runat="server" ErrorMessage="El código es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                   <%--El  formato  del  código  debe  ser  de  cuatro  letras  mayúsculas  y  dos  números.  Ejemplo:  FIME01. --%>
                   <asp:RegularExpressionValidator ID="rev_codigo" ValidationExpression="^[A-Z]{4}[0-9]{2}$" ControlToValidate="txtCodigo"
                       runat="server" ErrorMessage="El código debe ser 4 letras mayúsculas y 2 números." ValidationGroup="vlg1"></asp:RegularExpressionValidator>
               </td>
           </tr>
            <tr>
               <td>Nombre</td>
               <td>
                   <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfv_nombre" ControlToValidate="txtNombre" Display="Dynamic"
                       runat="server" ErrorMessage="El nombre es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
               </td>
           </tr>
           <tr>
               <td>Fecha de Creación</td>
               <td>
                   <%--El formato de fecha debe ser dd/mm/yyyy.--%>
                   <asp:TextBox ID="txtFechaCreacion" runat="server"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="rfv_fecha" ControlToValidate="txtFechaCreacion" Display="Dynamic"
                       runat="server" ErrorMessage="La fecha de creación es requerida." ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                   <asp:CompareValidator ID="cv_fecha" ControlToValidate="txtFechaCreacion" Type="Date" Operator="DataTypeCheck"
                       runat="server" ErrorMessage="El formato es incorrecto (dd/mm/yyyy)" ValidationGroup="vlg1"></asp:CompareValidator>
               </td>
           </tr>
           <tr>
               <td>Universidad</td>
               <td>
                   <asp:DropDownList ID="ddlUniversidades" runat="server"></asp:DropDownList>
                   <asp:RequiredFieldValidator ID="rfv_universidades" ControlToValidate="ddlUniversidades" Display="Dynamic"
                       runat="server" ErrorMessage="El nombre de la universidad es requerido." ValidationGroup="vlg1" InitialValue="0"></asp:RequiredFieldValidator>
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
                   
               </td>
           </tr>
       </table>
        </ContentTemplate>
    </asp:UpdatePanel>
<asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="Button1_Click" ValidationGroup="vlg1" />


    <asp:GridView ID="grd_facultades" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Código" DataField="codigo" />
        </Columns>
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
        </Columns>
        <Columns>
            <asp:BoundField HeaderText="Fecha de Creación" DataField="fechaCreacion" />
        </Columns>
        <Columns>
            <asp:BoundField HeaderText="Universidad" DataField="Universidad" />
        </Columns>
    </asp:GridView>

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
