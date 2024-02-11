namespace _12._02
{
	public class Company
	{
		public long СompanyId { get; set; }
		public string Name { get; set; }
		public string ShortName { get; set; }
		public string NameOther { get; set; } = "No other name";
		public string? Address { get; set; }
		public string? Country { get; set; }
		public Phone Phone { get; set; }
		public string? Email { get; set; }
		public string? Url { get; set; }
		public string? WorkingTime { get; set; }
		public override string ToString() =>
			$"Company ID: {СompanyId}\n" +
			$"Name: {Name}\n" +
			$"Shortname: {ShortName}\n" +
			$"Other name:  {NameOther}\n" +
			$"Address: {Address}\n" +
			$"Country: {Country}\n" +
			$"\nPhone:\n{Phone}\n" +
			$"Email: {Email}\n" +
			$"URL: {Url}\n" +
			$"Working Time: {WorkingTime}\n\n";
	}

	public class Phone
	{
		public string Ext { get; set; } = "No Ext";
		public string Type { get; set; }
		public string Number { get; set; }
		public string Info { get; set; } = "No Info";
		public override string ToString() =>
			$"Ext: {Ext}\n" +
			$"Type: {Type}\n" +
			$"Number: {Number}\n" +
			$"Info: {Info}\n";
	}
}
