using blog.models;
using Blog;
using Blog.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;

namespace blog.UserRoleScreen
{
    public class UserRoleScreen
    {
        public static void Load()
        {
            Console.WriteLine("Vinculando um papel a um usuário");
            Console.WriteLine("-------------------------------");

            var connection = Database.Connection;

            Console.Write("Digite o ID do usuário: ");
            int userId = int.Parse(Console.ReadLine());

            var user = connection.Get<User>(userId);

            if (user == null)
            {
                Console.WriteLine("Usuário não encontrado");
                return;
            }

            string queryUserRoles = @"
                SELECT Role.Id, Role.Name
                FROM Role 
                INNER JOIN UserRole ur ON Role.Id = ur.RoleId
                WHERE ur.UserId = @userId;";

            new User{
                Roles = connection.Query<Role>(queryUserRoles, new { UserId = userId }).ToList()
            };

            user.Roles = connection.Query<Role>(queryUserRoles, new { UserId = userId }).ToList();
      
            Console.WriteLine($"Papéis encontrados para o usuário {user.Name}: {user.Roles.Count}");
            foreach (var role in user.Roles)
            {
                Console.WriteLine($"- {role.Name}");
            }

            string queryRoles = "SELECT Id, Name FROM Role";
            var roles = connection.Query<Role>(queryRoles).ToList();

            Console.WriteLine("\nPapéis disponíveis:");
            foreach (var role in roles)
            {
                Console.WriteLine($"ID: {role.Id} - Nome: {role.Name}");
            }

            Console.Write("\nDigite o ID do papel a ser vinculado: ");
            int roleId = int.Parse(Console.ReadLine());

            if (user.Roles.Any(r => r.Id == roleId))
            {
                Console.WriteLine("Este usuário já possui esse papel.");
                return;
            }

            var roleToAdd = roles.FirstOrDefault(r => r.Id == roleId);
            if (roleToAdd == null)
            {
                Console.WriteLine("Papel não encontrado.");
                return;
            }

            user.Roles.Add(roleToAdd);

            Console.WriteLine($"Inserindo papel {roleToAdd.Name} (ID: {roleToAdd.Id}) para o usuário {userId}");

            string insertQuery = "INSERT INTO UserRole (UserId, RoleId) VALUES (@UserId, @RoleId)";
            connection.Execute(insertQuery, new { UserId = userId, RoleId = roleId });

            Console.WriteLine("Papel vinculado com sucesso!");
        }
    }
}