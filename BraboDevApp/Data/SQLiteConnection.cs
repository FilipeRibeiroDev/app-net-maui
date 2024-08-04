using BraboDevApp.Models;
using SQLite;
using System.Linq.Expressions;

namespace BraboDevApp.Data
{
    public class SQLiteConnection<T> where T : BaseSQLiteModel, new()
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteConnection()
        {

        }

        async Task Init()
        {
            if (_connection is not null)
                return;

            _connection = new SQLiteAsyncConnection(GlobalSettings.DatabasePath, GlobalSettings.Flags);
            await _connection.CreateTableAsync<T>();
        }

        public async Task<T> GetAsync(int id)
        {
            await Init();
            return await _connection.Table<T>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predExpr)
        {
            await Init();
            return await _connection.Table<T>().Where(predExpr).FirstOrDefaultAsync();
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> predExpr)
        {
            await Init();
            return await _connection.Table<T>().Where(predExpr).ToListAsync();
        }

        public async Task<int> AddAsync(T model)
        {
            await Init();
            return await _connection.InsertAsync(model);
        }

        public async Task<int> UpdateAsync(T model)
        {
            await Init();
            return await _connection.UpdateAsync(model);
        }

        public async Task<int> DeleteAsync(T model)
        {
            await Init();
            return await _connection.DeleteAsync(model);
        }
    }
}
