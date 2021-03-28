using Rover.DataModels;

namespace Rover.Commands
{
    public interface ICommand
    {
        CommandResultDto Result { get; }

        void Execute();
    }
}