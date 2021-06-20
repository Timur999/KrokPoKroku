using System;

namespace Kurier.Model
{
	public class Service
	{
		public Services Name { get; set; }
		public CountryCode[] DestinationCountries { get; set; }

		public void Send()
		{
			Console.WriteLine($"Wysłano paczke serwisem {Name}");
		}
	}

	public enum Services
	{
		Standard,
		Express
	}

	public enum CountryCode
	{
		PL,
		DE,
		IT,
		GB,
		ES
	}
}
