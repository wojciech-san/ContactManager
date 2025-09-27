using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager
{
    public interface IContactManager
    {
        public void AddContact();
        public void DisplayContacts();
        public void SearchContacts();
        public void SaveToFile(string filePath);
        public void LoadFromFile(string filePath);
    }
}