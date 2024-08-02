using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.UowAbstract
{
    public interface IGenericUowService<T>
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TDelete(T t);
        void TMultiUpdate(List<T> t);
        T TGetById(int id);
    }
}
