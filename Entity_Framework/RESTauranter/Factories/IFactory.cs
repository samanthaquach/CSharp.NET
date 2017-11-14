using Form_Submission.Models;
using System.Collections.Generic;

namespace Form_Submission.Factories
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}