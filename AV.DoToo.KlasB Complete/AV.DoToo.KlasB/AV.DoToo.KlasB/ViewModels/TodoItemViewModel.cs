using System;
using AV.DoToo.KlasB.Models;

namespace AV.DoToo.KlasB.ViewModels
{
    public class TodoItemViewModel : ViewModel
    {
        public TodoItem Item { get; set; }
        public event EventHandler ItemStatusChanged;

        public TodoItemViewModel(TodoItem item)
        {
            Item = item;
        }

        public string StatusText => Item.Completed ? "Reactivate" : "Completed";
    }
}
