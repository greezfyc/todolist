using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Git.Todolist.Data.DBContext
{

    public class MongoDbContext
    {
        private MongoClient client { get; set; }

        private string database = "todolist";
        private IMongoDatabase DataBase
        {
            get
            {
                return client.GetDatabase(database);
            }
        }

        public MongoDbContext()
        {
            client = new MongoClient
           (
           new MongoClientSettings()
           {
               Server = new MongoServerAddress("localhost"),
               Credentials = new List<MongoCredential>()
               {
                        MongoCredential.CreateMongoCRCredential(database,"sa","1")
               }
           }
       );
        }


        public IMongoCollection<T> DbSet<T>() where T : class => DataBase.GetCollection<T>(typeof(T).Name);

    }

    public interface IMongoDBContext
    {


        /// <summary>
        /// 具体的表连接器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IMongoCollection<T> DbSet<T>() where T : class;


    }
}
