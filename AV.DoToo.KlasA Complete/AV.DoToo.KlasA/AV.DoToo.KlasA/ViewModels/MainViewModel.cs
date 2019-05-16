using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AV.DoToo.KlasA.Models;
using AV.DoToo.KlasA.Repositories;
using AV.DoToo.KlasA.Views;
using Xamarin.Forms;

namespace AV.DoToo.KlasA.ViewModels
{
    public class MainViewModel : ViewModel
    {
        private readonly ToDoItemRepository repository;
        public ObservableCollection<ToDoItemViewModel> Items { get; set; }
        public bool ShowAll { get; set; }

        public string FilterText => ShowAll ? "All" : "Active";
        public ICommand ToggleFilter => new Command(async () =>
        {
            ShowAll = !ShowAll;
            await LoadData();
        });

        public ToDoItemViewModel SelectedItem { get { return null; } set
            {
                Device.BeginInvokeOnMainThread(async () => await NavigateToItem(value));
                RaisePropertyChanged(nameof(SelectedItem));
            } 
        }

        private async Task NavigateToItem(ToDoItemViewModel toDoItemViewModel)
        {
            if (toDoItemViewModel == null)
            {
                return;
            }
            var itemView = Resolver.Resolve<ItemView>();
            var vm = itemView.BindingContext as ItemViewModel;
            vm.todoItem = toDoItemViewModel.Item;
            await Navigation.PushAsync(itemView);
        }

        public MainViewModel(ToDoItemRepository repository)
        {
            //repository.OnItemAdded += (sender, item) =>
                //Items.Add(CreateToDoItemViewModel(item));

            //repository.OnItemUpdated += (sender, item) =>
                //Task.Run(async () => await LoadData());

            repository.OnItemAdded += OnItemAdded;
            repository.OnItemUpdated += OnItemUpdated;

            this.repository = repository;
            Task.Run(async () => await LoadData());
        }

        void OnItemAdded(object sender, ToDoItem item)
        {
            Items.Add(CreateToDoItemViewModel(item));
        }

        void OnItemUpdated(object sender, ToDoItem item)
        {
            Task.Run(async () => await LoadData());
        }

        private async Task LoadData()
        {
            var items = await repository.GetItems();

            if (!ShowAll)
            {
                items = items.Where(x => x.Completed == false).ToList();
            }

            var itemViewModels = items.Select(i => CreateToDoItemViewModel(i));

            //List<ToDoItemViewModel> itemViewModels = new List<ToDoItemViewModel>();
            //foreach(ToDoItem item in items)
            //{
            //    itemViewModels.Add(CreateToDoItemViewModel(item));
            //}

            Items = new ObservableCollection<ToDoItemViewModel>(itemViewModels);
        }

        private ToDoItemViewModel CreateToDoItemViewModel(ToDoItem i)
        {
            var itemViewModel = new ToDoItemViewModel(i);
            itemViewModel.ItemStatusChanged += ItemStatusChanged;
            return itemViewModel;
        }
         
        private void ItemStatusChanged(object sender, EventArgs e)
        {
            if(sender is ToDoItemViewModel item)
            {
                if (!ShowAll && item.Item.Completed)
                {
                    Items.Remove(item);
                }
                Task.Run(async () => await repository.UpdateItem(item.Item));
            }
        }

        public ICommand AddItem => new Command(async () =>
        {
            var itemView = Resolver.Resolve<ItemView>();
            await Navigation.PushAsync(itemView);
        });
    }
}
