using System;
using System.Windows.Input;
using AV.DoToo.KlasA.Models;
using Xamarin.Forms;

namespace AV.DoToo.KlasA.ViewModels
{
    public class ToDoItemViewModel : ViewModel
    {
        public ToDoItem Item { get; set; }

        public ToDoItemViewModel(ToDoItem item) => Item = item;

        public event EventHandler ItemStatusChanged;
        public string StatusText => Item.Completed ? "Reactivate" : "Completed";

        public ICommand ToggleCompleted => new Command((arg) =>
        {
            Item.Completed = !Item.Completed;
            ItemStatusChanged?.Invoke(this, new EventArgs());
        });
    }
}
