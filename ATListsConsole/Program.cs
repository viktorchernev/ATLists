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
using SQLite;

namespace ATListsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //Get JSON payload
            string json = getPayloadFromEmbedded();
            Payload payload = JsonConvert.DeserializeObject<Payload>(json);

            //Set DB path
            string fileName = @"TestDB.db";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string completePath = System.IO.Path.Combine(folderPath, fileName);
            Procedures.DATABASE_PATH = completePath;

            //DB items
            List<ListBase> lists;
            if (!Procedures.CheckTablesExist())
            {
                Procedures.CreateTables();
                lists = GetEntriesFromPayload(payload);
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
            string jsonInspect = JsonConvert.SerializeObject(INVENTORY_LISTS);
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
        static List<ListBase> GetEntriesFromPayload(Payload pld)
        {
            ListBasic lic = new ListBasic("Commands");
            foreach(KeyValuePair<string, List<Cmd>> kvp in pld.CommandEntries)
            {
                string cat = kvp.Key;
                CategoryBasic cb = new CategoryBasic(cat);
                foreach (Cmd cmd in kvp.Value)
                {
                    EntryMultyText e = new EntryMultyText(
                        "command_text", cmd.command_text,
                        "what_does", cmd.what_does,
                        "explanation", cmd.explanation,
                        "example", cmd.example,
                        "example_explanation", cmd.example_explanation,
                        "tags", cmd.tags.ToString());
                    cb.AddEntry(e);
                }
                lic.AddCategory(cb);
            }

            ListBasic lia = new ListBasic("Auxiliary");
            foreach (KeyValuePair<string, List<Aux>> kvp in pld.InfoEntries)
            {
                string cat = kvp.Key;
                CategoryBasic cb = new CategoryBasic(cat);
                foreach (Aux aux in kvp.Value)
                {
                    EntryMultyText e = new EntryMultyText(
                        "command_text", aux.command_text,
                        "description", aux.description,
                        "tags", aux.tags.ToString());
                    cb.AddEntry(e);
                }
                lia.AddCategory(cb);
            }

            return new List<ListBase>() { lic, lia };
        }
    }
}
