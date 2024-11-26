using VetApp.DTO;
using VetApp.ViewModel;

namespace VetApp.Views;

public partial class PetPageView : ContentPage
{
	public PetPageView(petDto pet)
	{
		InitializeComponent();
        BindingContext = new PetPageViewModel(pet);
    }
}