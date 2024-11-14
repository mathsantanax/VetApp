using VetApp.Models.ModelPetETutor;
using VetApp.Repositorios;
using VetApp.ViewModel;

namespace VetApp.Views;

public partial class AddNewPetPageView : ContentPage
{
    Tutor Tutor { get; set; }
    RacaRepositorio racaRepositorio = new RacaRepositorio();
    EspecieRepositorio especieRepositorio = new EspecieRepositorio();
    PetRepositorio petRepositorio = new PetRepositorio();
	public AddNewPetPageView(Tutor tutor)
	{
		InitializeComponent();
		BindingContext = new AddNewPetViewModel(tutor);
        Tutor = tutor;
        OnListRaca();
        OnListEspecie();
    }

    private async void OnAddEspecieClicked(object sender, EventArgs e)
    {
        string especie = await DisplayPromptAsync("Cadastrar", "Insira a Espécie");
        if (!string.IsNullOrEmpty(especie))
        {
            especieRepositorio.AddEspecie(new Especie
            {
                NomeEspecie = especie.ToUpper(),
            });
            await DisplayAlert($"Especie Cadastrada Com sucesso \n{especie}", "Alerta", "Ok");
            OnListEspecie();
        }
    }

    private async void OnAddRacaClicked(object sender, EventArgs e)
    {
        string raca = await DisplayPromptAsync("Cadastrar", "Insira a Raça");
        if (!string.IsNullOrEmpty(raca))
        {
            racaRepositorio.AddRaca(new Raca
            {
                TipoRaca = raca.ToUpper(),
            });
            await DisplayAlert($"Especie Cadastrada Com sucesso \n{raca}", "Alerta", "Ok");
            OnListRaca();
        }
    }

    private async void OnListRaca()
    {
        racaPicker.ItemsSource = null;
        racaPicker.Items.Clear();
        var racas = await racaRepositorio.GetRacas();
        racaPicker.ItemsSource = racas.Select(r => r.TipoRaca).ToList();
    }

    private async void OnListEspecie()
    {
        racaPicker.ItemsSource = null;
        racaPicker.Items.Clear();
        var especie = await especieRepositorio.GetEspecie();
        especiePicker.ItemsSource = especie.Select(e => e.NomeEspecie).ToList();
    }

    private async void OnAddPetClicked(object sender, EventArgs e)
    {
        string microchip = EntryMicrochip.Text == null ? "0" : EntryMicrochip.Text.ToUpper();
        if (Tutor != null)
        {
            petRepositorio.AddPet(new Pet
            {
                NomePet = EntryNomePet.Text.ToUpper(),
                NumeroMicrochip = microchip,
                IdEspecie = especiePicker.SelectedIndex + 1,
                IdRaca = racaPicker.SelectedIndex + 1,
                Idade = int.Parse(EntryIdadePet.Text),
                Peso = float.Parse(entryPeso.Text),
                Sexo = sexagemPicker.SelectedItem.ToString().ToUpper(),
                IdTutor = Tutor.Id
            });
            await DisplayAlert("Sucesso", "Cadastrado com Sucesso", "OK");
            await Navigation.PopModalAsync();
        }
    }
}