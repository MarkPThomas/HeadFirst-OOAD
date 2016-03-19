using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GSF.unit;

namespace GSF.board
{
    public class Board
    {
        public Tile[,] Tiles { get; private set; }

        public Board(int width, int height)
        {
            ConstructBoard(width, height);
        }

        private void ConstructBoard(int width, int height)
        {
            Tiles = new Tile[width, height];

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    Tiles[row, column] = new Tile(1, 1);
                }
            }
        }

        public Tile GetTile(int xPosition, int yPosition)
        {
            return Tiles[yPosition-1, xPosition-1];
        }

        public void AddUnit(Unit unit, int xPosition, int yPosition)
        {
            GetTile(xPosition, yPosition).AddUnit(unit);
        }

        public void RemoveUnit(Unit unit, int xPosition, int yPosition)
        {
            GetTile(xPosition, yPosition).RemoveUnit(unit);
        }

        public void RemoveUnits(int xPosition, int yPosition)
        {
            GetTile(xPosition, yPosition).RemoveUnits();
        }

        public List<Unit> GetUnits(int xPosition, int yPosition)
        {
            return GetTile(xPosition, yPosition).units;
        }
    }
}
