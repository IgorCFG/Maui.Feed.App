using System.Windows.Input;

namespace NareiaApp.Views.Pages;

public partial class IdeasPage : ContentPage
{
    #region Bindable Properties

    public static readonly BindableProperty DailyCommandProperty = BindableProperty.Create(
        propertyName: nameof(DailyCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(IdeasPage));

    public static readonly BindableProperty FavoriteCommandProperty = BindableProperty.Create(
        propertyName: nameof(FavoriteCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(IdeasPage));

    #endregion

    #region Properties

    public ICommand DailyCommand
    {
        get => (ICommand)GetValue(DailyCommandProperty);
        set => SetValue(DailyCommandProperty, value);
    }

    public ICommand FavoriteCommand
    {
        get => (ICommand)GetValue(FavoriteCommandProperty);
        set => SetValue(FavoriteCommandProperty, value);
    }

    #endregion

    #region Constructors

    public IdeasPage()
	{
		InitializeComponent();
    }

    #endregion

    #region Click Events

    //private void OnDailyClicked(object sender, EventArgs e)
    //{
    //    DailyCommand?.Execute(null);

    //    btDaily.BackgroundColor = Color.Parse("#FFF");
    //    btFav.BackgroundColor = Color.Parse("#00FFFFFF");
    //}

    //private void OnFavClicked(object sender, EventArgs e)
    //{
    //    FavoriteCommand?.Execute(null);

    //    btDaily.BackgroundColor = Color.Parse("#00FFFFFF");
    //    btFav.BackgroundColor = Color.Parse("#FFF");
    //}

    #endregion
}