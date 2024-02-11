using System.Xml.Serialization;

namespace _12._02
{
	public static class Tasks
	{
		public static void Task1()
		{
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

			Console.WriteLine($"Текст созданного XML файла\n\n" +
				$"{File.ReadAllText("books.xml")}\n");
		}

		public static void Task2()
		{
			XmlSerializer deserializer = new XmlSerializer(typeof(List<Company>));

			string fileName = "companies.xml";

			if (File.Exists(fileName))
			{
				File.Create(fileName).Close();
				File.WriteAllText(fileName, XmlText());
			}

			using (FileStream fs = new FileStream("companies.xml", FileMode.Open))
			{
				List<Company>? companies = (List<Company>?)deserializer.Deserialize(fs);

				Console.WriteLine("Данные о компаниях, полученные после десериализации\n");

				if (companies is not null)
				{
					foreach (var item in companies)
					{
						Console.WriteLine(item);
					}
					Console.WriteLine();
				}
			}
		}
		
		// Исправленная версия XML файла
		// Изменил имена элементов
		// Убрал лишний телефон
		// Другим решением было бы обвернуть оба телефона в ArrayOfPhone и создать соответстующую коллекцию в классе Сompany
		private static string XmlText() =>
			"<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n" +
			"<ArrayOfCompany>\r\n" +
			"\t<Company>\r\n" +
			"\t\t<СompanyId>770704034</СompanyId>\r\n" +
			"\t\t<Name>Якорь</Name>\r\n" +
			"\t\t<ShortName>Якорь</ShortName>\r\n" +
			"\t\t<Address>город Екатеринбург, просп. Ленина, 101, а</Address>\r\n" +
			"\t\t<Country>Россия</Country>\r\n" +
			"\t\t<Phone>\r\n" +
			"\t\t\t<Number>+7 (343) 375-13-99</Number>\r\n" +
			"\t\t\t<Ext>555</Ext>\r\n" +
			"\t\t\t<Info>секретарь</Info>\r\n" +
			"\t\t\t<Type>phone</Type>\r\n" +
			"\t\t</Phone>\r\n" +
			"\t\t<Email>info@yakor-anapa.ru</Email>\r\n" +
			"\t\t<Url>http://www.yakor-anapa.ru</Url>\r\n" +
			"\t\t<WorkingTime>ежедн. 10:00-21:00</WorkingTime>\r\n" +
			"\t</Company>\r\n" +
			"\t<Company>\r\n " +
			"\t\t<СompanyId>7707040070</СompanyId>\r\n" +
			" \t\t<Name>Якорьбанк</Name>\r\n" +
			" \t\t<ShortName>Якорьбанк</ShortName>\r\n" +
			" \t\t<NameOther>Якорьбанк, платёжное устройство</NameOther>\r\n" +
			" \t\t<Address>Россия, Республика Татарстан, Зеленодольский район, село Нурлаты, улица Гагарина, 46</Address>\r\n" +
			" \t\t<Phone>\r\n \t\t\t<Number>+7 (800) 999-99-90</Number>\r\n" +
			" \t\t\t<Ext/>\r\n \t\t\t<Info/>\r\n\t\t\t<Type>phone</Type>\r\n" +
			" \t\t</Phone>\r\n \t\t<Url>http://www.yakorbank.ru/</Url>\r\n" +
			" \t\t<WorkingTime>будни 8:30-18:00, сб 9:00-14:30</WorkingTime>\r\n" +
			" \t</Company>\r\n" +
			"</ArrayOfCompany>";

	}
}
