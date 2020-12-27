public class Cell
{
    public enum CellContents
    {
        Empty,
        Wall,
        Snake,
        Food
    }

    public CellContents CellContent;

    public Cell(CellContents startContent)
    {
        CellContent = startContent;
    }

    public CellContents GetContents()
    {
        return CellContent;
    }

    public void ChangeContent(CellContents newContent)
    {
        CellContent = newContent;
    }
}