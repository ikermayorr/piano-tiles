using System.Text;

namespace PianoTiles;

/// <summary>Se encarga únicamente de dibujar en consola. No contiene reglas.</summary>
public class Pantalla
{
    private const int Ancho = 40;

    public void Preparar()
    {
        Console.Clear();
        Console.CursorVisible = false;
    }

    public void DibujarPartida(Tablero tablero, Jugador jugador)
    {
        var sb = new StringBuilder();

        for (int fila = Tablero.Filas - 1; fila >= 0; fila--)
        {
            var linea = new StringBuilder("|");
            for (int col = 0; col < Tablero.Columnas; col++)
            {
                linea.Append(tablero.ColumnaDeFila(fila) == col ? " ## |" : "    |");
            }
            if (fila == 0)
            {
                linea.Append("  <-- pulsa aquí");
            }
            sb.AppendLine(Rellenar(linea.ToString()));
        }

        sb.AppendLine(Rellenar("  D    F    J    K"));
        sb.AppendLine(Rellenar(""));
        sb.AppendLine(Rellenar($"Puntos: {jugador.Puntos}   Vidas: {jugador.Vidas}   Récord: {jugador.Record}"));

        Console.SetCursorPosition(0, 0);
        Console.Write(sb.ToString());
    }

    public void MostrarFinDePartida(Jugador jugador)
    {
        Console.Clear();
        Console.CursorVisible = true;
        Console.WriteLine("=== FIN DE PARTIDA ===");
        Console.WriteLine($"Puntuación final: {jugador.Puntos}");
        Console.WriteLine($"Récord de la sesión: {jugador.Record}");
        Console.WriteLine();
    }

    // Rellena con espacios para borrar restos de dibujados anteriores.
    private static string Rellenar(string texto)
    {
        return texto.PadRight(Ancho);
    }
}
