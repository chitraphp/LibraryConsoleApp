using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace LibraryConsoleApp.util
{
	class AddDataToFile
	{
		public static string FILE_PATH = "C:\\chitra\\Sollers\\booksList.txt";
		public static string FILE_PATH1 = "C:\\chitra\\Sollers\\books.json";
		public static string path = "C:\\chitra\\Sollers\\books2.json";

		public static void WriteToFile()
		{
			try
			{
				//Pass the filepath and filename to the StreamWriter Constructor
				StreamWriter sw = new StreamWriter("C:\\chitra\\Sollers\\booksList.txt");

				//Write a line of text
				sw.WriteLine("Hello World!!");

				//Write a second line of text
				sw.WriteLine("From the StreamWriter class");

				//Close the file
				sw.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}
			finally
			{
				Console.WriteLine("Executing finally block.");
			}
		}

		public static void ReadFromFile()
		{
			string line;
			try
			{
				//Pass the file path and file name to the StreamReader constructor
				StreamReader sr = new StreamReader("C:\\chitra\\Sollers\\booksList.txt");

				//Read the first line of text
				line = sr.ReadLine();

				//Continue to read until you reach end of file
				while (line != null)
				{
					//write the lie to console window
					Console.WriteLine(line);
					//Read the next line
					line = sr.ReadLine();
				}
				

				//close the file
				sr.Close();
				//Console.ReadLine();
			}
			catch (Exception e)
			{
				Console.WriteLine("Exception: " + e.Message);
			}
			finally
			{
				Console.WriteLine("Executing finally block.");
			}
			
		}

		public static void WriteToFileJson(Book book)
		{
			//string json = JsonConvert.SerializeObject(book);
			//File.WriteAllText(@"C:\\chitra\\Sollers\\books.json", json);
			TextWriter writer = null;
			try
			{
				File.Open(FILE_PATH1, FileMode.Create);
				var contentsToWriteToFile = JsonConvert.SerializeObject(book);
				writer = new StreamWriter("C:\\chitra\\Sollers\\books.json", true);
				writer.Write(contentsToWriteToFile);
			}
			finally
			{
				if (writer != null)
					writer.Close();
				
			}

		}
		public static Book ReadFromfileJson()
		{
			TextReader reader = null;
			try
			{
				reader = new StreamReader(FILE_PATH1);
				var fileContents = reader.ReadToEnd();
				return (Book)JsonConvert.DeserializeObject(fileContents);
			}
			finally
			{
				if (reader != null)
					reader.Close();
			}

		}

		public static void WriteToFile2( Book book)
		{
			FileStream F = new FileStream(path, FileMode.OpenOrCreate | FileMode.Append,
			
				FileAccess.ReadWrite);
			try
			{
				
				
				var jsonToWrite = JsonConvert.SerializeObject(book, Formatting.Indented);
				//F.WriteAsync(jsonToWrite);
				using (var writer = new StreamWriter(path,true))
				{
					writer.Write(jsonToWrite);
					writer.Close();
				}

			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}			
		}

		public static dynamic ReadFromJsonFile2()
		{
			dynamic books = null;
			try
			{
				//string jsonFromFile = String.Empty;
				//using (var reader = new StreamReader(path))
				//{
				//	jsonFromFile = reader.ReadToEnd();
				//	var x = jsonFromFile.ToList();

				//	reader.Close();
				//}

				//richTextBoxReadJson.Text = jsonFromFile;

				books = JsonConvert.DeserializeObject<List<Book>>(File.ReadAllText(path));

				//books = (List<Book>)JsonConvert.DeserializeObject<List<Book>>(jsonFromFile);
				//books = JsonConvert.DeserializeObject<Book>(jsonFromFile);

				
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return books;
		}
	}
}
