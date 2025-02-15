using blog.models;
using Blog;
using Blog.Repositories;

namespace blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Criando um novo usuário");
            Console.WriteLine("-----------------");
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Bio: ");
            string bio = Console.ReadLine();
            Console.Write("PasswordHash: ");
            string passwordHash = Console.ReadLine();
            Console.Write("Image: ");
            string image = Console.ReadLine();
            Console.Write("Slug: ");
            string slug = Console.ReadLine();

            Create(new User { Name = name, 
            Email = email, 
            Bio = bio, 
            PasswordHash = passwordHash, 
            Image = image, 
            Slug = slug });
           
            MenuUserScreen.Load();

        }

        public static void Create(User user)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(user);
                Console.WriteLine("Usuário criado com sucesso!");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível criar o usuário.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}