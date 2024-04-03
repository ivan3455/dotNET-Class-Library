using System;
using System.Buffers.Binary;
using System.Collections;
using System.Reflection;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Демонстрація роботи розглянутих API .NET Standard
        ConvertIntegerToBytes();
        ArrayListExample();
        GetAssemblyInformation();
        FilterFruits();
        CreateXmlDocument();
    }

    static void ConvertIntegerToBytes()
    {
        int number = 123456789; // Ціле число для конвертації

        // Конвертація int у байтовий масив
        byte[] bytes = new byte[sizeof(int)];
        BinaryPrimitives.WriteInt32BigEndian(bytes, number);

        Console.WriteLine("Integer converted to bytes:");
        foreach (var b in bytes)
        {
            Console.Write(b + " ");
        }
        Console.WriteLine();

        // Конвертація байтового масиву у int
        int convertedNumber = BinaryPrimitives.ReadInt32BigEndian(bytes);
        Console.WriteLine("Bytes converted back to integer: " + convertedNumber);
    }

    static void ArrayListExample()
    {
        // Створення нового об'єкта ArrayList (динамічний масив об'єктів)
        ArrayList arrayList = new ArrayList();

        // Додавання елементів до ArrayList
        arrayList.Add("Apple");
        arrayList.Add("Banana");
        arrayList.Add("Orange");

        // Виведення всіх елементів ArrayList
        Console.WriteLine("Elements in ArrayList:");
        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }
    }

    static void GetAssemblyInformation()
    {
        // Отримання посилання на поточну збірку
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Отримання інформації про збірку
        string assemblyName = assembly.GetName().Name;
        Version assemblyVersion = assembly.GetName().Version;
        string location = assembly.Location;

        // Виведення інформації про збірку на консоль
        Console.WriteLine("Assembly Name: " + assemblyName);
        Console.WriteLine("Assembly Version: " + assemblyVersion);
        Console.WriteLine("Assembly Location: " + location);
    }

    static void FilterFruits()
    {
        // Створення списку рядків
        List<string> fruits = new List<string> { "Apple", "Banana", "Orange", "Grapes", "Kiwi" };

        // Вибірка тільки тих фруктів, які починаються з літери 'A'
        var result = fruits.Where(fruit => fruit.StartsWith("A"));

        // Виведення результату
        Console.WriteLine("Fruits that start with 'A':");
        foreach (var fruit in result)
        {
            Console.WriteLine(fruit);
        }
    }

    static void CreateXmlDocument()
    {
        // Створення нового XML-документу
        XmlDocument doc = new XmlDocument();

        // Створення вузла кореня
        XmlElement root = doc.CreateElement("Books");
        doc.AppendChild(root);

        // Додавання елементів книг до XML-документу
        AddBook(doc, root, "Harry Potter", "J.K. Rowling", 1997);
        AddBook(doc, root, "The Lord of the Rings", "J.R.R. Tolkien", 1954);

        // Збереження XML-документу в файл
        doc.Save("books.xml");

        Console.WriteLine("XML document created and saved successfully.");
    }

    static void AddBook(XmlDocument doc, XmlElement root, string title, string author, int year)
    {
        // Створення вузла книги
        XmlElement book = doc.CreateElement("Book");
        root.AppendChild(book);

        // Додавання дочірніх елементів до вузла книги
        XmlElement titleElement = doc.CreateElement("Title");
        titleElement.InnerText = title;
        book.AppendChild(titleElement);

        XmlElement authorElement = doc.CreateElement("Author");
        authorElement.InnerText = author;
        book.AppendChild(authorElement);

        XmlElement yearElement = doc.CreateElement("Year");
        yearElement.InnerText = year.ToString();
        book.AppendChild(yearElement);
    }
}
