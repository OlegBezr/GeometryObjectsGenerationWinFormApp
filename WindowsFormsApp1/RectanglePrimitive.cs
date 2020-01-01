using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class RectanglePrimitive : AbstractPrimitive
    {
        public RectanglePrimitive(Vector3 pos, double xSize, double ySize) : base(pos)
        {
            size = new Vector3(xSize, ySize, 10);
        }
    }
}
