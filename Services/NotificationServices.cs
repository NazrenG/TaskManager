using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TaskManager.Services
{
    public abstract class NotificationServices : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
                    => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
