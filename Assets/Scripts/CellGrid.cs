public class CellGrid
{
    public int Width, Height;

    public Cell[,] Grid;

    private int minWidht = 4, minHeight = 4;

    public CellGrid(int Width, int Height)
    {
        if(Width < minWidht)
        {
            Width = minWidht;
        }
        if(Height < minHeight)
        {
            Height = minHeight;
        }
        this.Width = Width;
        this.Height = Height;
    }
}
