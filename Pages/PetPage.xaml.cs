using VetApp.DTO;
using VetApp.Models.ModelPetETutor;
using VetApp.ModelView;
namespace VetApp.Pages;

public partial class PetPage : ContentPage
{
	public PetPage(petDto pet)
	{
		InitializeComponent();
		BindingContext = new PetModelView(pet);
	}
}