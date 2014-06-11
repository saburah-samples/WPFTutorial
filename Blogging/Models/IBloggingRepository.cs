using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blogging.Models
{
    public interface IBloggingRepository
    {
        Blog Find(int id);
        IEnumerable<Blog> FindAll();

        void Add(Blog blog);
    }
}
