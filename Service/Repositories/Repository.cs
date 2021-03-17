using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private DbSet<T> entities;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public void Create(T entity)
        {
            //context.Set<T>().Add(entity);
            if (entity != null)
            {
                entity.CreatedDate = DateTime.Now;
                entities.Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            try
            {
                entities.Remove(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public T GetById(int id)
        {
            return entities.Find(id);
        }

        public List<MovieGenreVM> GetMovieGenreVMs()
        {
            var result = from movie in context.Movies
                         join mg in context.MovieGenres on movie.Id equals mg.MovieId
                         join genre in context.Genres on mg.GenreId equals genre.Id
                         select new { movie.Id, movie.MovieName, movie.Description, movie.Duration, genre.GenreName };

            List<MovieGenreVM> movieGenreVMs = new List<MovieGenreVM>();
            foreach (var mg in result)
            {
                bool exist = false;
                foreach (var mgVM in movieGenreVMs)
                {
                    if (mg.Id == mgVM.MovieId)
                    {
                        exist = true;
                        mgVM.GenreName += "," + mg.GenreName;
                        break;
                    }
                }
                if (exist == false || movieGenreVMs.Count == 0)
                {
                    var moviegenre = new MovieGenreVM { MovieId = mg.Id, MovieName = mg.MovieName, Description = mg.Description, Duration = mg.Duration, GenreName = mg.GenreName };
                    movieGenreVMs.Add(moviegenre);
                }
               
            }
            return movieGenreVMs;
        }

        public void Update(T entity)
        {
            try
            {
                entities.Update(entity);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new NotSupportedException(ex.Message);
            }
        }
    }
}
