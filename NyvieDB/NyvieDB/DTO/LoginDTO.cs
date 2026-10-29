using System.ComponentModel.DataAnnotations;

namespace NyvieDB.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string? email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string? senha { get; set; }
    }
}
