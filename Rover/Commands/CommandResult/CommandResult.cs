using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover.DataModels
{
    public enum CommandResult 
    { 
        Unknown = 0,
        Success,
        Fail
    }

    public class CommandResultDto
    {
        public CommandResultDto(CommandResult result, string message)
        {
            Result = result;
            Message = message;
        }

        public CommandResult Result { get; private set; }
        public string Message { get; private set; }

    }
}
