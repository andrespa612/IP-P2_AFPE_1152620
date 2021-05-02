using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P2_AFPE_1152620
{
    public partial class Tablero : Form
    {
        Operaciones o;
        Image[,] tab;
        public Tablero(string[,] mapa, string nombre)
        {
            InitializeComponent();
            
            //Inicialización del mapa y creación del datagrid
            o = new Operaciones();
            tab = o.generarMapa(mapa, nombre);

            //Valida que el mapa sea valido, si lo es lo mandara al datagrid
            if(tab != null)
            {
                for (int i = 0; i < 20; i++)
                {
                    dgMapa.Rows.Add();
                    for (int j = 0; j < 20; j++)
                    {
                        dgMapa.Rows[i].Cells[j].Value = tab[i, j];
                    }
                }
            }
            else
            {
                Application.Restart();
            }
            //Inicializa los label
            lblCasillas.Text = o.casillas.ToString();
            lblMov.Text = o.movimientos.ToString();
            lblPuntos.Text = o.puntos.ToString();
            lblNombre.Text = nombre;
        }

        public void actualizarTablero(Image[,] map)
        {
            //Valida si el mapa no es nulo
            if(map != null)
            {
                //Actualiza el tablero
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 20; j++)
                    {
                        if(dgMapa.Rows[i].Cells[j].Value != map[i, j])
                        {
                            dgMapa.Rows[i].Cells[j].Value = map[i, j];
                        }
                    }
                }
            }
            else
            {
                if(o.gano)
                {
                    DialogResult th = MessageBox.Show("¡Has llegado a la tierra! \n" + "Puntos: " + o.puntos + "\n Movimientos: " + o.movimientos + "\n Casillas" + o.casillas + "\n¿Desea iniciar otro nuevo nivel?", "Mision Cumplida", MessageBoxButtons.YesNo);
                    if (th == DialogResult.Yes)
                    {
                        Application.Restart();
                    }
                    else if(th == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }
                else if(o.perdio)
                {
                    DialogResult th = MessageBox.Show("¡Te perdiste en el espacio!", "Mision Fallida", MessageBoxButtons.RetryCancel);
                    if (th == DialogResult.Retry)
                    {
                        reiniciar();
                    }
                    else if(th == DialogResult.Cancel)
                    {
                        Application.Restart();
                    }
                }
            }
        }

        private void dgMapa_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Down:
                    //Realiza el movimiento
                    actualizarTablero(o.bajar());

                    //Actualiza los labels
                    lblCasillas.Text = o.casillas.ToString();
                    lblMov.Text = o.movimientos.ToString();
                    lblPuntos.Text = o.puntos.ToString();
                    break;
                case Keys.Up:
                    //Realiza el movimiento
                    actualizarTablero(o.subir());

                    //Actualiza los labels
                    lblCasillas.Text = o.casillas.ToString();
                    lblMov.Text = o.movimientos.ToString();
                    lblPuntos.Text = o.puntos.ToString();
                    break;
                case Keys.Left:
                    //Realiza el movimiento
                    actualizarTablero(o.izquierda());

                    //Actualiza los labels
                    lblCasillas.Text = o.casillas.ToString();
                    lblMov.Text = o.movimientos.ToString();
                    lblPuntos.Text = o.puntos.ToString();
                    break;
                case Keys.Right:
                    //Realiza el movimiento
                    actualizarTablero(o.derecha());

                    //Actualiza los labels
                    lblCasillas.Text = o.casillas.ToString();
                    lblMov.Text = o.movimientos.ToString();
                    lblPuntos.Text = o.puntos.ToString();
                    break;
            }
        }

        private void dgMapa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void reiniciar()
        {

            //Reinicia el tablero
            actualizarTablero(o.reiniciar());

            //Reinicia los labels
            o.casillas = 0;
            o.movimientos = 0;
            o.puntos = 0;
            lblMov.Text = "0";
            lblCasillas.Text = "0";
            lblPuntos.Text = "0";
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            reiniciar();
           
        }

        





    }
}
