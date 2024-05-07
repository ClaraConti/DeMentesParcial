<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="UNIVERSIDAD.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>CRUD</title>
    <style>
        .container {
            text-align: center;
        }
        .button {
            background-color: #00aae4; 
            border: none;
            color: white;
            padding: 10px 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
            border-radius: 8px;
        }
        .grid-view {
            margin: 0 auto; /* Center the table */
            border-collapse: collapse;
            width: 80%; /* Adjust width as needed */
        }
        .grid-view th, .grid-view td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
        .grid-view th {
            background-color: #08e300;
            color: white;
        }
        .grid-view tr:nth-child(even) {
            background-color: #ddd;
        }
        .grid-view tr:hover {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>CRUD</h1>
            <p>Mantenimiento de la tabla Estudiante</p>
        <p>Cod Estudiante: <asp:TextBox runat="server" ID="txtCodEstudiante"></asp:TextBox></p>
        <p>Apellidos: <asp:TextBox runat="server" ID="txtApellidos"></asp:TextBox></p>
        <p>Nombres: <asp:TextBox runat="server" ID="txtNombres"></asp:TextBox></p>
        <p>
            <asp:Button runat="server" ID="btnAgregar" Text ="Agregar" OnClick="btnAgregar_Click" CssClass="button" />
            <asp:Button runat="server" ID="btnEliminar" Text ="Eliminar" OnClick="btnEliminar_Click" CssClass="button" />
            <asp:Button runat="server" ID="btnActualizar" Text ="Actualizar" OnClick="btnActualizar_Click" CssClass="button" />
        </p>
        <p>
            <asp:TextBox runat="server" ID="txtBuscar"></asp:TextBox>
            <asp:Button runat="server" ID="btnBuscar" Text ="Buscar" OnClick="btnBuscar_Click" CssClass="button" />
        </p>
        <p>
            <asp:GridView runat="server" ID="gvEstudiante" CssClass="grid-view"></asp:GridView>
        </p>
        <div class="container">
            <p>Mantenimiento de la tabla Asignatura</p>
        <p>Cod Asignatura: <asp:TextBox runat="server" ID="txtCodAsignatura"></asp:TextBox></p>
        <p>Nombres: <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox></p>
        <p>Creditos: <asp:TextBox runat="server" ID="txtCreditos"></asp:TextBox></p>
        <p>
            <asp:Button runat="server" ID="btnAgrega" Text ="Agregar" OnClick="btnAgrega_Click" CssClass="button" />
            <asp:Button runat="server" ID="btnElimino" Text ="Eliminar" OnClick="btnElimino_Click" CssClass="button" />
             <asp:Button runat="server" ID="btnActualizo" Text ="Actualizar" OnClick="btnActualizo_Click" CssClass="button" />
        </p>
        <p>
             <asp:TextBox runat="server" ID="txtBusco"></asp:TextBox>
             <asp:Button runat="server" ID="btnBusco" Text ="Buscar" OnClick="btnBusco_Click" CssClass="button" />
        </p>
        <p>
            <asp:GridView runat="server" ID="gvAsignatura" CssClass="grid-view"></asp:GridView>
        </p>
               <p>Mantenimiento de la tabla Matricula</p>
        <p>Cod Estudiantes: <asp:TextBox runat="server" ID="txtCodEstudiantes"></asp:TextBox></p>
        <p>Cod Asignaturas: <asp:TextBox runat="server" ID="txtCodAsignaturas"></asp:TextBox></p>
        <p>Periodo: <asp:TextBox runat="server" ID="txtPeriodo"></asp:TextBox></p>
        <p>Promedio: <asp:TextBox runat="server" ID="txtPromedio"></asp:TextBox></p>
        <p>
            <asp:Button runat="server" ID="btnAgregamos" Text ="Agregar" OnClick="btnAgregamos_Click" CssClass="button" />
            <asp:Button runat="server" ID="btnEliminamos" Text ="Eliminar" OnClick="btnEliminamos_Click" CssClass="button" />
             <asp:Button runat="server" ID="btnActualizamos" Text ="Actualizar" OnClick="btnActualizamos_Click" CssClass="button" />
        </p>
        <p>
             <asp:TextBox runat="server" ID="txtBusca"></asp:TextBox>
             <asp:Button runat="server" ID="btnBuscamos" Text ="Buscar" OnClick="btnBuscamos_Click" CssClass="button" />
        </p>
        <p>
           <asp:GridView runat="server" ID="gvMatricula" CssClass="grid-view" ></asp:GridView>
        </p>
           
      </div>
    </form>
</body>
</html>