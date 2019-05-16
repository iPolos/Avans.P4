using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AV.DoToo.KlasA.Models;
using SQLite;

namespace AV.DoToo.KlasA.Repositories
{
    public class ToDoItemRepository : IToDoItemRepository
    {
        private SQLiteAsyncConnection connection;

        public event EventHandler<ToDoItem> OnItemAdded;
        public event EventHandler<ToDoItem> OnItemUpdated;

        private async Task CreateConnection()
        {
            if (connection != null)
            {
                return;
            }

            var documentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var databasePath = Path.Combine(documentPath, "TodoItems.db");

            connection = new SQLiteAsyncConnection(databasePath);
            await connection.CreateTableAsync<ToDoItem>();

            if (await connection.Table<ToDoItem>().CountAsync() == 0)
            {
                await connection.InsertAsync(new ToDoItem() { Title = "Welcome to DoToo" });
            }
        }

        public async Task AddItem(ToDoItem item)
        {
            await CreateConnection();
            await connection.InsertAsync(item);
            OnItemAdded?.Invoke(this, item);
        }

        public async Task AddOrUpdate(ToDoItem item)
        {
            if (item.Id == 0)
            {
                await AddItem(item);
            }
            else
            {
                await UpdateItem(item);
            }
        }

        public async Task<List<ToDoItem>> GetItems()
        {
            await CreateConnection();
            return await connection.Table<ToDoItem>().ToListAsync();
        }

        public async Task UpdateItem(ToDoItem item)
        {
            await CreateConnection();
            await connection.UpdateAsync(item);
            OnItemUpdated?.Invoke(this, item);
        }
    }
}
