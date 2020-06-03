using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryConsoleApp.services
{
	public interface ILibraryCommand
	{
		string Description { get; }
		void Execute(Library library);
	}
}

