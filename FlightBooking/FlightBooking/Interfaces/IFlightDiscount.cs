using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FlightBooking.Model.Interfaces
{
	public interface IFlightDiscount
	{
		public void CreateNewDiscount()
		{
		}


		decimal Amount { get; }
		bool CanApply(Flight flight);

		bool DoCriteriaMatch(Flight flight);

	}
}
