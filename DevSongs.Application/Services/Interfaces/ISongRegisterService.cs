using DevSongs.Application.InputModels;
using DevSongs.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSongs.Application.Services.Interfaces
{
    public interface ISongRegisterService
    {
        List<SongViewModel> GetAll(string query);
        SongViewModel GetById(int id);
        int Create(NewSongInputModel inputModel);
        void Update(UpdateSongInputModel inputModel);
        void Delete(int id);
    }
}
