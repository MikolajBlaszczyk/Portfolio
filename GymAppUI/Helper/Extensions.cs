using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAppUI.Helper
{
    public static class Extensions
    {
        public static BindableCollection<T> ToBindableCollection<T>(this IEnumerable<T> source)
        {
            return new BindableCollection<T>(source);
        }
    }
}
