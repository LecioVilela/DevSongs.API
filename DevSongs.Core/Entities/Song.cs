using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSongs.Core.Entities
{
    public class Song : BaseEntity
    {
        public Song(string title, string author, string album, string gender)
        {
            Title = title;
            Author = author;
            Album = album;
            Gender = gender;
            RegisteredAt = DateTime.Now;
        }

        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Album { get; private set; }
        public string Gender { get; private set; }
        public DateTime RegisteredAt { get; private set; }

        public void Update(string title, string author)
        {
            Title = title;
            Author = author;
        }
    }
}
