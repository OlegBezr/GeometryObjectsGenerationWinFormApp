using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class RectanglePrimitive : AbstractPrimitive
    {
        public RectanglePrimitive():base()
        {
            this.size = new Vector3(0, 0, 0);
        }
        public RectanglePrimitive(Vector3 pos, double xSize, double ySize) : base(pos)
        {
            this.size = new Vector3(xSize, ySize, 10);
        }
    }
}
