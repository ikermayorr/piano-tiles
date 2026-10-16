using System.Diagnostics;

namespace PianoTiles;

/// <summary>Controla el bucle de juego: teclas, tiempo, reglas y final de partida.</summary>
public class Partida
{
    private const int IntervaloInicialMs = 800;
    private const int ReduccionMs = 50;
    private const int PuntosPorNivel = 10;
    private const int IntervaloMinimoMs = 200;

    private static readonly Dictionary<ConsoleKey, int> Teclas = new()
    {
        { ConsoleKey.D, 0 },
        { ConsoleKey.F, 1 },
        { ConsoleKey.J, 2 },
        { ConsoleKey.K, 3 }
    };

    private readonly Tablero _tablero = new();
    private readonly Pantalla _pantalla = new();
    private readonly Jugador _jugador;
    private readonly Stopwatch _reloj = new();

    public Partida(Jugador jugador)
    {
        _jugador = jugador;
    }

    public void Iniciar()
    {
        _jugador.Reiniciar();
        _tablero.Reiniciar();
        _pantalla.Preparar();
        _reloj.Restart();
        _pantalla.DibujarPartida(_tablero, _jugador);

        while (!_jugador.SinVidas)
        {
            bool huboCambio = false;

            if (Console.KeyAvailable)
            {
                ConsoleKey tecla = Console.ReadKey(true).Key;
                huboCambio = ProcesarTecla(tecla);
                VaciarBufferTeclado();
            }

            if (ActualizarPorTiempo())
            {
                huboCambio = true;
            }

            if (huboCambio)
            {
                _pantalla.DibujarPartida(_tablero, _jugador);
            }

            Thread.Sleep(10);
        }

        VaciarBufferTeclado();
        _pantalla.MostrarFinDePartida(_jugador);
    }

    /// <summary>Devuelve true si la tecla provocó un cambio en el estado.</summary>
    public bool ProcesarTecla(ConsoleKey tecla)
    {
        if (!Teclas.TryGetValue(tecla, out int columna))
        {
            return false; // Tecla no válida: se ignora.
        }

        if (columna == _tablero.ColumnaInferior())
        {
            _jugador.SumarPunto();
            _tablero.Avanzar();
            _reloj.Restart();
        }
        else
        {
            _jugador.PerderVida();
        }

        return true;
    }

    /// <summary>Devuelve true si se agotó el tiempo y se aplicó el fallo.</summary>
    public bool ActualizarPorTiempo()
    {
        if (_reloj.ElapsedMilliseconds < CalcularIntervalo(_jugador.Puntos))
        {
            return false;
        }

        _jugador.PerderVida();
        _tablero.Avanzar();
        _reloj.Restart();
        return true;
    }

    public int CalcularIntervalo(int puntos)
    {
        int intervalo = IntervaloInicialMs - (puntos / PuntosPorNivel) * ReduccionMs;
        return Math.Max(intervalo, IntervaloMinimoMs);
    }

    private static void VaciarBufferTeclado()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }
}
