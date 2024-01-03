

using Snake_C_;

namespace Program // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool gameOver = false;//Importante en el flujo de juego.

            Tablero tablero = new Tablero();
            Serpiente serpiente = new Serpiente();
            Comida comida = new Comida();

            //Proceso de juego en general
            while (!gameOver)
            {


                tablero.DibujaTablero();
                serpiente.Input();
                serpiente.Mover(ref gameOver);

                //Si la serpiente toca las barreras
                if (serpiente.X <= 0 || serpiente.X >= Tablero.LARGO - 1
                    || serpiente.Y <= 0 || serpiente.Y >= Tablero.ALTO - 1)
                {

                    gameOver = true;//Fin del juego
                }

                serpiente.Dibujar();

                //Si colisiona la serpiente con la fruta
                if (serpiente.X == comida.X
                    && serpiente.Y == comida.Y)
                {

                    //aumenta la longitud y puntuación
                    serpiente.Longitud++;
                    tablero.Puntuacion++;

                    //cambia la posición de la comida
                    comida.CambiaPosicion();
                }

                comida.Dibujar();

                Thread.Sleep(100);
                Console.Clear();


            }
            tablero.DibujaTablero();

            Console.WriteLine();
            Console.Write("Presiona una tecla para continuar...");
            Console.ReadKey();


        }
    }
}