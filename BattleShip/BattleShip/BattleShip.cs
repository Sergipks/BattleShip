/*
 * Programa principal de BattleShip
 * Se centra en la lógica de alternar entre pantalla de partida y de bienvenida
 */

using System;

class ConsoleInvaders
{
    static void Main()
    {
        // Ocultamos el cursor durante el juego
        Console.CursorVisible = false;

        Partida p = new Partida();
        p.Lanzar();

        Console.Clear();
    }
}