using System.Data;

namespace ReversiGame;

public class AlgorithmAI
{
    private const int WIN_VALUE = 100000;

    private Disc AIPlayer(Disc d) =>
        d == Disc.Black ? Disc.White : Disc.Black;

    private int AlphaBetaPruning(Board board, int depth, int alpha, int beta, bool maximizing, Disc me)
    {
        Disc currentPlayer = Disc.Black;
        if (depth == 0 || board.IsTerminal())
        {
            return Evaluate(board, me);
        }

        if (maximizing)
        {
            currentPlayer = me;
        }
        else
        {
            currentPlayer = AIPlayer(me);
        }

        var moves = board.GetValidMoves(currentPlayer);

        if (moves.Count == 0)
        {
            return AlphaBetaPruning(board, depth - 1, alpha, beta, !maximizing, me);
        }

        if (maximizing)
        {
            var value = Int32.MinValue;
            foreach (var move in moves)
            {
                var nextBoard = board.CloneAndApply(move, currentPlayer);
                var childValue = AlphaBetaPruning(nextBoard, depth - 1, alpha, beta, !maximizing, me);

                value = Math.Max(value, childValue);
                alpha = Math.Max(alpha, value);
                if (alpha >= beta) break;
            }

            return value;
        }
        else
        {
            var value = Int32.MaxValue;
            foreach (var move in moves)
            {
                var nextBoard = board.CloneAndApply(move, currentPlayer);
                var childValue = AlphaBetaPruning(nextBoard, depth - 1, alpha, beta, !maximizing, me);
                value = Math.Min(value, childValue);
                beta = Math.Min(beta, value);
                if (alpha >= beta) break;
            }

            return value;
        }
    }

    private int Evaluate(Board board, Disc me)
    {
        var (white, black) = board.GetScore();
        
        int my  = (me == Disc.White) ? white : black;
        int aiPlayer = (me == Disc.White) ? black : white;
        
        if (board.IsTerminal())
            (white, black) = board.GetScore();

        if (board.IsTerminal())
        {
            if (my > aiPlayer)  return WIN_VALUE;
            if (my < aiPlayer)  return -WIN_VALUE;
            return 0;
        }

        return Heuristic(board, me);
    }

    private int Heuristic(Board board, Disc me)
    {
        var (white, black) = board.GetScore();
        if (me == Disc.White)
            return white - black;
        
        return black - white;
    }

    public (int row, int col) ChooseBestMove(Board board, Disc me, int depth)
    {
        var moves = board.GetValidMoves(me);
        if (moves.Count == 0)
        {
            return (-1, -1);
        }

        var bestValue = Int32.MinValue;
        var bestMove = moves[0];

        foreach (var move in moves)
        {
            var nextBoard = board.CloneAndApply(move, me);
            var value = AlphaBetaPruning(nextBoard, depth - 1, Int32.MinValue, Int32.MaxValue, false, me);
            if (value > bestValue)
            {
                bestValue = value;
                bestMove = move;
            }
        }
        return bestMove;
    }
}