/// <summary>
/// La clase del tablero (también maneja
/// la puntuación).
/// </summary>
public class Tablero
{
    private int puntuacion;

    /// <summary>
    /// Inicializamos el valor de la puntuación en 0
    /// </summary>
    public Tablero()
    {
        puntuacion = 0;
    }

    public int Puntuacion
    {
        get { return puntuacion; }
        set { if(value>0) puntuacion = value; }
    }

    public void DibujaTablero()
    {
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < LARGO; i++)
            Console.Write('#');
        Console.WriteLine();


        for (int i = 1; i < ALTO - 1; i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write('#');
            Console.SetCursorPosition(LARGO - 1, i);
            Console.Write('#');
        }

        Console.SetCursorPosition(0, ALTO - 1);
        for (int i = 0; i < LARGO; i++)
            Console.Write('#');

        Console.SetCursorPosition(25, 25);
        Console.Write("Puntuacion: "+puntuacion);
    }

    /// <summary>
    /// El largo del tablero en "bloques".
    /// </summary>
    public static readonly int LARGO = 20;
    /// <summary>
    /// El alto del tablero en "bloques".
    /// </summary>
    public static readonly int ALTO = 20;

}
