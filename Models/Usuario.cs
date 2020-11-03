using System.Collections.Generic;

namespace e_descarte_api.Models
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(int id, string nome, string email, string fone, string senha, string tipo)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.fone = fone;
            this.senha = senha;
            this.tipo = tipo;
        }

        public int id { get; set; }
        public string nome { get; set; }       
        public string email { get; set; }    
        public string fone { get; set; }    
        public string senha { get; set; }       
        public string tipo { get; set; }       
    }
}