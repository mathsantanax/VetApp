using VetApp.Models.ModelPetETutor;
using VetApp.ModelView;

namespace VetApp.Pages;

public partial class TutorPage : ContentPage
{
    public TutorPage(Tutor tutor)
    {
        InitializeComponent();
        BindingContext = new PetsModelView(tutor);
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
