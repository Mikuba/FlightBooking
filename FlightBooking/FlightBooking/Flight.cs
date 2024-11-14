using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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

		public List<IFlightDiscount> Discounts { get; set; }

		public Flight(string flightId, string fromAirportCode, string toAirportCode, DateTime flightDateTime, decimal price, DateTime travellerBirthDate
		)
		{
			FlightId = flightId;
			FromAirportCode = fromAirportCode;
			ToAirportCode = toAirportCode;
			FlighDateTime = flightDateTime;
			Price = price;
			TravellerBirthDate = travellerBirthDate;
			Discounts = new List<IFlightDiscount>();
		}


		internal void ApplyDiscount(IFlightDiscount discount)
		{
			if (discount.CanApply(this))
			{
				Price = Price - discount.Amount;
				Discounts.Add(discount);
			}
		}

		internal void Validate()
		{
			if (!Regex.Match(FlightId.ToUpper(), @"^[A-Z]{3}\d{5}[A-Z]{3}$").Success)
			{
				throw new Exception("Flight number is not in correct format");
			}

			if (FlighDateTime < DateTime.Today)
			{
				throw new Exception("FLights in the past are not allowed");
			}

			if (TravellerBirthDate > DateTime.Today)
			{
				throw new Exception("Traveller not born yet");
			}

			//Validate airport codes 

		}

	}
}
