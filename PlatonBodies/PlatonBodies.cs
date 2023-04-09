using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatonBodies
{
    public class PlatonBodies
    {

        // Piramide
        public readonly float[] piramide_vertices =
        {
            // Position       

            -0.5f, 0.0f, -0.5f, // 0
            0.0f, -1.0f, 0.0f, // 1
            -1.0f, -1.0f, 0.0f, // 2
            0.0f, -1.0f, -1.0f, // 3
            -1.0f, -1.0f, -1.0f, // 4
        };


        public readonly uint[] piramide_indices =
        {
            0, 1, 2, // forward
            0, 3, 1, // left
            0, 3, 4, // back
            0, 4, 2, // right
            4, 2, 1, 1, 3, 4 // bottom

        };

        // Cube w texture
        public readonly float[] cube_w_texture_vertices =
        {
            // Position       Texture coordinates

            0.0f, 0.0f, 0.0f, 0.0f, 0.0f, // 0
            1.0f, 0.0f, 0.0f, 1.0f, 0.0f, // 1
            1.0f, 1.0f, 0.0f, 1.0f, 1.0f, // 2
            0.0f, 1.0f, 0.0f, 0.0f, 1.0f, // 3

            0.0f, 0.0f, 1.0f, 0.0f, 0.0f, // 4
            0.0f, 0.0f, 0.0f, 1.0f, 0.0f, // 5
            0.0f, 1.0f, 0.0f, 1.0f, 1.0f, // 6
            0.0f, 1.0f, 1.0f, 0.0f, 1.0f, // 7

            0.0f, 0.0f, 1.0f, 0.0f, 0.0f, // 8
            1.0f, 0.0f, 1.0f, 1.0f, 0.0f, // 9
            1.0f, 1.0f, 1.0f, 1.0f, 1.0f, // 10
            0.0f, 1.0f, 1.0f, 0.0f, 1.0f, // 11

            1.0f, 0.0f, 1.0f, 0.0f, 0.0f, // 12
            1.0f, 0.0f, 0.0f, 1.0f, 0.0f, // 13
            0.0f, 0.0f, 0.0f, 1.0f, 1.0f, // 14
            0.0f, 0.0f, 1.0f, 0.0f, 1.0f, // 15

            1.0f, 1.0f, 1.0f, 0.0f, 0.0f, // 16
            1.0f, 1.0f, 0.0f, 1.0f, 0.0f, // 17
            1.0f, 0.0f, 0.0f, 1.0f, 1.0f, // 18
            1.0f, 0.0f, 1.0f, 0.0f, 1.0f, // 19

            0.0f, 1.0f, 1.0f, 0.0f, 0.0f, // 20
            0.0f, 1.0f, 0.0f, 1.0f, 0.0f, // 21
            1.0f, 1.0f, 0.0f, 1.0f, 1.0f, // 22
            1.0f, 1.0f, 1.0f, 0.0f, 1.0f, // 23
        };


        public readonly uint[] cube_w_texture_indices =
        {
            0, 1, 2, 2, 3, 0, // forward
            4, 5, 6, 6, 7, 4, // left
            8, 9, 10, 10, 11, 8, // back
            12, 13, 14, 14, 15, 12, // top
            16, 17, 18, 18, 19, 16, // right
            20, 21, 22, 22, 23, 20, // bottom

        };


    }
}
