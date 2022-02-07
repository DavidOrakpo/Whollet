using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Whollet.Model.Helpers
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            //Establishing the conection
            _database = new SQLiteAsyncConnection(dbPath);
            // write each statement for the amount of tables you wish to create
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Address>().Wait();
        }

        // Show the registers
        public Task<List<T>> GetTableAsync<T>() where T : new()
        {
            var temp = _database.Table<T>().ToListAsync();     
            
            return temp;
        }

        // Save registers
        public Task<int> SaveAsync<T>(T model) where T : new()
        {
            return _database.InsertAsync(model);
        }

        public Task<T> GetWithChidsAsync<T>(int objectID) where T : new()
        {
            return _database.GetAsync<T>(objectID);
        }

        // Delete registers
        public Task<int> DeleteAsync<T>(T model) where T : new()
        {
            return _database.DeleteAsync(model);
        }

        public Task<int> DeleteAllAsync<T>() where T : new()
        {
          return  _database.DeleteAllAsync<T>();
            
        }

        // Save registers
        public Task<int> UpdateAsync<T>(T model) where T: new()
        {
            return _database.UpdateAsync(model);
        }
    }
}
