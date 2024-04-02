using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace SqliteTutorial
{
    public class Database
    {

        private SQLiteAsyncConnection _connection;

        public Database(string path) 
        { 
            // Path.Combine("", path) prej lepsi nez (path)
            _connection = new SQLiteAsyncConnection(Path.Combine("", path));
            // async = proces se zpracovava vedle, wait pocka az proces skonci mimo hlavni vlakno
            _connection.CreateTableAsync<Avenger>().Wait();
        }

        public Task<List<Avenger>> GetItemsAsync()
        {
            return _connection.Table<Avenger>().ToListAsync();
        }

        public Task<int> SaveItemAsync(Avenger item)
        {
            // you know you need to update
            if(item.Id != 0)
            {
                return _connection.UpdateAsync(item);

            }
            // else insert
            else
            {
                return _connection.InsertAsync(item);
            }
            
        }
    }
}
