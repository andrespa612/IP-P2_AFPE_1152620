using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace P2_AFPE_1152620
{
    public partial class Form2 : Form
    {
        string piloto, nombre, apellido;
        string[,] map;
        public Form2(string[,] mapa)
        {
            InitializeComponent();
            piloto = "GUA-";
            map = mapa;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text != null && txtNombre.Text != "" && txtApellido.Text != null && txtApellido.Text != "")
            {
                nombre = txtNombre.Text;
                apellido = txtApellido.Text;
                piloto = piloto + apellido.Substring(apellido.Length - 1, 1).ToUpper() + "-" + (nombre.Length + apellido.Length);
                var th = new Thread(() => Application.Run(new Tablero(map, piloto)));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Ingrese un nombre y un apellido");
            }
        }
    }
}
