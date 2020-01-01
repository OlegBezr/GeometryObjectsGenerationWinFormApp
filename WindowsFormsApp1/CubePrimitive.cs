using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CubePrimitive : AbstractPrimitive
    {
        public CubePrimitive(Vector3 pos, double size) : base(pos)
        {
            this.size = new Vector3(size, size, size);
        }

        public void Move(Random rand) {
            double abs_x_move = Convert.ToDouble(rand.Next(11));
            double abs_y_move = Convert.ToDouble(rand.Next(11));
            double abs_z_move = Convert.ToDouble(rand.Next(11));

            pos = new Vector3(pos.x + abs_x_move * (rand.Next(2) * 2 - 1), pos.y + abs_y_move * (rand.Next(2) * 2 - 1), pos.z + abs_z_move * (rand.Next(2) * 2 - 1));
        }
    }
}
