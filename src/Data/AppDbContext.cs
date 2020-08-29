using System;
using LiteDB;
using NetCoreLiteDB.Models;

namespace NetCoreLiteDB.Data
{
    public class AppDbContext
    {
        private readonly LiteDatabase _database;

        public ILiteCollection<Pessoa> Pessoas => _database.GetCollection<Pessoa>("pessoas");

        public AppDbContext()
        {
            _database = new LiteDatabase(@"MyData.db");
        }
    }
}