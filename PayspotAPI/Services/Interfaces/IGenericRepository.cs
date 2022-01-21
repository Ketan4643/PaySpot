using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace PayspotAPI.Services.Interfaces;
public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAll(
        Expression<Func<T, bool>> expression = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    Task<IPagedList<T>> GetPagedList(
        RequestParams requestParams, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);

    Task<T> Get(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
    Task Insert(T entity);
    Task InsertRange(IEnumerable<T> entities);
    Task Delete(int id);
    void DeleteRange(IEnumerable<T> entities);
    void Update(T entity);
}
