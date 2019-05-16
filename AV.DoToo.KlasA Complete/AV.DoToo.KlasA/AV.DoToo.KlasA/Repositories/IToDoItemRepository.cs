﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AV.DoToo.KlasA.Models;

namespace AV.DoToo.KlasA.Repositories
{
    public interface IToDoItemRepository
    {
        event EventHandler<ToDoItem> OnItemAdded;
        event EventHandler<ToDoItem> OnItemUpdated;

        Task<List<ToDoItem>> GetItems();
        Task AddItem(ToDoItem item);
        Task UpdateItem(ToDoItem item);
        Task AddOrUpdate(ToDoItem item);
    }
}
