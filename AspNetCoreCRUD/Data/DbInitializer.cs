using AspNetCoreCRUD.Models;
using System;
using System.Linq;

namespace AspNetCoreCRUD.Data
{
    public class DbInitializer
    {
        public static void Initialize(EntityContext context)
        {
            context.Database.EnsureCreated();

            if (context.Clients.Any())
            {
                return;  
            }

            Founder[] founders;
            Client[] clients;                        

            clients = new Client[]
            {
                new Client
                {
                    IdentificationNumber = "123456789123",
                    CompanyName = "ООО Привет Андрей",
                    Type = CompanyType.LegalEntity,
                    DateAdd = DateTime.Now.Date,
                    DateUpdate = DateTime.Now.Date,
                }
            };

            foreach (var client in clients)
            {
                context.Clients.AddRange(client);
            }
            context.SaveChanges();

            founders = new Founder[]
            {
                new Founder
                {
                    IdentificationNumber = "123456789987",
                    FullName = "Захаров Петр Иванович",
                    DateAdd = DateTime.Now.Date,
                    DateUpdate = DateTime.Now.Date,
                    ClientID = clients.Single(f => f.IdentificationNumber == "123456789123").ClientID
                },

                new Founder
                {
                    IdentificationNumber = "123456733333",
                    FullName = "Иванов Андрей Борисович",
                    DateAdd = DateTime.Now.Date,
                    DateUpdate = DateTime.Now.Date,
                    ClientID = clients.Single(f => f.IdentificationNumber == "123456789123").ClientID
                }
            };

            foreach (var founder in founders)
            {
                context.Founders.AddRange(founder);
            }
            context.SaveChanges();

        }
    }
}
