using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EducarWeb.Clases;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;

namespace EducarWeb
{
    public partial class PagoForm : Form
    {
        MySqlConnection conexion;
        string query1 = "SELECT * FROM pago";
        long idUsuario;

        DateTime fechaPago;
        string fechaFormateada;
        double monto;
        int nroFactura;
        string tipo;
        long cuotaId;
        long cuotaPersonaId;
        string mesBuscado;

        public PagoForm(MySqlConnection conexion, long idUsuario)
        {
            InitializeComponent();
            this.conexion = conexion;
            this.idUsuario = idUsuario;
            
        }
        private void PagoForm_Load(object sender, EventArgs e)
        {
            using(conexion)
            {
                ActualizarDataGridView();
                CargarHijosEnComboBox(idUsuario);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comprobarValores())
            {
                CargarPago();
                ActualizarDataGridView();
            }
        }
        private bool comprobarValores()
        {
            bool flag = true;
            
            DateTime fechaPago = dateTimePicker1.Value;
            fechaFormateada = fechaPago.ToString("yyyy-MM-dd HH:mm:ss");

            this.cuotaPersonaId = ObtenerAlumnoId();

            try
            {
                this.monto = Convert.ToDouble(textBox2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor ingrese el monto");
                flag = false;
            }
            try
            {
                this.nroFactura = Convert.ToInt32(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por Favor ingrese el numero de factura");
                flag = false;
            }

            this.tipo = ObtenerTipoPago();
            if (string.IsNullOrEmpty(this.tipo))
            {
                MessageBox.Show("Por Favor ingrese el tipo de pago");
                flag = false;
            }

            this.mesBuscado = comboBox1.Text;
            if (string.IsNullOrEmpty(this.mesBuscado))
            {
                MessageBox.Show("Por Favor ingrese el mes");
                flag = false;
            }
            else
            {
                this.cuotaId = ObtenerCuotaId(mesBuscado,cuotaPersonaId);
            }

            

            return flag;
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
            string query = "SELECT p.nombre, p.apellido, cuota.mes, cuota.fecha_vencimiento, cuota.monto, cuota.estado " +
               "FROM cuota " +
               "INNER JOIN persona_has_persona ON cuota.persona_id = persona_has_persona.hijo_id " +
               "INNER JOIN persona p ON persona_has_persona.hijo_id = p.id " +
               "WHERE persona_has_persona.padre_id = @idUsuario;";


            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conexion);
            adapter.SelectCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            string query2 = "SELECT pago.fecha, pago.monto, pago.nrofactura, pago.tipo, pago.estado " +
                    "FROM pago " +
                    "INNER JOIN cuota ON pago.cuota_id = cuota.id " +
                    "INNER JOIN persona_has_persona ON cuota.persona_id = persona_has_persona.hijo_id " +
                    "WHERE persona_has_persona.padre_id = @idUsuario";

            MySqlDataAdapter adapter2 = new MySqlDataAdapter(query2, conexion);
            adapter2.SelectCommand.Parameters.AddWithValue("@idUsuario", idUsuario);
            DataTable dataTable2 = new DataTable();
            adapter2.Fill(dataTable2);
            dataGridView2.DataSource = dataTable2;
        }
        private void CargarHijosEnComboBox(long idPadre)
        {
            List<string> listaNombresApellidos = new List<string>();

            using (conexion)
            {
                conexion.Open();

                string query = "SELECT CONCAT(p.nombre, ' ', p.apellido) AS NombreCompleto " +
                               "FROM persona_has_persona php " +
                               "INNER JOIN persona p ON php.hijo_id = p.id " +
                               "WHERE php.padre_id = @idPadre";

                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@idPadre", idPadre);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nombreCompleto = reader.GetString(0);
                            listaNombresApellidos.Add(nombreCompleto);
                        }
                    }
                }
            }

            comboBox2.DataSource = listaNombresApellidos;
        }
        private void CargarPago() 
        {
            using (conexion)
            {
                conexion.Open();

                string query = "INSERT INTO pago (fecha, monto, nrofactura, tipo, cuota_id, cuota_persona_id) " +
                               "VALUES (@fecha, @monto, @nrofactura, @tipo, @cuota_id, @cuota_persona_id)";

                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@fecha", fechaFormateada);
                    command.Parameters.AddWithValue("@monto", monto);
                    command.Parameters.AddWithValue("@nrofactura", nroFactura);
                    command.Parameters.AddWithValue("@tipo", tipo);
                    command.Parameters.AddWithValue("@cuota_id", cuotaId);
                    command.Parameters.AddWithValue("@cuota_persona_id", cuotaPersonaId);

                    command.ExecuteNonQuery();
                }
            }
        }
        private long ObtenerCuotaId(string mesBuscado, long cuotaPersonaId)
        {
            
            using (conexion)
            {
                conexion.Open();
                string query = "SELECT id FROM cuota WHERE mes = @mes AND persona_id = @cuotaPersonaId";
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@mes", mesBuscado);
                    command.Parameters.AddWithValue("@cuotaPersonaId", cuotaPersonaId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            long idprueba2 = reader.GetInt64("id");
                            MessageBox.Show(idprueba2.ToString());
                            return idprueba2;
                        }
                    }
                }
            }
            return 0;
        }
        private long ObtenerAlumnoId()
        {
            // Obtén el valor del comboBox2 que contiene el nombre y apellido del hijo
            string nombreApellidoHijo = comboBox2.SelectedItem.ToString();

            // Separa el nombre y el apellido
            string[] nombreApellidoArray = nombreApellidoHijo.Split(' ');
            string nombreHijo = nombreApellidoArray[0];
            string apellidoHijo = nombreApellidoArray[1];
            using (conexion)
            {
                conexion.Open();
                string query = "SELECT p.id AS id_hijo " +
                                    "FROM persona_has_persona php " +
                                    "INNER JOIN persona p ON php.hijo_id = p.id " +
                                    "WHERE php.padre_id = @id_padre " +
                                    "AND p.nombre = @nombre_hijo " +
                                    "AND p.apellido = @apellido_hijo;";

                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@id_padre", idUsuario);
                    command.Parameters.AddWithValue("@nombre_hijo", nombreHijo);
                    command.Parameters.AddWithValue("@apellido_hijo", apellidoHijo);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            long idprueba = reader.GetInt64("id_hijo");
                            MessageBox.Show(idprueba.ToString());
                            return idprueba;

                        }
                    }
                }
            }
            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datagridviewPrinter.PrintCuota(dataGridView1,"joselito");
            
        }

        
    }
}
