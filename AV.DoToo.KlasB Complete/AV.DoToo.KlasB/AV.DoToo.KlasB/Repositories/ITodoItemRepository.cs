using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AV.DoToo.KlasB.Models;

namespace AV.DoToo.KlasB.Repositories
{
    public interface ITodoItemRepository
    {
        event EventHandler<TodoItem> OnItemAdded;
        event EventHandler<TodoItem> OnItemUpdated;

        Task<List<TodoItem>> GetItems();
        Task AddItem(TodoItem item);
        Task UpdateItem(TodoItem item);
        Task AddOrUpdateItem(TodoItem item);
    }
}
