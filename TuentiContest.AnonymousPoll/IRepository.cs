using System.Collections.Generic;
using System.Resources;

namespace TuentiContest.AnonymousPoll
{
    public interface IRepository
    {
        IList<Student> All();
    }
}