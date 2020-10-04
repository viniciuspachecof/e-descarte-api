namespace Models.usuarioView
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "O campo é {0} obrigatorio")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]

        public string Email {get;set;}

        [Required(ErrorMessage = "O campo {0} é obrigatorio")]
       // [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", minimum)]
       
    }
}