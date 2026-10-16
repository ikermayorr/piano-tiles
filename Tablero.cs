namespace PianoTiles;

/// <summary>
/// Guarda las filas del tablero. Cada elemento es la columna (0-3) de la baldosa
/// de esa fila. El índice 0 es la fila inferior.
/// </summary>
public class Tablero
{
    public const int Columnas = 4;
    public const int Filas = 8;

    private readonly List<int> _filas = new();
    private readonly Random _random = new();

    public Tablero()
    {
        Reiniciar();
    }

    public void Reiniciar()
    {
        _filas.Clear();
        for (int i = 0; i < Filas; i++)
        {
            _filas.Add(GenerarColumnaAleatoria());
        }
    }

    public int GenerarColumnaAleatoria()
    {
        return _random.Next(Columnas);
    }

    public int ColumnaInferior()
    {
        return _filas[0];
    }

    public int ColumnaDeFila(int indice)
    {
        return _filas[indice];
    }

    /// <summary>Elimina la fila inferior y añade una nueva arriba.</summary>
    public void Avanzar()
    {
        _filas.RemoveAt(0);
        _filas.Add(GenerarColumnaAleatoria());
    }
}
