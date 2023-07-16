using BusinessObject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IAuthorRepository
    {
        void SaveAuthor(Author  c);
        Author  GetAuthorById(int id);
        void DeleteAuthor(Author  p);
        void UpdateAuthor(Author  p);
        List<Author > GetAuthor();
    }
}
