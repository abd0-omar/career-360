using Microsoft.EntityFrameworkCore;
using WebApplication1.DTO;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class GenericRepository<TEntity>(KompanyContext db) where TEntity: class
{
    // have all the CRUD queries
    public List<TEntity> GetAll() => db.Set<TEntity>().ToList();
    public TEntity? GetById(int id) => db.Set<TEntity>().Find(id);
    // delete 
    public bool Delete(int id)
    {
        var entity = db.Set<TEntity>().Find(id);
        if (entity == null) return false;
        db.Remove(entity);
        return true;
    }
    // edit
    public void Edit(TEntity entity)
    {
        db.Set<TEntity>().Entry(entity).State = EntityState.Modified;
    }
    // add
    public void Add(TEntity entity)
    {
        db.Set<TEntity>().Add(entity);
    }
}