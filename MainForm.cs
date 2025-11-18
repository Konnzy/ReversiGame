using System.Windows.Forms;

namespace ReversiGame
{
    public partial class MainForm : Form
    {
        private readonly Board _board = new Board();
        private Disc currentPlayer = Disc.Black;
        private readonly Disc AIPlayer = Disc.White;
        private readonly AlgorithmAI _ai = new AlgorithmAI();
        private readonly Random rand = new Random();

        private bool showHints = false;
        private List<(int row, int col)> validMoves = new();
        private int _aiDepth = 1;


        private Rules? rulesForm;

        public MainForm()
        {
            InitializeComponent();
            InitBoard();
            playBoard.Paint += Board_Paint;
        }

        private void RulesButton_Click(object sender, EventArgs e)
        {
            if (rulesForm == null || rulesForm.IsDisposed)
            {
                rulesForm = new Rules();
                rulesForm.Show();
            }
            else
            {
                rulesForm.Focus();
            }
        }

        private void Board_Paint(object? sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int cellSize = playBoard.Width / 8;
            g.FillRectangle(Brushes.DarkGreen, 0, 0, playBoard.Width, playBoard.Height);

            using (Pen bordPen = new(Color.Black, 10))
            {
                g.DrawRectangle(bordPen, 0, 0, playBoard.Width - 1, playBoard.Height - 1);
            }

            using (var p = new Pen(Color.Black, 2))
            {
                for (int i = 0; i <= 8; i++)
                {
                    g.DrawLine(p, i * cellSize, 0, i * cellSize, playBoard.Height);
                    g.DrawLine(p, 0, i * cellSize, playBoard.Width, i * cellSize);
                }
            }

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (_board[r, c] == Disc.White)
                        DrawDisc(g, r, c, true);
                    else if (_board[r, c] == Disc.Black)
                        DrawDisc(g, r, c, false);
                }
            }

            if (showHints && validMoves.Count > 0)
            {
                using (Brush hintBrush = new SolidBrush(Color.Firebrick))
                {
                    int radius = cellSize / 6;

                    foreach (var move in validMoves)
                    {
                        int row = move.row;
                        int col = move.col;

                        int centerX = col * cellSize + cellSize / 2;
                        int centerY = row * cellSize + cellSize / 2;

                        var rect = new Rectangle(
                            centerX - radius,
                            centerY - radius,
                            radius * 2,
                            radius * 2);

                        g.FillEllipse(hintBrush, rect);
                    }
                }
            }
        }

        private void DrawDisc(Graphics g, int row, int col, bool isWhite)
        {
            int cellSize = playBoard.Width / 8;
            int x = col * cellSize;
            int y = row * cellSize;
            int margin = cellSize / 10;
            var rect = new Rectangle(x + margin, y + margin, cellSize - 2 * margin, cellSize - 2 * margin);
            var brush = isWhite ? Brushes.White : Brushes.Black;
            g.FillEllipse(brush, rect);
        }

        private void SelectedDifficulty(object sender, EventArgs e)
        {
            if (sender is not Button clickedButton) return;
            if (clickedButton == EasyButton)
            {
                SelectDifLabel.Text = "Difficulty: Easy";
                PlayButton.Enabled = true;
                PlayButton.BackColor = Color.PowderBlue;
                PlayButton.ForeColor = Color.Black;
                InitBoard();
                WhiteLabel.Text = "White: 2";
                BlackLabel.Text = "Black: 2";
                playBoard.Invalidate();
                _aiDepth = 1;
            }
            else if (clickedButton == NormalButton)
            {
                SelectDifLabel.Text = "Difficulty: Normal";
                PlayButton.Enabled = true;
                PlayButton.BackColor = Color.PowderBlue;
                PlayButton.ForeColor = Color.Black;
                InitBoard();
                WhiteLabel.Text = "White: 2";
                BlackLabel.Text = "Black: 2";
                playBoard.Invalidate();
                _aiDepth = 2;
            }
            else if (clickedButton == HardButton)
            {
                SelectDifLabel.Text = "Difficulty: Hard";
                PlayButton.Enabled = true;
                PlayButton.BackColor = Color.PowderBlue;
                PlayButton.ForeColor = Color.Black;
                InitBoard();
                WhiteLabel.Text = "White: 2";
                BlackLabel.Text = "Black: 2";
                playBoard.Invalidate();
                _aiDepth = 5;
            }
        }

        private void InitBoard()
        {
            _board.Reset();
            currentPlayer = Disc.Black;
            validMoves = _board.GetValidMoves(currentPlayer);
            UpdateScore();
        }

        private void UpdateScore()
        {
            var (white, black) = _board.GetScore();
            WhiteLabel.Text = $"White: {white}";
            BlackLabel.Text = $"Black: {black}";
        }

        private void playBoard_MouseClick(object sender, MouseEventArgs e)
        {
            if (!showHints) return;
            int cellSize = playBoard.Width / 8;
            int col = e.X / cellSize;
            int row = e.Y / cellSize;
            if (_board.IsValidMove(row, col, currentPlayer))
            {
                _board.ApplyMove(row, col, currentPlayer);
                currentPlayer = currentPlayer == Disc.Black ? Disc.White : Disc.Black;
                validMoves = _board.GetValidMoves(currentPlayer);
                UpdateScore();

                if (currentPlayer == AIPlayer && validMoves.Count > 0)
                {
                    var best = _ai.ChooseBestMove(_board, AIPlayer, depth: _aiDepth);
                    if (best.row != -1)
                    {
                        _board.ApplyMove(best.row, best.col, AIPlayer);
                        currentPlayer = Disc.Black;
                        validMoves = _board.GetValidMoves(currentPlayer);
                        UpdateScore();
                        playBoard.Invalidate();
                    }
                }

                EasyButton.Enabled = false;
                EasyButton.BackColor = Color.LightGray;
                EasyButton.ForeColor = Color.DarkGray;
                NormalButton.Enabled = false;
                NormalButton.BackColor = Color.LightGray;
                NormalButton.ForeColor = Color.DarkGray;
                HardButton.Enabled = false;
                HardButton.BackColor = Color.LightGray;

                PlayButton.Enabled = false;
                PlayButton.BackColor = Color.LightGray;
                PlayButton.ForeColor = Color.DarkGray;
                if (validMoves.Count == 0)
                {
                    var (white, black) = _board.GetScore();

                    string result;
                    if (black > white) result = "Black wins! Game over!";
                    else if (white > black) result = "White wins! Game over!";
                    else result = "It's a tie! Game over!";

                    showHints = false;
                    MessageBox.Show(result, "Reversi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    EasyButton.Enabled = true;
                    EasyButton.BackColor = Color.PaleGreen;
                    EasyButton.ForeColor = Color.Black;
                    NormalButton.Enabled = true;
                    NormalButton.BackColor = Color.LightGoldenrodYellow;
                    NormalButton.ForeColor = Color.Black;
                    HardButton.Enabled = true;
                    HardButton.BackColor = Color.LightCoral;
                    HardButton.ForeColor = Color.Black;
                    SelectDifLabel.Text = "Select Difficulty:";
                }

                playBoard.Invalidate();
            }
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            InitBoard();
            currentPlayer = Disc.Black;

            showHints = true;
            playBoard.Invalidate();
        }
    }
}