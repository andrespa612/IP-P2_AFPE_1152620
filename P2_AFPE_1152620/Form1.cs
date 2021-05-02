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
using System.IO;

namespace P2_AFPE_1152620
{
    public partial class Form1 : Form
    {
        //Declaración de string
        string mapa, celda;
        //Declaración de matrices
        string[,] matrizLetras = new string[20, 20];
        //Declaración de arreglos
        string[] lineasMapa;
        OpenFileDialog openDialog = new OpenFileDialog();
        //Declaración de enteros
        int cantTierra = 0;
        int cantGemaR = 0;
        int cantGemaA = 0;
        int cantGemaAma = 0;
        int cantNave = 0;
        int cantAsteoride = 0;
        bool valido = true;
        public Form1()
        {
            InitializeComponent();
        }
       

        private void button1_Click(object sender, EventArgs e)
        {        
    
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        archivo:
            if (openDialog.ShowDialog() == DialogResult.OK)
            { 
                var text = new StreamReader(openDialog.FileName);
                //Valida que hay un texto que leer
                if (text != null)
                {
                    mapa = text.ReadToEnd();
                    lineasMapa = mapa.Split('\n');
                    if(lineasMapa.Length == 20)
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            //Esta linea elimina el caracter /r que aparece al final en 
                            //el archivo de texto del nivel}
                            if (lineasMapa[i].IndexOf('\r') != -1)
                            {
                                lineasMapa[i] = lineasMapa[i].Remove(lineasMapa[i].IndexOf('\r'), 1);
                            }

                            if(lineasMapa[i].Length == 20)
                            {
                                for (int j = 0; j < 20; j++)
                                {
                                    //Separa cada línea por letra
                                    celda = lineasMapa[i].Substring(j, 1);
                                    
                                    switch (celda)
                                    {
                                        case "A":
                                            matrizLetras[i, j] = celda;
                                            break;
                                        case "B":
                                            matrizLetras[i, j] = celda;
                                            cantNave++;
                                            break;
                                        case "C":
                                            matrizLetras[i, j] = celda;
                                            cantAsteoride++;
                                            break;
                                        case "D":
                                            matrizLetras[i, j] = celda;
                                            cantTierra++;
                                            break;
                                        case "E":
                                            matrizLetras[i, j] = celda;
                                            cantGemaA++;
                                            break;
                                        case "F":
                                            matrizLetras[i, j] = celda;
                                            cantGemaR++;
                                            break;
                                        case "G":
                                            matrizLetras[i, j] = celda;
                                            cantGemaAma++;
                                            break;
                                        default:
                                            valido = false;
                                            break;
                                    }
                                    


                                }
                            }
                            else
                            {
                                string mensaje = "Error al crear el nivel, el numero de columnas es inválido.";
                                var result = MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK);
                                goto archivo;
                            }
                        }
                        //Valida si las condiciones para que el nivel sea válido
                        if (cantAsteoride > 0 && cantNave == 1 && cantTierra == 1 && cantGemaA <= 5 && valido)
                        {
                            var th = new Thread(() => Application.Run(new Form2(matrizLetras)));
                            th.SetApartmentState(ApartmentState.STA);
                            th.Start();
                            this.Close();
                        }
                        else
                        {
                            //Muesta un mensaje de error cuando el nivel no es válido
                            string mensaje = "Error al crear el nivel, el archivo es inválido.";
                            var result = MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK);
                            goto archivo;
                        }
                    }
                    else
                    {
                        string mensaje = "La cantidad de filas es inválida";
                        var result = MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK);
                        goto archivo;
                    }
                }
                else
                {
                    //Si el archivo esta vacío, le pide al usuario elegir otro
                    string mensaje = "El arhivo esta vacío, por favor eliga otro.";
                    var result = MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK);
                    goto archivo;
                }
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var th = new Thread(() => Application.Run(new Instrucciones()));
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
