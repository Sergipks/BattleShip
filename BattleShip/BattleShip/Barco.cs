using System;
class Barco
{
    protected int x;
    protected int y;
    protected int tam;
    protected bool vertical;

    public Barco(int x, int y, int tam = 1, bool vertical = false)
    {
        this.x = x;
        this.y = y;
        this.tam = tam;
        this.vertical = vertical;
    }
    public int GetX()
    {
        return x;
    }
    public int GetY()
    {
        return y;
    }
    public bool GetVertical()
    {
        return vertical;
    }
    public int GetTam()
    {
        return tam;
    }

    public override bool Equals(object? obj)
    {
        return obj is Barco barco &&
               x == barco.x &&
               y == barco.y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
}