using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Windows.Forms;
using LearnOpenTK.Common;
using OpenTK.Input;
using System.Diagnostics;

namespace GameWindowApp
{
    public partial class Form1 : Form
    {
        PlatonBodies.PlatonBodies pb = new PlatonBodies.PlatonBodies();

        Boundry boundry = new Boundry();

        Movement movement = new Movement();

        private readonly Vector3 _lightPos = new Vector3(1.2f, 1.0f, 2.0f);

        private int _vertexBufferObject; // piramide

        private int _vertexBufferObject2; // octaedr

        private int _vertexBufferObject3; // cube

        private int _vertexBufferObject4; // dodecahedron

        private int _vertexBufferObject5; // icosahedron

        private int _vaoModel;

        private int _vaoModel2;

        private int _vaoModel3;

        private int _vaoModel4;

        private int _vaoModel5;

        private int _vaoLamp;

        private Shader _lampShader;

        private Shader _lightingShader;

        private Camera _camera;

        private bool _firstMove = true;

        private Vector2 _lastPos;

        private Matrix4 _view;

        private Matrix4 _projection;

        private Timer _timer = null!;

        float deltaTime = 0.0f;
        float lastFrame = 0.0f;

        private Stopwatch _stopwatch = new Stopwatch();

        private bool isFocused = true;

        // переменные параметры объектов

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

        public bool _moveEnabled1 = true;

        public bool _moveEnabled2 = true;

        public bool _moveEnabled3 = true;

        public bool _moveEnabled4 = true;

        public bool _moveEnabled5 = true;

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

        public Matrix4 _point1;

        public Matrix4 _point2;

        public Matrix4 _point3;

        public Matrix4 _point4;

        public Matrix4 _point5;

        public float[] _velocityVector1;

        public float[] _velocityVector2;

        public float[] _velocityVector3;

        public float[] _velocityVector4;

        public float[] _velocityVector5;

        public float[] _vectorSpeed1 = { 0, 0, 0 };

        public float[] _vectorSpeed2 = { 0, 0, 0 };

        public float[] _vectorSpeed3 = { 0, 0, 0 };

        public float[] _vectorSpeed4 = { 0, 0, 0 };

        public float[] _vectorSpeed5 = { 0, 0, 0 };


        public Form1()
        {
            InitializeComponent();
            _stopwatch.Start();

            _point1 = movement.randomPoint();
            _velocityVector1 = movement.vectorVelocity(_coordinate1, _point1);

            _point2 = movement.randomPoint();
            _velocityVector2 = movement.vectorVelocity(_coordinate2, _point2);

            _point3 = movement.randomPoint();
            _velocityVector3 = movement.vectorVelocity(_coordinate3, _point3);

            _point4 = movement.randomPoint();
            _velocityVector4 = movement.vectorVelocity(_coordinate4, _point4);

            _point5 = movement.randomPoint();
            _velocityVector5 = movement.vectorVelocity(_coordinate5, _point5);
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            glControl1.Resize += glControl1_Resize;
            glControl1.Paint += glControl1_Paint;

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, pb.piramide_vertices.Length * sizeof(float), pb.piramide_vertices, BufferUsageHint.StaticDraw);

            _vertexBufferObject2 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject2);
            GL.BufferData(BufferTarget.ArrayBuffer, pb.octaedr_vertices.Length * sizeof(float), pb.octaedr_vertices, BufferUsageHint.StaticDraw);

