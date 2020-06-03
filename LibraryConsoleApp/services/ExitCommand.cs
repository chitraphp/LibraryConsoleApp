using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryConsoleApp.services
{
	class ExitCommand:ILibraryCommand
	{
        public string Description
        {
            get
            {
                return "Exit";
            }
        }

        public void Execute(Library library)
        {
            Console.WriteLine("Exit Command");
            Environment.Exit(0);
            
        }
    }
}
