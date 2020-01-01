using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Vector2 {
        public Vector2(double x = 0, double y = 0) {
            this.x = x;
            this.y = y;
        }

        public double x { get; }
        public double y { get; }

        public double magnitude() {
            return Math.Sqrt((double)(x * x + y * y));
        }

        public static Vector2 operator +(Vector2 a, Vector2 b) {
            return new Vector2( a.x + b.x, a.y + b.y);
        }

        public static Vector2 operator -(Vector2 a) {
            return new Vector2( -a.x, -a.y );
        }

        public static Vector2 operator -(Vector2 a, Vector2 b) {
            return a + (-b);
        }

        public static Vector2 operator *(Vector2 a, double k) {
            return new Vector2( a.x* k, a.y* k );
        }

        public static Vector2 operator /(Vector2 a, double k) {
            return (a * (1 / k));
        }

        public Vector2 random(int x_min, int x_max, int y_min, int y_max, Random rand) {
            return new Vector2(rand.Next(x_min, x_max), rand.Next(y_min, y_max));
        }
    }
}
