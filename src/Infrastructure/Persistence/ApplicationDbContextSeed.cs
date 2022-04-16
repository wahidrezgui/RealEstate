using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.ValueObjects;
using CleanArchitecture.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infrastructure.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        var administratorRole = new IdentityRole("Administrator");

        if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await roleManager.CreateAsync(administratorRole);
        }

        var administrator = new ApplicationUser { UserName = "administrator@localhost", Email = "administrator@localhost" };

        if (userManager.Users.All(u => u.UserName != administrator.UserName))
        {
            await userManager.CreateAsync(administrator, "Administrator1!");
            await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });
        }
    }

    public static async Task SeedSampleDataAsync(ApplicationDbContext context)
    {
        // Seed, if necessary
        if (!context.TodoLists.Any())
        {
            context.TodoLists.Add(new TodoList
            {
                Title = "Shopping",
                Colour = Colour.Blue,
                Items =
                    {
                        new TodoItem { Title = "Apples", Done = true },
                        new TodoItem { Title = "Milk", Done = true },
                        new TodoItem { Title = "Bread", Done = true },
                        new TodoItem { Title = "Toilet paper" },
                        new TodoItem { Title = "Pasta" },
                        new TodoItem { Title = "Tissues" },
                        new TodoItem { Title = "Tuna" },
                        new TodoItem { Title = "Water" }
                    }
            });

            await context.SaveChangesAsync();
        }

        if (!context.Governorates.Any())
        {
            context.Governorates.AddRange(
             new Governorate
             {
                 Name = "Tunis",

                 Municipalites =
                {
                    new Municipalite { Name = "Le Bardo", PostalCode = "1" },
                    new Municipalite { Name = "Le Kram", PostalCode = "2" },
                    new Municipalite { Name = "La Goulette", PostalCode = "3" },
                    new Municipalite { Name = "Carthage", PostalCode = "4" },
                    new Municipalite { Name = "Sidi Bou Said", PostalCode = "5" },
                    new Municipalite { Name = "La Marsa", PostalCode = "6" },
                    new Municipalite { Name = "Sidi Hassine", PostalCode = "7" }
                }
             },
             new Governorate
             {
                 Name = "Ariana",

                 Municipalites =
                 {
                     new Municipalite { Name = "Ariana", PostalCode = "1" },
                     new Municipalite { Name = " La Soukra", PostalCode = "1" },
                     new Municipalite { Name = "Raoued", PostalCode = "1" },
                     new Municipalite { Name = "Kalâat el-Andalous", PostalCode = "1" },
                     new Municipalite { Name = "Sidi Thabet", PostalCode = "1" },
                     new Municipalite { Name = "Ettadhamen-Mnihla", PostalCode = "1" },
                 }
             },
             new Governorate
             {
                 Name = "Ben Arous",

                 Municipalites =
                 {
                     new Municipalite { Name = "Ben Arous", PostalCode = "1" },
                     new Municipalite { Name = "El Mourouj", PostalCode = "1" },
                     new Municipalite { Name = " Hammam Lif", PostalCode = "1" },
                     new Municipalite { Name = "Hammam Chott", PostalCode = "1" },
                     new Municipalite { Name = "Bou Mhel el-Bassatine", PostalCode = "1" },
                     new Municipalite { Name = "Ezzahra", PostalCode = "1" },
                     new Municipalite { Name = "Radès", PostalCode = "1" },
                     new Municipalite { Name = "Mégrine", PostalCode = "1" },
                     new Municipalite { Name = "Mohamedia-Fouchana", PostalCode = "1" },
                     new Municipalite { Name = "Mornag", PostalCode = "1" },
                     new Municipalite { Name = "Khalidia", PostalCode = "1" }
                 }
             },
             new Governorate
             {
                 Name = "Manouba",

                 Municipalites =
                 {
                     new Municipalite { Name = "Den Den", PostalCode = "1" },
                     new Municipalite { Name = "Douar Hicher", PostalCode = "1" },
                     new Municipalite { Name = "Oued Ellil", PostalCode = "1" },
                     new Municipalite { Name = "Mornaguia", PostalCode = "1" },
                     new Municipalite { Name = " Borj El Amri", PostalCode = "1" },
                     new Municipalite { Name = "Djedeida", PostalCode = "1" },
                     new Municipalite { Name = "Tebourba", PostalCode = "1" },
                     new Municipalite { Name = "El Battan", PostalCode = "1" }
                 }
             },
             new Governorate
             {
                 Name = "Zaghouan",

                 Municipalites =
                 {
                     new Municipalite
                     {
                         Name = "Zaghouan",
                         PostalCode = "1"
                     },
                     new Municipalite
                     {
                         Name = "Zriba",
                         PostalCode = "1"
                     },

                     new Municipalite
                     {
                         Name = "Bir Mcherga",
                         PostalCode = "1"
                     },

                     new Municipalite
                     {
                         Name = "Djebel Oust",
                         PostalCode = "1"
                     },

                     new Municipalite
                     {
                         Name = " El Fahs",
                         PostalCode = "1"
                     },

                     new Municipalite
                     {
                         Name = "Nadhour",
                         PostalCode = "1"
                     }
                 }
             },
             new Governorate
             {
                 Name = "Bizerte",

                 Municipalites =
                     {
                         new Municipalite
                         {
                             Name = "Bizerte",
                             PostalCode = "1"
                         },
                         new Municipalite
                         {
                             Name = "Sejnane",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Mateur",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Menzel Bourguiba",
                             PostalCode = "1"
                         },
                         new Municipalite
                         {
                             Name = "Tinja",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Ghar al Milh",
                             PostalCode = "1"
                         },
                         new Municipalite
                         {
                             Name = "Aousja",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Menzel Jemil",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Menzel Abderrahmane",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "El Alia",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = " Ras Jebel",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Metline",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Raf Raf",
                             PostalCode = "1"
                         }
                     }
             },
             new Governorate
             {
                 Name = "Béja",

                 Municipalites =
                     {
                         new Municipalite
                         {
                             Name = "Béja",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "El Maâgoula",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Zahret Medien",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Nefza",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Téboursouk",
                             PostalCode = "1"
                         },
                         new Municipalite
                         {
                             Name = "Testour",
                             PostalCode = "1"
                         },
                         new Municipalite
                         {
                             Name = "Goubellat",
                             PostalCode = "1"
                         },

                         new Municipalite
                         {
                             Name = "Majaz al Bab",
                             PostalCode = "1"
                         },
                     }
             },
             new Governorate
             {
                 Name = "Jendouba",

                 Municipalites =
                      {
                          new Municipalite
                          {
                              Name = "Jendouba",
                              PostalCode = "1"
                          },

                          new Municipalite
                          {
                              Name = "Bou Salem",
                              PostalCode = "1"
                          },

                          new Municipalite
                          {
                              Name = "Tabarka",
                              PostalCode = "1"
                          },

                          new Municipalite
                          {
                              Name = "Aïn Draham",
                              PostalCode = "1"
                          },
                          new Municipalite
                          {
                              Name = "Fernana",
                              PostalCode = "1"
                          },

                          new Municipalite
                          {
                              Name = "Beni M'Tir",
                              PostalCode = "1"
                          },
                          new Municipalite
                          {
                              Name = "Ghardimaou",
                              PostalCode = "1"
                          },

                          new Municipalite
                          {
                              Name = "Oued Melliz",
                              PostalCode = "1"
                          },
                      }
             },
             new Governorate
             {
                 Name = "Kef",

                 Municipalites =
                        {
                            new Municipalite
                            {
                                Name = "Kef",
                                PostalCode = "1"
                            },

                            new Municipalite
                            {
                                Name = "Nebeur",
                                PostalCode = "1"
                            },
                            new Municipalite
                            {
                                Name = "Touiref",
                                PostalCode = "1"
                            },
                            new Municipalite
                            {
                                Name = "Sakiet Sidi Youssef",
                                PostalCode = "1"
                            },
                            new Municipalite
                            {
                                Name = "Tajerouine",
                                PostalCode = "1"
                            },

                            new Municipalite
                            {
                                Name = "Menzel Salem",
                                PostalCode = "1"
                            },
                            new Municipalite
                            {
                                Name = "Kalaat es Senan",
                                PostalCode = "1"
                            },

                            new Municipalite
                            {
                                Name = "Kalâat Khasba",
                                PostalCode = "1"
                            },
                            new Municipalite
                            {
                                Name = "Jérissa",
                                PostalCode = "1"
                            },

                            new Municipalite
                            {
                                Name = "El Ksour",
                                PostalCode = "1"
                            },
                            new Municipalite
                            {
                                Name = "Dahmani",
                                PostalCode = "1"
                            },
                            new Municipalite
                            {
                                Name = "Le Sers",
                                PostalCode = "1"
                            }
                        }
             },
             new Governorate
             {
                 Name = "Siliana",

                 Municipalites =
                         {
                             new Municipalite
                             {
                                 Name = "Siliana",
                                 PostalCode = "1"
                             },

                             new Municipalite
                             {
                                 Name = "Bou Arada",
                                 PostalCode = "1"
                             },

                             new Municipalite
                             {
                                 Name = "Gaâfour",
                                 PostalCode = "1"
                             },

                             new Municipalite
                             {
                                 Name = "El Krib",
                                 PostalCode = "1"
                             },
                             new Municipalite
                             {
                                 Name = "Sidi Bou Rouis",
                                 PostalCode = "1"
                             },

                             new Municipalite
                             {
                                 Name = "Maktar",
                                 PostalCode = "1"
                             },
                             new Municipalite
                             {
                                 Name = "Rouhia",
                                 PostalCode = "1"
                             },
                             new Municipalite
                             {
                                 Name = "Kesra",
                                 PostalCode = "1"
                             },
                             new Municipalite
                             {
                                 Name = "Bargou",
                                 PostalCode = "1"
                             },

                             new Municipalite
                             {
                                 Name = "El Aroussa",
                                 PostalCode = "1"
                             },
                         }
             },
             new Governorate
             {
                 Name = "Sousse",

                 Municipalites =
                          {
                              new Municipalite
                              {
                                  Name = "Sousse",
                                  PostalCode = "1"
                              },

                              new Municipalite
                              {
                                  Name = "Ksibet Thrayet",
                                  PostalCode = "1"
                              },
                              new Municipalite
                              {
                                  Name = "Ezzouhour",
                                  PostalCode = "1"
                              },

                              new Municipalite
                              {
                                  Name = "Zaouiet Sousse",
                                  PostalCode = "1"
                              },

                              new Municipalite
                              {
                                  Name = "Hammam Sousse",
                                  PostalCode = "1"
                              },

                              new Municipalite
                              {
                                  Name = "Akouda",
                                  PostalCode = "1"
                              },

                              new Municipalite
                              {
                                  Name = "Kalâa Kebira",
                                  PostalCode = "1"
                              },
                              new Municipalite
                              {
                                  Name = "Sidi Bou Ali",
                                  PostalCode = "1"
                              },

                              new Municipalite
                              {
                                  Name = "Hergla",
                                  PostalCode = "1"
                              },
                              new Municipalite
                              {
                                  Name = "Enfidha",
                                  PostalCode = "1"
                              },
                              new Municipalite
                              {
                                  Name = "Bouficha",
                                  PostalCode = "1"
                              },
                              new Municipalite
                              {
                                  Name = "Sidi El Hani",
                                  PostalCode = "1"
                              },
                              new Municipalite
                              {
                                  Name = "M 'saken",
                                  PostalCode = "1"
                              },

                              new Municipalite
                              {
                                  Name = "Kalâa Seghira",
                                  PostalCode = "1"
                              },
                              new Municipalite
                              {
                                  Name = "Messaadine",
                                  PostalCode = "1"
                              },

                              new Municipalite
                              {
                                  Name = "Kondar",
                                  PostalCode = "1"
                              },
                          }
             },
             new Governorate
             {
                 Name = "Monastir",

                 Municipalites =
                           {
                               new Municipalite
                               {
                                   Name = "Monastir",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Khniss",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Ouerdanin",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Sahline Moôtmar",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Sidi Ameur",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Zéramdine",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Beni Hassen",
                                   PostalCode = "1"
                               },
                               new Municipalite
                               {
                                   Name = "Ghenada",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Jemmal",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Menzel Kamel",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Zaouiet Kontoch",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Bembla - Mnara",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Menzel Ennour",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "El Masdour",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Moknine",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = " Sidi Bennour",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = " Menzel Farsi",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Amiret El Fhoul",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Amiret Touazra",
                                   PostalCode = "1"
                               },
                               new Municipalite
                               {
                                   Name = " Amiret El Hojjaj",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = " Cherahil",
                                   PostalCode = "1"
                               },
                               new Municipalite
                               {
                                   Name = "Bekalta",
                                   PostalCode = "1"
                               },
                               new Municipalite
                               {
                                   Name = "Téboulba",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Ksar Hellal",
                                   PostalCode = "1"
                               },
                               new Municipalite
                               {
                                   Name = "Ksibet El Mediouni",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = " Benen Bodher",
                                   PostalCode = "1"
                               },
                               new Municipalite
                               {
                                   Name = "Touza",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Sayada",
                                   PostalCode = "1"
                               },
                               new Municipalite
                               {
                                   Name = "Lemta",
                                   PostalCode = "1"
                               },
                               new Municipalite
                               {
                                   Name = "  Bouhjar",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = " Menzel Hayet",
                                   PostalCode = "1"
                               },
                           }
             },
             new Governorate
             {
                 Name = "Mahdia",

                 Municipalites =
                           {
                               new Municipalite
                               {
                                   Name = "Mahdia",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Rejiche",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Bou Merdes",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Ouled Chamekh",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Chorbane",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Hebira",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = " Essouassi",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "El Djem",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Kerker",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Chebba",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Melloulèche",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Sidi Alouane",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "Ksour Essef",
                                   PostalCode = "1"
                               },

                               new Municipalite
                               {
                                   Name = "El Bradâa",
                                   PostalCode = "1"
                               },
                           }
             },
             new Governorate
             {
                 Name = "Sfax",

                 Municipalites =
     {
         new Municipalite
         {
             Name = "Sfax",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Sakiet Ezzit",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Chihia",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Sakiet Eddaïer",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Gremda",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "El Ain",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Thyna",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Agareb",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Jebiniana",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "El Hencha",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Menzel Chaker",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Ghraïba, Tunisia",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Bir Ali Ben Khélifa",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Skhira",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Mahares",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Kerkennah",
             PostalCode = "1"
         },
     }
             },
             new Governorate
             {
                 Name = "Kairouan",

                 Municipalites =
         {
             new Municipalite
             {
                 Name = "Kairouan",
                 PostalCode = "1"
             },
             new Municipalite
             {
                 Name = "Chebika",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Sbikha",
                 PostalCode = "1"
             },
             new Municipalite
             {
                 Name = "Oueslatia",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Aïn Djeloula",
                 PostalCode = "1"
             },
             new Municipalite
             {
                 Name = "Haffouz",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Alaâ",
                 PostalCode = "1"
             },
             new Municipalite
             {
                 Name = "Hajeb El Ayoun",
                 PostalCode = "1"
             },
             new Municipalite
             {
                 Name = "Nasrallah",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Menzel Mehiri",
                 PostalCode = "1"
             },
             new Municipalite
             {
                 Name = "Echrarda",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Bou Hajla",
                 PostalCode = "1"
             },
         }
             },
             new Governorate
             {
                 Name = "Kasserine",

                 Municipalites =
      {
          new Municipalite
          {
              Name = "Kasserine",
              PostalCode = "1"
          },

          new Municipalite
          {
              Name = "Sbeitla",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Sbiba",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Jedelienne",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Thala",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Haïdra",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Foussana",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Fériana",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Thélepte",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Magel Bel Abbès",
              PostalCode = "1"
          }
      }
             },
             new Governorate
             {
                 Name = "Sidi Bouzid",

                 Municipalites =
          {
              new Municipalite
              {
                  Name = "Sidi Bouzid",
                  PostalCode = "1"
              },
              new Municipalite
              {
                  Name = "Jilma",
                  PostalCode = "1"
              },
              new Municipalite
              {
                  Name = " Cebalet",
                  PostalCode = "1"
              },
              new Municipalite
              {
                  Name = "Bir El Hafey",
                  PostalCode = "1"
              },

              new Municipalite
              {
                  Name = "Sidi Ali Ben Aoun",
                  PostalCode = "1"
              },

              new Municipalite
              {
                  Name = "Menzel Bouzaiane",
                  PostalCode = "1"
              },

              new Municipalite
              {
                  Name = "Meknassy",
                  PostalCode = "1"
              },

              new Municipalite
              {
                  Name = "Mezzouna",
                  PostalCode = "1"
              },
              new Municipalite
              {
                  Name = "Regueb",
                  PostalCode = "1"
              },

              new Municipalite
              {
                  Name = "Ouled Haffouz",
                  PostalCode = "1"
              },
          }
             },
             new Governorate
             {
                 Name = "Gabès",

                 Municipalites =
     {
         new Municipalite
         {
             Name = "Gabès",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Chenini Nahal",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Ghannouch",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Métouia",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Oudhref",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "El Hamma",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Matmata",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = " Nouvelle Matmata",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Mareth",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Zarat",
             PostalCode = "1"
         },
     }
             },
             new Governorate
             {
                 Name = "Mednine",

                 Municipalites =
         {
             new Municipalite
             {
                 Name = "Mednine",
                 PostalCode = "1"
             },
             new Municipalite
             {
                 Name = "Beni Khedache",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Ben Gardane",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Zarzis",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Houmt El Souk(Djerba)",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Midoun(Djerba)",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Ajim(Djerba)",
                 PostalCode = "1"
             },
         }
             },
             new Governorate
             {
                 Name = "Tataouine",

                 Municipalites =
     {
         new Municipalite
         {
             Name = "Tataouine",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Bir Lahmar",
             PostalCode = "1"
         },
         new Municipalite
         {
             Name = "Ghomrassen",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Dehiba",
             PostalCode = "1"
         },

         new Municipalite
         {
             Name = "Remada",
             PostalCode = "1"
         },
     }
             },
             new Governorate
             {
                 Name = "Gafsa",

                 Municipalites =
    {
        new Municipalite
        {
            Name = "Gafsa",
            PostalCode = "1"
        },

        new Municipalite
        {
            Name = "El Ksar",
            PostalCode = "1"
        },

        new Municipalite
        {
            Name = "Moularès",
            PostalCode = "1"
        },

        new Municipalite
        {
            Name = "Redeyef",
            PostalCode = "1"
        },
        new Municipalite
        {
            Name = "Métlaoui",
            PostalCode = "1"
        },
        new Municipalite
        {
            Name = "Mdhila",
            PostalCode = "1"
        },

        new Municipalite
        {
            Name = "El Guettar",
            PostalCode = "1"
        },
        new Municipalite
        {
            Name = "Sened",
            PostalCode = "1"
        }
    }
             },
             new Governorate
             {
                 Name = "Tozeur",

                 Municipalites =
         {
             new Municipalite
             {
                 Name = "Tozeur",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = "Degache",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = " Hamet Jerid",
                 PostalCode = "1"
             },
             new Municipalite
             {
                 Name = "Nafta",
                 PostalCode = "1"
             },

             new Municipalite
             {
                 Name = " Tamerza",
                 PostalCode = "1"
             },
         }
             },
             new Governorate
             {
                 Name = "Kebili",

                 Municipalites =
      {
          new Municipalite
          {
              Name = "Kebili",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Djemna",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Douz",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "El Golâa",
              PostalCode = "1"
          },
          new Municipalite
          {
              Name = "Souk Lahad",
              PostalCode = "1"
          }
      }
             });

            await context.SaveChangesAsync();
        }
    }
}