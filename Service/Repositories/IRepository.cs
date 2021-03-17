using DataAccess.Entities;
using Service.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repositories
{
    public interface IRepository<T> where T:BaseEntity
    {
        List<T> GetAll();
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);

        List<MovieGenreVM> GetMovieGenreVMs();
        
    }
}
