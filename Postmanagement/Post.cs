using System;
using System.Collections.Generic;
using System.Text;

namespace Postmanagement
{
  public  class Post : IPost
    {
        private int id;
        private string title;
        private string content;
        private string author;
        private float averageRate;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string Author { get => author; set => author = value; }
        public float AverageRate { get => averageRate; }
        public List<int> RateList = new List<int>();

        public void CalculatorRate()
        {
            float total = 0;
            foreach (var item in RateList)
            {
                total += item;
            }
            averageRate = total / RateList.Count;
        }

        public void DisPlay()
        {
            Console.WriteLine($"{id}\t{title}\t{author}\t{content}\t{averageRate}");
        }
    }
}
