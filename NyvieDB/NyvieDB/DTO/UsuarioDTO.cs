using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O email do usuário é obrigatório.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O telefone do usuário é obrigatório.")]
        public string? Telefone { get; set; }

        public IFormFile? Imagem { get; set; }

        [Required(ErrorMessage = "O ID do departamento é obrigatório.")]
        public Guid? IdDepartamento { get; set; }

        [Required(ErrorMessage = "O ID do cargo é obrigatório.")]
        public Guid? IdCargo { get; set; }


    }
}
