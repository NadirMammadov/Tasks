using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    public interface IPerson
    {

        public List<Person> GetAllConnected();
        public List<Person> Search(string searchtext);
        public  List<Person> GetAllDisConnected();
        public  void Delete(int id);
        public bool Insert(Person person);

    }
}
