using OpenTK;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameWindowApp
{
    public partial class Form_Settings : Form
    {
        Form1 form1;

        public Vector3 _color1 = new Vector3(1.0f, 0.5f, 0.31f);

        public Vector3 _color2 = new Vector3(153.0f / 255.0f, 51f / 255f, 153f / 255f);

        public Vector3 _color3 = new Vector3(51f / 255f, 153f / 255f, 255f / 255f);

        public Vector3 _color4 = new Vector3(0.4f, 0.6f, 0.31f);

        public Vector3 _color5 = new Vector3(173f / 255f, 173f / 255f, 173f / 255f);

        public Vector3 _colorReflection1 = new Vector3(1.0f, 1.0f, 1.0f);

        public Vector3 _colorReflection2 = new Vector3(1.0f, 1.0f, 1.0f);

        public Vector3 _colorReflection3 = new Vector3(1.0f, 1.0f, 1.0f);

        public Vector3 _colorReflection4 = new Vector3(1.0f, 1.0f, 1.0f);

        public Vector3 _colorReflection5 = new Vector3(1.0f, 1.0f, 1.0f);

        public Matrix4 _coordinate1 = Matrix4.CreateTranslation(-2.0f, 0.0f, 0.0f);

        public Matrix4 _coordinate2 = Matrix4.CreateTranslation(-1.0f, 0.0f, 0.0f);

        public Matrix4 _coordinate3 = Matrix4.CreateTranslation(0.0f, 0.0f, 0.0f);

        public Matrix4 _coordinate4 = Matrix4.CreateTranslation(1.0f, 0.0f, 0.0f);

        public Matrix4 _coordinate5 = Matrix4.CreateTranslation(2.0f, 0.0f, 0.0f);

        public float[] _angle1 = { 0, 0, 0 };

        public float[] _angle2 = { 0, 0, 0 };

        public float[] _angle3 = { 0, 0, 0 };

        public float[] _angle4 = { 0, 0, 0 };

        public float[] _angle5 = { 0, 0, 0 };

        public Matrix4 _scale1 = Matrix4.CreateScale(1.0f, 1.0f, 1.0f);

        public Matrix4 _scale2 = Matrix4.CreateScale(1.0f, 1.0f, 1.0f);

        public Matrix4 _scale3 = Matrix4.CreateScale(1.0f, 1.0f, 1.0f);

        public Matrix4 _scale4 = Matrix4.CreateScale(0.33f, 0.33f, 0.33f);

        public Matrix4 _scale5 = Matrix4.CreateScale(0.33f, 0.33f, 0.33f);

        public bool _moveEnabled1 = false;

        public bool _moveEnabled2 = false;

        public bool _moveEnabled3 = false;

        public bool _moveEnabled4 = false;

        public bool _moveEnabled5 = false;

        public float _speed1 = 1.0f;

        public float _speed2 = 1.0f;

        public float _speed3 = 1.0f;

        public float _speed4 = 1.0f;

        public float _speed5 = 1.0f;

        public bool _polygonalEnabled1 = true;

        public bool _polygonalEnabled2 = true;

        public bool _polygonalEnabled3 = true;

        public bool _polygonalEnabled4 = true;

        public bool _polygonalEnabled5 = true;

        public Form_Settings(Form1 gameWindow)
        {
            InitializeComponent();
            form1 = gameWindow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1._color1 = new Vector3(153.0f / 255.0f, 51f / 255f, 153f / 255f);
        }
    }
}
