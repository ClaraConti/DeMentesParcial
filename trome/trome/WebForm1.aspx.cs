using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trome
{
    public partial class WebForm1 : System.Web.UI.Page

    {
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;
    
        private void CargarDatos()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TCliente";//Condultar SQL
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);//llevar la consulta BD
                DataTable tabla = new DataTable();//DECLARACION DE buffer de memoria tabla
                adapter.Fill(tabla);//tabla tiene contenido de la BD
                //lleVAR A LA TABLA grilla
                this.gvClientes.DataSource = tabla;
                this.gvClientes.DataBind();
            }
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TServicio";//Condultar SQL
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);//llevar la consulta BD
                DataTable tabla = new DataTable();//DECLARACION DE buffer de memoria tabla
                adapter.Fill(tabla);//tabla tiene contenido de la BD
                //lleVAR A LA TABLA grilla
                this.gvServicio.DataSource = tabla;
                this.gvServicio.DataBind();
            }
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TVehiculo";//Condultar SQL
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);//llevar la consulta BD
                DataTable tabla = new DataTable();//DECLARACION DE buffer de memoria tabla
                adapter.Fill(tabla);//tabla tiene contenido de la BD
                //lleVAR A LA TABLA grilla
                this.gvVehiculo.DataSource = tabla;
                this.gvVehiculo.DataBind();
            }
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TEnvio";//Condultar SQL
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);//llevar la consulta BD
                DataTable tabla = new DataTable();//DECLARACION DE buffer de memoria tabla
                adapter.Fill(tabla);//tabla tiene contenido de la BD
                //lleVAR A LA TABLA grilla
                this.gvEnvio.DataSource = tabla;
                this.gvEnvio.DataBind();
            }
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TColaborador";//Condultar SQL
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);//llevar la consulta BD
                DataTable tabla = new DataTable();//DECLARACION DE buffer de memoria tabla
                adapter.Fill(tabla);//tabla tiene contenido de la BD
                //lleVAR A LA TABLA grilla
                this.gvColaborador.DataSource = tabla;
                this.gvColaborador.DataBind();
            }
           

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //CARGAR LOS DATOS SOLO LA PRIMERA VEZ 
            if (!Page.IsPostBack)
                CargarDatos();
        }
        //CLIENTES
        protected void btnAgrega_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {

                    string idClientes = txtIdCliente.Text.Trim();
                    string nombres = txtNombre.Text.Trim();
                    string direccion = txtDireccion.Text.Trim();
                    string telefono = txtTelefono.Text.Trim();
                    string email = txtEmail.Text.Trim();
                    string consulta = " insert into TCliente values (@IdCliente,@Nombre,@Direccion,@Telefono,@Email)";
                    //utilizar un SQLcomand para llevar la consulta a la BD 
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    //llevar los parametros a la BD
                    comando.Parameters.AddWithValue("@IdCliente", idClientes);
                    comando.Parameters.AddWithValue("@Nombre", nombres);
                    comando.Parameters.AddWithValue("@Direccion", direccion);
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    comando.Parameters.AddWithValue("@Email", email);
                    // ejecutar la consulta
                    conexion.Open();//abrir lña conexion de la BD
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();//Cerrar la conexion BD
                    if (i == 1)
                    {
                        //agregar un registro a la tabla estudiante
                        CargarDatos();
                        Response.Write("<script>alert('Se agrego correctamente');</script");
                    }
                    else Response.Write("<script>alert('Problemas al agregar datos a la tabla');</script");
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message); conexion.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>"); conexion.Close();
                }
                finally
                {
                    conexion.Close();
                }

            }
        }

        protected void btnElimino_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string idClientes = txtIdCliente.Text.Trim();
                    string consulta = "DELETE FROM TCliente WHERE IdCliente = @IdCliente";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdCliente", idClientes);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se eliminó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al eliminar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
        protected void btnActualizo_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string idClientes = txtIdCliente.Text.Trim();
                    string nombres = txtNombre.Text.Trim();
                    string direccion = txtDireccion.Text.Trim();
                    string telefono = txtTelefono.Text.Trim();
                    string email = txtEmail.Text.Trim();

                    string consulta = "UPDATE TCliente SET Nombre = @Nombre, Direccion = @Direccion, Telefono = @Telefono, Email = @Email WHERE IdCliente = @IdCliente";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdCliente", idClientes);
                    comando.Parameters.AddWithValue("@Nombre", nombres);
                    comando.Parameters.AddWithValue("@Direccion", direccion);
                    comando.Parameters.AddWithValue("@Telefono", telefono);
                    comando.Parameters.AddWithValue("@Email", email);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se actualizó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al actualizar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }


        protected void btnBusco_Click(object sender, EventArgs e)
        {
            // Obtener el término de búsqueda ingresado por el usuario
            string terminoBusqueda = txtBusco.Text.Trim();

            // Consulta SQL para buscar clientes que coincidan con el término de búsqueda
            string consulta = "SELECT * FROM TCliente WHERE  Nombre LIKE @Termino OR Direccion LIKE @Termino OR Telefono LIKE @Termino OR Email LIKE @Termino";

            // Crear y abrir la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    // Crear un nuevo comando SQL
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    // Agregar el parámetro para el término de búsqueda
                    comando.Parameters.AddWithValue("@Termino", "%" + terminoBusqueda + "%");

                    // Crear un adaptador de datos para ejecutar la consulta y llenar un DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    // Asignar los resultados de la búsqueda al GridView
                    gvClientes.DataSource = tabla;
                    gvClientes.DataBind();
                }
                catch (SqlException ex)
                {
                    // Manejar excepciones de SQL
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    // Manejar excepciones generales
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }



        // SERVICIOS
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
  

                    string IdServicio = txtIdServicio.Text.Trim();
                    string descrIpcion = txtDescripcion.Text.Trim();
                    string tarifa = txtTarifa.Text.Trim();
                   
                    string consulta = " insert into TServicio  values (@IdServicio,@Descripcion,@Tarifa)";
                    //utilizar un SQLcomand para llevar la consulta a la BD 
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    //llevar los parametros a la BD
                    comando.Parameters.AddWithValue("@IdServicio", IdServicio);
                    comando.Parameters.AddWithValue("@Descripcion", descrIpcion);
                    comando.Parameters.AddWithValue("@Tarifa", tarifa);
         
                    // ejecutar la consulta
                    conexion.Open();//abrir lña conexion de la BD
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();//Cerrar la conexion BD
                    if (i == 1)
                    {
                        //agregar un registro a la tabla estudiante
                        CargarDatos();
                        Response.Write("<script>alert('Se agrego correctamente');</script");
                    }
                    else Response.Write("<script>alert('Problemas al agregar datos a la tabla');</script");
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message); conexion.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>"); conexion.Close();
                }
                finally
                {
                    conexion.Close();
                }

            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string IdServicio = txtIdServicio.Text.Trim();
                    string consulta = "DELETE FROM TServicio WHERE IdServicio= @IdServicio";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdServicio", IdServicio);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se eliminó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al eliminar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string IdServicio = txtIdServicio.Text.Trim();
                    string descrIpcion = txtDescripcion.Text.Trim();
                    string tarifa = txtTarifa.Text.Trim();

                    string consulta = "UPDATE TServicio SET Descripcion = @Descripcion , Tarifa = @Tarifa WHERE IdServicio = @IdServicio";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdServicio", IdServicio);
                    comando.Parameters.AddWithValue("@Descripcion", descrIpcion);
                    comando.Parameters.AddWithValue("@Tarifa", tarifa);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se actualizó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al actualizar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            // Obtener el término de búsqueda ingresado por el usuario
            string terminoBusqueda = txtBusca.Text.Trim();

            // Consulta SQL para buscar clientes que coincidan con el término de búsqueda
            string consulta = "SELECT * FROM TServicio WHERE IdServicio LIKE @Termino OR  Descripcion LIKE @Termino OR Tarifa LIKE @Termino";

            // Crear y abrir la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    // Crear un nuevo comando SQL
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    // Agregar el parámetro para el término de búsqueda
                    comando.Parameters.AddWithValue("@Termino", "%" + terminoBusqueda + "%");

                    // Crear un adaptador de datos para ejecutar la consulta y llenar un DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    // Asignar los resultados de la búsqueda al GridView
                    gvServicio.DataSource = tabla;
                    gvServicio.DataBind();
                }
                catch (SqlException ex)
                {
                    // Manejar excepciones de SQL
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    // Manejar excepciones generales
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
        //VEHICULOS
        protected void btnAgregara_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                   
                    string IdVehiculo = txtIdVehiculo.Text.Trim();
                    string marca = txtMarca.Text.Trim();
                    string modelo = txtModelo.Text.Trim();
                    string placa = txtPlaca.Text.Trim();
                    string CapacidadCarga = txtCapacidadCarga.Text.Trim();
                    string consulta = " insert into TVehiculo values (@IdVehiculo,@Marca,@Modelo,@Placa,@CapacidadCarga)";
                    //utilizar un SQLcomand para llevar la consulta a la BD 
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    //llevar los parametros a la BD
                    comando.Parameters.AddWithValue("@IdVehiculo", IdVehiculo);
                    comando.Parameters.AddWithValue("@Marca", marca);
                    comando.Parameters.AddWithValue("@Modelo", modelo );
                    comando.Parameters.AddWithValue("@Placa", placa);
                    comando.Parameters.AddWithValue("@CapacidadCarga", CapacidadCarga);
                    // ejecutar la consulta
                    conexion.Open();//abrir lña conexion de la BD
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();//Cerrar la conexion BD
                    if (i == 1)
                    {
                        //agregar un registro a la tabla estudiante
                        CargarDatos();
                        Response.Write("<script>alert('Se agrego correctamente');</script");
                    }
                    else Response.Write("<script>alert('Problemas al agregar datos a la tabla');</script");
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message); conexion.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>"); conexion.Close();
                }
                finally
                {
                    conexion.Close();
                }

            }
        }

        protected void btnEliminara_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string IdVehiculo = txtIdVehiculo.Text.Trim();
                    string consulta = "DELETE FROM  TVehiculo  WHERE IdVehiculo = @IdVehiculo";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdVehiculo", IdVehiculo);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se eliminó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al eliminar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnActualizara_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string IdVehiculo = txtIdVehiculo.Text.Trim();
                    string marca = txtMarca.Text.Trim();
                    string modelo = txtModelo.Text.Trim();
                    string placa = txtPlaca.Text.Trim();
                    string CapacidadCarga = txtCapacidadCarga.Text.Trim();

                    string consulta = "UPDATE TVehiculo  SET  Marca = @Marca , Modelo = @Modelo, Placa = @Placa ,CapacidadCarga = @CapacidadCarga  WHERE IdVehiculo = @IdVehiculo";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdVehiculo", IdVehiculo);
                    comando.Parameters.AddWithValue("@Marca", marca);
                    comando.Parameters.AddWithValue("@Modelo", modelo);
                    comando.Parameters.AddWithValue("@Placa", placa);
                    comando.Parameters.AddWithValue("@CapacidadCarga", CapacidadCarga);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se actualizó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al actualizar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el término de búsqueda ingresado por el usuario
            string terminoBusqueda = txtBuscar.Text.Trim();

            // Consulta SQL para buscar clientes que coincidan con el término de búsqueda
            string consulta = "SELECT * FROM TVehiculo WHERE  Marca LIKE @Termino OR Modelo LIKE @Termino OR Placa LIKE @Termino OR CapacidadCarga LIKE @Termino";

            // Crear y abrir la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    // Crear un nuevo comando SQL
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    // Agregar el parámetro para el término de búsqueda
                    comando.Parameters.AddWithValue("@Termino", "%" + terminoBusqueda + "%");

                    // Crear un adaptador de datos para ejecutar la consulta y llenar un DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    // Asignar los resultados de la búsqueda al GridView
                    gvVehiculo.DataSource = tabla;
                    gvVehiculo.DataBind();
                }
                catch (SqlException ex)
                {
                    // Manejar excepciones de SQL
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    // Manejar excepciones generales
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
        //ENVIO
        protected void btnAgregarare_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
   
                    string IdEnvio= txtIdEnvio.Text.Trim();
                    string IdClientes = txtIdClientes.Text.Trim();
                    string IdServicios = txtIdServicios.Text.Trim();
                    string FechaEnvio = txtFechaEnvio.Text.Trim();
                    string FechaRecojo = txtFechaRecojo.Text.Trim();
                    string MontoPago = txtMontoPago.Text.Trim();
                    string consulta = " insert into TEnvio  values (@IdEnvio,@IdClientes,@IdServicios , @FechaEnvio,@FechaRecojo,@MontoPago)";
                    //utilizar un SQLcomand para llevar la consulta a la BD 
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    //llevar los parametros a la BD
                    comando.Parameters.AddWithValue("@IdEnvio", IdEnvio);
                    comando.Parameters.AddWithValue("@IdClientes", IdClientes);
                    comando.Parameters.AddWithValue("@IdServicios", IdServicios);
                    comando.Parameters.AddWithValue("@FechaEnvio", FechaEnvio);
                    comando.Parameters.AddWithValue("@FechaRecojo", FechaRecojo);
                    comando.Parameters.AddWithValue("@MontoPago", MontoPago);
                    // ejecutar la consulta
                    conexion.Open();//abrir lña conexion de la BD
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();//Cerrar la conexion BD
                    if (i == 1)
                    {
                        //agregar un registro a la tabla estudiante
                        CargarDatos();
                        Response.Write("<script>alert('Se agrego correctamente');</script");
                    }
                    else Response.Write("<script>alert('Problemas al agregar datos a la tabla');</script");
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message); conexion.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>"); conexion.Close();
                }
                finally
                {
                    conexion.Close();
                }

            }
        }

        protected void btnEliminare_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string IdEnvio = txtIdEnvio.Text.Trim();
                    string consulta = "DELETE FROM  TEnvio WHERE IdEnvio = @IdEnvio";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdEnvio", IdEnvio);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se eliminó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al eliminar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnActualizare_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string IdEnvio = txtIdEnvio.Text.Trim();
                    string IdClientes = txtIdClientes.Text.Trim();
                    string IdServicios = txtIdServicios.Text.Trim();
                    string FechaEnvio = txtFechaEnvio.Text.Trim();
                    string FechaRecojo = txtFechaRecojo.Text.Trim();
                    string MontoPago = txtMontoPago.Text.Trim();
                    string consulta = "UPDATE TEnvio SET IdCliente = @IdClientes ,IdServicio = @IdServicios, FechaEnvio = @FechaEnvio ,FechaRecojo = @FechaRecojo ,MontoPago = @MontoPago WHERE IdEnvio = @IdEnvio";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdEnvio", IdEnvio);
                    comando.Parameters.AddWithValue("@IdClientes", IdClientes);
                    comando.Parameters.AddWithValue("@IdServicios", IdServicios);
                    comando.Parameters.AddWithValue("@FechaEnvio", FechaEnvio);
                    comando.Parameters.AddWithValue("@FechaRecojo", FechaRecojo);
                    comando.Parameters.AddWithValue("@MontoPago", MontoPago);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se actualizó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al actualizar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnBuscare_Click(object sender, EventArgs e)
        {
            // Obtener el término de búsqueda ingresado por el usuario
            string terminoBusqueda = txtbuscare.Text.Trim();

            // Consulta SQL para buscar clientes que coincidan con el término de búsqueda
            string consulta = "SELECT * FROM TEnvio WHERE  IdCliente LIKE @Termino OR IdServicio LIKE @Termino OR FechaEnvio LIKE @Termino OR FechaRecojo LIKE @Termino OR MontoPago LIKE @Termino";

            // Crear y abrir la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    // Crear un nuevo comando SQL
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    // Agregar el parámetro para el término de búsqueda
                    comando.Parameters.AddWithValue("@Termino", "%" + terminoBusqueda + "%");

                    // Crear un adaptador de datos para ejecutar la consulta y llenar un DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    // Asignar los resultados de la búsqueda al GridView
                    gvEnvio.DataSource = tabla;
                    gvEnvio.DataBind();
                }
                catch (SqlException ex)
                {
                    // Manejar excepciones de SQL
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    // Manejar excepciones generales
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
        //COLABORADOR
        protected void btnAgregaremos_Click(object sender, EventArgs e)
        {
             using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {

                    string IdColaborador = txtIdColaborador.Text.Trim();
                    string Nombres = txtNombres.Text.Trim();
                    string Cargo = txtCargo.Text.Trim();
                    string Telefonos = txtTelefonos.Text.Trim();
                    string Email = txtEmails.Text.Trim();
                    string IdVehiculos = txtIdVehiculos.Text.Trim();
                    string consulta = " insert into TColaborador values (@IdColaborador ,@Nombre,@Cargo , @Telefono  ,@Email , @IdVehiculos)";
                    //utilizar un SQLcomand para llevar la consulta a la BD 
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    //llevar los parametros a la BD
                    comando.Parameters.AddWithValue("@IdColaborador", IdColaborador);
                    comando.Parameters.AddWithValue("@Nombre", Nombres);
                    comando.Parameters.AddWithValue("@Cargo", Cargo);
                    comando.Parameters.AddWithValue("@Telefono ", Telefonos);
                    comando.Parameters.AddWithValue("@Email", Email);
                    comando.Parameters.AddWithValue("@IdVehiculos", IdVehiculos);
                    // ejecutar la consulta
                    conexion.Open();//abrir lña conexion de la BD
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();//Cerrar la conexion BD
                    if (i == 1)
                    {
                        //agregar un registro a la tabla estudiante
                        CargarDatos();
                        Response.Write("<script>alert('Se agrego correctamente');</script");
                    }
                    else Response.Write("<script>alert('Problemas al agregar datos a la tabla');</script");
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message); conexion.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>"); conexion.Close();
                }
                finally
                {
                    conexion.Close();
                }

            }
        }

        protected void btnEliminaremos_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string IdColaborador = txtIdColaborador.Text.Trim();
                    string consulta = "DELETE FROM  TColaborador WHERE IdColaborador = @IdColaborador";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdColaborador", IdColaborador);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se eliminó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al eliminar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnActualizaremos_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string IdColaborador = txtIdColaborador.Text.Trim();
                    string Nombres = txtNombres.Text.Trim();
                    string Cargo = txtCargo.Text.Trim();
                    string Telefonos = txtTelefonos.Text.Trim();
                    string Emails = txtEmails.Text.Trim();
                    string IdVehiculos = txtIdVehiculos.Text.Trim();
                    string consulta = "UPDATE TColaborador SET Nombre = @Nombre ,Cargo = @Cargo,Telefono = @Telefono ,Email= @Email ,IdVehiculos = @IdVehiculos WHERE IdColaborador = @IdColaborador";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@IdColaborador", IdColaborador);
                    comando.Parameters.AddWithValue("@Nombre", Nombres);
                    comando.Parameters.AddWithValue("@Cargo", Cargo);
                    comando.Parameters.AddWithValue("@Telefono ", Telefonos);
                    comando.Parameters.AddWithValue("@Email", Emails);
                    comando.Parameters.AddWithValue("@IdVehiculos", IdVehiculos);

                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    conexion.Close();

                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se actualizó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al actualizar el registro');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnBuscaremos_Click(object sender, EventArgs e)
        {
            // Obtener el término de búsqueda ingresado por el usuario
            string terminoBusqueda = txtBuscaremos.Text.Trim();

            // Consulta SQL para buscar clientes que coincidan con el término de búsqueda
            string consulta = "SELECT * FROM TColaborador WHERE IdColaborador LIKE @Termino OR  Nombre  LIKE @Termino OR Cargo  LIKE @Termino OR Telefono LIKE @Termino OR Email LIKE @Termino OR IdVehiculos LIKE @Termino";

            // Crear y abrir la conexión a la base de datos
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    // Crear un nuevo comando SQL
                    SqlCommand comando = new SqlCommand(consulta, conexion);

                    // Agregar el parámetro para el término de búsqueda
                    comando.Parameters.AddWithValue("@Termino", "%" + terminoBusqueda + "%");

                    // Crear un adaptador de datos para ejecutar la consulta y llenar un DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    // Asignar los resultados de la búsqueda al GridView
                    gvColaborador.DataSource = tabla;
                    gvColaborador.DataBind();
                }
                catch (SqlException ex)
                {
                    // Manejar excepciones de SQL
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    // Manejar excepciones generales
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}