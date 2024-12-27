using Microsoft.EntityFrameworkCore;

namespace webapiASP.Models
{
    public static class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            context.Database.Migrate();

            var prices = new[]
            {
                new Prices { ProgramCode = 123, MinutePrice = 1, ProgramName = "новости1" },
                new Prices { ProgramCode = 124, MinutePrice = 2, ProgramName = "новости2" },
                new Prices { ProgramCode = 125, MinutePrice = 3, ProgramName = "новости3" },
                new Prices { ProgramCode = 126, MinutePrice = 4, ProgramName = "новости4" },
                new Prices { ProgramCode = 127, MinutePrice = 5, ProgramName = "новости5" },
                new Prices { ProgramCode = 128, MinutePrice = 6, ProgramName = "новости6" },
                new Prices { ProgramCode = 129, MinutePrice = 7, ProgramName = "новости7" }
            };
            if (!context.Prices.Any())
            {
                context.Prices.AddRange(prices);
            }

            context.SaveChanges();
            var registrationPrograms = new[]
            {
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 123,
                    ProgramName = "новости1", Duration = 25 , Regularity = 5, Price = 500, Prices = prices[0]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 124,
                    ProgramName = "новости2", Duration = 25, Regularity = 5, Price = 600, Prices = prices[1]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 125,
                    ProgramName = "новости3", Duration = 25, Regularity = 5, Price = 700, Prices = prices[2]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 126,
                    ProgramName = "новости4", Duration = 25, Regularity = 5, Price = 800, Prices = prices[3]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 127,
                    ProgramName = "новости5", Duration = 25, Regularity = 5, Price = 900, Prices = prices[4]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 128,
                    ProgramName = "новости6", Duration = 35, Regularity = 5, Price = 1000, Prices = prices[5]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 129,
                    ProgramName = "новости7", Duration = 35, Regularity = 5, Price = 1500, Prices = prices[6]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 130,
                    ProgramName = "новости8", Duration = 35, Regularity = 5, Price = 1500, Prices = prices[0]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 131,
                    ProgramName = "новости9", Duration = 35, Regularity = 5, Price = 1500, Prices = prices[1]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 132,
                    ProgramName = "новости10", Duration = 35, Regularity = 15, Price = 1500, Prices = prices[2]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 133,
                    ProgramName = "новости11", Duration = 45, Regularity = 14, Price = 1500, Prices = prices[3]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 134,
                    ProgramName = "новости12", Duration = 45 , Regularity = 13, Price = 2000, Prices = prices[4]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 135,
                    ProgramName = "новости13", Duration = 45 , Regularity = 12, Price = 2000, Prices = prices[5]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 136,
                    ProgramName = "новости14", Duration = 45 , Regularity = 11, Price = 2000, Prices = prices[6]
                },
                new RegistrationProgram
                {
                    ProgramDate = new DateTime(2024, 12, 1), ProgramCode = 137,
                    ProgramName = "новости15", Duration = 45 , Regularity = 10, Price = 2000, Prices = prices[0]
                },
            };

            if (!context.RegistrationProgram.Any())
            {
                context.RegistrationProgram.AddRange(registrationPrograms);
            }

            context.SaveChanges();
            var users = new[]
            {
                new Persons { Login = "root", Password = "toor"},
            };
            if (!context.Users.Any())
            {
                context.Users.AddRange(users);
            }

            context.SaveChanges();
        }
    }
}