using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FriendStorage.UI.Events;
using Prism.Events;
using FriendStorage.UI.ViewModel;

namespace FriendStorage.UITests.ViewModel
{
    public class NavigationItemViewModelTests
    {
        [Fact]
        public void ShouldPublishOpenFriendsEditViewEvent()
        {
            const int friendId = 7;
            var eventMock = new Mock<OpenFriendEditViewEvent>();
            var eventAggregatorMock = new Mock<IEventAggregator>();
            eventAggregatorMock.Setup(ea => ea.GetEvent<OpenFriendEditViewEvent>())
                .Returns(eventMock.Object);

            var viewModel = new NavigationItemViewModel(friendId, "Thomas", eventAggregatorMock.Object);
            viewModel.OpenFriendEditViewCommand.Execute(null);

            eventMock.Verify(e=>e.Publish(friendId), Times.Once());
        }
    }
}
