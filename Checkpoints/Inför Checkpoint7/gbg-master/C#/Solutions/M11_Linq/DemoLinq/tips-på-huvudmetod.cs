        public void Run()
        {
            List<Show> allShows = GetShowsFromTextFile();

            DisplayInfoAboutShows(allShows);

            Console.ReadKey();
        }