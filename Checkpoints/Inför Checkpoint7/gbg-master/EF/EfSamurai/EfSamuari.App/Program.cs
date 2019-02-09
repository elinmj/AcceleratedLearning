using ConsoleService;
using EfSamurai.Domain;
using EfSamurai.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace EfSamurai.App
{
    class Program
    {
        private static ConsoleHelper ch = new ConsoleHelper();
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {
            // ----- Init logger ----------------------------------------------
            ch.Init();
            _context.GetService<ILoggerFactory>().AddProvider(new MyLoggerProvider());

            // ----- Clear database -------------------------------------------

            //_context.Database.EnsureCreated();
            
            ClearDatabase();

            // ----- Fill database with initial values ------------------------


            //AddOneSamurai();
            //AddQuoteAndConnectItToOneSamurai();
            //AddQuoteAndSamuraiAtTheSameTime();
            AddSomeSamurais();
            //AddSomeBattles();
            //AddOneSamuraiWithRelatedData();
            //AddSomeSamurais_WithRelatedData();

            // ----- Clear ----------------------------------------------------

            ch.Clear();

            // ----- Queries --------------------------------------------------

            //ListAllSamuraiNames();
            //ListAllSamuraiNames_OrderByName();
            //ListAllSamuraiNames_OrderByIdDescending();
            //FindSamuraiWithRealName("Karl");
            //ListAllQuotesOfType(QuoteStyle.Cheesy);
            //ListAllQuotesOfType_WithSamurai(QuoteStyle.Cheesy);
            //ListAllBattles(new DateTime(1600, 1, 1), new DateTime(1900, 2, 2), true);

            //ListAllBattles_WithLog(new DateTime(1600, 1, 1), new DateTime(1900, 2, 2), true);

            //ListSamuraisWithQuotePart("Some"); // tråkig?

            //List<string> namesWithAlias = AllSamuraiNameWithAlias();
            //DisplayList(namesWithAlias);

            //var samuraisWithInfo= GetSamuraiInfo(); 
            //samuraisWithInfo.ForEach(s => ch.Green(s.Name, s.RealName, s.BattleNames));

            //GetBattlesForSamurai("Kalle");

            //InvestigateWhenDatabaseIsQueried();
            //InvestigateGeneratedSqlQueries();             // hoppar över
            //InvestigateFindAndWhere(2);
            //InvestigateIdValueChangesOnEntities();        // hoppar över
            //InvestigateIQuerable();
            //RawSqlQueryCombinedWithLinq();
            //RawSqlCommand();

            // ----- Update --------------------------------------------------

            UpdateNameOfFirstSamurai();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultipleSamurais();
            //MultipleOperations();
            //QueryAndUpdateSamuraiDisconnected();
            //QueryAndUpdateDisconnectedBattle();
            //ReplaceSecretIdentity("Kalle");

            //AddSamuraiBattlesManually(5, 1);

            // ----- Update --------------------------------------------------

            //DeleteWhileTracked();
            //DeleteWhileNotTracked();
            //DeleteMany();

            // ----- Stored procedures----------------------------------------
            // RawSqlQueryStoredProcedure();
            // RawSqlCommandWithOutput();

            Console.ReadKey();
        }

        private static void AddQuoteAndConnectItToOneSamurai()
        {
            ch.Line("AddQuoteAndConnectItToOneSamurai");

            // Hämta en befintlig samurai
            Samurai s = null;
            using (var context = new SamuraiContext())
            {
                s = context.Samurais.First();
            }

            ch.Line("AddQuoteAndConnectItToOneSamurai", "AddQuote");

            // Skapa ett nytt citat och koppla det till en befintlig samuraj
            using (var context = new SamuraiContext())
            {
                var q = new Quote
                {
                    Text = "Mitt citat",
                    Style = QuoteStyle.Awesome,
                    SamuraiId = s.Id // Kan tyvärr inte skriva "Samurai = s" för då försöker EF skapa en helt ny samuraj
                };
                
                context.Quotes.Add(q);
                
                context.SaveChanges();
            }
        }


        private static void AddQuoteAndSamuraiAtTheSameTime()
        {
            // Här blir det mer intuitivt än förra (AddQuoteAndConnectItToOneSamurai)
            // ...för vi skapar en helt ny samurai och ny quote. 
            // Slipper ange SamuraiId

            ch.Line("AddQuoteAndSamuraiAtTheSameTime");

            // Skapa ett nytt citat och samtidigt en ny samuraj

            using (var context = new SamuraiContext())
            {
                var q = new Quote
                {
                    Text = "Mitt citat",
                    Style = QuoteStyle.Awesome,
                    Samurai = new Samurai { Name = "Kalle" }
                };

                context.Quotes.Add(q);

                context.SaveChanges();
            }
        }

        private static void UpdateNameOfFirstSamurai()
        {
            // Undersöker Update-kommando

            ch.Line("UpdateNameOfFirstSamurai");

            {
                // Vi försöker uppdatera en samurai som inte kommer från databasen (vi har inget id), så det kommer faila
                _context = new SamuraiContext();
                var samurai = new Samurai {Name="Will fail" };

                _context.Samurais.Update(samurai); 

                try
                {
                    _context.SaveChanges();
                }
                catch(DbUpdateConcurrencyException ex)
                {
                    ch.Red(ex.Message);  // "Database operation expected to affect 1 row(s) but actually affected 0 row(s). Data may have been modified or deleted since entities were loaded.
                }

            }

            {

                // Uppdatera data på normalt sätt

                _context = new SamuraiContext();
                var samurai = _context.Samurais.FirstOrDefault();

                samurai.Name = "Olle";

                // _context.Samurais.Update(samurai); // Räcker inte att göra Update. Entiteten sätts i Modified state
                _context.SaveChanges();

            }
            {
                // Hämta första samurajens namn

                _context = new SamuraiContext();
                var samuraiAgain = _context.Samurais.FirstOrDefault();
                ch.Green(samuraiAgain.Name);
            }
        }

        private static void ListSamuraisWithQuotePart(string textpart)
        {
            // Det går att borra sig ner i datan i filterfunktionen

            _context = new SamuraiContext();
            var samurais = _context.Samurais
                .Where(s => s.Quotes.Any(q => q.Text.Contains(textpart)))
            .ToList();

            foreach (var s in samurais)
            {
                ch.Green($"{s.Name} has a quote containing {textpart}");
            }
        }

        private static void ReplaceSecretIdentity(string samuraiName)
        {
            // Byt ut secret identity för en samurai som ev redan har en
            // Include krävs, annars blir SecretIdentity null
            // Include påverkar inte den typ som returneras av Linq-frågan

            var samurai = _context.Samurais.Include(s=>s.SecretIdentity).FirstOrDefault(s => s.Name == samuraiName);

            if (samurai == null)
            {
                ch.Red($"Samurai {samuraiName} don't exist");
                return;
            }

            if (samurai.SecretIdentity == null)
            {
                ch.Red($"The samurai {samuraiName} didn't have a secret identity");
                return;
            }

            samurai.SecretIdentity = new SecretIdentity { RealName = "NEW SECRET IDENTITY" };
            _context.SaveChanges();

            ch.Green($"New secret identity for '{samuraiName}'");
        }

        private static void DisplayList(List<string> list)
        {
            foreach (var item in list)
            {
                ch.Green(item);
            }
        }

        private static void AddOneSamurai()
        {
            ch.Line("AddOneSamurai");

            var sam = new Samurai { Name = "Karin" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(sam);
                context.SaveChanges();
            }


        }

        private static void ClearDatabase()
        {
            // För att ta bort ett objekt måste du först göra en query

            _context.RemoveRange(_context.Samurais);
            _context.RemoveRange(_context.Battles);

            ReseedAllTables();

            _context.SaveChanges();
        }

        private static void ReseedAllTables()
        {
            // Nollställer alla nycklar
            // Kopplingstabellen SamuraiBattles behöver inte nollställas
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Samurais', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('SecretIdentity', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Quotes', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('Battles', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('BattleLog', RESEED, 0)");
            _context.Database.ExecuteSqlCommand("DBCC CHECKIDENT('BattleEvent', RESEED, 0)");
        }

        private static Battle Battle1
        {
            get
            {
                return new Battle
                {
                    Name = "Battle 1",
                    Description = "Description of battle 1",
                    IsBrutal = true,
                    StartDate = new DateTime(1710, 2, 3),
                    EndDate = new DateTime(1710, 2, 8),
                    BattleLog = new BattleLog
                    {
                        Name = "Battlelog for battle 1",
                        BattleEvents = new List<BattleEvent>
                    {
                        new BattleEvent{Summary="Summary of event (order1, battle1)",Description="Description of event (order1, battle1)", Order=1 },
                        new BattleEvent{Summary="Summary of event (order2, battle1)",Description="Description of event (order2, battle1)", Order=2 },
                        new BattleEvent{Summary="Summary of event (order3, battle1)",Description="Description of event (order3, battle1)", Order=3 },
                    }
                    }

                };
            }

        }

        private static Battle Battle2
        {
            get
            {
                return new Battle
                {
                    Name = "Battle 2",
                    Description = "Description of battle 2",
                    IsBrutal = true,
                    StartDate = new DateTime(1805, 5, 6),
                    EndDate = new DateTime(1805, 5, 12),
                    BattleLog = new BattleLog
                    {
                        Name = "Battlelog for battle 2",
                        BattleEvents = new List<BattleEvent>
                    {
                        new BattleEvent{Summary="Summary of event (order1, battle2)",Description="Description of event (order1, battle2)", Order=1 },
                        new BattleEvent{Summary="Summary of event (order2, battle2)",Description="Description of event (order2, battle2)", Order=2 },
                    }
                    }

                };
            }
        }

        private static void AddOneSamuraiWithRelatedData()
        {

            var samurai = new Samurai
            {
                Name = "Kalle",
                Quotes = new List<Quote> {
                  new Quote { Text = "Some awesome quote by Kalle", Style=QuoteStyle.Awesome },
                  new Quote { Text = "Some cheesy quote by Kalle", Style=QuoteStyle.Cheesy },
                  new Quote { Text = "Another cheesy quote by Kalle", Style=QuoteStyle.Cheesy }
              },
                SecretIdentity = new SecretIdentity { RealName = "Karl" },
                SamuraiBattles = new List<SamuraiBattle>
              {
                  new SamuraiBattle{ Battle = Battle1 },
                  new SamuraiBattle{ Battle = Battle2 }
              },
                HairStyle = HairStyle.Chonmage

            };

            using (var context = new SamuraiContext())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }

        private static void AddSomeSamurais()
        {
            ch.Line("AddSomeSamurais");

            // Lägg till flera samuraier mha AddRange
            var samuraiPelle = new Samurai { Name = "Pelle" };
            var samuraiLasse = new Samurai { Name = "Lasse" };
            var samuraiJulia = new Samurai { Name = "Julle" };

            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samuraiPelle, samuraiLasse, samuraiJulia);

                context.SaveChanges();
            }
        }

        private static void AddSomeSamurais_WithRelatedData()
        {
            ch.Line("AddSomeSamurais_WithRelatedData");

            // Lägg till flera samuraier mha AddRange
            var samuraiPelle = new Samurai { Name = "Pelle", SecretIdentity= new SecretIdentity { RealName="Per" } };
            var samuraiLasse = new Samurai { Name = "Lasse", SecretIdentity = new SecretIdentity { RealName = "Lars" } };
            var samuraiJulia = new Samurai { Name = "Julle", SecretIdentity = new SecretIdentity { RealName = "Julia" } };

            using (var context = new SamuraiContext())
            {
                context.Samurais.AddRange(samuraiPelle, samuraiLasse, samuraiJulia);

                context.SaveChanges();
            }
        }

        private static void AddSomeBattles()
        {
            ch.Line("AddBattles");
            using (var context = new SamuraiContext())
            {
                context.Battles.AddRange(Battle1, Battle2);
                context.SaveChanges();
            }
        }

        private static void ListAllSamuraiNames()
        {
            ch.Line("ListAllSamuraiNames");
            using (var context = new SamuraiContext())
            {
                foreach (var samurai in context.Samurais)
                {
                    ch.Green(samurai.Name);
                }
            }
        }
        

        private static void ListAllSamuraiNames_OrderByName()
        {
            ch.Line("ListAllSamuraiNames_OrderByName");
            using (var context = new SamuraiContext())
            {
                foreach (var samurai in context.Samurais.OrderBy(s=>s.Name))
                {
                    ch.Green(samurai.Name);
                }
            }
        }

        private static void ListAllSamuraiNames_OrderByIdDescending()
        {
            ch.Line("ListAllSamuraiNames_OrderByIdDescending");
            using (var context = new SamuraiContext())
            {
                foreach (var samurai in context.Samurais.OrderByDescending(s => s.Id))
                {
                    ch.Green(samurai.Name, samurai.Id);
                }
            }
        }

        private static void FindSamuraiWithRealName(string realName)
        {
            ch.Line("FindSamuraiWithRealName");
            using (var context = new SamuraiContext())
            {
                var sam = context.Samurais.FirstOrDefault(s => s.SecretIdentity.RealName == realName);

                if (sam == null)
                {
                    ch.Red($"No samurai has the real name {realName}");
                } else
                {
                    ch.Green($"The samurai {sam.Name} has the real name {realName}");
                }
            }
        }

        private static void ListAllQuotesOfType(QuoteStyle quoteStyle)
        {
            ch.Line("ListAllQuotesOfType");
            using (var context = new SamuraiContext())
            {
                foreach (var quote in context.Quotes.Where(q=>q.Style == quoteStyle))
                {
                    ch.Green(quote.Text);
                }
            }
        }

        private static void ListAllQuotesOfType_WithSamurai_Fail(QuoteStyle quoteStyle)
        {
            ch.Line("ListAllQuotesOfType_WithSamurai");
            using (var context = new SamuraiContext())
            {
                foreach (var quote in context.Quotes.Where(q => q.Style == quoteStyle))
                {
                    // quote.Samurai will be null
                    ch.Green($"'{quote.Text}' is a {quoteStyle} quote by {quote.Samurai.Name}");
                }
            }
        }

        private static void ListAllQuotesOfType_WithSamurai(QuoteStyle quoteStyle)
        {
            ch.Line("ListAllQuotesOfType_WithSamurai");
            using (var context = new SamuraiContext())
            {
                foreach (var quote in context.Quotes.Where(q => q.Style == quoteStyle).Include(q=>q.Samurai))
                {
                    ch.Green($"'{quote.Text}' is a {quoteStyle.ToString().ToLower()} quote by {quote.Samurai.Name}");
                }
            }
        }

        private static void ListAllBattles(DateTime from, DateTime to, bool? isBrutal)
        {
            ch.Line("ListAllBattles");
            using (var context = new SamuraiContext())
            {
                var battles = context.Battles.Where(b => b.StartDate > from && b.EndDate < to);

                if (isBrutal!=null)
                {
                    battles = battles.Where(b => b.IsBrutal == isBrutal);
                }

                foreach (var battle in battles)
                {
                    string not = battle.IsBrutal ? "" : " not";

                    ch.Green($"'{battle.Name}' is{not} a brutal battle within the period");
                }
            }
        }

        private static void ListAllBattles_WithLog(DateTime from, DateTime to, bool isBrutal)
        {
            ch.Line("ListAllBattles_WithLog");
            using (var context = new SamuraiContext())
            {
                foreach (var battle in context.Battles
                    .Where(b => b.StartDate > from && b.EndDate < to && b.IsBrutal == isBrutal)
                    .Include(b=>b.BattleLog.BattleEvents)
                    .OrderBy(b=>b.Name))
                {
                    ch.Line(lineColor: ConsoleColor.Green);
                    ch.Green("Name of battle", battle.Name);
                    ch.Green("Log name", battle.BattleLog.Name);

                    foreach (var battleEvent in battle.BattleLog.BattleEvents.OrderBy(ev=>ev.Order))
                    {
                        ch.Green("Event", battleEvent.Summary);
                    }

                }
                ch.Line(lineColor: ConsoleColor.Green);
            }
        }

        private static List<string> AllSamuraiNameWithAlias()
        {
            using (var context = new SamuraiContext())
            {
                return context.Samurais.Select(s => $"{s.SecretIdentity.RealName} alias {s.Name}").ToList();
            }
        }

        private static List<SamuraiInfo> GetSamuraiInfo()
        {
            using (var context = new SamuraiContext())
            {
                return context.Samurais.Select(s =>
                    new SamuraiInfo
                    {
                        Name = s.Name,
                        RealName = s.SecretIdentity.RealName,
                        BattleNames = string.Join(",", s.SamuraiBattles.Select(sb => sb.Battle.Name))
                    }).ToList();

            }
        }

        private static void InvestigateWhenDatabaseIsQueried()
        {
            ch.Line("InvestigateWhenDatabaseIsQueried");
            using (var context = new SamuraiContext())
            {
                ch.Line("Before Queries");

                var query1 = context.Samurais;

                var query2 = context.Samurais.Where(s => s.Name.StartsWith("P"));

                var query3 = query2.Where(s => s.Id > 1);

                var query4 = context.Samurais.Where(s => s.Name.StartsWith("P")).ToList();

                var query5 = query3.FirstOrDefault();

                ch.Line("After Queries");
            
                ch.Line("Before ToList");
                var samurais = context.Samurais.ToList();
                ch.Line("After ToList");

                ch.Line("Before Foreach");
                foreach (var samurai in samurais)
                {
                    ch.Green(samurai.Name);
                }
                ch.Line("After Foreach");

                ch.Line("Before First");
                var first = context.Samurais.First();
                ch.Line("After First");

                ch.Green($"First samurai: {first.Name}");

                ch.Line("Before Add");
                context.Samurais.Add(new Samurai { Name = "Sven" });
                ch.Line("After Add");

            }
        }

        private static void InvestigateGeneratedSqlQueries()
        {
            ch.Line("InvestigateGeneratedSqlQueries");

            // Dessa tre querys ger samma sqlkommando. En enkel "select name from samurai"
            // ReverseString görs inte i databasen, utan det sker efteråt i minnet
            // Ev skippa denna

            var samurais = _context.Samurais
              .Select(s => new { newName = ReverseString(s.Name) })
              .ToList();

            ch.Line();

            var samuraisNeue = _context.Samurais
                .ToList();

            ch.Line();

            var samuraisAgain = _context.Samurais
                .Select(s => new Samurai { Name = ReverseString(s.Name) })
                .ToList();

            ch.Line();

            samuraisAgain.ForEach(s => ch.Green(s.Name));

            Console.WriteLine();
        }

        private static string DoubleName(string name)
        {
            return name + name;
        }

        private static void InvestigateFindAndWhere(int samuraiId)
        {
            ch.Line("InvestigateFindAndWhere");

            // Hämta en rad med Find
            // Om find anropas med samma id flera gånger + den redan finns => inget anrop sker mot databasen (bra!)
            // Testat samma fast med Where och FirstOrDefault => där sker anrop vid båda tillfällena

            ch.Line("Find");
            var samurai = _context.Samurais.Find(samuraiId);
            ch.Line("Find again with same id");
            var samuraiAgain = _context.Samurais.Find(samuraiId);
            ch.Line();

            //ch.Line("Where");
            //var samuraisWhere = _context.Samurais.Where(s => s.Id == id).FirstOrDefault();
            //ch.Line("Where again");
            //var samuraisWhereAgain = _context.Samurais.Where(s => s.Id == id).FirstOrDefault();

            if (samurai == null)
            {
                ch.Red($"No samurai with id={samuraiId}");
            }
            else
            {
                ch.Green($"Samurai with id={samuraiId} has name={samurai.Name}");
            }

        }

        private static void RawSqlQueryCombinedWithLinq()
        {
            // Med FromSql kan du göra en ren sql-fråga
            // ...och sedan använda linq för att bearbeta resultatet (sortera, filtrera)

            ch.Line("RawSqlQuery");

            var samurais = _context.Samurais.FromSql("Select * from Samurais")
                          .OrderBy(s => s.Name)
                          .Where(s => s.Name.Contains("a")).ToList();

            samurais.ForEach(s => ch.Green(s.Name));
        }


        // ------------------------------------------------------------------------
        // ------------------------------------------------------------------------
        // ------------------------------------------------------------------------




        private static void DeleteWhileTracked()
        {
            ch.Line("DeleteWhileTracked");

            string nameToDelete = "Lasse";

            // FirstOrDefault anropar databas
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == nameToDelete);

            // Får ArgumentNullException om man försöker ta bort null
            if (samurai == null)
            {
                ch.Red($"Samurai {nameToDelete} not found");
                return;
            }

            ch.Line("Before remove");

            // Om jag försöker ta bort _context.Remove("abc123")
            // 'The entity type 'string' was not found. Ensure that the entity type has been added to the model.'

            // Om flera remove sker efter varandra innan SaveChanges, så påverkar det inte SQL'en

            ch.Green($"Entry state: {_context.Entry(samurai).State}");
            _context.Samurais.Remove(samurai);
            _context.Samurais.Remove(samurai);
            _context.Samurais.Remove(samurai);
            ch.Green($"Entry state: {_context.Entry(samurai).State}");

            // alternates:

            // Ger samma sql
            // _context.Remove(samurai);

            // Ger samma sql
            //_context.Entry(samurai).State=EntityState.Deleted; 

            // Kräver att samuraien verkligen har det id'¨t
            // _context.Samurais.Remove(_context.Samurais.Find(1)); 

            _context.SaveChanges();

            ch.Green("Samurai removed");
            ch.Line("After remove");
        }

        private static void DeleteMany()
        {
            ch.Line("DeleteMany");
            IQueryable<Samurai> samurais = _context.Samurais.Where(s => s.Name.Contains("a"));

            _context.Samurais.RemoveRange(samurais);
            // alternate: 
            //_context.RemoveRange(samurais);

            // Om man av misstag skriver _context.RemoveRange(samurais); så:
            // 'The entity type 'EntityQueryable <Samurai> ' was not found. 
            // Ensure that the entity type has been added to the model.'

            // IQueryable är en Linq-grej

            _context.SaveChanges();
            ch.Line("DeleteMany - Done");
        }

        private static void DeleteWhileNotTracked()
        {
            // Ta bort en samurai med ett annat context, det funkar ändå

            var samurai = _context.Samurais.FirstOrDefault(s => s.Name == "Lasse");
            using (var contextNewAppInstance = new SamuraiContext())
            {
                contextNewAppInstance.Samurais.Remove(samurai);
                //contextNewAppInstance.Entry(samurai).State=EntityState.Deleted;
                contextNewAppInstance.SaveChanges();
            }

        }



        private static void RawSqlQueryStoredProcedure()
        {
            // Med FromSql kan du även anropa stored procedures (mot en entitet som Samurais)
            // Det går att skicka in parametrar i frågan
            // Som innan går det att bearbeta resultatet

            // Kör ett stored procedure som tidigare lagts in i Migration

            ch.Line("RawSqlQueryStoredProcedure");

            // Hämtar en samurai där namnet innehåller en viss text 


            var namePart = "k";
            var samurais = _context.Samurais
              .FromSql("EXEC FilterSamuraiByNamePart {0}", namePart)
              .OrderByDescending(s => s.Name).ToList();

            samurais.ForEach(s => ch.Green(s.Name));
        }


        private static void RawSqlCommand()
        {
            // För att utföra sql-commandon så anropa ExecuteSqlCommand. Metoden finns under "Database"
            // Alla rader blir affected även om de inte uppdateras

            ch.Line("RawSqlCommand");

            var affected = _context.Database.ExecuteSqlCommand(
              "update samurais set Name=REPLACE(Name,'lle','POW')");
            ch.Green($"Affected rows {affected}");
        }


        private static void RawSqlCommandWithOutput()
        {
            // Kör en stored procedure och ta hand om resultatet
            // ExecuteCommand kan även anropa stored procedures

            var procResult = new SqlParameter
            {
                ParameterName = "@procResult",
                SqlDbType = SqlDbType.BigInt,
                Direction = ParameterDirection.Output,
                Size = 50
            };
            _context.Database.ExecuteSqlCommand(
              "exec FindLongestName @procResult OUT", procResult);
            Console.WriteLine($"Longest name: {procResult.Value}");
        }



        private static string ReverseString(string value)
        {
            var stringChar = value.AsEnumerable();
            return string.Concat(stringChar.Reverse());
        }

        private static void QueryAndUpdateDisconnectedBattle()
        {
            // Uppdatera datum på ett krig
            // Använd ..Battles.Update( ... ) för att uppdatera ett krig

            ch.Line("QueryAndUpdateDisconnectedBattle");

            var battle = _context.Battles.FirstOrDefault();
            battle.EndDate = new DateTime(2100, 1, 2);
            using (var contextNewAppInstance = new SamuraiContext())
            {
                contextNewAppInstance.Battles.Update(battle); // Kan ändra även om det är olika context
                contextNewAppInstance.SaveChanges();
            }
        }

        private static void QueryAndUpdateSamuraiDisconnected()
        {
            // Lägg till "San" på den första Kalle-samuraien

            ch.Line("QueryAndUpdateSamuraiDisconnected");

            // Vid FirstOrDefault så görs ett anrop direkt
            ch.Line("FirstOrDefault Before");
            var samurai = _context.Samurais.FirstOrDefault(s => s.Name.StartsWith("Lasse"));
            ch.Line("FirstOrDefault After");

            samurai.Name += "HAAAAA";
            using (var contextNewAppInstance = new SamuraiContext())
            {
                // Samuraien kommer från en annan context där den är modifierade
                // Men den nya context kan ändå utföra uppdateringen

                contextNewAppInstance.Samurais.Update(samurai); // Detta context lyckas uppdatera den tidigare samuraien
                ch.Line("Before Save");
                contextNewAppInstance.SaveChanges();
                ch.Line("After Save");
            }

        }

        private static void MultipleOperations()
        {
            // Lägg till "San" till den första samaraien
            // Lägg dessutom till två Samuraier till (Erik och Bob)

            ch.Line("MultipleOperations");
            var samurai = _context.Samurais.FirstOrDefault();
            ch.Line("After FirstOrDefault");

            samurai.Name += "San";
            _context.Samurais.Add(new Samurai { Name = "Erik" });
            _context.Add(new Samurai { Name = "Bob", SecretIdentity = new SecretIdentity { RealName = "Robert" } });

            ch.Line("Before Save");
            _context.SaveChanges();
            ch.Line("After Save");
        }

        private static void RetrieveAndUpdateMultipleSamurais()
        {
            // Hämta alla samuraier från databasen
            // Modifiera dem på valfritt sätt lokalt (inget anrop till databasen sker vid ForEach)

            ch.Line("RetrieveAndUpdateMultipleSamurais");
            var samurais = _context.Samurais.ToList();

            ch.Line("Modification Before");
            samurais.ForEach(s => s.Name += "Zooooom");
            ch.Line("Modification End");

            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateSamurai()
        {
            // Hämta en samurai från databasen
            // Modifiera
            // SaveChanges => uppdateringen sker

            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "Brutal";
            _context.SaveChanges();
        }

        private static void InvestigateIdValueChangesOnEntities()
        {
            // Lägg till en Samurai med flera Quotes
            // Primary och foreign key skapas automatiskt

            ch.Line("InvestigateIdValueChangesOnEntities");

            var samurai = new Samurai
            {
                Name = "Kyūzō",
                Quotes = new List<Quote> {
                  new Quote {Text = "Watch out for my sharp sword!"},
                  new Quote {Text = "I told you to watch out for the sharp sword! Oh well!" }
                }
            };

            // Samurai id = 0 
            ch.Green("Samurai id", samurai.Id);
            ch.Green("Quote id", samurai.Quotes.First().Id);
            _context.Samurais.Add(samurai);

            ch.Line();

            // Nu trackas Samurien och den får ett lågt negativt värde
            ch.Green("Samurai id", samurai.Id);
            ch.Green("Quote id", samurai.Quotes.First().Id);
            ch.Green("int.MinValue", int.MinValue);

            _context.SaveChanges();

            ch.Line();

            // Efter att databasen är uppdaterad så vet vi det verkliga id't
            ch.Green("Samurai id", samurai.Id);
            ch.Green("Quote id", samurai.Quotes.First().Id);

        }



        private static void InvestigateIQuerable()
        {
            ch.Line("InvestigateIQuerable");

            // Lägg till några samuarjer

            AddSomeSamurais();

            // Undersök vad IQuerable-objektet innehåller

            IQueryable<Samurai> test = _context.Samurais.Where(x=>x.Name.StartsWith("J") || x.Name.StartsWith("L"));

            // Dessa är unika properties för IQuerable:

            Type elementType = test.ElementType;
            System.Linq.Expressions.Expression expression = test.Expression;
            IQueryProvider queryProvider = test.Provider;

            ch.Green($"expression.ToString() = {expression.ToString()}"); // ==> ger själva frågan på detta format: .Where(x => (x.Name.StartsWith("J") OrElse x.Name.StartsWith("L")))
            ch.Green($"elementType.Name = {elementType.Name}"); // ==> Samurai
            // queryProvider innehåller metoder Execute och CreateQuery

        }

        private static void AddSamuraiBattlesManually(int samuraiId, int samuraiBattleId)
        {
            // Om id'n saknas så fås DbUpdateException

            ch.Line("AddSamuraiBattlesManually");

            var sb = new SamuraiBattle { SamuraiId = samuraiId, BattleId = samuraiBattleId };
            _context.SamuraiBattles.Add(sb);

            try
            {
                _context.SaveChanges();
                ch.Green($"SamuraiBattle added ({samuraiId}, {samuraiBattleId})");
            }
            catch (DbUpdateException ex)
            {
                ch.Red(ex.InnerException.Message);
            }
        }

        private static void GetBattlesForSamurai(string samuraiName)
        {
            // ThenInclude fortsätter på SamuraiBattles
            // Med bara Include så är vi fast i Samurai

            // ThenInclude måste läggas efter en Include (inte direkt från start)

            _context = new SamuraiContext();
            var samuraiWithBattles = _context.Samurais
              .Where(s => s.Name == samuraiName)
              .Include(s => s.SamuraiBattles)
              .ThenInclude(sb => sb.Battle).FirstOrDefault();

            if (samuraiWithBattles == null)
            {
                ch.Red($"{samuraiName} not found");
                return;
            }

            ch.Green($"Samurai {samuraiName} is participating in the following battles:");

            samuraiWithBattles.SamuraiBattles.ToList().ForEach(
                sb => ch.Green(sb.Battle.Id, sb.Battle.Name)
            );
            

        }

    }
}