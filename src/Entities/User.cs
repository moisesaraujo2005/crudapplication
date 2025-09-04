public class User
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Cpf { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }


    public User()
    {

    }
    public User(int id, string nome, string cpf, string email, string password)
    {
        Id = id;
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Password = password;
}

}