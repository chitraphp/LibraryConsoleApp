using LibraryConsoleApp.util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LibraryConsoleApp.services
{
	class AddCommand : ILibraryCommand
	{
		//public event EventHandler<AddedBookToLibEventArgs> BookAdded;
		public string Description => "Add Book";

		public void Execute(Library library)
		{
			Console.WriteLine("Add Book details");
			Console.WriteLine("Enter book title: >>>>>>>>>>>");
			string title=Console.ReadLine();
			Console.WriteLine("Enter Book author: >>>>>>>>>>");
			string author = Console.ReadLine();
			Console.WriteLine("Enter Book publisher: >>>>>>>>>>");
			string publisher = Console.ReadLine();
			Console.WriteLine("Enter Book price: >>>>>>>>>>");
			decimal price;
			decimal.TryParse(Console.ReadLine(),out price);

			Book book = new Book(author, price, publisher, title);
			library.AddBook(book);
			AddDataToFile.WriteToFile2(book);
			//RaiseBookAddedEvent(new AddedBookToLibEventArgs(book.Title));
			

		}

		//protected virtual void RaiseBookAddedEvent(AddedBookToLibEventArgs eventArgs)
		//{
		//	BookAdded?.Invoke(this, eventArgs);
		//	Console.WriteLine("adddd");
		//}
	}
}
