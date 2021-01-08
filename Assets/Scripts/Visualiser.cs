using System.Collections;
using System.Collections.Generic;
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
				VisGrid[x, y] = Instantiate(Plane, new Vector3(x, y, 0), transform.rotation).GetComponent<Renderer>().material;
			}
		}
	}

	public void FlashDead()
	{
		StartCoroutine(FlashDeadCoRoutine());
	}


	public IEnumerator FlashDeadCoRoutine()
	{
		foreach (var cell in VisGrid)
		{
			cell.color = Floor;
			Debug.Log(cell.color);
		}
		yield return new WaitForSeconds(0.5f);
		//Visualize();
		//yield return new WaitForSeconds(0.5f);
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
