using GalaSoft.MvvmLight;//最顶层的命名空间，包含了MvvmLight的主体,最核心的功能都在这里。
                         //1.ICleanup            接口。实现该接口的ViewModel需要在Cleanup方法中释放资源，特别是-=event
                         //2.ObservableObject    该类实现了INotifyPropertyChanged接口，定义了一个可通知的对象基类，供ViewModelBase继承
                         //3.ViewModelBase       继承自ObsevableObject,ICleanup。将作为MvvmLight框架下使用的ViewModel的基类。主要提供Set和RaisePropertyChanged供外部使用。同时会在Cleanup方法里，Unregister该实例的所有MvvmLight Messager（在GalaSoft.MvvmLight.Messaging命名空间内定义）
using MvvmLight4EF.Model;

namespace MvvmLight4EF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase//ViewModelBase继承了INotifyPropertyChanged接口并提供了一个Set方法来给属性赋值。
                                              //（也就是不用自己在VeiwModel实现INotifyProperrtyChanged,然后在属性赋值时通知了，当然也可以手动通知）
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}