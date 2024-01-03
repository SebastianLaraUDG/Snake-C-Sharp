using System.Windows.Input;

/// <summary>
/// La clase de la serpiente (jugador principal)
/// </summary>
public class Serpiente
{
	private int x;
	private int y;
	private int longitud;
	private const char cabeza = 'O';
	private const char caracterCola = 'o';
	private Direccion direccion;

	private int[] colaX;
	private int[] colaY;

	public int X
	{
		get => x; set { x = value; }
	}
	public int Y
	{
		get => y; set { y = value; }
	}
    public int Longitud
    {
        get => longitud;
        set
        { 
            if(value>=1)longitud = value;
        }
    }

    /// <summary>
    /// Las posibles direcciones de la serpiente.
    /// </summary>
    public enum Direccion
    {	QUIETO = 0,
		IZQUIERDA,DERECHA,ARRIBA,ABAJO
    }

	/// <summary>
	/// Inicializa en el centro de la pantalla con
	/// dirección QUIETO
	/// </summary>
	public Serpiente()
	{
		this.x = Tablero.LARGO/2;
		this.y = Tablero.ALTO/2;
		this.longitud = 1;
		this.direccion = Direccion.QUIETO;
		colaX = new int[100];
		colaY = new int[100];
	}

    /// <summary>
    /// Inicializa en la posicion x,y de los parámetros
    /// y dirección QUIETO y longitud 1.
    /// </summary>
    /// <param name="x">La coordenada en X</param>
    /// <param name="y">La coordenada en Y</param>
    public Serpiente(int x, int y)
	{
        this.x = x;
        this.y = y;
        this.longitud = 1;
        this.direccion = Direccion.QUIETO;
        colaX = new int[100];
        colaY = new int[100];
    }

    /// <summary>
    /// Inicializa en las
	/// coordenadas indicadas y una dirección
    /// </summary>
    /// <param name="x">Coordenada en X</param>
    /// <param name="y">Coordenada en Y</param>
    /// <param name="direccion">La direccion a la
	/// que se moverá la serpiente</param>
    public Serpiente(int x, int y, Direccion direccion)
	{
		this.x= x;
		this.y= y;
		this.longitud= 1;
		this.direccion= direccion;
		colaX=new int[100];
		colaY=new int[100];
	}

	/// <summary>
	/// Función encargada de mover a
	/// la serpiente
	/// </summary>
	/// <param name="gameOver">Variable de proceso de juego</param>
	public void Mover(ref bool gameOver)
	{
        colaX[0] = this.x;
        colaY[0] = this.y;

        int prevX = this.colaX[0];
        int prevY = this.colaY[0];
        int prev2X, prev2Y;


        for (int i = 1; i < longitud; i++)
        {
            prev2X = colaX[i];
            prev2Y = colaY[i];
            colaX[i] = prevX;
            colaY[i] = prevY;
            prevX = prev2X;
            prevY = prev2Y;
        }

        switch (this.direccion)
        {
            case Direccion.ARRIBA:
                y--;
                break;
            case Direccion.ABAJO:
                y++;
                break;
            case Direccion.IZQUIERDA:
                x--;
                break;
            case Direccion.DERECHA:
                x++;
                break;
        }

        if (longitud >= 2)
            //Si la cabeza choca con la cola, fin del juego
            for (int i = 0; i < longitud; i++)
                if (colaX[i] == x && colaY[i] == y)
                    gameOver = true;
    }

	public void Dibujar()
	{
        
        //Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.Red;
        //Console.WriteLine("White on blue.");
        Console.SetCursorPosition(this.x, this.y);
        Console.Write(cabeza);

        Console.ForegroundColor = ConsoleColor.White;
        if(longitud>=2)
            for(int j = 0; j < longitud; j++)
            {
                Console.SetCursorPosition(this.colaX[j], this.colaY[j]);
                Console.Write(caracterCola);
            }
    }

    public void Input()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);

            switch (cki.Key)
            {
                case ConsoleKey.W:
                    if (this.direccion != Direccion.ABAJO)
                        this.direccion = Direccion.ARRIBA;
                    break;

                case ConsoleKey.S:
                    if (this.direccion != Direccion.ARRIBA)
                        this.direccion = Direccion.ABAJO;
                    break;

                case ConsoleKey.A:
                    if (this.direccion != Direccion.DERECHA)
                        this.direccion = Direccion.IZQUIERDA;
                    break;
                case ConsoleKey.D:
                    if (this.direccion != Direccion.IZQUIERDA)
                        this.direccion = Direccion.DERECHA;
                    break;
            }
        }
	}


}
