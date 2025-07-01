using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverControl.Domain.Entities
{
    public class Plateau
    {
        public int MaxX { get; }
        public int MaxY { get; }
        private readonly HashSet<Position> _occupiedPositions = new();

        public Plateau(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsValidPosition(Position pos) =>
            pos.X >= 0 && pos.Y >= 0 && pos.X <= MaxX && pos.Y <= MaxY;

        public bool IsOccupied(Position pos) => _occupiedPositions.Contains(pos);

        public void Occupy(Position pos) => _occupiedPositions.Add(pos);
        public void Vacate(Position pos) => _occupiedPositions.Remove(pos);
    }
}
