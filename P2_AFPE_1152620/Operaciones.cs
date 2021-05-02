using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace P2_AFPE_1152620
{
    class Operaciones
    {
        

        //Declaración de matrices
        string[,] matrizLetras = new string[20, 20];
        string[,] inicialLetras = new string[20, 20];
        
        Image[,] matrizMapa = new Image[20, 20];

        Image[,] inicialMapa = new Image[20, 20];

        //Declaración de strings
        static string path = @".\Images\";
        string name;

        //Declaración de las imagenes
        Bitmap imagenNaveAr = new Bitmap(path + "nave.jpg");
        Bitmap imagenNaveAb = new Bitmap(path + "nave_abajo.jpg");
        Bitmap imagenNaveD = new Bitmap(path + "nave_derecha.jpg");
        Bitmap imagenNaveI = new Bitmap(path + "nave_izquierda.jpg");
        Bitmap imagenVacio = new Bitmap(path + "vacio.jpg");
        Bitmap imagenSombreado = new Bitmap(path + "vaciosombreado.jpg");
        Bitmap imagenGemaRoja = new Bitmap(path + "gema_roja.jpg");
        Bitmap imagenGemaAzul = new Bitmap(path + "gema_azul.jpg");
        Bitmap imagenGemaAmarilla = new Bitmap(path + "gema_amarilla.jpg");
        Bitmap imagenAsteroide = new Bitmap(path + "asteroide.jpg");
        Bitmap imagenTierra = new Bitmap(path + "tierra.jpg");

        //Declaración de enteros
        int posNaveX = 0;
        int posNaveY = 0;
        int inicioX = 0;
        int inicioY = 0;

        public int puntos { set; get; }
        public int movimientos { set; get; }
        public int casillas { set; get; }

        //Declaración de strings
        string celda;

        //Declaración de booleanos
        public bool gano { set; get; }
        public bool perdio { set; get; }
        bool parar = false;
        

        public Image[,] generarMapa(string[,] mL, string nombre)
        {
            //Declaración y asignación de variables
            name = nombre;
            gano = false;
            perdio = false;
            puntos = 0;
            movimientos = 0;
            casillas = 0;
            matrizLetras = mL;

            //Separa por lineas el texto del mapa
            for (int i = 0; i < 20; i++ )
            {
                for (int j = 0; j < 20; j++ )
                {
                    //Verifica cada celda e inserta la imagen en el data grid
                    //según la letra de cada casilla
                    switch (mL[i,j])
                    {
                        case "A":
                            matrizMapa[i, j] = imagenVacio;
                            break;
                        case "B":
                            matrizMapa[i, j] = imagenNaveAr;

                            //Asgina la posición inicial de la nave
                            posNaveY = i;
                            inicioY = i;
                            posNaveX = j;
                            inicioX = j;
                            break;
                        case "C":
                            matrizMapa[i, j] = imagenAsteroide;
                            break;
                        case "D":
                            matrizMapa[i, j] = imagenTierra;
                            break;
                        case "E":
                            matrizMapa[i, j] = imagenGemaAzul;
                            break;
                        case "F":
                            matrizMapa[i, j] = imagenGemaRoja;
                            break;
                        case "G":
                            matrizMapa[i, j] = imagenGemaAmarilla;
                            break;
                    }
                    inicialLetras = matrizLetras;
                    inicialMapa = matrizMapa;
                }
            }
            return matrizMapa;
                    
        }

        public Image[,] reiniciar()
        {
            posNaveX = inicioX;
            posNaveY = inicioY;
            matrizLetras = inicialLetras;
            matrizMapa = inicialMapa;
            gano = false;
            perdio = false;
            parar = false;
            return matrizMapa;
        }

        public Image[,] bajar()
        {
             parar = false;

            //Aumenta movimientos
            movimientos++;

            //Ciclo que realiza todos los movimientos posibles
            while(posNaveY + 1 <= 20 && !gano && !perdio && !parar)
            {
                //Verifica si la nave aun se encuentra entre el rango del mapa
                if((posNaveY) < 19)
                {
                    celda = matrizLetras[posNaveY + 1, posNaveX];
                    //Realiza todas las acciones segun el elemento
                    switch(celda)
                    {
                        case "A":
                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en Y
                            posNaveY++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveAb;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;
                            break;
                        case "C":
                            parar = true;
                            break;
                        case "D":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en Y
                            posNaveY++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveAb;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //El jugador gana la partida automáticamente
                            gano = true;
                            break;
                        case "E":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en Y
                            posNaveY++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveAb;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 100;
                            break;
                        case "F":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en Y
                            posNaveY++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveAb;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 200;
                            break;
                        case "G":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en Y
                            posNaveY++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveAb;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 50;
                            break;
                    }
                }
                else
                {
                    //De lo contrario el jugador perdió automáticamente la partida
                    perdio = true;
                }
            }
            if (perdio || gano)
            {
                
                return null;
            }
            else
            {
                //Si se logra mover el jugador gana la partida
                return matrizMapa;
            }
            
        }

        public Image[,] subir()
        {
            parar = false;
            //Aumenta movimientos
            movimientos++;

            //Ciclo que realiza todos los movimientos posibles
            while (posNaveY-1 >= -1 && !gano && !perdio && !parar)
            {
                //Verifica si la nave aun se encuentra entre el rango del mapa
                if ((posNaveY) > 0)
                {
                    celda = matrizLetras[posNaveY - 1, posNaveX];
                    //Realiza todas las acciones segun el elemento
                    switch (celda)
                    {
                        case "A":

                            if(posNaveY == 0)
                            {
                                perdio = true;
                                break;
                            }
                            else
                            {
                                //Cambia la posición anterior de la nave por una casilla vacía
                                matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                                matrizLetras[posNaveY, posNaveX] = "A";

                                //Disminuye en 1 la poscisión en Y
                                posNaveY--;

                                //Cambia la posición de la nave a la nueva casilla
                                matrizMapa[posNaveY, posNaveX] = imagenNaveAr;
                                matrizLetras[posNaveY, posNaveX] = "B";
                                casillas++;
                                break;
                            }
                        case "C":
                            parar = true;
                            break;
                        case "D":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Disminuye en 1 la poscisión en Y
                            posNaveY--;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveAr;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //El jugador gana la partida automáticamente
                            gano = true;
                            break;
                        case "E":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Disminuye en 1 la poscisión en Y
                            posNaveY--;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveAr;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 100;
                            break;
                        case "F":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Disminuye en 1 la poscisión en Y
                            posNaveY--;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveAr;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 200;
                            break;
                        case "G":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Disminuye en 1 la poscisión en Y
                            posNaveY--;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveAr;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 50;
                            break;
                    }
                }
                else
                {
                    //De lo contrario el jugador perdió automáticamente la partida
                    perdio = true;
                }
            }
            if (perdio || gano)
            {
                
                return null;
            }
            else
            {
                //Si se logra mover el jugador gana la partida
                return matrizMapa;
            }
        }

        public Image[,] derecha()
        {
            parar = false;

            //Aumenta movimientos
            movimientos++;

            //Ciclo que realiza todos los movimientos posibles
            while (posNaveX + 1 <= 20 && !gano && !perdio && !parar)
            {
                //Verifica si la nave aun se encuentra entre el rango del mapa
                if ((posNaveX) < 19)
                {
                    celda = matrizLetras[posNaveY, posNaveX + 1];
                    //Realiza todas las acciones segun el elemento
                    switch (celda)
                    {
                        case "A":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en X
                            posNaveX++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveD;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;
                            break;
                        case "C":
                            parar = true;
                            break;
                        case "D":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en X
                            posNaveX++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveD;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //El jugador gana la partida automáticamente
                            gano = true;
                            break;
                        case "E":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en X
                            posNaveX++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveD;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 100;
                            break;
                        case "F":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en X
                            posNaveX++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveD;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 200;
                            break;
                        case "G":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Aumenta en 1 la poscisión en X
                            posNaveX++;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveD;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 50;
                            break;
                    }
                }
                else
                {
                    //De lo contrario el jugador perdió automáticamente la partida
                    perdio = true;
                }
            }
            if (perdio || gano)
            {
                return null;
            }
            else
            {
                //Si se logra mover el jugador gana la partida
                return matrizMapa;
            }
        }

        public Image[,] izquierda()
        {
            parar = false;

            //Aumenta movimientos
            movimientos++;

            //Ciclo que realiza todos los movimientos posibles
            while (posNaveX - 1 >= -1 && !gano && !perdio && !parar)
            {
                //Verifica si la nave aun se encuentra entre el rango del mapa
                if ((posNaveX) > 0)
                {
                    celda = matrizLetras[posNaveY, posNaveX - 1];
                    //Realiza todas las acciones segun el elemento
                    switch (celda)
                    {
                        case "A":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Disminuye en 1 la poscisión en X
                            posNaveX--;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveI;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;
                            break;
                        case "C":
                            parar = true;
                            break;
                        case "D":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Disminuye en 1 la poscisión en X
                            posNaveX--;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveI;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //El jugador gana la partida automáticamente
                            gano = true;
                            break;
                        case "E":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Disminuye en 1 la poscisión en X
                            posNaveX--;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveI;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 100;
                            break;
                        case "F":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Disminuye en 1 la poscisión en X
                            posNaveX--;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveI;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 200;
                            break;
                        case "G":

                            //Cambia la posición anterior de la nave por una casilla vacía
                            matrizMapa[posNaveY, posNaveX] = imagenSombreado;
                            matrizLetras[posNaveY, posNaveX] = "A";

                            //Disminuye en 1 la poscisión en X
                            posNaveX--;

                            //Cambia la posición de la nave a la nueva casilla
                            matrizMapa[posNaveY, posNaveX] = imagenNaveI;
                            matrizLetras[posNaveY, posNaveX] = "B";
                            casillas++;

                            //Sube los puntos al jugador
                            puntos = puntos + 50;
                            break;
                    }
                }
                else
                {
                    //De lo contrario el jugador perdió automáticamente la partida
                    perdio = true;

                }
            }
            if (perdio || gano)
            {
                
                return null;
            }
            else
            {
                //Si se logra mover el jugador gana la partida
                return matrizMapa;
            }
        }
        
    }
}
