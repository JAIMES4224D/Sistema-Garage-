using ClosedXML.Excel;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaGarage
{
    public partial class btnHistorial : Form
    {
        public btnHistorial()
        {
            InitializeComponent();
            CargarAutos();
        }

        // Este evento se crea si le diste doble clic al Label, lo dejamos vacío para que no de error.
        private void label1_Click(object sender, EventArgs e)
        {
        }

        // Este es el evento principal del botón "Registrar Entrada"
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPlaca.Text))
            {
                MessageBox.Show("Por favor, escribe una placa antes de registrar.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // El 'return' detiene todo, no deja que el código siga.
            }
            // 1. CONFIGURACIÓN: Cadena de conexión
            // Esto le dice al programa dónde buscar la base de datos "GarageDB"
            string cadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GarageDB;Integrated Security=True";

            // 2. ORDEN: La consulta SQL
            // @Placa y @Fecha son "huecos" que rellenaremos abajo para evitar errores de seguridad
            string query = "INSERT INTO Tickets (Placa, FechaEntrada) VALUES (@Placa, @Fecha)";

            // 3. ACCIÓN: Ejecutar todo
            // El 'using' asegura que la conexión se cierre sola al terminar (libera memoria)
            using SqlConnection conexion = new SqlConnection(cadenaConexion);
            SqlCommand comando = new SqlCommand(query, conexion);

            // Rellenamos los huecos con la información real de la pantalla
            // IMPORTANTE: Asegúrate de que tu caja de texto se llame 'txtPlaca'
            // Si no le cambiaste el nombre, cambia 'txtPlaca.Text' por 'textBox1.Text'
            comando.Parameters.AddWithValue("@Placa", txtPlaca.Text);
            comando.Parameters.AddWithValue("@Fecha", DateTime.Now);

            try
            {
                conexion.Open(); // Abrimos la puerta de la base de datos
                comando.ExecuteNonQuery(); // Ejecutamos la orden de guardado

                // Mensaje de éxito
                MessageBox.Show("¡Ticket Guardado en Base de Datos correctamente!");
                ticketImpresora.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("TicketPersonalizado", 315, 600);
                // 2. Quitamos los márgenes gigantes de Word
                ticketImpresora.DefaultPageSettings.Margins = new System.Drawing.Printing.Margins(10, 10, 10, 10);
                // -------------------------------------------
                // Mostrar el ticket en pantalla (esto ya lo tenías)
                vistaPrevia.ShowDialog();
                // Opcional: Limpiar la caja de texto para el siguiente auto
                txtPlaca.Clear();
                CargarAutos();
            }
            catch (Exception error)
            {
                // Si algo falla, nos dirá exactamente qué pasó
                MessageBox.Show("Hubo un error al guardar: " + error.Message);
            }
        }
        // Función para refrescar la tabla
        private void CargarAutos()
        {
            string cadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GarageDB;Integrated Security=True";

            // CONSULTA: "Selecciona ID, Placa y Hora de los tickets que NO tengan fecha de salida"
            string query = "SELECT Id, Placa, FechaEntrada FROM Tickets WHERE FechaSalida IS NULL ORDER BY FechaEntrada DESC";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                // El Adaptador es como un 'camión' que trae los datos de la base a tu app
                SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                System.Data.DataTable tabla = new System.Data.DataTable();

                adaptador.Fill(tabla); // Llenamos la tabla virtual
                dgvVehiculos.DataSource = tabla; // Se la mostramos al usuario
                if (dgvVehiculos.Columns.Contains("CostoTotal"))
                {
                    dgvVehiculos.Columns["CostoTotal"].DefaultCellStyle.Format = "C2"; // C2 significa Currency (Moneda) con 2 decimales
                }
                if (dgvVehiculos.Columns.Contains("FechaEntrada"))
                {
                    dgvVehiculos.Columns["FechaEntrada"].DefaultCellStyle.Format = "g"; // g es formato general (fecha corta + hora corta)
                }
                if (dgvVehiculos.Columns.Contains("FechaSalida"))
                {
                    dgvVehiculos.Columns["FechaSalida"].DefaultCellStyle.Format = "g";
                }

                // 3. (Opcional) Cambiar los títulos de las columnas a español bonito
                if (dgvVehiculos.Columns.Contains("FechaEntrada")) dgvVehiculos.Columns["FechaEntrada"].HeaderText = "Hora Entrada";
                if (dgvVehiculos.Columns.Contains("FechaSalida")) dgvVehiculos.Columns["FechaSalida"].HeaderText = "Hora Salida";
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            string placaBuscada = txtPlacaSalida.Text;
            if (string.IsNullOrWhiteSpace(txtPlacaSalida.Text))
            {
                MessageBox.Show("Por favor, escribe una placa antes de marcar la salida.", "Falta información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // El 'return' detiene todo, no deja que el código siga.
            }
            decimal tarifaPorHora = 5.00m; // <--- AQUÍ CAMBIAS EL PRECIO
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GarageDB;Integrated Security=True";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();

                // 2. BUSCAR: ¿A qué hora entró este auto?
                string queryBuscar = "SELECT Id, FechaEntrada FROM Tickets WHERE Placa = @Placa AND FechaSalida IS NULL";

                SqlCommand cmdBuscar = new SqlCommand(queryBuscar, conexion);
                cmdBuscar.Parameters.AddWithValue("@Placa", placaBuscada);

                // Ejecutamos la búsqueda (Reader es para leer datos)
                using (SqlDataReader lector = cmdBuscar.ExecuteReader())
                {
                    if (lector.Read()) // Si encontró el auto...
                    {
                        // Obtenemos los datos de la base de datos
                        int idTicket = lector.GetInt32(0); // El ID
                        DateTime fechaEntrada = lector.GetDateTime(1); // La hora de entrada

                        // Cerramos el lector para poder hacer otra operación después
                        lector.Close();

                        // 3. MATEMÁTICAS: Calcular tiempo y dinero
                        DateTime fechaSalida = DateTime.Now;
                        TimeSpan tiempo = fechaSalida - fechaEntrada;

                        // Cobramos por horas completas (o fracción como 1 hora)
                        // Math.Ceiling redondea hacia arriba (ej: 1.1 horas se cobran como 2)
                        decimal horasACobrar = (decimal)Math.Ceiling(tiempo.TotalHours);
                        if (horasACobrar == 0) horasACobrar = 1; // Mínimo 1 hora

                        decimal totalPagar = horasACobrar * tarifaPorHora;

                        // 4. CONFIRMACIÓN: Mostrar el cobro
                        DialogResult respuesta = MessageBox.Show(
                            $"Auto: {placaBuscada}\n" +
                            $"Tiempo: {tiempo.Hours}h {tiempo.Minutes}m\n" +
                            $"Total a Pagar: ${totalPagar}\n\n" +
                            "¿Confirmar salida y abrir barrera?",
                            "Confirmar Cobro",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (respuesta == DialogResult.Yes)
                        {
                            // 5. GUARDAR SALIDA: Actualizamos el ticket
                            string queryActualizar = "UPDATE Tickets SET FechaSalida = @Salida, CostoTotal = @Costo WHERE Id = @Id";
                            SqlCommand cmdUpdate = new SqlCommand(queryActualizar, conexion);
                            cmdUpdate.Parameters.AddWithValue("@Salida", fechaSalida);
                            cmdUpdate.Parameters.AddWithValue("@Costo", totalPagar);
                            cmdUpdate.Parameters.AddWithValue("@Id", idTicket);

                            cmdUpdate.ExecuteNonQuery(); // ¡Guardado final!

                            MessageBox.Show("¡Cobro registrado y salida exitosa!");

                            // Limpiamos y recargamos la tabla
                            txtPlacaSalida.Clear();
                            CargarAutos();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró ningún vehículo con esa placa dentro del estacionamiento.");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cadenaConexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GarageDB;Integrated Security=True";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                // 1. CONSULTA NUEVA:
                // "Traeme los tickets donde la Fecha de Salida (solo la parte del día) sea IGUAL a la fecha que elegí"
                // CAST(FechaSalida AS DATE) sirve para ignorar la hora y comparar solo el día.
                string query = "SELECT Id, Placa, FechaEntrada, FechaSalida, CostoTotal " +
                               "FROM Tickets " +
                               "WHERE CAST(FechaSalida AS DATE) = @FechaSeleccionada";

                SqlCommand comando = new SqlCommand(query, conexion);
                // Le pasamos la fecha del calendario (dtpFecha.Value.Date toma solo el día, sin hora)
                comando.Parameters.AddWithValue("@FechaSeleccionada", dtpFecha.Value.Date);

                // 2. LLENAR TABLA
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                System.Data.DataTable tabla = new System.Data.DataTable();
                adaptador.Fill(tabla);
                dgvVehiculos.DataSource = tabla;

                // 3. SUMAR GANANCIAS (Igual que antes)
                decimal sumaTotal = 0;
                foreach (System.Data.DataRow fila in tabla.Rows)
                {
                    if (fila["CostoTotal"] != DBNull.Value)
                    {
                        sumaTotal += Convert.ToDecimal(fila["CostoTotal"]);
                    }
                }

                // Mostramos el resultado con la fecha bonita
                lblGanancias.Text = $"Total del día {dtpFecha.Value.ToShortDateString()}: ${sumaTotal.ToString("0.00")}";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarAutos(); // Llamamos a la función que ya tenías hecha antes
            lblGanancias.Text = "Vista: Autos en Curso";
        }

        private void ticketImpresora_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font fuenteTitulo = new Font("Arial", 10, FontStyle.Bold);
            Font fuenteNormal = new Font("Consolas", 8, FontStyle.Regular);
            Brush pincel = Brushes.Black;

            // Coordenadas (X, Y)
            // Dibuja el texto en el papel virtual
            e.Graphics.DrawString("ESTACIONAMIENTO EL GARAGE", fuenteTitulo, pincel, new Point(10, 10));
            e.Graphics.DrawString("-----------------------------------", fuenteNormal, pincel, new Point(10, 40));

            e.Graphics.DrawString("Ticket de Entrada", fuenteNormal, pincel, new Point(10, 60));
            e.Graphics.DrawString("Placa: " + txtPlaca.Text.ToUpper(), fuenteTitulo, pincel, new Point(10, 90));
            e.Graphics.DrawString("Fecha: " + DateTime.Now.ToShortDateString(), fuenteNormal, pincel, new Point(10, 130));
            e.Graphics.DrawString("Hora:  " + DateTime.Now.ToShortTimeString(), fuenteNormal, pincel, new Point(10, 150));

            e.Graphics.DrawString("-----------------------------------", fuenteNormal, pincel, new Point(10, 180));
            e.Graphics.DrawString("¡Conserve este ticket!", new Font("Arial", 8, FontStyle.Italic), pincel, new Point(10, 200));
        }

        private void vistaPrevia_Load(object sender, EventArgs e)
        {

        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya datos para exportar
            if (dgvVehiculos.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Preguntar dónde guardar
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Excel Files|*.xlsx"; // Ahora sí es un Excel real (.xlsx)
            guardar.FileName = "Reporte_Garage_" + DateTime.Now.ToString("dd-MM-yyyy");

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // OBTENEMOS LOS DATOS DIRECTO DE LA GRILLA
                    // (Convertimos lo que ves en pantalla a una tabla de datos)
                    System.Data.DataTable dt = (System.Data.DataTable)dgvVehiculos.DataSource;

                    using (XLWorkbook libro = new XLWorkbook())
                    {
                        // Agregamos una hoja
                        var hoja = libro.Worksheets.Add("Reporte");

                        // --- AQUÍ OCURRE LA MAGIA ---
                        // 1. Insertamos los datos empezando en la celda A1
                        var tablaExcel = hoja.Cell(1, 1).InsertTable(dt);

                        // 2. Le damos estilo visual (Tema azulito profesional)
                        tablaExcel.Theme = XLTableTheme.TableStyleMedium9;

                        // 3. Ajustamos el ancho de las columnas automáticamente para que se lea todo
                        hoja.Columns().AdjustToContents();

                        // 4. Guardamos el archivo
                        libro.SaveAs(guardar.FileName);
                    }

                    MessageBox.Show("¡Excel exportado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception error)
                {
                    MessageBox.Show("Ocurrió un error al exportar: " + error.Message);
                }
            }
        }
    }
}