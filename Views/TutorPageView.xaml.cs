using VetApp.Models.ModelPetETutor;
using VetApp.ViewModel;

namespace VetApp.Views;

public partial class TutorPageView : ContentPage
{
	public TutorPageView(Tutor tutor)
	{
		InitializeComponent();
		BindingContext = new TutorViewModel(tutor);
	}
    async void OnItemTapped(object sender, EventArgs e)
    {
        var frame = (Frame)sender;
        var originalColor = Colors.White;
        frame.BackgroundColor = Color.FromArgb("#D3D3D3");
        await Task.Delay(200);
        frame.BackgroundColor = originalColor;
    }
}