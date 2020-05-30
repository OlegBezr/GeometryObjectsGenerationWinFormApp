using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Field
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

        public bool CheckIntersection(int i, int j)
        {
            if (i < 0 || j < 0)
            {
                return false;
            }
            else if (i >= Primitives.Count || j >= Primitives.Count)
            {
                return false;
            }

            return Primitives[i].CheckIntersection(Primitives[j]);
        }
    }
}
