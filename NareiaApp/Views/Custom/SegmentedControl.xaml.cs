using System.Windows.Input;

namespace NareiaApp.Views.Custom;

public partial class SegmentedControl : Frame
{
    #region Bindable Properties

    public static readonly BindableProperty FirstOptionNameProperty = BindableProperty.Create(
        propertyName: nameof(FirstOptionName),
        returnType: typeof(string),
        declaringType: typeof(SegmentedControl));

    public static readonly BindableProperty SecondOptionNameProperty = BindableProperty.Create(
        propertyName: nameof(SecondOptionName),
        returnType: typeof(string),
        declaringType: typeof(SegmentedControl));

    public static readonly BindableProperty FirstOptionCommandProperty = BindableProperty.Create(
        propertyName: nameof(FirstOptionCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(SegmentedControl));

    public static readonly BindableProperty SecondOptionCommandProperty = BindableProperty.Create(
        propertyName: nameof(SecondOptionCommand),
        returnType: typeof(ICommand),
        declaringType: typeof(SegmentedControl));

    #endregion

    #region Properties

    public string FirstOptionName
    {
        get => (string)GetValue(FirstOptionNameProperty);
        set => SetValue(FirstOptionNameProperty, value);
    }
    public string SecondOptionName
    {
        get => (string)GetValue(SecondOptionNameProperty);
        set => SetValue(SecondOptionNameProperty, value);
    }

    public ICommand FirstOptionCommand
    {
        get => (ICommand)GetValue(FirstOptionCommandProperty);
        set => SetValue(FirstOptionCommandProperty, value);
    }

    public ICommand SecondOptionCommand
    {
        get => (ICommand)GetValue(SecondOptionCommandProperty);
        set => SetValue(SecondOptionCommandProperty, value);
    }

    #endregion

    #region Constructors

    public SegmentedControl()
	{
		InitializeComponent();
    }

    #endregion

    #region Click Events

    private void OnFirstOptionClicked(object sender, EventArgs e)
    {
        FirstOptionCommand?.Execute(null);

        brFirstOption.BackgroundColor = Color.Parse("#FFF");
        btSecondOption.BackgroundColor = Color.Parse("#00FFFFFF");
    }

    private void OnSecondOptionClicked(object sender, EventArgs e)
    {
        SecondOptionCommand?.Execute(null);

        brFirstOption.BackgroundColor = Color.Parse("#00FFFFFF");
        btSecondOption.BackgroundColor = Color.Parse("#FFF");
    }

    #endregion
}