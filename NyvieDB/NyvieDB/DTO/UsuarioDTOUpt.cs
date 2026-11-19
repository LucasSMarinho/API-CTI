namespace NyvieDB.DTO;

public class UsuarioDTOUpt
{

  
        public string? Nome { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public string? Telefone { get; set; }

        public IFormFile? Imagem { get; set; }

        public Guid? IdDepartamento { get; set; }

        public Guid? IdCargo { get; set; }
    

}
