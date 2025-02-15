using blog.models;
using Blog;
using Blog.Repositories;

namespace blog.Screens.RoleScreens
{
    public static class ListRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Papéis");
            Console.WriteLine("--------------");

            List();

            Console.ReadKey();
            MenuRoleScreen.Load();
        }

        public static void List(){
            var repository = new Repository<Role>(Database.Connection);
            var roles = repository.GetAll();
            foreach(var item in roles) {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}