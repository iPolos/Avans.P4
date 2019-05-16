using System;
using System.Windows.Input;
using AV.DoToo.KlasB.Models;
using AV.DoToo.KlasB.Repositories;
using Xamarin.Forms;

namespace AV.DoToo.KlasB.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private readonly TodoItemRepository _todoItemRepository;

        public TodoItem Item { get; set; }

        public ItemViewModel(TodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
            Item = new TodoItem { Due = DateTime.Now.AddDays(1) };
        }

        public ICommand SaveItem => new Command(async () =>
        {
            await _todoItemRepository.AddItem(Item);
            await Navigation.PopAsync();
        });
    }
}
