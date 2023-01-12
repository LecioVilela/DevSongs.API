using AutoMapper;
using DevSongs.Application.InputModels;
using DevSongs.Application.ViewModels;
using DevSongs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSongs.Application.Profiles
{
    public class SongProfile : Profile
    {
        public SongProfile()
        {
            CreateMap<NewSongInputModel, Song>();

            CreateMap<Song, SongViewModel>();
        }
    }
}
