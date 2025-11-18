namespace ReversiGame;

public class Board
{
    public const int Size = 8;

    private readonly Disc[,] _cells = new Disc[Size, Size];

    public Disc this[int row, int col] => _cells[row, col];

    public Board(bool initStart = true)
    {
        if (initStart)
            Reset();
    }

    public void Reset()
    {
        for (int r = 0; r < Size; r++)
        for (int c = 0; c < Size; c++)
            _cells[r, c] = Disc.Empty;

        _cells[3, 3] = Disc.White;
        _cells[3, 4] = Disc.Black;
        _cells[4, 3] = Disc.Black;
        _cells[4, 4] = Disc.White;
    }

    private bool InsideBoard(int r, int c) =>
        r >= 0 && r < Size && c >= 0 && c < Size;

    public bool IsValidMove(int row, int col, Disc player)
    {
        if (!InsideBoard(row, col) || _cells[row, col] != Disc.Empty)
            return false;

        Disc opponent = player == Disc.Black ? Disc.White : Disc.Black;

        int[,] directions =
        {
            { -1, -1 }, { -1, 0 }, { -1, 1 },
            { 0, -1 }, { 0, 1 },
            { 1, -1 }, { 1, 0 }, { 1, 1 }
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int dr = directions[i, 0];
            int dc = directions[i, 1];

            int r = row + dr;
            int c = col + dc;

            if (!InsideBoard(r, c) || _cells[r, c] != opponent)
                continue;

            while (InsideBoard(r, c))
            {
                r += dr;
                c += dc;

                if (!InsideBoard(r, c))
                    break;

                if (_cells[r, c] == Disc.Empty)
                    break;

                if (_cells[r, c] == player)
                    return true;
            }
        }

        return false;
    }

    public void ApplyMove(int row, int col, Disc player)
    {
        _cells[row, col] = player;
        Disc opponent = player == Disc.Black ? Disc.White : Disc.Black;

        int[,] directions =
        {
            { -1, -1 }, { -1, 0 }, { -1, 1 },
            { 0, -1 }, { 0, 1 },
            { 1, -1 }, { 1, 0 }, { 1, 1 }
        };

        for (int i = 0; i < directions.GetLength(0); i++)
        {
            int dr = directions[i, 0];
            int dc = directions[i, 1];

            int r = row + dr;
            int c = col + dc;

            var toFlip = new List<(int, int)>();

            while (InsideBoard(r, c) && _cells[r, c] == opponent)
            {
                toFlip.Add((r, c));
                r += dr;
                c += dc;
            }

            if (InsideBoard(r, c) && _cells[r, c] == player)
            {
                foreach (var (fr, fc) in toFlip)
                    _cells[fr, fc] = player;
            }
        }
    }

    public List<(int row, int col)> GetValidMoves(Disc player)
    {
        var list = new List<(int, int)>();
        for (int r = 0; r < Size; r++)
        for (int c = 0; c < Size; c++)
            if (_cells[r, c] == Disc.Empty && IsValidMove(r, c, player))
                list.Add((r, c));
        return list;
    }

    public (int white, int black) GetScore()
    {
        int white = 0, black = 0;
        foreach (var cell in _cells)
        {
            if (cell == Disc.White) white++;
            else if (cell == Disc.Black) black++;
        }

        return (white, black);
    }

    public bool IsTerminal()
    {
        return GetValidMoves(Disc.Black).Count == 0 &&
               GetValidMoves(Disc.White).Count == 0;
    }

    public Board Clone()
    {
        var copy = new Board(initStart: false);
        for (int r = 0; r < Size; r++)
        for (int c = 0; c < Size; c++)
            copy._cells[r, c] = _cells[r, c];
        return copy;
    }

    public Board CloneAndApply((int row, int col) move, Disc player)
    {
        var copy = Clone();
        copy.ApplyMove(move.row, move.col, player);
        return copy;
    }
}