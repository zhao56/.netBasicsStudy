using System;
using System.Collections.Generic;
using System.Text;

namespace zhao56.study.basic.Common
{
    public interface IdbHelper
    {
        T Get<T>(decimal id) where T :class;
        bool Del(decimal id);
        bool Update<T>(T t) where T : class;
        bool Add<T>(T t) where T : class;
        List<T> Query<T>() where T : class;
    }
}
