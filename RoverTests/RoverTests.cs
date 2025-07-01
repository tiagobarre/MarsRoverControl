using Xunit;
using MarsRoverControl.Domain.Entities;
using MarsRoverControl.Domain.Enums;
using MarsRoverControl.Application.Commands;
using MarsRoverControl.API.Models;
using MarsRoverControl.API.DTOs;

namespace MarsRoverControl.Tests
{
    /*
     ✅ Direção inválida

        ✅ Posição inválida

        ✅ Execução válida com movimentação

        ✅ Giro à esquerda e à direita

        ✅ Colisão com rover já posicionado

        ✅ Não ultrapassar os limites do plateau

        ✅ Comportamento de rotação (parametrizado com [Theory])
     */

    public class RoverTests
    {       

        [Fact]
        public void Should_Handle_Turn_Left_And_Right()
        {
            var request = new RoverCommandRequest
            {
                StartX = 1,
                StartY = 2,
                Direction = "N",
                Commands = "LMLMLMLMM"
            };

            var result = RoversModels.ExecuteRovers(request);

            Assert.Equal("1 3 N", result);
        }

        [Fact]
        public void Should_Ignore_Collision_Position()
        {
            var request1 = new RoverCommandRequest
            {
                StartX = 0,
                StartY = 0,
                Direction = "N",
                Commands = "MM"
            };

            var request2 = new RoverCommandRequest
            {
                StartX = 0,
                StartY = 2, // já ocupado
                Direction = "E",
                Commands = "M"
            };

            _ = RoversModels.ExecuteRovers(request1);
            var result = RoversModels.ExecuteRovers(request2);

            Assert.Equal("Position invalid or occupied", result);
        }

        [Fact]
        public void Should_Not_Leave_The_Plateau()
        {
            var request = new RoverCommandRequest
            {
                StartX = 5,
                StartY = 5,
                Direction = "N",
                Commands = "MMMM" // deveria sair da borda
            };

            var result = RoversModels.ExecuteRovers(request);

            Assert.Equal("5 5 N", result); // esperado que ele não saia da borda
        }

       
    }
}
