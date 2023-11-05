using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EducarWeb.Clases;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1;

namespace EducarWeb
{
    public partial class PagoFromAdmin : Form
    {
        private MySqlConnection conexion;
        private int pagoId;
        private double pagoMonto;
        private int pagoCuotaId;
        private double cuotaMonto;
        private double pagoEstado;
        private double montoFinal;
        private string estadoFinal;

        private string nombre;

        public PagoFromAdmin(MySqlConnection conexion)
        {
            this.conexion = conexion;
            InitializeComponent();
            ActualizarDataGrid();
        }
        private void ActualizarDataGrid()
        {
            string query1 = "SELECT * FROM pago";
            using (conexion)
            {
                
                using (MySqlCommand command = new MySqlCommand(query1, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna los datos al DataGridView
                        dataGridView2.DataSource = dataTable;
                    }
                }
            }
            string query2 = "SELECT * FROM cuota";
            using (conexion)
            {
                
                using (MySqlCommand command = new MySqlCommand(query2, conexion))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Asigna los datos al DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"ID: {pagoId}, Monto: {pagoMonto}, Cuota_ID: {pagoCuotaId}");
            ObtenerMontoCuotaPorId(pagoCuotaId);

            if (controlarEstadoPago() == "Pendiente")
            {
                modificarEstadoCuota();

                modificarMontoCuota();
                nombre = ObtenerNombrePadre();

                modificarEstadoPago();

                ActualizarDataGrid();

                FacturaA factura = new FacturaA();
                factura.GenerarFactura(7000, nombre);
            }
            else
            {
                MessageBox.Show("Este pago ya ha sido confirmado previamente.");
            } 
        }

        private void modificarEstadoCuota()
        {
            montoFinal = cuotaMonto - pagoMonto;
            if (montoFinal <= 0)
            {
                estadoFinal = "Saldada";
                MessageBox.Show("La cuota esta saldada");
                
            }
            else
            {
                estadoFinal = "Pendiente";
                MessageBox.Show("La cuota aun esta pendiente");
            }
            string query = "UPDATE cuota SET estado = @estadoFinal WHERE id = @pagoCuotaId";
            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@estadoFinal", estadoFinal);
                    command.Parameters.AddWithValue("@pagoCuotaId", pagoCuotaId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Estado de cuota modificado correctamente" + montoFinal);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }

        }

        private void modificarMontoCuota()
        {
            string query = "UPDATE cuota SET monto = @montoFinal WHERE id = @pagoCuotaId";
            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@montoFinal", montoFinal);
                    command.Parameters.AddWithValue("@pagoCuotaId", pagoCuotaId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("El monto pendiente de la cuota: "+ montoFinal);
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
            }
            ActualizarDataGrid();
        }

        private double ObtenerMontoCuotaPorId(int cuotaId)
        {
            string query = "SELECT monto FROM cuota WHERE id = @cuotaId";
            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@cuotaId", cuotaId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cuotaMonto = Convert.ToDouble(reader["monto"]);
                        }
                    }
                }
            }
            return 0;
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (dataGridView2.Rows[e.RowIndex].Cells["id"].Value != null)
                {
                    pagoId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id"].Value);
                }

                if (dataGridView2.Rows[e.RowIndex].Cells["monto"].Value != null)
                {
                    pagoMonto = Convert.ToDouble(dataGridView2.Rows[e.RowIndex].Cells["monto"].Value);
                }

                if (dataGridView2.Rows[e.RowIndex].Cells["cuota_id"].Value != null)
                {
                    pagoCuotaId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["cuota_id"].Value);
                }
            }
        }
        private string ObtenerNombrePadre()
        {
            using (conexion)
            {
                conexion.Open();

                string query = "SELECT p.nombre AS nombre_padre, p.apellido AS apellido_padre " +
                    "FROM cuota c " +
                    "JOIN persona_has_persona php ON c.persona_id = php.hijo_id " +
                    "JOIN persona p ON php.padre_id = p.id " +
                    "WHERE c.id = @pagoCuotaId;";

                using (MySqlCommand commando = new MySqlCommand(query, conexion))
                {
                    commando.Parameters.AddWithValue("@pagoCuotaId", pagoCuotaId);

                    using(MySqlDataReader reader = commando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string nombrePadre = reader["nombre_padre"].ToString(); // Usar el alias
                            string apellidoPadre = reader["apellido_padre"].ToString(); // Usar el alias
                            return nombrePadre +" "+ apellidoPadre;
                        }
                    }
                }
            }
            return string.Empty;
        }
        
        private void modificarEstadoPago()
        {
            string query = "UPDATE pago SET estado = 'Confirmado' WHERE id = @pagoId";
            using (conexion)
            {
                conexion.Open();

                using(MySqlCommand command = new MySqlCommand( query, conexion))
                {
                    command.Parameters.AddWithValue("@pagoId", pagoId);
                    command.ExecuteNonQuery();
                }

            }
        }

        private string controlarEstadoPago()
        {
            string query = "SELECT estado FROM pago WHERE id = @pagoId";
            using (conexion)
            {
                conexion.Open();
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    command.Parameters.AddWithValue("@pagoId", pagoId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Asegúrate de llamar a Read() para avanzar al primer resultado.
                        {
                            string estado = reader.GetString(0);
                            return estado;
                        }
                        return string.Empty;
                    }
                }
            }
        }
    }
}
