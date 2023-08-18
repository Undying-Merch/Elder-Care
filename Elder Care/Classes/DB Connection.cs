using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Elder_Care.Classes
{
    class DB_Connection
    {
        HttpClient client;
        JsonSerializerOptions options;
        public string Address = "http://192.168.1.148";

        public DB_Connection()
        {
            client = new HttpClient();
            options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase, WriteIndented = true };
        }

        public Person GetPerson(string personURL)
        {
            string json = client.GetStringAsync(personURL).Result;
            string[] personString = jsonSplit(json);
            Person person = JsonConvert.DeserializeObject<Person>(personString[0]);
            return person;
        }

        public List<Personel> getAllPersonel()
        {
            List<Personel> pList = new List<Personel>();
            string json = client.GetStringAsync(Address + ":8000/data/medarbejderliste/").Result;
            string[] personelStrings = jsonSplit(json);
            for (int i = 0; i < personelStrings.Length; i++)
            {
                Personel person = JsonConvert.DeserializeObject<Personel>(personelStrings[i]);
                pList.Add(person);
            }

            return pList;
        }

        public List<institution> getAllInstitution()
        {
            List<institution> instits = new List<institution>();
            string json = client.GetStringAsync(Address + ":8000/data/institutionliste/").Result;
            string[] institutionStrings = jsonSplit(json);
            for(int i = 0;i < institutionStrings.Length; i++)
            {
                institution institution = JsonConvert.DeserializeObject<institution>(institutionStrings[i]);
                instits.Add(institution);
            }
            return instits;
        }

        


        private String[] jsonSplit(string json)
        {
            char split = '}';
            String[] splittedString = json.Split(split);
            splittedString = splittedString.SkipLast(1).ToArray();
            for (int i = 0; i < splittedString.Length; i++)
            {
                splittedString[i] = splittedString[i].TrimStart(',', '[');
                splittedString[i] = splittedString[i].TrimEnd(']');
                splittedString[i] = splittedString[i] + "}";
            }
            return splittedString;
        }


        public bool loginCheck(string username, string password)
        {
            List<Personel> personels = getAllPersonel();
            for (int i = 0;i < personels.Count;i++)
            {
                if (personels[i].brugernavn == username && personels[i].password == password)
                {
                    return true;
                }
            }
            return false;
        }
        

        
    }
}
