using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReversiGame
{
    public partial class Rules : Form
    {
        public Rules()
        {
            InitializeComponent();
            rulesInfo.Text = 
                "\n1. The game is played on an 8x8 grid.\n" +
                "2. Two players take turns placing their pieces (black and white) on the board.\n" +
                "3. A valid move must capture at least one of the opponent's pieces by surrounding them in a straight line (horizontally, vertically, or diagonally).\n" +
                "4. Captured pieces are flipped to the capturing player's color.\n" +
                "5. If a player cannot make a valid move, they must pass their turn.\n" +
                "6. The game ends when neither player can make a valid move (usually when the board is full).\n" +
                "7. The player with the most pieces on the board at the end of the game wins.";
        }
    }
}
