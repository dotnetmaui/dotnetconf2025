namespace demoMonkeyCache
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            
            if (MonkeyCache.SQLite.Barrel.Current.Exists("count"))
            {
                var cacheResult = MonkeyCache.SQLite.Barrel.Current.Get<int>("count");
                if (cacheResult >= 10)
                {
                    App.Current.MainPage.DisplayAlert("안내", "어엇! 선생님 10개 넘었는데요?", "확인");
                    return;
                }
            })
            MonkeyCache.SQLite.Barrel.Current.Add("count", count, TimeSpan.FromDays(1));
        }
    }

}
