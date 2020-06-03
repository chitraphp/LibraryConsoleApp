using ConsoleTables;
using LibraryConsoleApp.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LibraryConsoleApp
{
    class UserInputHandler
    {
        private ILibraryCommand[] m_commands = new ILibraryCommand[] { new AddCommand(), new ExitCommand() };

        public UserInputHandler(Library library)
        {
            library.BookAdded += OnBookAdded;
        }

        public ILibraryCommand GetCommand()
        {
            while (true)
            {
                Console.Clear();
                var bookList = Library.bookDictionary.Values.ToList();
                var table = ConsoleTable.From(bookList);
                Console.Write(table);
                Console.WriteLine("What do you want to do?: ");

                for (int i = 0; i < m_commands.Length; i++)
                {
                    Console.WriteLine($"{i + 1}: {m_commands[i].Description}");
                }

                Console.Write("Enter a command No.: ");
                string input = Console.ReadLine();

                int index;
                if (int.TryParse(input, out index) && index > 0 && index <= m_commands.Length)
                {
                    return m_commands[index - 1];
                }

            }
        }

        private void OnBookAdded(object sender, AddedBookToLibEventArgs e)
        {
            Console.WriteLine("\nThe book '" + e.Title + "' has been added to the library");
            Console.WriteLine(e.Title);
            Thread.Sleep(6000);
            
        }


    }
}
