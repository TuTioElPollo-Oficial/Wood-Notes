using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wood_Notes
{
    public partial class frmNotasSubMenu : Form
    {
        public frmNotasSubMenu()
        {
            InitializeComponent();
            conexion.AbrirConexion();
            dtpNewDate.Format = DateTimePickerFormat.Custom;
            dtpNewDate.CustomFormat = "yyyy/MM/dd";
        }

        Conexion conexion = new Conexion();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtTitulo.ForeColor!=Color.Silver && rtxtNota.ForeColor != Color.Silver)
            {
                conexion.InsertarNotas(txtTitulo.Text, rtxtNota.Text, dtpNewDate.Text);
                txtTitulo.Text = "";
                rtxtNota.Text = "";
                dtpNewDate.Value = DateTime.Now;
            }
            else
            {
                if (txtTitulo.ForeColor == Color.Silver)
                {
                    errorTitulo.SetError(txtTitulo, "El campo no puede estar vacío");
                    errorNota.Clear();
                }
                else if(rtxtNota.ForeColor == Color.Silver)
                {
                    errorNota.SetError(rtxtNota, "El campo no puede estar vacío");
                    errorTitulo.Clear();
                }
                else
                {
                    errorTitulo.Clear();
                    errorNota.Clear();
                }
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTitulo_Enter(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "Título")
            {
                txtTitulo.Text = "";
                txtTitulo.ForeColor = Color.Black;
            }
        }

        private void txtTitulo_Leave(object sender, EventArgs e)
        {
            if (txtTitulo.Text == "")
            {
                txtTitulo.Text = "Título";
                txtTitulo.ForeColor = Color.Silver;
            }
        }

        private void rtxtNota_Enter(object sender, EventArgs e)
        {
            if (rtxtNota.Text == "Escribe una nota")
            {
                rtxtNota.Text = "";
                rtxtNota.ForeColor = Color.Black;
            }
        }

        private void rtxtNota_Leave(object sender, EventArgs e)
        {
            if (rtxtNota.Text == "")
            {
                rtxtNota.Text = "Escribe una nota";
                rtxtNota.ForeColor = Color.Silver;
            }
        }
    }
}
