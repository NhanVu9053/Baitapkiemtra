using System;
using System.Net.Mime;

namespace Postmanagement
{
    class Program
    {
        public static Forum forum = new Forum();
        public int increment = 0;

        public static void Main(string[] args)
        {
            int choice = 0;
            while (choice != 7)
            {
                string temp;
                Console.WriteLine("Please select an option: ");
                Console.WriteLine("1. Create Post ");
                Console.WriteLine("2. Update Post");
                Console.WriteLine("3. Remove Post");
                Console.WriteLine("4. Show Posts");
                Console.WriteLine("5. Search Author");
                Console.WriteLine("6. Rating");
                Console.WriteLine("7. Exit");
                do
                {
                    Console.Write("Enter choice:  ");
                    temp = Console.ReadLine();
                }
                while (!IsNumber(temp) || int.Parse(temp) > 7);
                choice = int.Parse(temp);
                switch (choice)
                {
                    case 1:
                        CreatPost();
                       
                        break;
                    case 2:
                        UpdatePost();
                        
                        break;
                    case 3:
                        RemovePost();
                        
                        break;
                    case 4:
                        ShowPost();
                       
                        break;
                    case 5:
                        SearchAuthor();
                       
                        break;
                    case 6:
                        Rating();
                       
                        break;
                }
            }
            void CreatPost()
            {
                int id = forum.Add();
                string key = "Y";
                do
                {
                    bool result;
                    int number;
                    do
                    {
                        System.Console.WriteLine(" enter rate: "); ;
                        result = int.TryParse(Console.ReadLine(), out number);
                    } while (!result || number < 0 || number > 5);
                    forum.posts[id].RateList.Add(number);
                    Console.Write("continue r? (Y/N): ");
                    key = Console.ReadLine();
                }
                while (key.ToUpper() != "N");
                forum.posts[id].CalculatorRate();

            }
            bool IsNumber(string pValue)
            {
                foreach (Char c in pValue)
                {
                    if (!Char.IsDigit(c))
                        return false;
                }
                return true;
            }
            void UpdatePost()
            {
                Console.WriteLine("Enter id: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter new content: ");
                string conten = Console.ReadLine();
                forum.Update(id, conten);
            }
            void RemovePost()
            {
                Console.WriteLine("Enter new content: ");
                string conten = Console.ReadLine();
                Console.WriteLine("Enter id: ");
                int id = int.Parse(Console.ReadLine());
                forum.Remove(id, conten);
            }
            void ShowPost()
            {
                forum.Show();
            }
            void SearchAuthor()
            {
                Console.WriteLine("Please input author");
                string author = Console.ReadLine();
                Post l = forum.FindAuthor(author);
                l.DisPlay();
            }
            void Rating()
            {
                Console.WriteLine("Enter id: ");
                int id = int.Parse(Console.ReadLine());
                int pos = forum.Find(id);
                if (pos != -1)
                {
                    bool result;
                    int number;
                    do
                    {
                        Console.WriteLine($" enter rate: ");

                        result = int.TryParse(Console.ReadLine(), out number);

                    } while (!result || number < 0 || number > 5);

                    forum.posts[id].RateList.Add(number);
                    forum.posts[id].CalculatorRate();

                }
                else
                {
                    Console.WriteLine("Invalid Post  ");
                }
            }
        }


    }
}

