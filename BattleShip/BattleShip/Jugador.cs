using System;
class Jugador
{
	private List<Barco> barcos;
	private bool IA;

	public Jugador(bool IA = false)
	{
		this.IA = IA;
		barcos = new List<Barco>();
    }

    public List<Barco> GetBarcos()
    {
        return barcos;
    }

	public void GenerarBarcos()
	{
        Console.WriteLine("Añadiendo barcos al tablero");
		for (int i = 0; i < Configuracion.numeroBarcos; i++)
		{
			Barco barco;
			int[] coords;
            do
            {
                if (!IA)
                {
                    coords = PedirCoordsUsuario();
                }
                else
                {
                    coords = PedirCoordsIA();
                    Thread.Sleep(1000);
                }
                barco = new Barco(coords[0], coords[1]);
            }
            while (barcos.Any(b => b.Equals(barco)));
            barcos.Add(barco);
		}		
	}

    public void QuitarBarco(Barco barco)
    {
        barcos.RemoveAll(b => b.Equals(barco));
    }

    public static int[] PedirCoordsUsuario()
    {
        int[] coords = new int[2];
        bool correcto;
        string coord;
        do
        {
            correcto = true;
            try
            {
                Console.WriteLine("Elija la coordenada [(A-J)(0-9)] Ej.: B5");
                coord = Console.ReadLine();

                if (coord.Length != 2)
                {
                    throw new Exception("Longtiud de la coordenada erronea");
                }
                else if (!(char.IsLetter(coord[0]) && char.IsDigit(coord[1])))
                {
                    throw new Exception("Formato de coordenada erroneo");
                }
                else if (!(((int)(char.ToUpper(coord[0])) >= 65 &&
                         (int)(char.ToUpper(coord[0])) <= 74) &&
                         ((int)coord[1] >= 48 && (int)coord[1] <= 57)))
                {
                    throw new Exception("Coordenada fuera de los valores establecidos");
                }
                else
                {
                    coords[0] = (int)(char.ToUpper(coord[0])) - 65;
                    coords[1] = (int)coord[1] - 48;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                correcto = false;
            }
        }
        while (!correcto);
        return coords;
    }

    public static int[] PedirCoordsIA()
    {
        int[] coords = { Configuracion.random.Next(Configuracion.tamTablero), Configuracion.random.Next(Configuracion.tamTablero) };
        return coords;
    }
}


