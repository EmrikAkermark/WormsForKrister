public class Cell
{
	public enum CellContent
	{
		Empty,
		Snake,
		Wall,
		Food
	}

	public CellContent WhatsHere = CellContent.Empty;

	public Cell(CellContent cellContent)
	{
		WhatsHere = cellContent;
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
