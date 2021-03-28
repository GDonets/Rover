using Rover.DataModels;
using System;
using System.Collections.Generic;

namespace Rover.Commands
{
    public class MovementCommand : ICommand
    {
        private IRover _rover;
        private Queue<char> _movements;

        public MovementCommand(IRover rover, string message)
        {
            _rover = rover;

            foreach (var m in message.ToCharArray()) 
            {
                _movements.Enqueue(m);
            }
        }

        public CommandResultDto Result { get; private set; }

        public void Execute()
        {
            while (_movements.Count > 0)
            {
                var movement = _movements.Dequeue();
                ProcessMovement(movement);
            }

            Result = new CommandResultDto(CommandResult.Success, string.Empty);
        }

        private void ProcessMovement(char movement)
        {
            switch (movement)
            {
                case char c when c == 'R':
                    _rover.TurnRight();
                    break;
                case char c when c == 'R':
                    _rover.TurnLeft();
                    break;
                case char c when c == 'M':
                    var res = _rover.TryMove();
                    if (res != RoverMovementResult.Success)
                    {
                        Result = new CommandResultDto(CommandResult.Fail, $"Movement failed. Reason: {res:G}");
                    }
                    break;
                default:
                    throw new ArgumentException($"Incorrect command literal {movement} at position {_movements.Count + 1}");
            }
        }
    }
}
