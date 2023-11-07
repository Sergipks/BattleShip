using System;

/*
 * Configuración general del juego
 */
class Configuracion
{
    // Generador de números aleatorios
    public static Random random = new Random();
    public static int tamTablero = 10;
    public static int numeroBarcos = 4;
    public static readonly log4net.ILog log =
    log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
}