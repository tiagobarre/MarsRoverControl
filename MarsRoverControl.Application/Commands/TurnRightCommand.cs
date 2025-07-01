using MarsRoverControl.Domain.Entities;
using MarsRoverControl.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverControl.Application.Commands
{
    public class TurnRightCommand : ICommand
    {
        public void Execute(Rover rover, Plateau plateau)
        {
            rover.UpdateDirection(rover.Direction switch
            {
                Direction.N => Direction.E,
                Direction.E => Direction.S,
                Direction.S => Direction.W,
                Direction.W => Direction.N,
                _ => rover.Direction
            });
        }
    }
}
