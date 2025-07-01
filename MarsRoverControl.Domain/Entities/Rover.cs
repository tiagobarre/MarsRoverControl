using MarsRoverControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverControl.Domain.Entities
{
    public class Rover
    {
        public Guid Id { get; } = Guid.NewGuid();
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        public Rover(Position startPosition, Direction startDirection)
        {
            Position = startPosition;
            Direction = startDirection;
        }

        public void UpdateDirection(Direction newDirection) => Direction = newDirection;
        public void UpdatePosition(Position newPosition) => Position = newPosition;
    }
}
