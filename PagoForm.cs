using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EducarWeb
{
    public partial class PagoForm : Form
    {
        MySqlConnection conexion;
        string query1 = "SELECT * FROM pago";
        
        public PagoForm(MySqlConnection conexion)
        {
            InitializeComponent();
            this.conexion = conexion;
            string query = "SELECT     p.id AS PagoID,    p.fecha AS FechaPago,   p.monto AS MontoPago,    " +
                    "padre.nombre AS NombrePadre,    padre.apellido AS ApellidoPadre,    hijo.nombre AS NombreAlumno,    " +
                    "hijo.apellido AS ApellidoAlumno FROM pago AS p INNER JOIN pago_has_persona AS php ON p.id = php.pago_id " +
                    "LEFT JOIN persona AS padre ON php.padre_id = padre.id LEFT JOIN persona AS hijo ON php.hijo_id = hijo.id; ";
        }

        private void PagoForm_Load(object sender, EventArgs e)
        {
            using(conexion)
            {
                ActualizarDataGridView();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numeroFactura = textBox1.Text;
            double monto;
            string tipo = "";
            
            if (double.TryParse(textBox2.Text, out monto))
            {
                // El valor en el cuadro de texto se ha convertido a un número con éxito.
                // Puedes usar la variable 'monto' en tu código.
            }
            else
            {
                // Manejo de error si el contenido del cuadro de texto no es un número válido.
                MessageBox.Show("El monto ingresado no es válido.");
            }
            Pago(monto, numeroFactura);

        }
        public void Pago(double monto, string numeroFactura)
        {
            using (conexion)
            {
                conexion.Open();
                string fechaActual = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Insertar el pago en la tabla 'pago' y relacionarlo con el padre e hijo
                if (InsertarPagoYRelacion(fechaActual, monto, numeroFactura))
                {
                    // Actualizar el DataGridView u otra lógica necesaria
                    ActualizarDataGridView();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el pago o la relación en la base de datos.");
                }
            }
        }

        private bool InsertarPagoYRelacion(string fecha, double monto, string numeroFactura)
        {
            // Obtener los valores de los ID del padre y el hijo
            if (long.TryParse(textBox3.Text, out long padreId) && long.TryParse(textBox4.Text, out long hijoId))
            {
                // Verificar que el ID del hijo sea el ID del hijo/alumno del padre
                if (VerificarRelacionPadreHijo(padreId, hijoId))
                {
                    // Insertar el pago en la tabla 'pago'
                    long pagoId = InsertarPago(fecha, monto, numeroFactura);

                    if (pagoId > 0)
                    {
                        // Insertar la relación en la tabla 'pago_has_persona'
                        return InsertarPagoHasPersona(pagoId, padreId, hijoId);
                    }
                }
            }
            return false;
        }

        private bool VerificarRelacionPadreHijo(long padreId, long hijoId)
        {
            // Consulta SQL para verificar la relación entre padre e hijo
            string consultaRelacion = "SELECT COUNT(*) FROM persona_has_persona WHERE padre_id = @padreId AND hijo_id = @hijoId";

            using (MySqlCommand cmd = new MySqlCommand(consultaRelacion, conexion))
            {
                cmd.Parameters.AddWithValue("@padreId", padreId);
                cmd.Parameters.AddWithValue("@hijoId", hijoId);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                // La relación debe existir para que la inserción sea válida
                return count > 0;
            }
        }
        private long InsertarPago(string fecha, double monto, string numeroFactura)
        {
            string insertPagoQuery = "INSERT INTO pago (fecha, monto, nrofactura, tipo) VALUES (@fecha, @monto, @nrofactura, @tipo)";

            using (MySqlCommand cmd = new MySqlCommand(insertPagoQuery, conexion))
            {
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@monto", monto);
                cmd.Parameters.AddWithValue("@nrofactura", numeroFactura);

                string tipo = ObtenerTipoPago();
                cmd.Parameters.AddWithValue("@tipo", tipo);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return cmd.LastInsertedId;
                }

                return 0;
            }
        }

        private bool InsertarPagoHasPersona(long pagoId, long padreId, long hijoId)
        {
            string insertPagoHasPersonaQuery = "INSERT INTO pago_has_persona (pago_id, padre_id, hijo_id) VALUES (@pago_id, @padre_id, @hijo_id)";

            using (MySqlCommand cmdPagoHasPersona = new MySqlCommand(insertPagoHasPersonaQuery, conexion))
            {
                cmdPagoHasPersona.Parameters.AddWithValue("@pago_id", pagoId);
                cmdPagoHasPersona.Parameters.AddWithValue("@padre_id", padreId);
                cmdPagoHasPersona.Parameters.AddWithValue("@hijo_id", hijoId);

                int rowsAffectedPagoHasPersona = cmdPagoHasPersona.ExecuteNonQuery();

                return rowsAffectedPagoHasPersona > 0;
            }
        }

        private string ObtenerTipoPago()
        {
            if (checkBox1.Checked)
                return "Debito";
            if (checkBox2.Checked)
                return "Credito";
            if (checkBox3.Checked)
                return "Efectivo";
            if (checkBox4.Checked)
                return "Electronico";

            return string.Empty;
        }

        private void ActualizarDataGridView()
        {
            string query = "SELECT p.id AS PagoID, p.fecha AS Fecha, p.monto AS Monto, p.nrofactura AS NumeroFactura, " +
                  "p.tipo AS Tipo, perPadre.nombre AS NombrePadre, perHijo.nombre AS NombreHijo " +
                  "FROM pago p " +
                  "INNER JOIN pago_has_persona php ON p.id = php.pago_id " +
                  "INNER JOIN persona perPadre ON php.padre_id = perPadre.id " +
                  "INNER JOIN persona perHijo ON php.hijo_id = perHijo.id";

            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
