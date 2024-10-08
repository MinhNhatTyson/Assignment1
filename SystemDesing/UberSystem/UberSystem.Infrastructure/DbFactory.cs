using System;
using Microsoft.EntityFrameworkCore;
 
namespace UberSystem.Infrastructure
{
	public class DbFactory : IDisposable
	{
    	private bool _disposed;
    	private Func<UberSystemDbContext> _instanceFunc;
    	private DbContext _dbContext;
    	public DbContext DbContext => _dbContext ?? (_dbContext = _instanceFunc.Invoke());
 
        public DbFactory(Func<UberSystemDbContext> dbContextFactory)
    	{
        	_instanceFunc = dbContextFactory;
    	}
 
    	public void Dispose()
    	{
        	if (!_disposed && _dbContext != null)
        	{
            	_disposed = true;
            	_dbContext.Dispose();
        	}
    	}
	}
}