namespace PianoTiles;

/// <summary>Guarda puntos, vidas y récord de la sesión.</summary>
public class Jugador
{
    public const int VidasIniciales = 3;

    public int Puntos { get; private set; }
    public int Vidas { get; private set; } = VidasIniciales;
    public int Record { get; private set; }
    public bool SinVidas => Vidas <= 0;

    public void Reiniciar()
    {
        Puntos = 0;
        Vidas = VidasIniciales;
    }

    public void SumarPunto()
    {
        Puntos++;
        if (Puntos > Record)
        {
            Record = Puntos;
        }
    }

    public void PerderVida()
    {
        if (Vidas > 0)
        {
            Vidas--;
        }
    }
}
