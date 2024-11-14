// See https://aka.ms/new-console-template for more information

using FlightBooking;
using FlightBooking.Model;
using FlightBooking.Model.FlightDiscounts;

Tenant tenant = new Tenant(TenantGroupEnum.GroupA);
Flight flight = new Flight("KLM12345ABC", "WAW", "AKL", new DateTime(2024, 11, 28, 11, 23, 0),
	30, new DateTime(1976, 11, 28));
tenant.AddFlight(flight);

FlightDiscount discount1 = new FlightDiscountThursdayToAfrica();
FlightDiscount discount2 = new FlightDiscountBirthday();

tenant.AddDiscountToFlight("KLM12345ABC", discount1);
tenant.AddDiscountToFlight("KLM12345ABC", discount2);
tenant.Purchase("KLM12345ABC ");



