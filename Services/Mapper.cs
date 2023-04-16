using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{
    public static class Mapper
    {
        public static TDto AutoMap<T, TDto>(this T item)
        where TDto : class
        where T : class
        {
            var list = item.GetType().GetProperties();
            var inst = Activator.CreateInstance(typeof(TDto));
            foreach (var i in list)
            {
                if (((TDto)inst!).GetType().GetProperty(i.Name) == null)
                    continue;
                try
                {
                    var valor = i.GetValue(item, null);
                    ((TDto)inst).GetType().GetProperty(i.Name)?.SetValue((TDto)inst, valor);
                }
                catch { }
            }
            return (TDto)inst!;
        }
        public static void Remap<Class1, Class2>(Class1 Origin, Class2 NewInstanse)
            where Class2 : class
            where Class1 : class
        {
            foreach (var d in Origin.GetType().GetProperties())
            {
                foreach (var _d in NewInstanse.GetType().GetProperties())
                {
                    try
                    {
                        if (d.Name == _d.Name)
                        {
                            d.SetValue(Origin, _d.GetValue(NewInstanse));
                            break;
                        }
                    }
                    catch { }
                }
            }
        }
    }
}