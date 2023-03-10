using AutoMapper;
using DevSongs.Application.InputModels;
using DevSongs.Application.Services.Interfaces;
using DevSongs.Application.ViewModels;
using DevSongs.Core.Entities;
using DevSongs.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSongs.Application.Services.Implementations
{
    public class SongService : ISongService
    {
        // alterar depois para SongService
        private readonly DevSongsDbContext _dbContext;
        private readonly IMapper _mapper;

        public SongService(DevSongsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public int Create(NewSongInputModel inputModel)
        {
            var song = new Song(inputModel.Title, inputModel.Author, inputModel.Album, inputModel.Gender);

            _dbContext.Songs.Add(song);
            _dbContext.SaveChanges();

            return song.Id;
        }

        public void Delete(int id)
        {
            var song = _dbContext.Songs.SingleOrDefault(s => s.Id == id);
            _dbContext.SaveChanges();
        }

        public List<SongViewModel> GetAll(string query)
        {
            var songs = _dbContext.Songs.ToList();

            var songViewModel = _mapper.Map<List<SongViewModel>>(songs);

            //var songViewModel = song.Select(s => new SongViewModel(s.Id, s.Title, s.RegisteredAt)).ToList();

            return songViewModel;
        }

        public SongViewModel GetById(int id)
        {
            var song = _dbContext.Songs.SingleOrDefault(s => s.Id == id);

            if(song is null)
            {
                return null;
            }

            var songViewModel = _mapper.Map<SongViewModel>(song);

            //var songViewModel = new SongViewModel(song.Id, song.Title, song.RegisteredAt); 

            return songViewModel;
        }

        public void Update(UpdateSongInputModel inputModel)
        {
            var song = _dbContext.Songs.FirstOrDefault(s => s.Id == inputModel.Id);

            song.Update(inputModel.Title, inputModel.Id.ToString());

            _dbContext.SaveChanges();
        }
    }
}
