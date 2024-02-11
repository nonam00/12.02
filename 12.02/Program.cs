using _12._02;
using System.Xml.Serialization;

List<Book> books =
[
	new Book
	{
		Title = "Crime and Punishment",
		Author = new Author
		{
			FirstName = "Fyodor",
			LastName = "Dostoevsky"
		},
		Publisher = new Publisher
		{
			Title = "Esmo",
			City = "Moscow"
		}
	},
	new Book
	{
		Title = "Demian",
		Author = new Author
		{
			FirstName = "Hermann",
			LastName = "Hesse"
		},
		Publisher = new Publisher
		{
			Title = "Hornbook",
			City = "Saint Petersburg"
		}
	}
];

XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
{
	serializer.Serialize(fs, books);
}

Console.WriteLine($"Текст сознанного XML файла\n\n" +
	$"{File.ReadAllText("books.xml")}\n");

XmlSerializer deserializer = new XmlSerializer(typeof(List<Company>));

using (FileStream fs = new FileStream("companies.xml", FileMode.OpenOrCreate))
{
	List<Company>? companies = (List<Company>?)deserializer.Deserialize(fs);

	Console.WriteLine("Данные о компаниях, полученные после десериализации\n");

	if(companies is not null)
	{
		foreach (var item in companies)
		{
			Console.WriteLine(item);
		}
		Console.WriteLine();
	}
}