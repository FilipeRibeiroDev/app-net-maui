
using BraboDevApp.Models.Users;
using BraboDevApp.Services.Users;

namespace BraboDevApp.Views
{
    [QueryProperty(nameof(Route), "route")]
    public partial class CadastroView : ContentPage
    {
        public string Route { get; set; }

        public const double FontSizeBraboDev = 14;
        public readonly IUserService _userService;
        public CadastroView(IUserService userService)
        {
            _userService = userService;
            InitializeComponent();
        }

        private async void Cadastrar_Clicked(object sender, EventArgs e)
        {
            var user = new User();
            var nome = NomeCompleto.Text.Split(' ');
            if(nome.Length > 0)
            {
                user.FirstName = nome.First();
                if (nome.Length > 1)
                    user.LastName = nome.Last();
                
            }


            user.BirthDate = DataNascimento.Date.ToShortDateString();
            user.Gender = Genero.SelectedItem.ToString();
            user.Age = Convert.ToInt32(Idade.Text);

            var userResult = await _userService.Add(user);

            DisplayAlert("Cadastro de Usuário", string.Format("Cadastro do usuário {0} foi realizado com sucesso", userResult.FirstName), "Ok!");

            await Shell.Current.GoToAsync(Route);
        }

        private void DataNascimento_DateSelected(object sender, DateChangedEventArgs e)
        {
            var dataNascimento = DataNascimento.Date;
            int idade = CalcularIdade(dataNascimento);
            Idade.Text = idade.ToString("D");
        }

        static int CalcularIdade(DateTime dataNascimento)
        {
            var dataAtual = DateTime.Today;
            int idade = dataAtual.Year - dataNascimento.Year;

            if(dataAtual < dataNascimento.AddYears(idade))
            {
                return idade--;
            }

            return idade;
        }
    }

    public class GlobalFontSizeExtension : IMarkupExtension
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return DeviceInfo.Platform == DevicePlatform.Android ? 18 : CadastroView.FontSizeBraboDev;
        }
    }
}
