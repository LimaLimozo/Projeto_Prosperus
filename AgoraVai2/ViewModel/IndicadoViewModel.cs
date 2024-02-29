using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AgoraVai2.ViewModel
{
    public class IndicadoViewModel
    {
        public string nome { get; set; }

        public string numeroTelefone { get; set; }

        public string observacoes { get; set; }

    }
    public class IndicadorViewModel
    {
        public string nomeIndicador { get; set; }

        public string telefoneIndicador { get; set; }


        public List<IndicadoViewModel> indicadoList { get; set; }
    }

}
