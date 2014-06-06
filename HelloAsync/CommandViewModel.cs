using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace HelloAsync
{
    public class CommandViewModel: ViewModel
    {
        public CommandViewModel(string displayName, ICommand command)
        {
            Contract.Assert(command != null, String.Format("The argument {0} is null.", "command"));
            this.DisplayName = displayName;
            this.Command = command;
        }

        public string DisplayName { get; protected set; }

        public ICommand Command { get; protected set; }
    }
}
