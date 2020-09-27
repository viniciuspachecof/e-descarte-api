using System.Collections.Generic;

namespace e_descarte_api.Models
{
    public class Item
    {
        public Item() { }
        public Item(int id, string nome)
        {
            this.id = id;
            this.nome = nome;        
        }

        public int id { get; set; }
        public string nome { get; set; }      
    }
}