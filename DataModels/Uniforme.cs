using Projeto_Final_AVMB.DataModels;

namespace Projeto_final_AVMB.DataModels
{
    public class Uniforme
    {
        public int id { get; set; }
        public string peca_roupa { get; set; }
        public virtual ICollection<AlunoUniforme>? AlunoUniformes { get; set; }
    }
}
