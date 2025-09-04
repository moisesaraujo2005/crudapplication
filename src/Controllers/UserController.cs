using CrudApplication.Services;

public class UserController
{

    private UserService _service = new UserService();

    public void Registrar(User user)
    {
        _service.Registrar(user);
    }

    public void Atualizar(User user)
    {
        _service.Atualizar(user);
    }

    public void Excluir(User user)
    {
        _service.Excluir(user);
    }

    public List<User> ListarTodos()
    {
        return _service.GetAll();
    }

    public User? BuscarPorId(int id)
    {
        return _service.GetById(id);
    }
    

}