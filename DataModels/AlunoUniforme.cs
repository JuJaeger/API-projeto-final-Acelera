using Projeto_final_AVMB.DataModels;

namespace Projeto_Final_AVMB.DataModels
{
    public class AlunoUniforme
    {
        public int alunoId { get; set; }
        public int uniformeId { get; set; }

        public virtual Aluno aluno { get; set; }
        public virtual Uniforme uniforme { get; set; }
    }
}
