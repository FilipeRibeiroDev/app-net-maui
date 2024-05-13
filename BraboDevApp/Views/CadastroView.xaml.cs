
namespace BraboDevApp.Views
{
    public partial class CadastroView : ContentPage
    {
        public const double FontSizeBraboDev = 14;
        public CadastroView()
        {
            InitializeComponent();
        }

        private void Cadastrar_Clicked(object sender, EventArgs e)
        {
            var nome = NomeCompleto.Text;
            var data = DataNascimento.Date;
            var genero = Genero.SelectedItem;
            var idade = Idade.Text;

            DisplayAlert("Cadastro de Usuário", string.Format("Cadastro do usuário {0} foi realizado com sucesso", nome), "Ok!");
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
