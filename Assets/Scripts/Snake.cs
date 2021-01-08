using UnityEngine;

public class Snake : MonoBehaviour
{
	public int Width, Height;
	public Visualiser Vis;
	
	public float TickDelay = 1f, FoodDelay = 5f;
	private float timeSnake, timeFood;

	private Coroutine Dead;

	private bool isAlive = true;
	public enum Directions
	{
		Left,
		Right,
		Up,
		Down
	}

	public Directions NewDirection = Directions.Left;
	public Directions CurrentDirection = Directions.Left;

    private SnakeBody body;
	private CellGrid grid;

	struct IntVector2
	{
		public int x, y;
		public IntVector2(int Xcoordinate, int Ycoordinate)
		{
			x = Xcoordinate;
			y = Ycoordinate;
		}
	}

	private IntVector2 headPosition;

	private void Start()
	{
		NewGame();
		Vis.Setup(grid);
		Vis.Visualize();
	}

	private void Update()
	{
		if(!isAlive)
		{
			return;
		}

		timeSnake += Time.deltaTime;
		if(timeSnake > TickDelay)
		{
			timeSnake -= TickDelay;
			MoveToNewCell();
			Vis.Visualize();
		}
		timeFood += Time.deltaTime;
		if(timeFood > FoodDelay)
		{
			timeFood -= FoodDelay;
			bool foundSpot = false;
			int width = grid.Cells.GetLength(0) - 1;
			int height = grid.Cells.GetLength(1) - 1;
			while (!foundSpot)
			{
				foundSpot = grid.Cells[Random.Range(1, width), Random.Range(1, height)].AddFood();
				Vis.Visualize();
			}
		}
	}




	public void NewGame()
	{
		
		grid = new CellGrid(Width, Height);
		int startX = Mathf.FloorToInt(Width / 2);
		int startY = Mathf.FloorToInt(Height / 2);
		body = new SnakeBody(grid.GetGridCell(startX, startY));
		headPosition = new IntVector2(startX, startY);
	}

	public void SwitchDirection(Directions InputDirection)
	{
		switch (InputDirection)
		{
			case Directions.Left:
				if(CurrentDirection == Directions.Right)
				{
					return;
				}
				break;
			case Directions.Right:
				if (CurrentDirection == Directions.Left)
				{
					return;
				}
				break;
			case Directions.Up:
				if (CurrentDirection == Directions.Down)
				{
					return;
				}
				break;
			case Directions.Down:
				if (CurrentDirection == Directions.Up)
				{
					return;
				}
				break;
			default:
				break;
		}
		NewDirection = InputDirection;
	}

	public void MoveToNewCell()
	{
		switch (NewDirection)
		{
			case Directions.Left:
				headPosition.x -= 1;
				break;
			case Directions.Right:
				headPosition.x += 1;
				break;
			case Directions.Up:
				headPosition.y += 1;
				break;
			case Directions.Down:
				headPosition.y -= 1;
				break;
			default:
				break;
		};
		CurrentDirection = NewDirection;
		Cell newCell = grid.GetGridCell(headPosition.x, headPosition.y);
		switch (newCell.CheckCell())
		{
			case Cell.CellContent.Empty:
				body.MovetoNewCell(newCell);
				break;
			case Cell.CellContent.Food:
				body.AteFood(newCell);
				break;
			default:
				isAlive = false;
				Vis.FlashDead();
				break;
		}
	}
}
