using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
