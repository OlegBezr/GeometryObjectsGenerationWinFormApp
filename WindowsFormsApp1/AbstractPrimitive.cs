using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public abstract class AbstractPrimitive
    {
        public AbstractPrimitive()
        {
            this.pos = new Vector3(0, 0, 0);
        }
        public AbstractPrimitive(Vector3 pos)
        {
            this.pos = pos;
        }

        public Vector3 pos;
        public Vector3 size;

        public virtual bool CheckIntersection(AbstractPrimitive obj) {
            AbstractPrimitive[][] pairs = new[] { new[] { obj, this }, new[] { this, obj } };

            AbstractPrimitive[] pair;

            for (int n = 0; n < 2; n++) {
                pair = pairs[n];

                Vector3 pos1 = pair[0].pos;
                Vector3 hSize1 = pair[0].size / 2;

                Vector3 pos2 = pair[1].pos;
                Vector3 hSize2 = pair[1].size / 2;

                Vector3 dif = pos1 - pos2;
                Vector3 sizeSum = hSize1 + hSize2;

                if (Math.Abs(dif.x) <= sizeSum.x && Math.Abs(dif.y) <= sizeSum.y && Math.Abs(dif.z) <= sizeSum.z) {
                    return true;
                }
            }
            return false;
        }
    }
}
