﻿namespace Git.Todolist.Core
{
    public class DBConnection
    {
        public static bool Encrypt { get; set; }

        public DBConnection(bool encrypt)
        {
            Encrypt = encrypt;
        }

        public static string connectionString
        {
            get
            {
                string connection = System.Configuration.ConfigurationManager.ConnectionStrings["BaseDbContext"].ConnectionString;
                if (Encrypt == true)
                {
                    return DESEncrypt.Decrypt(connection);
                }
                else
                {
                    return connection;
                }
            }
        }
    }
}