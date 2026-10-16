using System.Text;
using PianoTiles;

Console.OutputEncoding = Encoding.UTF8;

try
{
    new MenuAplicacio().Ejecutar();
}
catch (Exception ex)
{
    Console.CursorVisible = true;
    Console.WriteLine($"Error inesperado: {ex.Message}");
}
