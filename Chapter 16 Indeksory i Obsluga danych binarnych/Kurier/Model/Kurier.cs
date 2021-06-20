using System.Linq;

namespace Kurier.Model
{
	class Kurier
	{
		private Service[] services;

		public Kurier()
		{
			var Standard = new Service()
			{ Name = Services.Standard, DestinationCountries = new CountryCode[] { CountryCode.DE, CountryCode.ES } };
			var Express = new Service()
			{ Name = Services.Express, DestinationCountries = new CountryCode[] { CountryCode.PL, CountryCode.ES, CountryCode.GB } };

			services = new Service[] { Standard, Express };
		}

		public Service ZnajdzSerwisKtoryWysylaDo(CountryCode countryCode)
		{
			// Wyszykaj z tablicy
			var szukanySerwis = services.FirstOrDefault(x => x.DestinationCountries.Contains(countryCode));

			return szukanySerwis;
		}
	}
}
