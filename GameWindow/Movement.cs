using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWindowApp
{
    public class Movement
    {
        public Matrix4 randomPoint()
        {
            Random rand = new Random();

            float xm, ym, zm;

            if (rand.Next(0, 1) == 0) xm = -1;
            else xm = 1;
            if (rand.Next(0, 1) == 0) ym = -1;
            else ym = 1;
            if (rand.Next(0, 1) == 0) zm = -1;
            else zm = 1;

            return Matrix4.CreateTranslation((float)rand.NextDouble() * 6 * xm, (float)rand.NextDouble() * 6 * ym, (float)rand.NextDouble() * 6 * zm);
        }

        public float[] vectorVelocity(Matrix4 body, Matrix4 point)
        {
            var xst = body.ExtractTranslation().X;
            var yst = body.ExtractTranslation().Y;
            var zst = body.ExtractTranslation().Z;

            var xend = point.ExtractTranslation().X;
            var yend = point.ExtractTranslation().Y;
            var zend = point.ExtractTranslation().Z;

            var dx = xend - xst;
            var dy = yend - yst;
            var dz = zend - zst;

            var d = (float)Math.Sqrt(dx*dx + dy*dy + dz*dz);

            var vx = dx / d;
            var vy = dy / d;
            var vz = dz / d;

            return new[] { vx, vy, vz };
        }
    }
}
