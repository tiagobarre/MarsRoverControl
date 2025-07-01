using MarsRoverControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverControl.Application.Commands
{
    public interface ICommand
    {
        void Execute(Rover rover, Plateau plateau);
    }
}
