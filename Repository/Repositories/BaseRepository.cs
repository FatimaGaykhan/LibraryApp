﻿using System;
using System.Linq.Expressions;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected readonly AppDbContext _context;

        protected readonly DbSet<T> _entities;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();

        }

        public async Task EditAsync(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.AsNoTracking().ToListAsync();
        }



        public async Task<T> GetById(int id)
        {
            return await _entities.AsNoTracking().Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public IQueryable<T> Find(Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _entities;
            if (include is not null)
            {
                query = include(query);
            }

            return query.AsNoTracking();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _entities;

            query = query.Where(predicate);

            if (include is not null)
            {
                query = include(query);
            }

            return query.AsNoTracking();

        }
    }
}

