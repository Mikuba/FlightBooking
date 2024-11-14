using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Model.FlightDiscounts
{
	public class FlightDiscountThursdayToAfrica : FlightDiscount
	{
		public override bool DoCriteriaMatch(Flight flight)
		{
			return flight.FlighDateTime.DayOfWeek == DayOfWeek.Thursday &&
				   Utils.IsAirportInAfrica(flight.ToAirportCode);

		}
	}
}
