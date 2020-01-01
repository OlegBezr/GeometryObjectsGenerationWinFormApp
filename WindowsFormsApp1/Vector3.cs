using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Vector3 {
        public Vector3(double x = 0, double y = 0, double z = 0) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double x { get; }
        public double y { get; }
        public double z { get; }

        public double magnitude() {
            return Math.Sqrt((double)(x * x + y * y + z * z));
        }

        public Vector2 toV2() {
            return new Vector2(x, y);
        }

        public static Vector3 operator +(Vector3 a, Vector3 b) {
            return new Vector3( a.x + b.x, a.y + b.y, a.z + b.z );
        }

        public static Vector3 operator -(Vector3 a) {
            return new Vector3( -a.x, -a.y, -a.z );
        }

        public static Vector3 operator -(Vector3 a, Vector3 b) {
            return a + (-b);
        }

        public static Vector3 operator *(Vector3 a, double k) {
            return new Vector3( a.x* k, a.y* k, a.z* k );
        }

        public static Vector3 operator /(Vector3 a, double k) {
            return (a * (1 / k));
        }

        public Vector3 random(int x_min, int x_max, int y_min, int y_max, int z_min, int z_max, Random rand) {
            return new Vector3(rand.Next(x_min, x_max), rand.Next(y_min, y_max), rand.Next(z_min, z_max));
        }
    }
}
