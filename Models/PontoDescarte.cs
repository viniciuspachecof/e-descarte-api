using System.Collections.Generic;

namespace e_descarte_api.Models
{
    public class PontoDescarte
    {
        public PontoDescarte() { }
        public PontoDescarte(int id, string nome, string fone, double latitude, double longitude, bool ativo, bool status,  int tipo, int usuarioId)
        {
            this.id = id;
            this.nome = nome;
            this.fone = fone;
            this.latitude = latitude;
            this.longitude = longitude;
            this.ativo = ativo;
            this.status = status;
            this.tipo = tipo;
            this.usuarioId = usuarioId;        
        }

        public int id { get; set; }
        public string nome { get; set; }       
        public string fone { get; set; }       
        public double longitude { get; set; }       
        public double latitude { get; set; }            
        public bool ativo { get; set; }            
        public bool status { get; set; }            
        public int tipo { get; set; }       
        public int usuarioId { get; set; }            
        public Usuario usuario { get; set; }                   
    }
}