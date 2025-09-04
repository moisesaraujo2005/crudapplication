namespace CrudApplication.Services;
class UserService
{
    private UserRepository _repository = new UserRepository();

    public void Registrar(User user)
    {
        _repository.Registrar(user);
    }

    public void Excluir(User user)
    {
        _repository.Excluir(user.Id);
    }

    public void Atualizar(User user)
    {
        _repository.Atualizar(user);

    }


    public List<User> GetAll()
    {
        return _repository.GetAll();
    }

    public User? GetById(int id)
    {
        return _repository.GetById(id);
    }
}