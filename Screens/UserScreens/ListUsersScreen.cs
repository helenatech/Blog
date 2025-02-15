using blog.models;
using blog.repositories;
using Blog;
using Blog.Repositories;

namespace blog.Screens.UserScreens
{
    public static class ListUsersScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Usuários");
            Console.WriteLine("-----------------");

            List();

            Console.ReadKey();
            MenuUserScreen.Load();

        }

        public static void List()
        {
            var userRepository = new UserRepository(Database.Connection);
            var users = userRepository.GetWithRoles();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}, {user.Name}, {user.Email}, Roles: {string.Join(", ", user.Roles.Select(r => r.Name))}");
                if (user.Roles.Any())
                {
                    foreach (var role in user.Roles)
                    {
                        Console.WriteLine($"- {role.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum papel associado.");
                }
            }
        }
    }
}