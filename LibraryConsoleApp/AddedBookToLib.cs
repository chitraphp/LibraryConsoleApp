using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryConsoleApp
{
	public class AddedBookToLibEventArgs:EventArgs
	{
        public  AddedBookToLibEventArgs(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
