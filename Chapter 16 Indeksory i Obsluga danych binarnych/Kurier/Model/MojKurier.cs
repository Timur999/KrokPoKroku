using System.Linq;

namespace Kurier.Model
{
	class MojKurier
	{
		private Service[] _services;

		public MojKurier()
		{
			var Standard = new Service
			{ Name = Services.Standard, DestinationCountries = new CountryCode[] { CountryCode.DE, CountryCode.ES } };
			var Express = new Service
			{ Name = Services.Express, DestinationCountries = new CountryCode[] { CountryCode.PL, CountryCode.ES, CountryCode.GB } };

			_services = new Service[] { Standard, Express };
		}

		public CountryCode[] this[Services serviceName]
		{
			get { return _services.FirstOrDefault(x => x.Name.Equals(serviceName))?.DestinationCountries; }
		}

		public Services[] this[CountryCode countryCode]
		{
			get { return _services.Where(x => x.DestinationCountries.Contains(countryCode)).Select(x => x.Name).ToArray(); }
		}

		/*private Services[] GetAllowedServicesInCountry(CountryCode countryCode)
		{
			_

		}*/
	}
}
