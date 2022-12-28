using Microsoft.VisualBasic;
using Projeto_Final_AVMB.DataModels;

namespace Projeto_final_AVMB.DataModels
{
    public class Aluno
    {
        public int id { get; set; }
        public string nome_completo { get; set; }
        public string nome_guerra { get; set; }
        public int numero { get; set; }
        public string nome_responsavel { get; set; }
        public DateTime data_cadastro { get; set; }

        public virtual ICollection<AlunoUniforme>? AlunoUniformes { get; set; }
    }
}
