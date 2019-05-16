using System;
using System.Windows.Input;
using AV.DoToo.KlasA.Models;
using AV.DoToo.KlasA.Repositories;
using Xamarin.Forms;

namespace AV.DoToo.KlasA.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private ToDoItemRepository repository;
        public ToDoItem todoItem { get; set; }

        public ItemViewModel(ToDoItemRepository repository)
        {
            this.repository = repository;
            todoItem = new ToDoItem() { Due = DateTime.Now.AddDays(1) };
        }

        public ICommand Save => new Command(async() => {
            await repository.AddOrUpdate(todoItem);
            await Navigation.PopAsync();
        });
    }
}