            _vertexBufferObject3 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject3);
            GL.BufferData(BufferTarget.ArrayBuffer, pb.cube_vertices.Length * sizeof(float), pb.cube_vertices, BufferUsageHint.StaticDraw);

            _vertexBufferObject4 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject4);
            GL.BufferData(BufferTarget.ArrayBuffer, pb.dodecahedron_vertices_normals.Length * sizeof(float), pb.dodecahedron_vertices_normals, BufferUsageHint.StaticDraw);

            _vertexBufferObject5 = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject5);
            GL.BufferData(BufferTarget.ArrayBuffer, pb.icosahedron_vertices_normals.Length * sizeof(float), pb.icosahedron_vertices_normals, BufferUsageHint.StaticDraw);

            _lightingShader = new Shader("../../../Shader/shader.vert", "../../../Shader/lighting.frag");
            _lampShader = new Shader("../../../Shader/shader.vert", "../../../Shader/shader.frag");

            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
                _vaoModel = GL.GenVertexArray();
                GL.BindVertexArray(_vaoModel);

                var positionLocation = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);

                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);


                var normalLocation = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation);
                GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            }

            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject2);
                _vaoModel2 = GL.GenVertexArray();
                GL.BindVertexArray(_vaoModel2);

                var positionLocation = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);

                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);


                var normalLocation = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation);
                GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            }

            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject3);
                _vaoModel3 = GL.GenVertexArray();
                GL.BindVertexArray(_vaoModel3);

                var positionLocation = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);

                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);


                var normalLocation = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation);
                GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            }

            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject4);
                _vaoModel4 = GL.GenVertexArray();
                GL.BindVertexArray(_vaoModel4);

                var positionLocation = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);

                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);

                var normalLocation = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation);
                GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));

            }

            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject5);
                _vaoModel5 = GL.GenVertexArray();
                GL.BindVertexArray(_vaoModel5);

                var positionLocation = _lightingShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);

                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);

                var normalLocation = _lightingShader.GetAttribLocation("aNormal");
                GL.EnableVertexAttribArray(normalLocation);
                GL.VertexAttribPointer(normalLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));

            }

            {
                GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject3);
                _vaoLamp = GL.GenVertexArray();
                GL.BindVertexArray(_vaoLamp);

                var positionLocation = _lampShader.GetAttribLocation("aPos");
                GL.EnableVertexAttribArray(positionLocation);
                GL.VertexAttribPointer(positionLocation, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            }



            _camera = new Camera(Vector3.UnitZ * 3, Size.Width / (float)Size.Height);

            // Redraw the screen every 1/20 of a second.
            _timer = new Timer();
            _timer.Tick += (sender, e) =>
            {
                Render();
            };
            _timer.Interval = 15;   // 1000 ms per sec / 50 ms per frame = 20 FPS
            _timer.Start();

            // Ensure that the viewport and projection matrix are set correctly initially.
            glControl1_Resize(glControl1, EventArgs.Empty);
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void glControl1_Resize(object? sender, EventArgs e)
        {
            glControl1.MakeCurrent();

            if (glControl1.ClientSize.Height == 0)
                glControl1.ClientSize = new System.Drawing.Size(glControl1.ClientSize.Width, 1);

            GL.Viewport(0, 0, glControl1.ClientSize.Width, glControl1.ClientSize.Height);

            float aspect_ratio = Math.Max(glControl1.ClientSize.Width, 1) / (float)Math.Max(glControl1.ClientSize.Height, 1);
            Matrix4 perpective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perpective);
        }

        private void Render()
        {
            glControl1.MakeCurrent();

            float deltaTime = (float)_stopwatch.ElapsedMilliseconds / 1000.0f;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(_vaoModel); // piramide

            _lightingShader.Use();

            if (_moveEnabled1)
            {
                _vectorSpeed1[0] += _velocityVector1[0] * _speed1 * deltaTime;
                _vectorSpeed1[1] += _velocityVector1[1] * _speed1 * deltaTime;
                _vectorSpeed1[2] += _velocityVector1[2] * _speed1 * deltaTime;
            }

            Matrix4 _angleMatrix1 = Matrix4.Identity * Matrix4.CreateRotationX(_angle1[0]) * Matrix4.CreateRotationY(_angle1[1]) * Matrix4.CreateRotationZ(_angle1[2]);
            var model1 = Matrix4.Identity * _scale1 * _angleMatrix1 * _coordinate1 * Matrix4.CreateTranslation(_vectorSpeed1[0], _vectorSpeed1[1], _vectorSpeed1[2]);

            if (!boundry.checkBorder(model1))
            {
                _point1 = movement.randomPoint();
                _velocityVector1 = movement.vectorVelocity(model1, _point1);
            }

            _lightingShader.SetMatrix4("model", model1);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", _color1);
            _lightingShader.SetVector3("lightColor", _colorReflection1);
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            if (_polygonalEnabled1)
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            else
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 18);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.BindVertexArray(_vaoModel2); // octaedr

            _lightingShader.Use();

            if (_moveEnabled2)
            {
                _vectorSpeed2[0] += _velocityVector2[0] * _speed2 * deltaTime;
                _vectorSpeed2[1] += _velocityVector2[1] * _speed2 * deltaTime;
                _vectorSpeed2[2] += _velocityVector2[2] * _speed2 * deltaTime;
            }

            Matrix4 _angleMatrix2 = Matrix4.Identity * Matrix4.CreateRotationX(_angle2[0]) * Matrix4.CreateRotationY(_angle2[1]) * Matrix4.CreateRotationZ(_angle2[2]);
            var model2 = Matrix4.Identity * _scale2 * _angleMatrix2 * _coordinate2 * Matrix4.CreateTranslation(_vectorSpeed2[0], _vectorSpeed2[1], _vectorSpeed2[2]);

            if (!boundry.checkBorder(model2))
            {
                _point2 = movement.randomPoint();
                _velocityVector2 = movement.vectorVelocity(model2, _point2);
            }

            _lightingShader.SetMatrix4("model", model2);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", _color2); // Можно брать значения RGB 256
            _lightingShader.SetVector3("lightColor", _colorReflection2);
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            if (_polygonalEnabled2)
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            else
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 24);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.BindVertexArray(_vaoModel3); // cube

            _lightingShader.Use();

            if (_moveEnabled3)
            {
                _vectorSpeed3[0] += _velocityVector3[0] * _speed3 * deltaTime;
                _vectorSpeed3[1] += _velocityVector3[1] * _speed3 * deltaTime;
                _vectorSpeed3[2] += _velocityVector3[2] * _speed3 * deltaTime;
            }

            Matrix4 _angleMatrix3 = Matrix4.Identity * Matrix4.CreateRotationX(_angle3[0]) * Matrix4.CreateRotationY(_angle3[1]) * Matrix4.CreateRotationZ(_angle3[2]);
            var model3 = Matrix4.Identity * _scale3 * _angleMatrix3 * _coordinate3 * Matrix4.CreateTranslation(_vectorSpeed3[0], _vectorSpeed3[1], _vectorSpeed3[2]);

            if (!boundry.checkBorder(model3))
            {
                _point3 = movement.randomPoint();
                _velocityVector3 = movement.vectorVelocity(model3, _point3);
            }

            _lightingShader.SetMatrix4("model", model3);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", _color3);
            _lightingShader.SetVector3("lightColor", _colorReflection3);
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            if (_polygonalEnabled3)
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            else
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.BindVertexArray(_vaoModel4); // dodecahedron

            _lightingShader.Use();

            if (_moveEnabled4)
            {
                _vectorSpeed4[0] += _velocityVector4[0] * _speed4 * deltaTime;
                _vectorSpeed4[1] += _velocityVector4[1] * _speed4 * deltaTime;
                _vectorSpeed4[2] += _velocityVector4[2] * _speed4 * deltaTime;
            }

            Matrix4 _angleMatrix4 = Matrix4.Identity * Matrix4.CreateRotationX(_angle4[0]) * Matrix4.CreateRotationY(_angle4[1]) * Matrix4.CreateRotationZ(_angle4[2]);
            var model4 = Matrix4.Identity * _scale4 * _angleMatrix4 * _coordinate4 * Matrix4.CreateTranslation(_vectorSpeed4[0], _vectorSpeed4[1], _vectorSpeed4[2]);

            if (!boundry.checkBorder(model4))
            {
                _point4 = movement.randomPoint();
                _velocityVector4 = movement.vectorVelocity(model4, _point4);
            }

            _lightingShader.SetMatrix4("model", model4);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", _color4);
            _lightingShader.SetVector3("lightColor", _colorReflection4);
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            if (_polygonalEnabled4)
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            else
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 108);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.BindVertexArray(_vaoModel5); // isocahedron

            _lightingShader.Use();

            if (_moveEnabled5)
            {
                _vectorSpeed5[0] += _velocityVector5[0] * _speed5 * deltaTime;
                _vectorSpeed5[1] += _velocityVector5[1] * _speed5 * deltaTime;
                _vectorSpeed5[2] += _velocityVector5[2] * _speed5 * deltaTime;
            }

            Matrix4 _angleMatrix5 = Matrix4.Identity * Matrix4.CreateRotationX(_angle5[0]) * Matrix4.CreateRotationY(_angle5[1]) * Matrix4.CreateRotationZ(_angle5[2]);
            var model5 = Matrix4.Identity * _scale5 * _angleMatrix5 * _coordinate5 * Matrix4.CreateTranslation(_vectorSpeed5[0], _vectorSpeed5[1], _vectorSpeed5[2]);

            if (!boundry.checkBorder(model5))
            {
                _point5 = movement.randomPoint();
                _velocityVector5 = movement.vectorVelocity(model5, _point5);
            }

            _lightingShader.SetMatrix4("model", model5);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", _color5);
            _lightingShader.SetVector3("lightColor", _colorReflection5);
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            if (_polygonalEnabled5)
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);
            else
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 60);

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.BindVertexArray(_vaoLamp);

            _lampShader.Use();

            Matrix4 lampMatrix = Matrix4.CreateScale(0.2f);
            lampMatrix = lampMatrix * Matrix4.CreateTranslation(_lightPos);

            _lampShader.SetMatrix4("model", lampMatrix);
            _lampShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lampShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.End();


            OpenTK.Input.KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Close();
            }

            const float cameraSpeed = 1.5f;
            const float sensitivity = 0.2f;


            _stopwatch.Restart();

            if (input.IsKeyDown(Key.W))
            {
                _camera.Position += _camera.Front * cameraSpeed * deltaTime; // Forward
            }
            if (input.IsKeyDown(Key.S))
            {
                _camera.Position -= _camera.Front * cameraSpeed * deltaTime; // Backwards
            }
            if (input.IsKeyDown(Key.A))
            {
                _camera.Position -= _camera.Right * cameraSpeed * deltaTime; // Left
            }
            if (input.IsKeyDown(Key.D))
            {
                _camera.Position += _camera.Right * cameraSpeed * deltaTime; // Right
            }
            if (input.IsKeyDown(Key.Space))
            {
                _camera.Position += _camera.Up * cameraSpeed * deltaTime; // Up
            }
            if (input.IsKeyDown(Key.ShiftLeft))
            {
                _camera.Position -= _camera.Up * cameraSpeed * deltaTime; // Down
            }

            OpenTK.Input.MouseState mouse = Mouse.GetState();

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                if (isFocused)
                {
                    var deltaX = mouse.X - _lastPos.X;
                    var deltaY = mouse.Y - _lastPos.Y;
                    _lastPos = new Vector2(mouse.X, mouse.Y);

                    _camera.Yaw += deltaX * sensitivity;
                    _camera.Pitch -= deltaY * sensitivity;
                }
            }

            glControl1.SwapBuffers();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Settings form2 = new Form_Settings(this);
            form2.Show();
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
        }

        private void Form1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
        }

        private void опрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_About form3 = new Form_About();
            form3.Show();
        }

        private void содержимоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Info form4 = new Form_Info();
            form4.Show();
        }
    }
}
