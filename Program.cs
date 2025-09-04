using System;
using CrudApplication.Services;
class Program
{
    static void Main(string[] args)
    {

        var service = new UserService();

        // //Register
        // var novoUsuario = new User(3, "Jean", "12345211", "jean@gmail.com", "abobora");
        // service.Registrar(novoUsuario);

        // Console.WriteLine($"O Nome do user é {novoUsuario.Nome} o cpf é {novoUsuario.Cpf} o email é {novoUsuario.Email}");

        // //Delete
        // int id = 2;
        // service.Excluir(new User { Id = id });


        //Edit 

        // var usuarioEditado = new User(3, "Gaby", "1212121", "gabybarreto@gmail.com", "moiseslindo");

        // service.Atualizar(usuarioEditado);

        //List All 
        // var listar = service.GetAll();

        // foreach (var user in listar)
        // {
        //     Console.WriteLine($" Id:{user.Id} Nome:{user.Nome} Cpf:{user.Cpf} Email:{user.Email}");
        // }

        //List id exactly 

        // var idEspecifico = 3;
        // var pegarId = service.GetById(idEspecifico);
        // Console.WriteLine($"o nome do usuário 3 é {pegarId.Nome} o cpf é {pegarId.Cpf} e o email é ${pegarId.Email}");

    }
}