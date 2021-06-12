using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User> {
                new User {Name="Том", Age=23, Languages = new List<string>{"английский", "немецкий"}},
                new User {Name="Боб", Age=27, Languages = new List<string>{"английский", "французский"}},
                new User {Name="Джон", Age=29, Languages = new List<string>{"английский", "испанский"}},
                new User {Name="Элис", Age=24, Languages = new List<string>{"испанский", "немецкий"}}
            };

            //Вопрос: Как вывести весь список выше с языками?

            //StringBuilder посмотреть


            users.ForEach(u =>
            {
                Console.WriteLine($"Пользователь: Имя: {u.Name} Возраст: {u.Age}" +
                    $" {string.Join(", ", u.Languages)} {Environment.NewLine}");
            });

            

            var i = 0;

            foreach (var item in users)
            {

                string langs = "";
                foreach (var lang in item.Languages)
                {
                    if (lang == item.Languages.Last())
                    {
                        langs += lang;
                    }
                    else
                    {
                        langs += lang + ", ";
                    }
                }
                Console.WriteLine($"Пользователь {i}: Имя: {item.Name} Возраст: {item.Age}" +
                    $" языки: {langs} {Environment.NewLine}");
                i++;
            }


            #region Задание №1

            // 1. Выбрать имена всех пользователей, чей возраст больше 25, но меньше 30. 

            //Вопрос: Как вывести всех с именем, возрастом и языками?

            Console.WriteLine("Задание 1: Выбрать имена всех пользователей, чей возраст больше 25, но меньше 30" + Environment.NewLine);

            var users1 = users.Where(age => age.Age > 25 && age.Age < 30);

            foreach (var user in users1)
            {
                Console.WriteLine($"{user.Name}");
            };

            Console.WriteLine(Environment.NewLine);

            //List<String> langs = new List<string>();

            //foreach (User user in users)
            //{
            //    Console.WriteLine($"Имя: {user.Name}, возраст: {user.Age}, языки: {user.Languages}");
            //};

            //foreach (var language in users.Languages)
            //{
            //    langs.Add();
            //}

            #endregion

            //#region Задание №2

            //// 2. Выбрать языки первого найденного пользователя в списке, чей возраст меньше 25.

            //// Вопрос: Как вывести один раз имя и сразу оба языка

            Console.WriteLine("Задание 2: Выбрать языки первого найденного пользователя в списке, чей возраст меньше 25" 
                + Environment.NewLine);


            var users2 = users.Where(age => age.Age < 25).FirstOrDefault();
            var langs1 = string.Join(", ", users2.Languages);
            // string langs1 = "";

            foreach (var lang in users2.Languages)
            {
                if (lang == users2.Languages.Last())
                {
                    langs1 += lang;
                }
                else
                {
                    langs1 += lang + ", ";
                }
            }

            Console.WriteLine($"Первый найденный пользователь в списке с возрастом меньше 25: {users2.Name}, языки: {langs1}");

            Console.WriteLine(Environment.NewLine);

            //#endregion

            //#region Задание №3   

            //// 3. Определить, есть ли в списке пользователь, владеющий французским языком. В случае, если пользователь
            ////имеется в списке, вывести «Пользователь найден».

            Console.WriteLine("Задание 3: Определить, есть ли в списке пользователь, владеющий французским языком.В случае, если пользователь" +
             Environment.NewLine + "имеется в списке, вывести «Пользователь найден»" + Environment.NewLine);


            var users3 = from user in users
                         from lang in user.Languages
                         where lang.ToLower() == "французский"
                         select user;
            if (users3.Count() != 0) Console.WriteLine("Пользователь найден");

            var users33 = users.Select(u => u.Languages.Contains("французский"));
            if (users33.Contains(true))
            {
                Console.WriteLine("Пользователь найден");
            }

            Console.WriteLine(Environment.NewLine);

            //#endregion


            //#region Задание №4

            //// 4. Выбрать возраст второго по старшинству пользователя (например, в списке выше это пользователь с возрастом 27).

            Console.WriteLine("Задание 4: Выбрать возраст второго по старшинству пользователя" +
                Environment.NewLine + "(например, в списке выше это пользователь с возрастом 27)" + Environment.NewLine);

            var users4 = users.OrderBy(age => age.Age);
            Console.WriteLine($"Возраст второго по старшинству пользователя: {users4.ElementAt(2).Name} - {users4.ElementAt(2).Age}");

            Console.WriteLine(Environment.NewLine);

            //#endregion


            //#region Задание №5

            //// 5. Выбрать имя пользователя, который самый младший из владеющих немецким языком.

            //// Вопрос: Почему не могу обратиться в выводе как users5[0].Name?

            Console.WriteLine("Задание 5: Выбрать имя пользователя, который самый младший из владеющих немецким языком" +
                Environment.NewLine);

            var users5 = from user in users
                         from lang in user.Languages
                         where lang.ToLower() == "немецкий"
                         orderby user.Age
                         select user;

            Console.WriteLine(users5.ElementAt(0).Name);

            var users55 = users
                .SelectMany(u => u.Languages, (u, l) => new { User = u, Lang = l })
                .Where(u => u.Lang.ToLower() == "немецкий")
                .Select(u => u.User)
                .OrderBy(u => u.Age);
                

            var users56 = users
                .Where(x => x.Languages.Contains("немецкий"))
                .OrderBy(x => x.Age)
                .First();

            Console.WriteLine(users55.ElementAt(0).Name);

            //#endregion

        }

        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }

            public User()
            {
                Languages = new List<String>();
            }
        }
    }
}

