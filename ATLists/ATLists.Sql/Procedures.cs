using System;
using System.Collections.Generic;
using System.IO;

namespace ATLists.SQL
{
    public static class Procedures
    {
        public static string LAST_EXCEPTION;
        public static string DATABASE_PATH;  //App.DATABASE_PATH


        public static Dictionary<int, SqlSingleText> SingleTexts { get; private set; }
        public static Dictionary<int, SqlMultyText> MultyTexts { get; private set; }
        public static Dictionary<int, SqlColorable> Colorables { get; private set; }
        public static Dictionary<int, SqlQualifiable> Qualifiables { get; private set; }
        public static Dictionary<int, SqlQuantifiable> Quantifiables { get; private set; }
        public static Dictionary<int, SqlIconable> Iconables { get; private set; }
        public static Dictionary<int, SqlEntryStorage> EntryStorages { get; private set; }
        public static Dictionary<int, SqlCategoryStorage> CategoryStorages { get; private set; }
        public static Dictionary<int, SqlEntry> Entries { get; private set; }
        public static Dictionary<int, SqlCategory> Categories { get; private set; }
        public static Dictionary<int, SqlList> Lisis { get; private set; }
        static Procedures()
        {
            SingleTexts = new Dictionary<int, SqlSingleText>();
            MultyTexts = new Dictionary<int, SqlMultyText>();
            Colorables = new Dictionary<int, SqlColorable>();
            Qualifiables = new Dictionary<int, SqlQualifiable>();
            Quantifiables = new Dictionary<int, SqlQuantifiable>();
            Iconables = new Dictionary<int, SqlIconable>();
            EntryStorages = new Dictionary<int, SqlEntryStorage>();
            CategoryStorages = new Dictionary<int, SqlCategoryStorage>();
            Entries = new Dictionary<int, SqlEntry>();
            Categories = new Dictionary<int, SqlCategory>();
            Lisis = new Dictionary<int, SqlList>();
        }



