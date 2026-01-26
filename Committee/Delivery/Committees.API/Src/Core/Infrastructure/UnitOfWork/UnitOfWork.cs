using Committees.Infrastructure.Helpers;

namespace Committees.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DBContext _dbContext;
        private IDbContextTransaction _transaction;
        public Guid _loggedInUserId;
        public UnitOfWork(DBContext dbContext, IHttpContextAccessor _httpContextAccessor)
        {
            _dbContext = dbContext;
            _loggedInUserId = LoggedInUserProvider.GetLoggedInUserId(_httpContextAccessor);

        }

        #region Transaction
        public void BeginTransaction() => _transaction = _dbContext.Database.BeginTransaction();
        public async Task BeginTransactionAsync() => _transaction = await _dbContext.Database.BeginTransactionAsync();
        public void Commit() => _transaction.Commit();
        public async Task CommitAsync() => await _transaction.CommitAsync();
        public void Rollback() => _transaction?.Rollback();
        public async Task RollbackAsync() => await _transaction.RollbackAsync();

        public void Dispose()
        {
            _transaction?.Dispose();
            _dbContext.Dispose();
        }
        public async Task DisposeAsync()
        {
            await _transaction.DisposeAsync();
            await _dbContext.DisposeAsync();
        }
        #endregion


        #region SaveChanges
        public void SaveChanges()
        {
            try
            {
                var entries = _dbContext.ChangeTracker.Entries()
                    .Where(e => (e.Entity is AuditEntity<Guid>) && (e.State == EntityState.Added || e.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Modified)
                    {
                        ((AuditEntity<Guid>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                        ((AuditEntity<Guid>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                        entityEntry.Property("CreatedOn").IsModified = false;
                        entityEntry.Property("CreatedBy").IsModified = false;
                    }

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((AuditEntity<Guid>)entityEntry.Entity).CreatedOn = DateTime.Now;
                        ((AuditEntity<Guid>)entityEntry.Entity).CreatedBy = _loggedInUserId;
                    }

                }
                if (_dbContext.Database.CurrentTransaction == null)
                    BeginTransaction();
                _dbContext.SaveChanges();
                //Commit();
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;

            }

        }

        public async Task SaveChangesAsync()
        {
            try
            {

                var entries = _dbContext.ChangeTracker.Entries()
.Where(e => (e.Entity is AuditEntity<Guid>) && (
     e.State == EntityState.Added
     || e.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Modified)
                    {
                        ((AuditEntity<Guid>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                        ((AuditEntity<Guid>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                        entityEntry.Property("CreatedOn").IsModified = false;
                        entityEntry.Property("CreatedBy").IsModified = false;


                    }

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((AuditEntity<Guid>)entityEntry.Entity).CreatedOn = DateTime.Now;
                        ((AuditEntity<Guid>)entityEntry.Entity).CreatedBy = _loggedInUserId;
                    }
                }
                if (_dbContext.Database.CurrentTransaction == null)
                    await BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                //Commit();
            }
            catch (Exception)
            {
                await RollbackAsync();

            }

        }
        #endregion


        #region SaveChanges
        public void LKSaveChanges()
        {
            try
            {
                var entries = _dbContext.ChangeTracker.Entries()
                    .Where(e => (e.Entity is AuditEntity<int>) && (e.State == EntityState.Added || e.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Modified)
                    {
                        ((AuditEntity<int>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                        ((AuditEntity<int>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                        entityEntry.Property("CreatedOn").IsModified = false;
                        entityEntry.Property("CreatedBy").IsModified = false;
                    }

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((AuditEntity<int>)entityEntry.Entity).CreatedOn = DateTime.Now;
                        ((AuditEntity<int>)entityEntry.Entity).CreatedBy = _loggedInUserId;
                    }

                }
                if (_dbContext.Database.CurrentTransaction == null)
                    BeginTransaction();
                _dbContext.SaveChanges();
                //Commit();
            }
            catch (Exception ex)
            {
                Rollback();
                throw ex;

            }

        }

        public async Task LKSaveChangesAsync()
        {
            try
            {

                var entries = _dbContext.ChangeTracker.Entries()
.Where(e => (e.Entity is AuditEntity<int>) && (
     e.State == EntityState.Added
     || e.State == EntityState.Modified));

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Modified)
                    {
                        ((AuditEntity<int>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                        ((AuditEntity<int>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                        entityEntry.Property("CreatedOn").IsModified = false;
                        entityEntry.Property("CreatedBy").IsModified = false;


                    }

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((AuditEntity<int>)entityEntry.Entity).CreatedOn = DateTime.Now;
                        ((AuditEntity<int>)entityEntry.Entity).CreatedBy = _loggedInUserId;
                    }
                }
                if (_dbContext.Database.CurrentTransaction == null)
                    await BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                //Commit();
            }
            catch (Exception)
            {
                await RollbackAsync();

            }

        }
        #endregion

    }
}
