<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_i.aspx.cs" Inherits="Escuela.Alumnos.alumno_i" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
               <tr>
                   <td>Matrícula</td>
                   <td>
                       <asp:TextBox ID="txtMatricula" MaxLength="8" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="rfv_matricula" ControlToValidate="txtMatricula" Display="Dynamic"
                           runat="server" ErrorMessage="La matrícula es requerida" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="rev_matricula" runat="server" ValidationExpression="^[0-9]+$" 
                           ControlToValidate="txtMatricula" ErrorMessage="Solo se aceptan números interos" ValidationGroup="vlg1"></asp:RegularExpressionValidator> 
                   </td>
               </tr>
               <tr>
                   <td>Nombre</td>
                   <td>
                       <asp:TextBox ID="txtNombre" MaxLength="100" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="rfv_nombre" ControlToValidate="txtNombre" Display="Dynamic"
                           runat="server" ErrorMessage="El nombre es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>

                   </td>
               </tr>
               <tr>
                   <td>Fecha de Nacimiento:</td>
                   <td>
                       <asp:TextBox ID="txtFechaNacimiento" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="rfv_fecha" ControlToValidate="txtFechaNacimiento" Display="Dynamic"
                           runat="server" ErrorMessage="La fecha es requerida" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                       <asp:CompareValidator ID="cv_fecha" runat="server" ControlToValidate="txtFechaNacimiento" Type="Date" Operator="DataTypeCheck"
                           ErrorMessage="El formato es incorrecto (dd/mm/yyyy) o (mm/dd/yyyy)" ValidationGroup="vlg1"></asp:CompareValidator>
                   </td>
               </tr>
               <tr>
                   <td>Semestre</td>
                   <td>
                       <asp:TextBox ID="txtSemestre" runat="server"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="rfv_semestre" ControlToValidate="txtSemestre" Display="Dynamic"
                           runat="server" ErrorMessage="El semestre es requerido" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                       <asp:RangeValidator ID="rv_semestre" runat="server" ErrorMessage="El semestre tiene que estar entre 1 y 12" 
                           ControlToValidate="txtSemestre" Type="Integer" MinimumValue="1" MaximumValue="12" ValidationGroup="vlg1" ></asp:RangeValidator>
                   </td>
               </tr>
               <tr>
                   <td>Facultad</td>
                   <td>
                       <asp:DropDownList ID="ddlFacultad" CssClass="lista" runat="server"></asp:DropDownList>
                       <asp:RequiredFieldValidator ID="rfv_facultad" ControlToValidate="ddlFacultad"
                           runat="server" ErrorMessage="La facultad es requerida" ValidationGroup="vlg1" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>

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
                       <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="Button1_Click" ValidationGroup="vlg1" />
                   </td>
               </tr>
           </table>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:GridView ID="grd_alumnos" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Matrícula" DataField="matricula" />
        </Columns>
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
        </Columns>
    </asp:GridView>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#MainContent_txtFechaNacimiento").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1960:2008",
                dateFormat: "dd-mm-yy"
            });

            $('.lista').chosen();
        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {
            $("#MainContent_txtFechaNacimiento").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1960:2008",
                dateFormat: "dd-mm-yy"
            });

            $('.lista').chosen();
        });

    </script>

</asp:Content>
