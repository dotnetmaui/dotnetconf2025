namespace demoOneSignal
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            if (!OneSignalSDK.DotNet.OneSignal.Notifications.Permission)
            {
                var result = await OneSignalSDK.DotNet.OneSignal.Notifications.RequestPermissionAsync(true);
                if (!result)
                {
                    await App.Current.MainPage.DisplayAlert("안내","알림 기능을 켜주세요","확인");
                }
            }
        }
    }

}
