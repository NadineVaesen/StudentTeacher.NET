using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SchoolMomentsApp.Extensions
{
    public static class ListExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> list)
        {
            ObservableCollection<T> collection = new ObservableCollection<T>();
            foreach (T item in list)
            {
                Console.WriteLine("item List moments", item);
                collection.Add(item);
            }

            return collection;
        }
    }
}
