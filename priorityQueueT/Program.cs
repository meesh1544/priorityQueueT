using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel.Design;

namespace priorityQueueT
{
    public class Holiday
    {
        public string Name { get; set; } = string.Empty;
        public int Rating { get; set; }
        public Holiday(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }
     }
    internal class Program
    {
        static void Main(string[] args)
        {
            var holiday = new List<(Holiday, int)>()
            {
                (new("Christmas", 1),1),
                (new("Halloween", 2),2),
                (new("Thanksgiving", 5),3),
                (new("Forth of July", 10), 4),
                (new("St. Patricks Day", 3), 5),
            };
            var holidayQueue = new PriorityQueue < Holiday, int>(holiday);
            int selection = Menu();
            string name;
            int rating, priority;
            while(selection != 4)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Holiday Name: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Rating: ");
                        rating=int.Parse(Console.ReadLine());  
                        priority = int.Parse(Console.ReadLine());
                        holidayQueue.Enqueue(new Holiday(name, rating), priority);    
                        break;
                    case 2:
                        holidayQueue.TryPeek(out Holiday nextHoliday, out int holidayPriority);
                        Console.WriteLine($"Highest priority holiday: {nextHoliday.Name}, Rating: {nextHoliday.Rating}");
                        break;
                    case 3:
                        holidayQueue.TryDequeue(out Holiday lessHoliday, out int lessPriority);
                        Console.WriteLine($"Holiday is over, next: {lessHoliday.Name}, Rating: {lessHoliday.Rating}");
                        break;
                    default:
                        Console.WriteLine("You have entered an invalid selection, try again");
                        break;
                }
                selection = Menu();
            }
        }
        static int Menu()
        {
            Console.WriteLine("Holiday Priority Queue");
            Console.WriteLine("1 to Add a holiday\n2 to view the highest priority\n3 to move to the next holiday\n4 to quit");
            int choice = int.Parse (Console.ReadLine());
            return choice;
        }
    }
}
