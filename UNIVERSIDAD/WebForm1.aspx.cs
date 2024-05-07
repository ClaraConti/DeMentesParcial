using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;//llamar a la cadena de conexion
using System.Data;//llamar a los bufer de memoria para la BD
using System.Data.SqlClient;//llamar al driver de Sql Sever
namespace UNIVERSIDAD
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //llamar a la cadena de conexion 
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        private void CargarDatos()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "select * from TEstudiante";//Condultar SQL
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);//llevar la consulta BD
                DataTable tabla = new DataTable();//DECLARACION DE buffer de memoria tabla
                adapter.Fill(tabla);//tabla tiene contenido de la BD
                //lleVAR A LA TABLA grilla
                this.gvEstudiante.DataSource = tabla;
                this.gvEstudiante.DataBind();
            }
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TAsignatura";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                gvAsignatura.DataSource = tabla;
                gvAsignatura.DataBind();
            }
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM TMatricula";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataTable tabla = new DataTable();
                adapter.Fill(tabla);
                gvMatricula.DataSource = tabla;
                gvMatricula.DataBind();
            }

        }
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //CARGAR LOS DATOS SOLO LA PRIMERA VEZ 
            if (!Page.IsPostBack)
                CargarDatos();
   
        }
        

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string codEstudiante = txtCodEstudiante.Text.Trim();
                    string apellidos = txtApellidos.Text.Trim();
                    string nombres = txtNombres.Text.Trim();
                    string consulta = " insert into TEstudiante values (@CodEstudiante,@Apellidos,@Nombres)";
                    //utilizar un SQLcomand para llevar la consulta a la BD 
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    //llevar los parametros a la BD
                    comando.Parameters.AddWithValue("@CodEstudiante", codEstudiante);
                    comando.Parameters.AddWithValue("@Apellidos", apellidos);
                    comando.Parameters.AddWithValue("@Nombres", nombres);
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
                    string codEstudiante = txtCodEstudiante.Text.Trim();
                    string consulta = "DELETE FROM TEstudiante WHERE CodEstudiante = @CodEstudiante";

                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@CodEstudiante", codEstudiante);

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
            if (!string.IsNullOrEmpty(txtCodEstudiante.Text))
            {
                string codEstudiante = txtCodEstudiante.Text.Trim();
                string apellidos = txtApellidos.Text.Trim();
                string nombre = txtNombres.Text.Trim();

                string consulta = "UPDATE TEstudiante SET Apellidos = @Apellidos, Nombres = @Nombres WHERE CodEstudiante = @CodEstudiante";

                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@Apellidos", apellidos);
                        comando.Parameters.AddWithValue("@Nombres", nombre);
                        comando.Parameters.AddWithValue("@CodEstudiante", codEstudiante);

                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        conexion.Close();

                        if (filasAfectadas > 0)
                        {
                            CargarDatos();
                            Response.Write("<script>alert('El estudiante ha sido actualizado correctamente');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('No se encontró ningún estudiante con ese código');</script>");
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
            else
            {
                Response.Write("<script>alert('Por favor, seleccione un estudiante de la lista para actualizar');</script>");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Obtener el término de búsqueda ingresado por el usuario
            string terminoBusqueda = txtBuscar.Text.Trim();

            // Consulta SQL para buscar estudiantes que coincidan con el término de búsqueda
            string consulta = "SELECT * FROM TEstudiante WHERE CodEstudiante LIKE @Termino OR Apellidos LIKE @Termino OR Nombres LIKE @Termino";

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
                    gvEstudiante.DataSource = tabla;
                    gvEstudiante.DataBind();
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
        //Asignatura
        protected void btnAgrega_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string codAsignatura = txtCodAsignatura.Text.Trim();
                    string nombres = txtNombre.Text.Trim();
                    string creditos = txtCreditos.Text.Trim();
                    string consulta = "INSERT INTO TAsignatura VALUES (@CodAsignatura, @Nombre, @Creditos)";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@CodAsignatura", codAsignatura);
                    comando.Parameters.AddWithValue("@Nombre", nombres);
                    comando.Parameters.AddWithValue("@Creditos", creditos);
                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
                    if (i == 1)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se agregó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Problemas al agregar datos a la tabla');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnElimino_Click(object sender, EventArgs e)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    string codAsignatura = txtCodAsignatura.Text.Trim();
                    string consulta = "DELETE FROM TAsignatura WHERE CodAsignatura = @CodAsignatura";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@CodAsignatura", codAsignatura);
                    conexion.Open();
                    int i = comando.ExecuteNonQuery();
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
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void btnActualizo_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodAsignatura.Text))
            {
                string codAsignatura = txtCodAsignatura.Text.Trim();
                string nombres = txtNombre.Text.Trim();
                string creditos = txtCreditos.Text.Trim();

                string consulta = "UPDATE TAsignatura SET Creditos = @Creditos, Nombre = @Nombre WHERE CodAsignatura = @CodAsignatura";

                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@CodAsignatura", codAsignatura);
                        comando.Parameters.AddWithValue("@Nombre", nombres);
                        comando.Parameters.AddWithValue("@Creditos", creditos);

                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        conexion.Close();

                        if (filasAfectadas > 0)
                        {
                            CargarDatos();
                            Response.Write("<script>alert('El estudiante ha sido actualizado correctamente');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('No se encontró ningún estudiante con ese código');</script>");
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
            else
            {
                Response.Write("<script>alert('Por favor, seleccione un estudiante de la lista para actualizar');</script>");
            }
        }

        protected void btnBusco_Click(object sender, EventArgs e)
        {
            // Obtener el término de búsqueda ingresado por el usuario
            string terminoBusqueda = txtBusco.Text.Trim();

            // Consulta SQL para buscar estudiantes que coincidan con el término de búsqueda
            string consulta = "SELECT * FROM TAsignatura WHERE CodAsignatura LIKE @Termino OR Nombre LIKE @Termino OR Creditos LIKE @Termino";

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
                    gvAsignatura.DataSource = tabla;
                    gvAsignatura.DataBind();
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
        //Matricula
        protected void btnAgregamos_Click(object sender, EventArgs e)
        {
            // Retrieve values from input controls
            string codEstudiantes = txtCodEstudiantes.Text; // Assuming txtCodEstudiante is the ID of the textbox for CodEstudiante
            string codAsignaturas = txtCodAsignaturas.Text; // Assuming txtCodAsignatura is the ID of the textbox for CodAsignatura
            string periodo = txtPeriodo.Text; // Assuming txtPeriodo is the ID of the textbox for Periodo
            int promedio = Convert.ToInt32(txtPromedio.Text); // Assuming txtPromedio is the ID of the textbox for Promedio

            // Construct the SQL INSERT statement
            string consulta = "INSERT INTO TMatricula (CodEstudiantes, CodAsignaturas, Periodo, Promedio) VALUES (@CodEstudiantes, @CodAsignaturas, @Periodo, @Promedio)";

            // Create and open the connection
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    // Create the command and parameterize it to prevent SQL injection
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@CodEstudiantes", codEstudiantes);
                    comando.Parameters.AddWithValue("@CodAsignaturas", codAsignaturas);
                    comando.Parameters.AddWithValue("@Periodo", periodo);
                    comando.Parameters.AddWithValue("@Promedio", promedio);

                    // Open the connection and execute the command
                    conexion.Open();
                    int i = comando.ExecuteNonQuery();

                    if (i == 1)
                    {
                        // If one row is affected, it means the insertion was successful
                        // Reload the data into the GridView after insertion
                        CargarDatos();
                        Response.Write("<script>alert('Se agregó correctamente');</script>");
                    }
                    else
                    {
                        // If no rows are affected, something went wrong
                        Response.Write("<script>alert('Problemas al agregar datos a la tabla');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    // Handle SQL exceptions
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                finally
                {
                    // Close the connection in the finally block to ensure it's always closed
                    conexion.Close();
                }
            }
        }




        protected void btnBuscamos_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = txtBusca.Text.Trim();

            string consulta = "SELECT * FROM TMatricula WHERE CodEstudiantes LIKE @Termino OR CodAsignaturas LIKE @Termino OR Periodo LIKE @Termino OR Promedio LIKE @Termino ";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@Termino", "%" + terminoBusqueda + "%");

                    conexion.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(comando);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);

                    gvMatricula.DataSource = tabla;
                    gvMatricula.DataBind();
                }
                catch (SqlException ex)
                {
                    Response.Write(ex.Message);
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
                finally
                {
                    conexion.Close();
                }
            }
        }

        protected void btnEliminamos_Click(object sender, EventArgs e)
        {
            string codEstudiantes = txtCodEstudiantes.Text.Trim();

            string consulta = "DELETE FROM TMatricula WHERE CodEstudiantes = @CodEstudiantes";

            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                try
                {
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@CodEstudiantes", codEstudiantes);

                    conexion.Open();
                    int rowsAffected = comando.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        CargarDatos();
                        Response.Write("<script>alert('Se eliminó correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('No se encontró el registro');</script>");
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
                finally
                {
                    conexion.Close();
                }
            }
        }

        protected void btnActualizamos_Click(object sender, EventArgs e)
        {
            string codEstudiantes = txtCodEstudiantes.Text; // Assuming txtCodEstudiante is the ID of the textbox for CodEstudiante
            string codAsignaturas = txtCodAsignaturas.Text; // Assuming txtCodAsignatura is the ID of the textbox for CodAsignatura
            string periodo = txtPeriodo.Text; // Assuming txtPeriodo is the ID of the textbox for Periodo
            int promedio = Convert.ToInt32(txtPromedio.Text); // Assuming txtPromedio is the ID of the textbox for Promedio

            if (int.TryParse(txtPromedio.Text.Trim(), out promedio))
            {
                string consulta = "UPDATE TMatricula SET CodAsignaturas = @CodAsignaturas, Periodo = @Periodo, Promedio = @Promedio  WHERE CodEstudiantes = @CodEstudiantes";

                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    try
                    {
                        SqlCommand comando = new SqlCommand(consulta, conexion);
                        comando.Parameters.AddWithValue("@CodEstudiantes", codEstudiantes);
                        comando.Parameters.AddWithValue("@CodAsignaturas", codAsignaturas);
                        comando.Parameters.AddWithValue("@Periodo", periodo);
                        comando.Parameters.AddWithValue("@Promedio", promedio);

                        conexion.Open();
                        int rowsAffected = comando.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            CargarDatos();
                            Response.Write("<script>alert('Se actualizó correctamente');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('No se encontró el registro');</script>");
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
                    finally
                    {
                        conexion.Close();
                    }
                }
            }
            else
            {
                Response.Write("<script>alert('El valor de promedio no es válido');</script>");
            }
        }

    }
}
