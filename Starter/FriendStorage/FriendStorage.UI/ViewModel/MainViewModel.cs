using FriendStorage.DataAccess;
using FriendStorage.UI.DataProvider;
using FriendStorage.UI.Events;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FriendStorage.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IFriendEditViewModel _selectedFriendEditViewModel;
        private Func<IFriendEditViewModel> _friendEditVmCreator;

        public MainViewModel(INavigationViewModel navigationViewModel,
            Func<IFriendEditViewModel> friendEditVmCreator,
            IEventAggregator eventAggregator)
        {
            NavigationViewModel = navigationViewModel;
            FriendEditViewModels = new();
            _friendEditVmCreator = friendEditVmCreator;
            eventAggregator.GetEvent<OpenFriendEditViewEvent>().Subscribe(OnOpenFriendEditView);
        }
        public INavigationViewModel NavigationViewModel { get; private set; }
        public ObservableCollection<IFriendEditViewModel> FriendEditViewModels { get; private set; }


        public IFriendEditViewModel SelectedFriendEditViewModel
        {
            get => _selectedFriendEditViewModel;
            set
            {
                _selectedFriendEditViewModel = value;
                OnPropertyChanged();
            }
        }
        private void OnOpenFriendEditView(int friendId)
        {
            var friendEditVm = FriendEditViewModels.SingleOrDefault(vm => vm.Friend.Id == friendId);
            if (friendEditVm == null)
            {
                friendEditVm = _friendEditVmCreator();
                FriendEditViewModels.Add(friendEditVm);
                friendEditVm.Load(friendId);
            }
            SelectedFriendEditViewModel = friendEditVm;
        }

        public void Load()
        {
            NavigationViewModel.Load();
        }
    }
}
