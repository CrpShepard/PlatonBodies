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

        public Form_Settings(Form1 gameWindow)
        {
            InitializeComponent();
            form1 = gameWindow;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._color1 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._color2 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._color3 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._color4 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._color5 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._colorReflection1 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._colorReflection2 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._colorReflection3 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._colorReflection4 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                form1._colorReflection5 = new Vector3(colorDialog.Color.R / 255.0f, colorDialog.Color.G / 255f, colorDialog.Color.B / 255f);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1._coordinate1 = Matrix4.CreateTranslation(float.Parse(textBox1.Text), float.Parse(textBox2.Text), float.Parse(textBox3.Text));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            form1._coordinate2 = Matrix4.CreateTranslation(float.Parse(textBox20.Text), float.Parse(textBox18.Text), float.Parse(textBox17.Text));

        }

        private void button17_Click(object sender, EventArgs e)
        {
            form1._coordinate3 = Matrix4.CreateTranslation(float.Parse(textBox30.Text), float.Parse(textBox29.Text), float.Parse(textBox28.Text));

        }

        private void button23_Click(object sender, EventArgs e)
        {
            form1._coordinate4 = Matrix4.CreateTranslation(float.Parse(textBox40.Text), float.Parse(textBox39.Text), float.Parse(textBox38.Text));

        }

        private void button29_Click(object sender, EventArgs e)
        {
            form1._coordinate5 = Matrix4.CreateTranslation(float.Parse(textBox50.Text), float.Parse(textBox49.Text), float.Parse(textBox48.Text));

        }

        private void button3_Click(object sender, EventArgs e)
        {
            form1._angle1[0] = float.Parse(textBox6.Text);
            form1._angle1[1] = float.Parse(textBox5.Text);
            form1._angle1[2] = float.Parse(textBox4.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            form1._angle2[0] = float.Parse(textBox16.Text);
            form1._angle2[1] = float.Parse(textBox15.Text);
            form1._angle2[2] = float.Parse(textBox14.Text);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            form1._angle3[0] = float.Parse(textBox27.Text);
            form1._angle3[1] = float.Parse(textBox26.Text);
            form1._angle3[2] = float.Parse(textBox25.Text);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            form1._angle4[0] = float.Parse(textBox37.Text);
            form1._angle4[1] = float.Parse(textBox36.Text);
            form1._angle4[2] = float.Parse(textBox35.Text);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            form1._angle5[0] = float.Parse(textBox47.Text);
            form1._angle5[1] = float.Parse(textBox46.Text);
            form1._angle5[2] = float.Parse(textBox45.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form1._scale1 = Matrix4.CreateScale(float.Parse(textBox9.Text), float.Parse(textBox8.Text), float.Parse(textBox7.Text));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            form1._scale2 = Matrix4.CreateScale(float.Parse(textBox13.Text), float.Parse(textBox12.Text), float.Parse(textBox11.Text));

        }

        private void button15_Click(object sender, EventArgs e)
        {
            form1._scale3 = Matrix4.CreateScale(float.Parse(textBox24.Text), float.Parse(textBox23.Text), float.Parse(textBox22.Text));

        }

        private void button21_Click(object sender, EventArgs e)
        {
            form1._scale4 = Matrix4.CreateScale(float.Parse(textBox34.Text), float.Parse(textBox33.Text), float.Parse(textBox32.Text));

        }

        private void button27_Click(object sender, EventArgs e)
        {
            form1._scale5 = Matrix4.CreateScale(float.Parse(textBox44.Text), float.Parse(textBox43.Text), float.Parse(textBox42.Text));

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                form1._moveEnabled1 = true;
            }
            if (radioButton2.Checked)
            {
                form1._moveEnabled1 = false;
            }
            if (radioButton5.Checked)
            {
                form1._moveEnabled2 = true;
            }
            if (radioButton6.Checked)
            {
                form1._moveEnabled2 = false;
            }
            if (radioButton9.Checked)
            {
                form1._moveEnabled3 = true;
            }
            if (radioButton10.Checked)
            {
                form1._moveEnabled3 = false;
            }
            if (radioButton17.Checked)
            {
                form1._moveEnabled4 = true;
            }
            if (radioButton18.Checked)
            {
                form1._moveEnabled4 = false;
            }
            if (radioButton21.Checked)
            {
                form1._moveEnabled5 = true;
            }
            if (radioButton22.Checked)
            {
                form1._moveEnabled5 = false;
            }

            if (radioButton13.Checked)
            {
                form1._polygonalEnabled1 = false;
            }
            if (radioButton14.Checked)
            {
                form1._polygonalEnabled1 = true;
            }
            if (radioButton3.Checked)
            {
                form1._polygonalEnabled2 = false;
            }
            if (radioButton4.Checked)
            {
                form1._polygonalEnabled2 = true;
            }
            if (radioButton7.Checked)
            {
                form1._polygonalEnabled3 = false;
            }
            if (radioButton8.Checked)
            {
                form1._polygonalEnabled3 = true;
            }
            if (radioButton15.Checked)
            {
                form1._polygonalEnabled4 = false;
            }
            if (radioButton16.Checked)
            {
                form1._polygonalEnabled4 = true;
            }
            if (radioButton19.Checked)
            {
                form1._polygonalEnabled5 = false;
            }
            if (radioButton20.Checked)
            {
                form1._polygonalEnabled5 = true;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            form1._speed1 = float.Parse(textBox19.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            form1._speed2 = float.Parse(textBox10.Text);

        }

        private void button13_Click(object sender, EventArgs e)
        {
            form1._speed3 = float.Parse(textBox21.Text);

        }

        private void button19_Click(object sender, EventArgs e)
        {
            form1._speed4 = float.Parse(textBox31.Text);

        }

        private void button25_Click(object sender, EventArgs e)
        {
            form1._speed5 = float.Parse(textBox41.Text);

        }
    }
}
