<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_s.aspx.cs" Inherits="Escuela.Facultad.facultad_s" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="main"></div>
    <%--<asp:GridView ID="grd_facultad" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_facultad_RowCommand">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/lapiz.png" 
                        Height="20px" Width="20px" commandName="Editar" CommandArgument='<%# Eval("ID_Facultad")%>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/trash.png" 
                        Height="20px" Width="20px" commandName="Eliminar" CommandArgument='<%# Eval("ID_Facultad")%>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="ID" DataField="ID_Facultad" />
            <asp:BoundField HeaderText="Código" DataField="codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Fecha de Creación" DataField="fechaCreacion" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="Universidad" DataField="universidad" />
            <asp:BoundField HeaderText="Ciudad" DataField="ciudad" />
        </Columns>--%>
<%--    </asp:GridView>--%>

    <script type="text/javascript">

        $(document).ready(function () {
            $.ajax({
                type: "GET",
                crossDomain: true,
                url: '<%= ResolveUrl("http://localhost:50447/ServicioWCFFacultad.svc/consultaFacultadesJSON") %>',
                success: function (data) {
                    var html = '';
                    html = html + '<table style="border: 1px;"><tr><th>ID Facultad</th><th>Facultad</th><th>Código</th><th>Nombre</th><th>Fecha de creación</th><th>Universidad</th><th>Ciudad</th></tr>';
                    console.log("Llamada de ajax exitosa!");
                    var arrayFacultades = JSON.parse(data["d"]);
                    console.log(arrayFacultades);
                    for (i = 0; i < arrayFacultades.length; i++) {
                        html += '<tr>'
                        html += '<td>' + arrayFacultades[i]["ID_Facultad"] + '</td>';
                        html += '<td>' + arrayFacultades[i]["nombre"] + '</td>';
                        html += '<td>' + arrayFacultades[i]["codigo"] + '</td>';
                        html += '<td>' + arrayFacultades[i]["nombre"] + '</td>';
                        html += '<td>' + arrayFacultades[i]["fechaCreacion"] + '</td>';
                        html += '<td>' + arrayFacultades[i]["universidad"] + '</td>';
                        html += '<td>' + arrayFacultades[i]["ciudad"] + '</td>';

                    }
                    html += '</table>';
                    $("#main").append(html);
                    console.log(html);
                },
                error: function (e) {
                    console.log("Error en la llamada de Ajax :c");
                    console.log(e);
                }
            })
        })
    </script>

</asp:Content>