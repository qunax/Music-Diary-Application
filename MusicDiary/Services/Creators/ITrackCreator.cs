﻿using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.Services.Creators
{
    public interface ITrackCreator
    {
        Task CreateTrack(Track track);
    }
}
