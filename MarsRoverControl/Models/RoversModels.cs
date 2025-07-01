using MarsRoverControl.API.DTOs;
using MarsRoverControl.Application.Parser;
using MarsRoverControl.Domain.Entities;
using MarsRoverControl.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace MarsRoverControl.API.Models
{
    public class RoversModels
    {
        private static Plateau _plateau = new(5, 5);

        public static string ExecuteRovers(RoverCommandRequest request)
        {
            if (!Enum.TryParse<Direction>(request.Direction, out var dir))
                return "Invalid direction";

            var startPos = new Position(request.StartX, request.StartY);

            if (!_plateau.IsValidPosition(startPos) || _plateau.IsOccupied(startPos))
                return "Position invalid or occupied";

            var rover = new Rover(startPos, dir);
            _plateau.Occupy(startPos);

            var commands = CommandParser.Parse(request.Commands);
            foreach (var cmd in commands)
                cmd.Execute(rover, _plateau);

            return $"{rover.Position.X} {rover.Position.Y} {rover.Direction}";
        }
    }
}
