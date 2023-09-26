namespace WinDateFrom.maui;

public partial class InfoPage : ContentPage
{
	public InfoPage()
	{
		InitializeComponent();
#if ANDROID
        lblinfo.Text =App.GetResource(Resource.String.info);
        btnDeletePreferences.Text =App.GetResource(Resource.String.delete_settings);
#else
        lblinfo.Text = App.d["info"] as string;
        btnDeletePreferences.Text = App.d["delete_settings"] as string;
#endif
    }
    private async void OnSito_Click(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync(new Uri("https://github.com/numerunix/WinDateFrom.maui"));
    }
    private void DeleteOpzioni_Click(object sender, EventArgs e)
    {
#if ANDROID
        long cal = Preferences.Get("calendar", 0L);
#endif
        Preferences.Clear();
#if ANDROID
        Preferences.Set("calendar", cal);
        WinDateFrom.maui.Platforms.Android.CalendarHelperService.ResetCalendar(Preferences.Get("calendar", 0L));
#endif
    }

}