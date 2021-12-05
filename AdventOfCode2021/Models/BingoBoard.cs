namespace AdventOfCode2021.Models;

public class BingoBoard
{
    private readonly int _boardDimensions;
    private readonly bool[,] _checkedBoard;
    private readonly int[,] _board;
    private readonly Dictionary<int, (int, int)> _boardPositions;

    public bool HasBingo { get; private set; }

    public BingoBoard(IEnumerable<string> board, int boardDimensions)
    {
        _boardDimensions = boardDimensions;
        _checkedBoard = new bool[_boardDimensions, _boardDimensions];
        _board = new int[_boardDimensions, _boardDimensions];
        _boardPositions = new Dictionary<int, (int, int)>();

        SetupBoard(board);
    }

    private void SetupBoard(IEnumerable<string> board)
    {
        for (var i = 0; i < board.Count(); i++)
        {
            var cols = board.ElementAt(i).Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (var j = 0; j < cols.Length; j++)
            {
                var value = Convert.ToInt32(cols[j]);
                _checkedBoard[i, j] = false;
                _boardPositions.Add(value, (i, j));
                _board[i, j] = value;
            }
        }
    }

    public void PickNumber(int number)
    {
        if (!_boardPositions.ContainsKey(number) || HasBingo)
            return;

        var (row, col) = _boardPositions[number];
        _checkedBoard[row, col] = true;

        CheckHasBingo(col, row);
    }

    internal void CheckHasBingo(int column, int row)
    {
        HasBingo = IsColumnChecked(column);
        HasBingo |= IsRowChecked(row);
    }

    public bool IsColumnChecked(int columnNumber)
    {
        return Enumerable.Range(0, _checkedBoard.GetLength(0))
            .Select(x => _checkedBoard[x, columnNumber]).All(x => x);
    }

    public bool IsRowChecked(int rowNumber)
    {
        return Enumerable.Range(0, _checkedBoard.GetLength(1))
            .Select(x => _checkedBoard[rowNumber, x]).All(x => x);
    }

    public int[] GetUnmarkedNumbers()
    {
        var unmarked = new List<int>();

        for (var i = 0; i < _boardDimensions; i++)
        {
            for (var j = 0; j < _boardDimensions; j++)
            {
                if(!_checkedBoard[i, j])
                    unmarked.Add(_board[i, j]);
            }
        }

        return unmarked.ToArray();
    }
}