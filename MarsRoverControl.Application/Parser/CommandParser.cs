using MarsRoverControl.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverControl.Application.Parser
{
    public static class CommandParser
    {
        public static List<ICommand> Parse(string commandString)
        {
            var commands = new List<ICommand>();

            foreach (char cmd in commandString)
            {
                commands.Add(cmd switch
                {
                    'L' => new TurnLeftCommand(),
                    'R' => new TurnRightCommand(),
                    'M' => new MoveCommand(),
                    _ => throw new ArgumentException($"Invalid command: {cmd}")
                });
            }

            return commands;
        }
    }
}
