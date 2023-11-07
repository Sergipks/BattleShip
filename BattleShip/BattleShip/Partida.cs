using System;

class Partida
{
    public Partida()
    {
    }

    // Lanza la partida principal
    public void Lanzar()
    {
        Configuracion.log.Info("Partida lanzada");
        Jugador usuario = new Jugador();
        Jugador IA = new Jugador(true);
        bool finPartida = false;
        bool turnoUsuario = Configuracion.random.Next(2) == 0;
        char[,] tableroIA = CrearTablero();
        char[,] tableroUs = CrearTablero();
        int[] coordUs = new int[2];
        int[] coordIA = new int[2];
        DibujarTablero(tableroUs);
        usuario.GenerarBarcos();
        IA.GenerarBarcos();
        
        do
        {
            Console.Clear();
            DibujarTablero(tableroIA);
            DibujarTablero(tableroUs);
            if(turnoUsuario)
            {
                coordUs = Jugador.PedirCoordsUsuario();
                ActualizarTablero(ref tableroIA, coordUs[0], coordUs[1], IA);
                turnoUsuario = false;
            }
            else
            {
                coordIA = Jugador.PedirCoordsIA();
                ActualizarTablero(ref tableroUs, coordIA[0], coordIA[1], usuario);
                turnoUsuario = true;
                Console.WriteLine("Turno de la IA");
                Thread.Sleep(1500);
            }

            if(usuario.GetBarcos().Count == 0 || IA.GetBarcos().Count == 0)
            {
                finPartida = true;
            }
        }
        while (!finPartida);
        
    }

    static char[,] CrearTablero()
    {
        char[,] tablero = new char[Configuracion.tamTablero, Configuracion.tamTablero];
        char espacio = ' ';

        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                tablero[i, j] = espacio;
            }
        }
        return tablero;
    }

    static void DibujarTablero(char[,] tablero)
    {
        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            Console.WriteLine(" -----------------------------------------");
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                Console.Write("| ");
                if (tablero[i, j] == '~')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(tablero[i, j] + " ");
                    Console.ResetColor();
                }
                else if (tablero[i, j] == 'X')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(tablero[i, j] + " ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(tablero[i, j] + " ");
                }
            }
            Console.WriteLine("|");
        }
        Console.WriteLine(" ----------------------------------------");
    }

    private void ActualizarTablero(ref char[,] tablero, int x, int y, Jugador player)
    {
        if(Tocado(x, y, player))
        {
            tablero[x, y] = 'X';
        }
        else
        {
            tablero[x, y] = '~';
        }
    }

    private bool Tocado(int x, int y, Jugador player)
    {
        bool tocado = false;
        Barco barco = new Barco(x, y);
        if(player.GetBarcos().Any(b => b.Equals(barco)))
        {
            player.QuitarBarco(barco);
            tocado = true;
        }
        
        return tocado;
    }
}