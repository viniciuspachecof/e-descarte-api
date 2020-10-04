using System.Collections.Generic;

namespace e_descarte_api.Models
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(int id, string nome, string email, string senha, string tipo)
        {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.senha = senha;
            this.tipo = tipo;
            // this.imagem = imagem;
        }

        public int id { get; set; }
        public string nome { get; set; }       
        public string email { get; set; }    
        public string senha { get; set; }       
        public string tipo { get; set; }       
        // public string imagem { get; set; }   
    }
}