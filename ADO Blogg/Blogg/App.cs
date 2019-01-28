using Blogg.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blogg
{
    class App
    {
        DataAccess dataAccess = new DataAccess();

        internal void Run()
        {
            PageMainMenu();
        }

        private void PageMainMenu()
        {

            Header("HUVUDMENY");

            ShowAllPosts();

            ShowMainMenue();
        }

        private void PageUpdateBlogPost()
        {
            Header("Uppdatera bloggpost");

            List<Blogpost> list = dataAccess.GetAllBlogPostsBrief();

            PrintAllBlogPostBrief(list);

            int index = ShowMenueChooseBloggpost();

            Blogpost blogpost = list[index-1];

            WriteLine("Den nuvarande titeln är: " + blogpost.Title);

            WriteLine("Ange ny titel");

            string newTitle = Console.ReadLine();

            blogpost.Title = newTitle;

            dataAccess.UpdateBlogpost(blogpost);

            WriteLine("Bloggposten uppdaterad");
            Console.ReadKey();
            PageMainMenu();
        }

        private int ShowMenueChooseBloggpost()
        {
            WriteLine("Vilken bloggpost vill du ändra på? (ange index)");
            int usersChoice = int.Parse(Console.ReadLine());

            return usersChoice;
        }

        private void ShowMainMenue()
        {
            WriteLine("Vad vill du göra?");
            WriteLine("a) Gå till huvudmenyn");
            WriteLine("b) Uppdatera en bloggpost");
            WriteLine("c) Ta bort en bloggpost");
            WriteLine("d) Lägg till tagg");
            WriteLine("e) Ta bort tagg");
            WriteLine("f) Lägg till kommentar");
            WriteLine("g) Visa en bloggposts kommentarer");
            WriteLine("h) Gör bloggpost");

            var command = Console.ReadKey(true).Key;

            switch (command)
            {
                case ConsoleKey.A:
                    PageMainMenu();
                    break;
                case ConsoleKey.B:
                    PageUpdateBlogPost();
                    break;
                case ConsoleKey.C:
                    PageDeleteBlogPost();
                    break;
                case ConsoleKey.D:
                    PageAddTag();
                    break;
                case ConsoleKey.E:
                    PageDeleteTag();
                    break;
                case ConsoleKey.F:
                    PageAddComment();
                    break;
                case ConsoleKey.G:
                    PageShowComments();
                    break;
                case ConsoleKey.H:
                    PageCreateBlogpost();
                    break;
                default:
                    break;
            }
        }

        private void PageCreateBlogpost()
        {
            Header("Gör en bloggpost");

            List<Blogpost> list = dataAccess.GetAllBlogPostsBrief();

            Blogpost blogpost = new Blogpost();
            Console.Write("Ange namn: ");
            string name = Console.ReadLine();
            blogpost.Author = name;
            Console.Write("Gör bloggpost: ");
            string newBlogPost = Console.ReadLine();
            blogpost.Title = newBlogPost;

            dataAccess.AddBlogPost(blogpost);

            WriteLine("Bloggpost är är tillagd");
            Console.ReadKey();
            PageMainMenu();
        }

        private void PageDeleteTag()
        {
            Header("Ta bort en tagg");

            List<Blogpost> list = dataAccess.GetAllTags();

            ShowAllTags();

            WriteLine("Vilken tagg vill du ta bort? (ange index)");
            int index = int.Parse(Console.ReadLine());
            Blogpost blogpost = list[index - 1];
            dataAccess.DeleteTag(blogpost);


            WriteLine("Taggen borttagen");
            Console.ReadKey();
            PageMainMenu();
        }

        private void PageAddTag()
        {
            Header("Addera en tagg");

            List<Blogpost> tagList = ShowAllTags();

            WriteLine("Bloggposter:");
            List<Blogpost> list = dataAccess.GetAllBlogPostsBrief();
            ShowAllPosts();

            WriteLine("Vilken bloggpost vill du addera en tagg till? (ange index)");
            int index = int.Parse(Console.ReadLine());
            Blogpost blogpost = list[index - 1];
            Console.WriteLine();


            WriteLine("Ange tagg! Här kan du både lägga till en helt ny tagg eller addera en befintlig till en bloggpost:");

            string newTag = Console.ReadLine();
            blogpost.Tag = newTag;

            bool doesTagExist = dataAccess.DoesTagExist(blogpost);
            bool doesTagPostCombinationExist = dataAccess.DoesTagPostCombinationExist(blogpost);
            if (!doesTagExist && !doesTagPostCombinationExist)
            {
                dataAccess.AddTag(blogpost);
                dataAccess.AddTagToBlogPost(blogpost);
            }
            else if (doesTagExist && !doesTagPostCombinationExist)
            {
                dataAccess.AddTagToBlogPost(blogpost);
            }
            else
            {
                WriteLine("Taggen finns redan!");
                Console.ReadKey();
                PageAddTag();
            }
            
           
            Console.WriteLine();
            WriteLine("Tagg är tillagd");
            Console.ReadKey();
            PageMainMenu();
        }


        private List<Blogpost> ShowAllTags()
        {
            WriteLine("Befintliga taggar:");

            List<Blogpost> list = dataAccess.GetAllTags();

            for (int index = 1; index <= list.Count; index++)
            {
                WriteLine($"{index,-5}{list[index - 1].Tag,-10}");
            }

            Console.WriteLine();

            return list;
        }

        private void PageShowComments()
        {
            Header("Visa kommentarer");

            List<Blogpost> list = dataAccess.GetAllBlogPostsBrief();

            ShowAllPosts();

            WriteLine("För vilken bloggpost vill du visa alla kommentarer? (ange index)");
            int index = int.Parse(Console.ReadLine());
            Blogpost blogpost = list[index - 1];
            List<Blogpost> commentList = dataAccess.ShowComments(blogpost);

            Console.WriteLine();
            Console.WriteLine("Kommentarer:" );
            foreach (var item in commentList)
            {
                Console.WriteLine($"{item.Comment}");
            }
            Console.ReadKey();
            PageMainMenu();
        }

        private void PageAddComment()
        {
            Header("Addera en kommentar");

            List<Blogpost> list = dataAccess.GetAllBlogPostsBrief();

            ShowAllPosts();

            WriteLine("Vilken bloggpost vill du addera en kommentar till? (ange index)");
            int index = int.Parse(Console.ReadLine());
            Blogpost blogpost = list[index - 1];
            WriteLine("Ange ny kommentar:");

            string newComment = Console.ReadLine();

            blogpost.Comment = newComment;
            dataAccess.AddComment(blogpost);


            WriteLine("Kommentar är tillagd");
            Console.ReadKey();
            PageMainMenu();
        }

        private void PageDeleteBlogPost()
        {
            Header("Ta bort en bloggpost");

            List<Blogpost> list = dataAccess.GetAllBlogPostsBrief();

            ShowAllPosts();

            WriteLine("Vilken bloggpost vill du ta bort? (ange index)");
            int index = int.Parse(Console.ReadLine());
            Blogpost blogpost = list[index - 1];
            dataAccess.DeleteBlogPost(blogpost);


            WriteLine("Bloggposten borttagen");
            Console.ReadKey();
            PageMainMenu();
        }
         

        private void ShowAllPosts()
        {

            List<Blogpost> list = dataAccess.GetAllBlogPostsBrief();

            PrintAllBlogPostBrief(list);

            WriteLine();
        }

        private void PrintAllBlogPostBrief(List<Blogpost> list)
        {
            for (int index = 1; index <= list.Count; index++)
            {
                WriteLine($"{index,-5}{list[index - 1].Author,-10}{list[index-1].Title,-30}");
            }
        }

        private void Header(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            text = text.ToUpper();

            Console.WriteLine();
            WriteLine(text);
            Console.WriteLine();

            Console.ResetColor();
        }

        private void WriteLine(string text = "")
        {
            Console.WriteLine(text);
        }

    }
}