        public static int Insert(SqlSingleText o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                SingleTexts.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlColorable o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                Colorables.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlQualifiable o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                Qualifiables.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlQuantifiable o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                Quantifiables.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlMultyText o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                MultyTexts.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlIconable o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                Iconables.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlEntryStorage o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                EntryStorages.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlCategoryStorage o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                CategoryStorages.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlEntry o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                Entries.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlCategory o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                Categories.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }
        public static int Insert(SqlList o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.Insert(o);
                }
                Lisis.Add(o.Id, o);
                return o.Id;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return -1;
            }
        }



        public static bool Update(SqlMultyText o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }
        public static bool Update(SqlSingleText o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }
        public static bool Update(SqlColorable o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }
        public static bool Update(SqlQualifiable o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }
        public static bool Update(SqlQuantifiable o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }
        public static bool Update(SqlIconable o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }
        public static bool Update(SqlEntryStorage o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }
        public static bool Update(SqlCategoryStorage o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }
        public static bool Update(SqlCategory o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }
        public static bool Update(SqlList o)
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.RunInTransaction(() =>
                    {
                        conn.Update(o);
                    });
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }



        /// <summary>
        /// Delete all tables
        /// </summary>
        /// <returns>True if successful</returns>
        public static bool DropTables()
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.DropTable<SqlSingleText>();
                    conn.DropTable<SqlMultyText>();
                    conn.DropTable<SqlColorable>();
                    conn.DropTable<SqlQualifiable>();
                    conn.DropTable<SqlQuantifiable>();
                    conn.DropTable<SqlIconable>();
                    conn.DropTable<SqlEntryStorage>();
                    conn.DropTable<SqlCategoryStorage>();
                    conn.DropTable<SqlEntry>();
                    conn.DropTable<SqlCategory>();
                    conn.DropTable<SqlList>();
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Delete all records from all tables
        /// </summary>
        /// <returns>True if successful</returns>
        public static bool CleanTables()
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.DeleteAll<SqlSingleText>();
                    conn.DeleteAll<SqlMultyText>();
                    conn.DeleteAll<SqlColorable>();
                    conn.DeleteAll<SqlQualifiable>();
                    conn.DeleteAll<SqlQuantifiable>();
                    conn.DeleteAll<SqlIconable>();
                    conn.DeleteAll<SqlEntryStorage>();
                    conn.DeleteAll<SqlCategoryStorage>();
                    conn.DeleteAll<SqlEntry>();
                    conn.DeleteAll<SqlCategory>();
                    conn.DeleteAll<SqlList>();
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Creates all the database Tables
        /// </summary>
        /// <returns>True if successful</returns>
        public static bool CreateTables()
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    conn.CreateTable<SqlSingleText>();
                    conn.CreateTable<SqlMultyText>();
                    conn.CreateTable<SqlColorable>();
                    conn.CreateTable<SqlQualifiable>();
                    conn.CreateTable<SqlQuantifiable>();
                    conn.CreateTable<SqlIconable>();
                    conn.CreateTable<SqlEntryStorage>();
                    conn.CreateTable<SqlCategoryStorage>();
                    conn.CreateTable<SqlEntry>();
                    conn.CreateTable<SqlCategory>();
                    conn.CreateTable<SqlList>();
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Loads all SQL objects from the database to the static vars
        /// "InventoryLists", "InventoryCategories" and "InventoryEntries"
        /// </summary>
        /// <returns>True if successful</returns>
        public static bool RetrieveAll()
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    List<SqlSingleText> singleTexts = conn.Query<SqlSingleText>("select * from SqlSingleText");
                    List<SqlMultyText> multyTexts = conn.Query<SqlMultyText>("select * from SqlMultyText");
                    List<SqlColorable> colorables = conn.Query<SqlColorable>("select * from SqlColorable");
                    List<SqlQualifiable> qualifiables = conn.Query<SqlQualifiable>("select * from SqlQualifiable");
                    List<SqlQuantifiable> quantifiables = conn.Query<SqlQuantifiable>("select * from SqlQuantifiable");
                    List<SqlIconable> iconables = conn.Query<SqlIconable>("select * from SqlIconable");
                    List<SqlEntryStorage> entryStorages = conn.Query<SqlEntryStorage>("select * from SqlEntryStorage");
                    List<SqlCategoryStorage> categoryStorages = conn.Query<SqlCategoryStorage>("select * from SqlCategoryStorage");
                    List<SqlEntry> entries = conn.Query<SqlEntry>("select * from SqlEntry");
                    List<SqlCategory> categories = conn.Query<SqlCategory>("select * from SqlCategory");
                    List<SqlList> lists = conn.Query<SqlList>("select * from SqlList");

                    SingleTexts = new Dictionary<int, SqlSingleText>();
                    MultyTexts = new Dictionary<int, SqlMultyText>();
                    Colorables = new Dictionary<int, SqlColorable>();
                    Qualifiables = new Dictionary<int, SqlQualifiable>();
                    Quantifiables = new Dictionary<int, SqlQuantifiable>();
                    Iconables = new Dictionary<int, SqlIconable>();
                    EntryStorages = new Dictionary<int, SqlEntryStorage>();
                    CategoryStorages = new Dictionary<int, SqlCategoryStorage>();
                    Entries = new Dictionary<int, SqlEntry>();
                    Categories = new Dictionary<int, SqlCategory>();
                    Lisis = new Dictionary<int, SqlList>();

                    foreach (SqlSingleText o in singleTexts) SingleTexts.Add(o.Id, o);
                    foreach (SqlMultyText o in multyTexts) MultyTexts.Add(o.Id, o);
                    foreach (SqlColorable o in colorables) Colorables.Add(o.Id, o);
                    foreach (SqlQualifiable o in qualifiables) Qualifiables.Add(o.Id, o);
                    foreach (SqlQuantifiable o in quantifiables) Quantifiables.Add(o.Id, o);
                    foreach (SqlIconable o in iconables) Iconables.Add(o.Id, o);
                    foreach (SqlEntryStorage o in entryStorages) EntryStorages.Add(o.Id, o);
                    foreach (SqlCategoryStorage o in categoryStorages) CategoryStorages.Add(o.Id, o);
                    foreach (SqlEntry o in entries) Entries.Add(o.Id, o);
                    foreach (SqlCategory o in categories) Categories.Add(o.Id, o);
                    foreach (SqlList o in lists) Lisis.Add(o.Id, o);
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Tries to load all SQL objects from the database and returns true if there is at least 1 item 
        /// in each of the 3 main tables
        /// </summary>
        /// <returns>True if successful and the database is not empty</returns>
        public static bool CheckTablesExist()
        {
            LAST_EXCEPTION = null;
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    List<SqlList> lists = conn.Query<SqlList>("select * from SqlList");
                    List<SqlCategory> cats = conn.Query<SqlCategory>("select * from SqlCategory");
                    List<SqlEntry> entries = conn.Query<SqlEntry>("select * from SqlEntry");

                    if (lists.Count < 1 || cats.Count < 1 || entries.Count < 1) return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                LAST_EXCEPTION = ex.Message;
                return false;
            }
        }


        /// <summary>
        /// Inserts some example info in the database
        /// </summary>
        /// <returns></returns>
        public static bool InsertDummyLists()
        {
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {

                }
                return true;
            }
            catch (Exception ex)
            {
                string exc = ex.Message;
                return false;
            }
        }



        public static byte[] GetDatabase()
        {
            try
            {
                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(DATABASE_PATH))
                {
                    byte[] db = File.ReadAllBytes(DATABASE_PATH);
                    return db;
                }
            }
            catch (Exception ex)
            {
                string exc = ex.Message;
                return null;
            }
        }
    }
}
