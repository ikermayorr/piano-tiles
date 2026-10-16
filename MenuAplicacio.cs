namespace PianoTiles;

/// <summary>Menú principal: validar la opción, lanzar partidas y salir.</summary>
public class MenuAplicacio
{
    private readonly Jugador _jugador = new();

    public void Ejecutar()
    {
        bool salir = false;

        while (!salir)
        {
            MostrarMenu();
            string? opcion = Console.ReadLine()?.Trim();

            switch (opcion)
            {
                case "1":
                    JugarPartidas();
                    break;
                case "2":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida. Pulsa Enter para continuar...");
                    Console.ReadLine();
                    break;
            }
        }

        Console.WriteLine("¡Hasta pronto!");
    }

    private static void MostrarMenu()
    {
        Console.Clear();
        Console.WriteLine("=== PIANO TILES ===");
        Console.WriteLine("1. Jugar");
        Console.WriteLine("2. Salir");
        Console.WriteLine();
        Console.Write("Elige una opción: ");
    }

    private void JugarPartidas()
    {
        bool volverAJugar;

        do
        {
            new Partida(_jugador).Iniciar();
            volverAJugar = PreguntarVolverAJugar();
        }
        while (volverAJugar);
    }

    private static bool PreguntarVolverAJugar()
    {
        while (true)
        {
            Console.Write("¿Volver a jugar? (S/N): ");
            string? respuesta = Console.ReadLine()?.Trim().ToUpper();

            if (respuesta == "S") return true;
            if (respuesta == "N") return false;

            Console.WriteLine("Respuesta no válida. Introduce S o N.");
        }
    }
}
