using ConsoleTables;
using LibraryConsoleApp.services;
using LibraryConsoleApp.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LibraryConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
            try
            {
                //AddDataToFile.WriteToFile();
                
                Library library = new Library();
                //var table = new ConsoleTable("Title", "Author", "Price");
                var bookList = Library.bookDictionary.Values.ToList();
                var table = ConsoleTable.From(bookList);
                Console.Write(table);

                //dynamic books = AddDataToFile.ReadFromJsonFile2();
                //var books2 = books.ToList();
                //Console.WriteLine(book.Author);
                //foreach (dynamic book in books)
                //{
                //    Console.WriteLine("Hello");
                //    Console.WriteLine(book.Author);
                //}

                UserInputHandler inputHandler = new UserInputHandler(library);
                
                Console.WriteLine("Welcome to the Library");
                Console.Write("Press Enter to Continue...");
                Console.ReadLine();

                ILibraryCommand command = null;
                do
                {
                    //Console.Clear();                    
                    command = inputHandler.GetCommand();
                    command.Execute(library);
                    
                    Thread.Sleep(1000);

                } while (!(command is ExitCommand));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                
            }
            //Console.WriteLine(book.Author);

            Console.WriteLine("Hello");
            Console.WriteLine("\nPress Enter to Exit...");
            Console.ReadLine();
        }
	}
}
