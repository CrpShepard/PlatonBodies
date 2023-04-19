using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWindowApp
{
    public class Boundry
    {
        public Vector3 p1 = new Vector3(-5.0f, -5.0f, -5.0f);
        public Vector3 p2 = new Vector3(5.0f, -5.0f, -5.0f);
        public Vector3 p3 = new Vector3(5.0f, 5.0f, -5.0f);
        public Vector3 p4 = new Vector3(-5.0f, 5.0f, -5.0f);
        public Vector3 p5 = new Vector3(-5.0f, -5.0f, 5.0f);
        public Vector3 p6 = new Vector3(5.0f, -5.0f, 5.0f);
        public Vector3 p7 = new Vector3(5.0f, 5.0f, 5.0f);
        public Vector3 p8 = new Vector3(-5.0f, 5.0f, 5.0f);

        public bool checkBorder(Matrix4 body)
        {
            var x = body.ExtractTranslation().X;
            var y = body.ExtractTranslation().Y;
            var z = body.ExtractTranslation().Z;

            if (x <= -5.0f || x >= 5.0f)
            {
                return false;
            }
            if (y <= -5.0f || y >= 5.0f)
            {
                return false;
            }
            if (z <= -5.0f || z >= 5.0f)
            {
                return false;
            }
            return true;

        }
    }
}
