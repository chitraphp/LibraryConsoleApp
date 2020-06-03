using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryConsoleApp
{
	
	public class Library
	{
		public event EventHandler<AddedBookToLibEventArgs> BookAdded;
		//public string Name { get; set; }
		public static Dictionary<string, Book> bookDictionary;
		public Library()
		{
			//Name = name;
			bookDictionary = new Dictionary<string, Book>();
			bookDictionary.Add("story",new Book("chitra", 23, "xxxx", "story"));
		}
		
		public void AddBook(Book book)
		{
			bookDictionary.Add(book.Author, book);
			RaiseBookAddedEvent(new AddedBookToLibEventArgs(book.Title));
		}
		public void RemoveBook() { }
		protected virtual void RaiseBookAddedEvent(AddedBookToLibEventArgs eventArgs)
		{
			BookAdded?.Invoke(this, eventArgs);
			Console.WriteLine("Event has completed raised from library");
		}

	}
	[Serializable]
	public class Book
	{
		public Book(string author, decimal price, string publisher, string title)
		{
			Author = author;
			Price = price;
			Title = title;
			Publisher = publisher;

		}
		public string Author { get; set; }
		public string Title { get; set; }
		public string Publisher { get; set; }
		//public DateTime ReleaseDate { get; set; }
		public decimal Price { get; set; }
	}
}
