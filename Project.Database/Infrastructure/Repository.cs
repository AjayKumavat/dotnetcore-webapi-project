using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Database.Infrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected ProjectContext ProjectContext { get; set; }
        public Repository(ProjectContext projectContext)
        {
            this.ProjectContext = projectContext;
        }

        #region Crud Implementation
        public virtual void Add(T entity)
        {
            ProjectContext.Add(entity);
        }

        public virtual void Add(List<T> entity)
        {
            ProjectContext.AddRange(entity);
        }

        public virtual void Delete(T entity)
        {
            ProjectContext.Set<T>().Remove(entity);
        }

        public virtual void Update(T entity)
        {
            ProjectContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            ProjectContext.Set<T>().Update(entity);
        }

        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> expression)
        {
            return await ProjectContext.Set<T>().Where(expression).ToListAsync();
        }

        public virtual async Task<T> GetDefault(Expression<Func<T, bool>> expression)
        {
            return await ProjectContext.Set<T>().Where(expression).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await ProjectContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await ProjectContext.Set<T>().FindAsync(id);
        }
        #endregion
    }
}
