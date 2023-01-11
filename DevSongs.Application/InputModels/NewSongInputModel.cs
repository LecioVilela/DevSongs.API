using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSongs.Application.InputModels
{
    public class NewSongInputModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Album { get; set; }
        public string Gender { get; set; }
    }
}
