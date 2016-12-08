using Project1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project1.DAL
{
    public class MissionContext : DbContext
    {
        public MissionContext()
            : base("MissionContext")//allows us access to the db context
        {

        }

        /*This DBsets will hold the data the is returned from the query*/
        public DbSet<Missions> Mission { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<MissionQuestions> MissionQuestion { get; set; }
        public DbSet<TablesAll> TableAlls { get; set; }


    }
}