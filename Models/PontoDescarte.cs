using System.Collections.Generic;

namespace e_descarte_api.Models
{
    public class PontoDescarte
    {
        public PontoDescarte() { }
        public PontoDescarte(int id, string nome, string fone, double latitude, double longitude, bool status, int cidadeId, int usuarioId)
        {
            this.id = id;
            this.nome = nome;
            this.fone = fone;
            // this.imagem = imagem;
            this.latitude = latitude;
            this.longitude = longitude;
            this.status = status;
            this.cidadeId = cidadeId;
            this.usuarioId = usuarioId;        
        }

        public int id { get; set; }
        public string nome { get; set; }       
        public string fone { get; set; }       
        // public string imagem { get; set; }   
        public double longitude { get; set; }       
        public double latitude { get; set; }            
        public bool status { get; set; }            
        public int cidadeId { get; set; }            
        public Cidade cidade { get; set; }  
        public int usuarioId { get; set; }            
        public Usuario usuario { get; set; }                   
    }
}