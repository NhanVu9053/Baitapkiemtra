
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System;

namespace Postmanagement
{
  public   class Forum 
    { int increment = 0;
        public  Post post = new Post();
        //public Post post = new Post();
        public SortedList<int,Post> posts= new SortedList<int, Post>() ;

        public  int Add()
        {
            increment++;
            post.Id = increment;
            System.Console.WriteLine("input title:");
            post.Title = Console.ReadLine();
            Console.WriteLine("input content:");
            post.Content = Console.ReadLine();
            Console.WriteLine("input author:");
            post.Author = Console.ReadLine();
            posts.Add(post.Id, post);
            return post.Id;
        }

        public int Find(int number)
        {
            int pos = -1;
            foreach( var item in posts.Keys)
            {
                if (item == number)
                {
                    pos= item;
                }
            }
            return pos;
        }
        
        public void Update(int id,string content)
        {
          int  pos = Find(id);
            if(pos != -1)
            {
                posts[pos].Content = content;
            }
             
        }
        public void Remove(int id, string content)
        {
            int pos = Find(id);
            if (pos != -1)
            {
                posts.Remove(id);
            }
        }
        public void Show()
        {
            foreach (var item in posts.Keys)
            {
                posts[item].DisPlay();
            }
        }

        internal void Remove(int id, object content)
        {
            throw new NotImplementedException();
        }
        public Post FindAuthor(string authors)
        {
            int pos = -1;
            //for (int i = 1; i <= Posts.Count; i++)
            //{
            //    if (Posts[i].Author == authors)
            //    {
            //        pos = i;
            //    }
            //}
            foreach (var item in posts.Keys)
            {
                if (posts[item].Author == authors)
                {
                    pos = item;
                }
            }
            if (pos != -1) return posts[pos];
            else return (Post)default;
        }

    }
}
