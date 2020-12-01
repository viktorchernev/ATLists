using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; 

using ATLists;
using ATLists.SQL;

namespace ATListsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get JSON payload
            string json = getPayloadFromEmbedded();
            object payload = JsonConvert.DeserializeObject<Payload>(json);

            //Set DB path
            string fileName = @"roadrun_db.db3";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completePath = System.IO.Path.Combine(folderPath, fileName);
            Procedures.DATABASE_PATH = completePath;

            //Dummy DB items
            Procedures.DropTables();
            if (!Procedures.CheckTablesExist())
            {
                Procedures.CreateTables();
                Procedures.InsertDummyLists();
            }

            //Load all from DB
            Procedures.RetrieveAll();   //Load all SQL Items

            //Build all the View items
            Dictionary<string, ListBase> INVENTORY_LISTS = new Dictionary<string, ListBase>();
            foreach (KeyValuePair<int, SqlList> kvp in Procedures.Lisis)
            {
                var list = new ListBasic(kvp.Value);
                INVENTORY_LISTS.Add(list.Text, list);
            }

            //Done, look at the results in debugger
            Console.WriteLine(INVENTORY_LISTS.Count());
        }

        static string getPayloadFromEmbedded()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "ATListsConsole.payload.json";
            string payload;

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    payload = reader.ReadToEnd();
                }
            }

            return payload;
        }
    }
}
