namespace blog.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Usuário");
            Console.WriteLine("---------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar usuários");
            Console.WriteLine("2 - Cadastrar usuário");
            Console.WriteLine("3 - Atualizar usuário");
            Console.WriteLine("4 - Excluir usuário");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListUsersScreen.Load();
                    break;
                case 2:
                    CreateUserScreen.Load();
                    break;
                // case 3:
                //     UpdateRoleScreen.Load();
                // //     break;
                // case 4:
                //     DeleteRoleScreen.Load();
                //     break;
                // default: Load(); break;
            }

        }
    }
}