using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSongs.Application.ViewModels
{
    public class SongViewModel
    {
        public SongViewModel(int id, string title, DateTime registeredAt)
        {
            Id = id;
            Title = title;
            RegisteredAt = registeredAt;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime RegisteredAt { get; private set; }
    }
}
