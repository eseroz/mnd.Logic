using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace mnd.Logic.Helper
{
    public static class MyEf_Extension
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        {
            return new ObservableCollection<T>(source);
        }
    }
}