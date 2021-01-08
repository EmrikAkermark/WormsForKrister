public class Cell
{
	public int Xcoordinate, Ycoordinate;

	public enum CellContent
	{
		Empty,
		Snake,
		Wall,
		Food
	}

	public CellContent WhatsHere = CellContent.Empty;

	public Cell(CellContent cellContent, int Xcoordinate, int Ycoordinate)
	{
		WhatsHere = cellContent;
		this.Xcoordinate = Xcoordinate;
		this.Ycoordinate = Ycoordinate;
	}

	public CellContent CheckCell()
	{
		return WhatsHere;
	}

	public void SnakeHere()
	{
		WhatsHere = CellContent.Snake;
	}

	public void SnakeGone()
	{
		WhatsHere = CellContent.Empty;
	}

	public bool AddFood()
	{
		if(WhatsHere != CellContent.Empty)
		{
			return false;
		}
		else
		{
			WhatsHere = CellContent.Food;
			return true;
		}
	}
}
