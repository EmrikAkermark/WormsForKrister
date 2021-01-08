
public class CellGrid
{
    private int minimumWidth = 4, minimumHeight = 4;
	public Cell[,] Cells;

	public Cell GetGridCell(int x, int y)
	{
		return Cells[x, y];
	}

    public CellGrid(int width, int height)
	{
		int actualWidth;
		int actualHeight;
		if(width < minimumWidth)
		{
			actualWidth = minimumWidth;
		}
		else
		{
			actualWidth = width;
		}
		if(height < minimumHeight)
		{
			actualHeight = minimumHeight;
		}
		else
		{
			actualHeight = height;
		}

		Cells = new Cell[actualWidth, actualHeight];
		for (int x = 0; x < actualWidth; x++)
		{
			if (x == 0 || x == actualWidth-1)
			{
				for (int y = 0; y < actualHeight; y++)
				{
					Cells[x, y] = new Cell(Cell.CellContent.Wall);
				}
			}
			else
			{
				Cells[x, 0] = new Cell(Cell.CellContent.Wall);
				Cells[x, actualHeight-1] = new Cell(Cell.CellContent.Wall);
				for (int y = 1; y < actualHeight-1; y++)
				{
					Cells[x, y] = new Cell(Cell.CellContent.Empty);
				}
			}
		}

	}

}
