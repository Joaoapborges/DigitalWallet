using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace ipgt_oop.Helpers
{
    class UserStore
    {

        // vai buscar caminho em especifico de cada computador
        private static string FilePath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "ipgt_users.json");

        public static void SaveUsername(string username)
        {
            List<String> users = LoadUsernames();

            //se ja existir, nao duplica
            if (!users.Contains(username))
            {

                users.Add(username);
                string json = JsonSerializer.Serialize(users);
                File.WriteAllText(FilePath, json);

            }


        }

        public static List<String> LoadUsernames()
        {

            if (!File.Exists(FilePath))
            {
                return new List<String>();
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

        }
    }
}
