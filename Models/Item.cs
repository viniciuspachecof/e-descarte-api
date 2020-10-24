using System.Collections.Generic;

namespace e_descarte_api.Models
{
    public class Item
    {
        public Item() { }
        public Item(int id, string nome, int ponto)
        {
            this.id = id;
            this.nome = nome;        
            this.ponto = ponto;        
        }

        public int id { get; set; }
        public string nome { get; set; }      
        public int ponto { get; set; }      
    }
}