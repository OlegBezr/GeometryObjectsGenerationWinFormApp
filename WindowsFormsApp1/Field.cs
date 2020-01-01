using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Field
    {
        public Field()
        {

        }

        public List<AbstractPrimitive> Primitives = new List<AbstractPrimitive>();

        public void AddObject(AbstractPrimitive obj)
        {
            Primitives.Add(obj);
        }

        public void DeleteObject(AbstractPrimitive obj)
        {
            Primitives.Remove(obj);
        }
    }
}
