﻿public class SnakeBody
{
	public SnakeBody(Cell startPosition)
	{
		Head = new SnakeSegment(startPosition, null);
	}

	public SnakeSegment Head; //this is funny to me

	public void AteFood(Cell foodCell)
	{
		Head = new SnakeSegment(foodCell, Head);
	}

	public void MovetoNewCell(Cell newCell)
	{
		Head.MoveToNewCell(newCell);
	}


}

public class SnakeSegment
{
	public SnakeSegment Next;
	public Cell OccupiedCell;
	public Cell PreviousCell;

    public SnakeSegment(Cell startingCell, SnakeSegment nextSegment)
	{
		OccupiedCell = startingCell;
		OccupiedCell.SnakeHere();
		Next = nextSegment;
	}
	
	public void MoveToNewCell(Cell newCell)
	{
		if(Next == null)
		{
			OccupiedCell.SnakeGone();
			PreviousCell = OccupiedCell;
			OccupiedCell = newCell;
			OccupiedCell.SnakeHere();
		}
		else
		{
			Cell oldCell = OccupiedCell;
			OccupiedCell = newCell;
			OccupiedCell.SnakeHere(); //Might be superfluous
			Next.MoveToNewCell(oldCell);
		}
	}

	public void MoveToNextCell(Cell newCell)
	{
		if(Next == null)
		{
			OccupiedCell.SnakeGone();
			OccupiedCell = newCell;
		}
		else
		{
			Cell oldCell = OccupiedCell;
			OccupiedCell = newCell;
			Next.MoveToNextCell(oldCell);
		}
	}

	public int GetXCoordinate()
	{
		return OccupiedCell.Xcoordinate;
	}
	public int GetYCoordinate()
	{
		return OccupiedCell.Ycoordinate;
	}

}
