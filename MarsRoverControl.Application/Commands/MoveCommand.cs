using MarsRoverControl.Domain.Entities;
using MarsRoverControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverControl.Application.Commands
{
    public class MoveCommand : ICommand
    {
        public void Execute(Rover rover, Plateau plateau)
        {
            Position newPos = rover.Direction switch
            {
                Direction.N => new Position(rover.Position.X, rover.Position.Y + 1),
                Direction.S => new Position(rover.Position.X, rover.Position.Y - 1),
                Direction.E => new Position(rover.Position.X + 1, rover.Position.Y),
                Direction.W => new Position(rover.Position.X - 1, rover.Position.Y),
                _ => rover.Position
            };

            if (!plateau.IsValidPosition(newPos) || plateau.IsOccupied(newPos))
                return;

            plateau.Vacate(rover.Position);
            rover.UpdatePosition(newPos);
            plateau.Occupy(newPos);
        }
    }
}
