using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
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
			//ValidateFlight
			Flights.Add(flight);
		}

		public void AddDiscountToFlight(string flightId, IFlightDiscount discount)
		{
			Flight? flight = Flights.FirstOrDefault(x => x.FlightId == flightId);
			if (flight != null)
			{
				if (discount.CanApply(flight))
				{
					flight.ApplyDiscount(discount, tenantGroup == TenantGroupEnum.GroupA);
				}
			}
		}

		public void Purchase(string flightId)
		{
			Flight? flight = Flights.FirstOrDefault(x => x.FlightId == flightId);
			if (flight == null)
			{
				throw new Exception("No flight with this number");
			}
			//Save(flight)

		}


	}
}
