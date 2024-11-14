using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightBooking.Model.Interfaces;

namespace FlightBooking.Model
{
	public class FlightDiscount : IFlightDiscount
	{
		public FlightDiscount()
		{

		}

		private decimal amount = 5;

		public decimal Amount => amount;

		public bool CanApply(Flight flight)
		{
			return IsPriceAboveMinimum(flight) && DoCriteriaMatch(flight);
		}

		/// <summary>
		/// Override this method for each discount
		/// </summary>
		/// <param name="parms"></param>
		/// <returns></returns>
		public virtual bool DoCriteriaMatch(Flight flight)
		{
			return true;
		}

		public bool IsPriceAboveMinimum(Flight? flight)
		{
			return flight.Price - amount >= 20;
		}
	}
}
