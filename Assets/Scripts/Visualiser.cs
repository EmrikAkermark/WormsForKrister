using System.Collections;
using UnityEngine;

public class Visualiser : MonoBehaviour
{
    public CellGrid RefGrid;
	public GameObject Plane;
	public Material[,] VisGrid;
	public Color Snake, Wall, Food, Floor;

	private int width, height;


	public void Setup(CellGrid refGrid)
	{
		RefGrid = refGrid;
		width = RefGrid.Cells.GetLength(0);
		height = RefGrid.Cells.GetLength(1);
		VisGrid = new Material[width, height];
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				VisGrid[x, y] = Instantiate(Plane, new Vector3(x - width / 2 + 0.5f, y - height/ 2 + 0.5f, 0), transform.rotation).GetComponent<Renderer>().material;
			}
		}
	}

	public void UpdateSnake(SnakeSegment snakeHead)
	{
		SnakeSegment snakePart = snakeHead;
		int x = snakePart.GetXCoordinate();
		int y = snakePart.GetYCoordinate();
		VisGrid[x, y].color = Snake;
		bool notOnLastSegment = true;
		while (notOnLastSegment)
		{
			if(snakePart.Next == null)
			{
				x = snakePart.PreviousCell.Xcoordinate;
				y = snakePart.PreviousCell.Ycoordinate;
				VisGrid[x, y].color = Floor;
				notOnLastSegment = false;
			}
			else
			{
				snakePart = snakePart.Next;
			}
		}
	}

	public void HideSnake(SnakeSegment snakeHead)
	{
		SnakeSegment SnakePart = snakeHead;
		bool stillOnSnake = true;
		while (stillOnSnake)
		{
			int x = SnakePart.GetXCoordinate();
			int y = SnakePart.GetYCoordinate();
			VisGrid[x, y].color = Floor;
			if(SnakePart.Next != null)
			{
				SnakePart = SnakePart.Next;
			}
			else
			{
				stillOnSnake = false;
			}
		}
	}

	public void ShowSnake(SnakeSegment snakeHead)
	{
		SnakeSegment SnakePart = snakeHead;
		bool stillOnSnake = true;
		while (stillOnSnake)
		{
			int x = SnakePart.GetXCoordinate();
			int y = SnakePart.GetYCoordinate();
			VisGrid[x, y].color = Snake;
			if (SnakePart.Next != null)
			{
				SnakePart = SnakePart.Next;
			}
			else
			{
				stillOnSnake = false;
			}
		}
	}

	public void AddFood(int Xcoordinate, int Ycoordinate)
	{
		VisGrid[Xcoordinate, Ycoordinate].color = Food;
	}

	public IEnumerator FlashDead(SnakeSegment snakeHead)
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			HideSnake(snakeHead);
			yield return new WaitForSeconds(0.5f);
			ShowSnake(snakeHead);
		}
	}

	public void Visualize()
	{
		//This is ugly
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				switch (RefGrid.Cells[x,y].WhatsHere)
				{
					case Cell.CellContent.Empty:
						VisGrid[x, y].color = Floor;
						break;
					case Cell.CellContent.Snake:
						VisGrid[x, y].color = Snake;
						break;
					case Cell.CellContent.Wall:
						VisGrid[x, y].color = Wall;
						break;
					case Cell.CellContent.Food:
						VisGrid[x, y].color = Food;
						break;
					default:
						break;
				}
			}
		}
	}

}
