namespace Bussines.Data.Requests.Usuario
{
    public record UsuarioRequest(Guid? UsuarioId = null, string? NomeCompleto = null, string? Telefone = null, string? CPF = null, string? Email = null, string? Senha = null);

}
