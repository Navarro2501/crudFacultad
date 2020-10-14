<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Escuela.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/login.css" rel="stylesheet" />
</head>
<body>
    <form id="formLogin" runat="server">
        <div id="imgLogin"></div>
            <table>
                <tr>
                    <td>Nombre de usuario</td>
                    <td>
                        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña</td>
                    <td>
                        <asp:TextBox ID="txtContraseña" TextMode="Password" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
                    </td>
                </tr>
            </table>
    </form>
</body>
</html>
