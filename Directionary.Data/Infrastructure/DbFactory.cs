using System;

namespace Directionary.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DirectionaryDbContext Init();
    }
    public class DbFactory : Disposable, IDbFactory
    {
        private DirectionaryDbContext dbContext;

        public DirectionaryDbContext Init()
        {
            return dbContext ?? (dbContext = new DirectionaryDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}