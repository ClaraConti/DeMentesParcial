<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="trome.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>CRUD</title>
    <style>
          /* Estilos de la página */
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }
        header {
            background-color: #808080;
            color: #808080;
            padding: 10px;
            text-align: center;
        }
        nav {
            background-color: #b6ff00;
            padding: 10px;
            text-align: center;
        }
        nav ul {
            list-style-type: none;
            padding: 0;
        }
        nav ul li {
            display: inline;
            margin-right: 10px;
        }
        nav ul li a {
            color: #000000;
            text-decoration: none;
            padding: 5px 10px;
            border-radius: 5px;
            transition: background-color 0.3s ease;
        }
        nav ul li a:hover {
            background-color: #808080;
        }
        .container {
            text-align: center;
        }
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
              <img src="images.jpeg" alt="Logo de Transportes Trome Express Cargo">
            <h1>TRANSPORTES TROME EXPRESS CARGO</h1>

            <header>
                <nav>
                <ul>
            <li><a href="#tablaClientes">Clientes</a></li>
            <li><a href="#tablaServicios">Servicios</a></li>
            <li><a href="#tablaVehiculos">Vehículos</a></li>
            <li><a href="#tablaEnvio">Envíos</a></li>
            <li><a href="#tablaColaborador">Colaboradores</a></li>
              </ul>
            </nav>
    </header>

            <!-- Tabla de clientes -->
            <div id="tablaClientes">
                <h2>Tabla de clientes</h2>
                <p>IdCliente: <asp:TextBox runat="server" ID="txtIdCliente"></asp:TextBox></p>
                <p>Nombre: <asp:TextBox runat="server" ID="txtNombre"></asp:TextBox></p>
                <p>Direccion: <asp:TextBox runat="server" ID="txtDireccion"></asp:TextBox></p>
                <p>Telefono: <asp:TextBox runat="server" ID="txtTelefono"></asp:TextBox></p>
                <p>Email: <asp:TextBox runat="server" ID="txtEmail"></asp:TextBox></p>
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
                    <asp:GridView runat="server" ID="gvClientes" CssClass="grid-view"></asp:GridView>
                </p>
            </div>
            
            <!-- Tabla de servicios -->
            <div id="tablaServicios">
                <h2>Tabla de Servicios</h2>
                <p>IdServicio: <asp:TextBox runat="server" ID="txtIdServicio"></asp:TextBox></p>
                <p>Descripción: <asp:TextBox runat="server" ID="txtDescripcion"></asp:TextBox></p>
                <p>Tarifa: <asp:TextBox runat="server" ID="txtTarifa"></asp:TextBox></p>
                <p>
                    <asp:Button runat="server" ID="btnAgregar" Text ="Agregar" OnClick="btnAgregar_Click" CssClass="button" />
                    <asp:Button runat="server" ID="btnEliminar" Text ="Eliminar" OnClick="btnEliminar_Click" CssClass="button" />
                    <asp:Button runat="server" ID="btnActualizar" Text ="Actualizar" OnClick="btnActualizar_Click" CssClass="button" />
                </p>
                <p>
                    <asp:TextBox runat="server" ID="txtBusca"></asp:TextBox>
                    <asp:Button runat="server" ID="btnBusca" Text ="Buscar" OnClick="btnBusca_Click" CssClass="button" />
                </p>
                <p>
                    <asp:GridView runat="server" ID="gvServicio" CssClass="grid-view"></asp:GridView>
                </p>
            </div>
             <!-- Tabla de vehiculos -->
            <div id="tablaVehiculos">
                <h2>Tabla de Vehiculos </h2>
                <p>IdVehiculo: <asp:TextBox runat="server" ID="txtIdVehiculo"></asp:TextBox></p>
                <p>Marca: <asp:TextBox runat="server" ID="txtMarca"></asp:TextBox></p>
                <p>Modelo: <asp:TextBox runat="server" ID="txtModelo"></asp:TextBox></p>
                <p>Placa : <asp:TextBox runat="server" ID="txtPlaca"></asp:TextBox></p>
                <p>CapacidadCarga: <asp:TextBox runat="server" ID="txtCapacidadCarga"></asp:TextBox></p>
                <p>
                    <asp:Button runat="server" ID="btnAgregara" Text ="Agregar" OnClick="btnAgregara_Click" CssClass="button" />
                    <asp:Button runat="server" ID="btnEliminara" Text ="Eliminar" OnClick="btnEliminara_Click" CssClass="button" />
                    <asp:Button runat="server" ID="btnActualizara" Text ="Actualizar" OnClick="btnActualizara_Click" CssClass="button" />
                </p>
                <p>
                    <asp:TextBox runat="server" ID="txtBuscar"></asp:TextBox>
                    <asp:Button runat="server" ID="btnBuscar" Text ="Buscar" OnClick="btnBuscar_Click" CssClass="button" />
                </p>
                <p>
                    <asp:GridView runat="server" ID="gvVehiculo" CssClass="grid-view"></asp:GridView>
                </p>
            </div>
            <!-- Tabla de envio-->
            <div id="tablaEnvio">
                <h2>Tabla de Envios  </h2>
                <p>IdEnvio: <asp:TextBox runat="server" ID="txtIdEnvio"></asp:TextBox></p>
                <p>IdCliente: <asp:TextBox runat="server" ID="txtIdClientes"></asp:TextBox></p>
                <p>IdServicio: <asp:TextBox runat="server" ID="txtIdServicios"></asp:TextBox></p>
                <p>FechaEnvio : <asp:TextBox runat="server" ID="txtFechaEnvio"></asp:TextBox></p>
                <p>FechaRecojo: <asp:TextBox runat="server" ID="txtFechaRecojo"></asp:TextBox></p>
                 <p>MontoPago: <asp:TextBox runat="server" ID="txtMontoPago"></asp:TextBox></p>

                <p>
                    <asp:Button runat="server" ID="btnAgregare" Text ="Agregar" OnClick="btnAgregarare_Click" CssClass="button" />
                    <asp:Button runat="server" ID="btnEliminare" Text ="Eliminar" OnClick="btnEliminare_Click" CssClass="button" />
                    <asp:Button runat="server" ID="btnActualizare" Text ="Actualizar" OnClick="btnActualizare_Click" CssClass="button" />
                </p>
                <p>
                    <asp:TextBox runat="server" ID="txtbuscare"></asp:TextBox>
                    <asp:Button runat="server" ID="btnBuscare" Text ="Buscar" OnClick="btnBuscare_Click" CssClass="button" />
                </p>
                <p>
                    <asp:GridView runat="server" ID="gvEnvio" CssClass="grid-view"></asp:GridView>
                </p>
            </div>
            <!-- Tabla de colabolador-->
            <div id="tablaColaborador">
                <h2>Tabla de Colaborador </h2>
                <p>IdColaborador: <asp:TextBox runat="server" ID="txtIdColaborador"></asp:TextBox></p>
                <p>Nombre: <asp:TextBox runat="server" ID="txtNombres"></asp:TextBox></p>
                <p>Cargo: <asp:TextBox runat="server" ID="txtCargo"></asp:TextBox></p>
                <p>Telefono: <asp:TextBox runat="server" ID="txtTelefonos"></asp:TextBox></p>
                <p>Email: <asp:TextBox runat="server" ID="txtEmails"></asp:TextBox></p>
                 <p>IdVehiculo: <asp:TextBox runat="server" ID="txtIdVehiculos"></asp:TextBox></p>
                <p>
                    <asp:Button runat="server" ID="btnAgregaremos" Text ="Agregar" OnClick="btnAgregaremos_Click" CssClass="button" />
                    <asp:Button runat="server" ID="btnEliminaremos" Text ="Eliminar" OnClick="btnEliminaremos_Click" CssClass="button" />
                    <asp:Button runat="server" ID="btnActualizaremos" Text ="Actualizar" OnClick="btnActualizaremos_Click" CssClass="button" />
                </p>
                <p>
                    <asp:TextBox runat="server" ID="txtBuscaremos"></asp:TextBox>
                    <asp:Button runat="server" ID="btnBuscsremos" Text ="Buscar" OnClick="btnBuscaremos_Click" CssClass="button" />
                </p>
                <p>
                    <asp:GridView runat="server" ID="gvColaborador" CssClass="grid-view"></asp:GridView>
                </p>
            </div>
        </div>
    </form>
</body>
</html>