using System;
using System.Collections.Generic;
using System.Text;

namespace Command_Pattern
{
    public class ModifyPrice
    {
        private readonly List<ICommand> invokedCommands;

        private ICommand command;

        public ModifyPrice()
        {
            invokedCommands = new List<ICommand>();
        }

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void Invoke()
        {
            invokedCommands.Add(command);
            command.ExecuteAction();
        }
    }
}
