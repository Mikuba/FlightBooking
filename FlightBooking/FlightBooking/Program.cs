// See https://aka.ms/new-console-template for more information

using FlightBooking;
using FlightBooking.Model;
using FlightBooking.Model.FlightDiscounts;

Tenant tenant = new Tenant(TenantGroupEnum.GroupA);
Flight flight = new Flight("KLM12345ABC", "WAW", "AKL", new DateTime(2024, 11, 28, 11, 23, 0),
	40, new DateTime(1976, 11, 28));
FlightDiscount discount1 = new FlightDiscountThursdayToAfrica();
FlightDiscount discount2 = new FlightDiscountBirthday();

flight.ApplyDiscount(discount1);
flight.ApplyDiscount(discount2);
tenant.AddFlight(flight);

tenant.Purchase("KLM12345ABC ");



