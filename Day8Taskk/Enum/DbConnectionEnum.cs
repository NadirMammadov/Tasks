using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8Taskk.Enum
{
    public enum DbConnectionEnum
    {
        [Display(Name = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;")]
        Sql,
        [Display(Name = "mongodb://mongodb0.example.com:27017")]
        MongoDb,
        [Display(Name = "Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;")]
        MySql
    }
}
