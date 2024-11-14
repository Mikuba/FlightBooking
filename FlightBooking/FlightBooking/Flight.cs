using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FlightBooking.Model;
using FlightBooking.Model.Interfaces;
using Microsoft.VisualBasic;

namespace FlightBooking
{
	public class Flight
	{
		public string FlightId { get; set; }
		public string FromAirportCode { get; set; }
		public string ToAirportCode { get; set; }
		public DateTime FlighDateTime { get; set; }
		public decimal Price { get; set; }

		public string TravellerFIrstName { get; set; }
		public string TravellerLastName { get; set; }
		public DateTime TravellerBirthDate { get; set; }

		public IEnumerable<FlightDiscount> Discounts { get; set; }

		public Flight(string flightId, string fromAirportCode, string toAirportCode, DateTime flightDateTime, decimal price, DateTime travellerBirthDate
		)
		{
			FlightId = flightId;
			FromAirportCode = fromAirportCode;
			ToAirportCode = toAirportCode;
			FlighDateTime = flightDateTime;
			Price = price;
			TravellerBirthDate = travellerBirthDate;
			Discounts = new List<FlightDiscount>();
		}


		internal void ApplyDiscount(IFlightDiscount discount, bool saveDiscountCriteria)
		{
			Price = Price - discount.Amount;
			if (saveDiscountCriteria)
				Discounts.Append(discount);

		}
	}
}
