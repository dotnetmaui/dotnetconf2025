namespace demoSupabase
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
            Supabase.Client client = 
                new Supabase.Client("https://unypozjstlkzhakzqyrt.supabase.co", 
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InVueXBvempzdGxremhha3pxeXJ0Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3MzYzMzkzODMsImV4cCI6MjA1MTkxNTM4M30.SDPMQdIhf00_LmynTh_1Bf6cuXyiidPZAHSU2vZ865Q");

            var authUrl = new Uri("https://unypozjstlkzhakzqyrt.supabase.co/auth/v1/authorize?provider=kakao");
            var callbackUrl = new Uri("dotnetconf://auth/callback");

            try
            {
                var authResult = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);
                if (authResult != null)
                {
                    // 성공 처리
                    Supabase.Gotrue.Session session = new Supabase.Gotrue.Session
                    {
                        AccessToken = authResult.AccessToken,
                        CreatedAt = authResult.Timestamp.DateTime,
                        ExpiresIn = authResult.ExpiresIn.Value.ToUnixTimeMilliseconds(),
                        RefreshToken = authResult.RefreshToken,
                        ProviderToken = authResult.Properties["provider_token"],
                        TokenType = authResult.Properties["token_type"]
                    };
                    await client.Auth.SetSession(session.AccessToken, session.RefreshToken);
                }
            }
            catch (Exception ex)
            {
                // 에러 처리
            }
        }
    }
}
