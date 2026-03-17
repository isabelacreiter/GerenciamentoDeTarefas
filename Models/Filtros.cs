namespace GerenciamentoDeTarefas.Models
{
    public class Filtros
    {
        public Filtros(string filtroString, string categoriaId, int statusId, string prazo)
        {
            FiltroString = filtroString ?? "todos-todos-0-todos";
            string[] filtros = FiltroString.Split('-');

            CategoriaId = filtros[0];
            Prazo = filtros[1];

            StatusId = int.TryParse(filtros[2], out int status)
                ? status
                : 0;

            Criacao = filtros.Length > 3 ? filtros[3] : "todos";
        }

        public string FiltroString { get; set; }
        public string CategoriaId { get; set; }
        public int StatusId { get; set; }
        public string Prazo { get; set; }
        public string Criacao { get; set; }

        public bool TemCategoria => CategoriaId.ToLower() != "todos";
        public bool TemPrazo => Prazo.ToLower() != "todos";
        public bool TemStatus => StatusId != 0;
        public bool TemCriacao => Criacao.ToLower() != "todos";

        public static Dictionary<string, string> PrazoFiltros =>
            new Dictionary<string, string>
            {
                { "sem", "Sem vencimento" },
                { "hoje", "Vence hoje" },
                { "semana", "Próximos 7 dias" },
                { "atrasada", "Atrasadas" }
            };


        public static Dictionary<string, string> CriacaoFiltros =>
            new Dictionary<string, string>
            {
                { "hoje", "Criadas hoje" },
                { "semana", "Criadas esta semana" },
                { "mes", "Criadas este mês" }
            };

        public bool SemVencimento => Prazo.ToLower() == "sem";
        public bool VenceHoje => Prazo.ToLower() == "hoje";
        public bool ProximaSemana => Prazo.ToLower() == "semana";
        public bool Atrasada => Prazo.ToLower() == "atrasada";

        public bool CriadasHoje => Criacao.ToLower() == "hoje";
        public bool CriadasSemana => Criacao.ToLower() == "semana";
        public bool CriadasMes => Criacao.ToLower() == "mes";
    }
}