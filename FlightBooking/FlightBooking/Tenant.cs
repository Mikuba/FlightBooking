using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FlightBooking.Model;
using FlightBooking.Model.Interfaces;

namespace FlightBooking
{
	internal class Tenant
	{
		private TenantGroupEnum tenantGroup { get; set; }
		List<Flight> Flights { get; set; }

		public Tenant(TenantGroupEnum tGroup)
		{
			tenantGroup = tGroup;
			Flights = new List<Flight>();
		}

		public void AddFlight(Flight flight)
		{
			try
			{
				flight.Validate();
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
			Flights.Add(flight);
		}


		public void Purchase(string flightId)
		{
			Flight? flight = Flights.FirstOrDefault(x => x.FlightId.Trim() == flightId.Trim());
			if (flight == null)
			{
				throw new Exception("No flight with this number");
			}

			if (tenantGroup == TenantGroupEnum.GroupA)
			{
				//clear list of discounts so they do not get saved
				flight.Discounts = new List<IFlightDiscount>();
			}
			//Calll to API tp save a flight

			//Save(flight)
			//The discounts are recognised by typeof(discount) which then can be mapped to database value 
		}
	}
}
