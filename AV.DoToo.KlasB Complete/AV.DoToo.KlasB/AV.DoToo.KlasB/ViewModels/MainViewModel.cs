using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AV.DoToo.KlasB.Models;
using AV.DoToo.KlasB.Repositories;
using AV.DoToo.KlasB.Views;
using Xamarin.Forms;

namespace AV.DoToo.KlasB.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly TodoItemRepository _todoItemRepository;
        public ObservableCollection<TodoItemViewModel> Items { get; set; }

        public TodoItemViewModel SelectedItem
        {
            get { return null; }
            set
            {
                Device.BeginInvokeOnMainThread(async () => await NavigateToItem(value));
                RaisePropertyChanged(nameof(SelectedItem));
            }
        }

        private async Task NavigateToItem(TodoItemViewModel item)
        {
            if (item == null)
            {
                return;
            }

            var itemView = Resolver.Resolve<ItemView>();
            var vm = itemView.BindingContext as ItemViewModel;
            vm.Item = item.Item;

            await Navigation.PushAsync(itemView);
        }

        public MainViewModel(TodoItemRepository todoItemRepository)
        {
            todoItemRepository.OnItemAdded += (sender, item) =>
                Items.Add(CreateToDoItemViewModel(item));
            todoItemRepository.OnItemUpdated += (sender, item) =>
                Task.Run(async () => await LoadData());

            _todoItemRepository = todoItemRepository;
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            var items = await _todoItemRepository.GetItems();
            var itemViewModels = items.Select(i => CreateToDoItemViewModel(i));
            Items = new ObservableCollection<TodoItemViewModel>(itemViewModels);
        }

        private TodoItemViewModel CreateToDoItemViewModel(TodoItem i)
        {
            var itemViewModel = new TodoItemViewModel(i);
            itemViewModel.ItemStatusChanged += ItemStatusChanged;
            return itemViewModel;
        }

        private void ItemStatusChanged(object sender, EventArgs e)
        {
        
        }

        public ICommand AddItem => new Command(async () =>
        {
            var itemView = Resolver.Resolve<ItemView>();
            await Navigation.PushAsync(itemView);
        });
    }
}
