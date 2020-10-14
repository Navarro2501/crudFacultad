<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="alumno_s.aspx.cs" Inherits="Escuela.Alumnos.alumno_s" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%-- Esta sentencia crea la tabla en un ciclo for de los datos enviados --%>
    <asp:GridView ID="grd_alumnos" AutoGenerateColumns="false" runat="server" OnRowCommand="grd_alumnos_RowCommand">
        <Columns>
            <%-- Crea los botones de editar y borrar --%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/lapiz.png" 
                        Height="20px" Width="20px" commandName="Editar" CommandArgument='<%# Eval("matricula")%>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/trash.png" 
                        Height="20px" Width="20px" commandName="Eliminar" CommandArgument='<%# Eval("matricula")%>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Matricula" DataField="matricula" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Fecha de Nacimiento" DataField="fechaNacimiento" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="Semestre" DataField="semestre" />
            <asp:BoundField HeaderText="Facultad" DataField="nombreFacultad" />
            <asp:BoundField HeaderText="Ciudad" DataField="nombreCiudad" />
        </Columns>
    </asp:GridView>

    <script type="text/javascript">

        $(document).ready(function () {
            $.ajax({
                type: "GET",
                crossDomain: true,
                url: '<%= ResolveUrl("http://localhost:50447/ServicioWCFAlumnos.svc/ConsultaAlumnosJSON") %>',
                success: function (data) {
                    console.log("Llamada de ajax exitosa!");
                    console.log(data);
                },
                error: function (e) {
                    console.log("Error en la llamada de Ajax :c");
                    console.log(e);
                }
            })
        })
    </script>

</asp:Content>
