using System.Collections.Generic;

namespace e_descarte_api.Models
{
    public class Cidade
    {
        public Cidade() { }
        public Cidade(int id, string nome, string uf)
        {
            this.id = id;
            this.nome = nome;
            this.uf = uf;
        }

        public int id { get; set; }
        public string nome { get; set; }
        public string uf { get; set; }        
    }
}