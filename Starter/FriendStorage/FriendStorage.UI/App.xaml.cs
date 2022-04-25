using FriendStorage.UI.ViewModel;
using FriendStorage.UI.View;
using System.Windows;
using FriendStorage.UI.DataProvider;
using FriendStorage.DataAccess;
using FriendStorage.UI.Startup;
using Autofac;

namespace FriendStorage.UI
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var bootStrapper = new BootStrapper();
            var container = bootStrapper.BootStrap();

            var mainWindow = container.Resolve<MainWindow>();

            mainWindow.Show();
        }
    }
}
