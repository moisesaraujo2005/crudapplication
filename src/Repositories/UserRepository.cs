using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data.SqlClient;

public class UserRepository
{
    private readonly string _connectionString;
    public UserRepository()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public void Registrar(User user)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string queryRegistrar = "INSERT INTO [User] (Nome, Cpf, Email, Password) VALUES (@Nome, @Cpf, @Email, @Password)";
            using (SqlCommand cmd = new SqlCommand(queryRegistrar, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", user.Nome);
                cmd.Parameters.AddWithValue("@Cpf", user.Cpf);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Atualizar(User user)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string queryAtualizar = "UPDATE [User] SET Nome = @Nome, Cpf = @Cpf, Email = @Email, Password = @Password WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(queryAtualizar, conn))
            {
                cmd.Parameters.AddWithValue("@Nome", user.Nome);
                cmd.Parameters.AddWithValue("@Cpf", user.Cpf);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Id", user.Id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public void Excluir(int id)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string queryExcluir = "DELETE FROM [User] WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(queryExcluir, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }

    public List<User> GetAll()
    {
        var users = new List<User>();
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string queryListarTodos = "SELECT Id, Nome, Cpf, Email, Password FROM [User]";
            using (SqlCommand cmd = new SqlCommand(queryListarTodos, conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var user = new User
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Cpf = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4)
                    };
                    users.Add(user);
                }
            }
        }
        return users;
    }

    public User? GetById(int id)
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "SELECT Id, Nome, Cpf, Email, Password FROM [User] WHERE Id = @Id";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Cpf = reader.GetString(2),
                            Email = reader.GetString(3),
                            Password = reader.GetString(4)
                        };
                    }
                }
            }
        }
        return null;
    }
}