using Kurier.Model;
using System;

namespace Kurier
{
	class Program
	{
		static void Main(string[] args)
		{
			WyslijPaczke(CountryCode.GB);

			PokazListeKrajow();

			Console.ReadKey();
		}


		static bool WyslijPaczke(CountryCode countryCode)
		{
			var kurier = new Model.Kurier();
			var service = kurier.ZnajdzSerwisKtoryWysylaDo(countryCode);
			if (service != null)
			{
				service.Send();
				return true;
			}

			Console.WriteLine($"Kurier nie wysyla do kraju {countryCode}");
			return false;
		}

		static void PokazListeKrajow()
		{
			MojKurier mojKurier = new MojKurier();

			// Lista krajów w ktorych serwis funkcjionuje
			CountryCode[] lista = mojKurier[Services.Standard];
			foreach (var kraj in lista)
			{
				Console.WriteLine(kraj);
			}

			// Lista serwiow obslugiwanych w kraju
			Services[] serwisy = mojKurier[CountryCode.ES];
			foreach (var serwis in serwisy)
			{
				Console.WriteLine(serwis);
			}
		}
	}
}
