/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
using System;

namespace Snake_C_
{
    /// <summary>
    /// El alimento de la serpiente
    /// </summary>
    internal class Comida
    {
        private int x;
        private int y;
        private const char caracter = 'F';

        public int X
        {
            get => x; set => x = value;
        }
        public int Y
        {
            get=>y; set => y = value;
        }

        /// <summary>
        /// Inicializa la posicion de la comida en
        /// un lugar aleatorio
        /// </summary>
        public Comida()
        {
            Random random = new Random();
            this.x = random.Next(1, 20);
            this.y = random.Next(1,20);
        }


        /// <summary>
        /// Inicializa la posición de la comida en los
        /// valores de X y Y indicados
        /// </summary>
        /// <param name="x">Coordenada en x</param>
        /// <param name="y">Coordenada en y</param>
        public Comida(int x, int y)
        {
            this.x=x;
            this.y=y;
        }

        public void Dibujar()
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.Write(caracter);
        }

        public void CambiaPosicion()
        {
            Random random=new Random();
            this.x = random.Next(1, 20);
            this.y = random.Next(1, 20);
        }

    }
}
