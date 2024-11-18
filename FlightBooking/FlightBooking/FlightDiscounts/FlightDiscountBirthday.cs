using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Model.FlightDiscounts
{
	public class FlightDiscountBirthday : FlightDiscount
	{
		public override bool DoCriteriaMatch(Flight flight)
		{
			return flight.TravellerBirthDate.Month == flight.FlighDateTime.Month &&
				   flight.TravellerBirthDate.Day == flight.FlighDateTime.Day;
		}
	}
}
