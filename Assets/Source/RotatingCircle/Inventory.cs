using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory
{
    private List<Cell> _cells = new List<Cell>()
    {
        new Cell (new FireBall(), 2),
        new Cell (new WaterBall(), 2),
        new Cell (new DustBall(), 2),
        new Cell (new WaterBall1(), 2),
        new Cell (new WaterBall2(), 2),
        new Cell (new WaterBall3(), 2),
        new Cell (new WaterBall4(), 2),
        new Cell (new WaterBall5(), 2),
        new Cell(new WaterBall6(), 2),
    };

    public IReadOnlyList<IReadonlyCell> Cells => _cells;

    public void Remove(IEffectBall ball, int count)
    {
        Cell currentCell = _cells.FirstOrDefault(cell => cell.Ball == ball);

        if (currentCell == null)
            throw new InvalidOperationException();

        if (currentCell.Count < count)
            _cells.Remove(currentCell);
        else
            currentCell.Count -= count;
    }
}

public class Cell : IReadonlyCell
{
    public IEffectBall Ball { get; private set; }
    public int Count { get; set; }

    public Cell(IEffectBall ball, int count)
    {
        Ball = ball;
        Count = count;
    }
}

public interface IReadonlyCell
{
    public IEffectBall Ball { get; }
    public int Count { get; }
}