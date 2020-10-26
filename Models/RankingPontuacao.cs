using System.Collections.Generic;

namespace e_descarte_api.Models
{
    public class RankingPontuacao
    {
        public RankingPontuacao() { }
        public RankingPontuacao(int id, int pontuacao, int usuarioId)
        {
            this.id = id;
            this.pontuacao = pontuacao;
            this.usuarioId = usuarioId;        
        }

        public int id { get; set; }
        public int pontuacao { get; set; }       
        public int usuarioId { get; set; }            
        public Usuario usuario { get; set; }                   
    }
}