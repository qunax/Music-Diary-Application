﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MusicDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicDiary.DBContexts
{
    public class MusicDiaryDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Artist> Artists { get; set; }



        public MusicDiaryDbContext(DbContextOptions options) : base(options)
        {
        }
    }

    public class MusicDiaryDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MusicDiaryDbContext>
    {
        public MusicDiaryDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=musicDiary.db").Options;

            return new MusicDiaryDbContext(options);
        }
    }

    public class MusicDiaryDbContextFactory
    {
        private readonly string _connectionString;

        public MusicDiaryDbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MusicDiaryDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            return new MusicDiaryDbContext(options);
        }
    }
}
