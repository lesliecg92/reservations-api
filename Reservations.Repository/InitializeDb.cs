using System;
using System.Collections.Generic;
using System.Linq;
using Reservations.Repository.Contexts;
using Reservations.Repository.Domain;

namespace Reservations.Repository
{
    public static class InitializeDb
    {

        public static void Seed(ReservationDbContext context)
        {
            if (context.Reservations.Any() && context.Contacts.Any())
            {
                return;
            }

            if (!context.ContactTypes.Any())
            {
                var contactTypes = new List<ContactType>
                {
                    new ContactType{Name = "Type 1"},
                    new ContactType{Name = "Type 2"},
                    new ContactType{Name = "Type 3"},
                    new ContactType{Name = "Type 4"},
                    new ContactType{Name = "Type 5"}
                };
                context.ContactTypes.AddRange(contactTypes);
                context.SaveChanges();
            }

            if (!context.Contacts.Any())
            {
                var contacts = new List<Contact>
                {
                    new Contact
                    {
                        BirthDate = DateTime.Parse("1992-12-22"),
                        ContactType = context.ContactTypes.FirstOrDefault(),
                        Name = "Dave",
                        PhoneNumber = "77985869",
                        Reservations = new List<Reservation>
                        {
                            new Reservation
                            {
                                CreationDate = DateTime.Now,
                                Destination = "Caribbean",
                                Description = "asmklasmdlask aldkmlaskmd alsmd lasmd lasdm alskdm",
                                IsFavorite = true,
                                Ranking = 5
                            },
                            new Reservation
                            {
                                CreationDate = DateTime.Now,
                                Destination = "Maldives",
                                Description = "asmklasmdlask aldkmlaskmd alsmd lasmd lasdm alskdm",
                                IsFavorite = false,
                                Ranking = 3
                            }
                        }
                    }
                };

                context.Contacts.AddRange(contacts);
            }
            else
            {
                var contact = context.Contacts.First();
                var reservations = new List<Reservation>
                {
                    new Reservation
                    {
                        CreationDate = DateTime.Now,
                        Destination = "Caribbean",
                        Description = "asmklasmdlask aldkmlaskmd alsmd lasmd lasdm alskdm",
                        IsFavorite = true,
                        Ranking = 5,
                        Contact = contact
                    },
                    new Reservation
                    {
                        CreationDate = DateTime.Now,
                        Destination = "Maldives",
                        Description = "asmklasmdlask aldkmlaskmd alsmd lasmd lasdm alskdm",
                        IsFavorite = false,
                        Ranking = 3,
                        Contact = contact
                    }
                };

                context.Reservations.AddRange(reservations);
            }

            context.SaveChanges();

        }
    }
}
