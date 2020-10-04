using System.Collections.Generic;

namespace e_descarte_api.Models
{
    public class Usuario
    {
        public Usuario() { }
        public Usuario(int id, string nome, string tipo, string email, string senha)
        {
            this.id = id;
            this.nome = nome;
            this.tipo = tipo;
            this.email = email;
            // this.imagem = imagem;
            this.senha = senha;
        }

        public int id { get; set; }
        public string nome { get; set; }       
        public string tipo { get; set; }       
        public string email { get; set; }       
        // public string imagem { get; set; }   
        public string senha { get; set; }       
    }
}