using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LearnOpenTK;
using OpenTK.Windowing.Desktop;
//using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using LearnOpenTK.Common;
using OpenTK.Input;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Diagnostics;

namespace GameWindowApp
{
    public partial class Form1 : Form
    {
        PlatonBodies.PlatonBodies pb = new PlatonBodies.PlatonBodies();

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

        private double _time;

        private Matrix4 _view;

        private Matrix4 _projection;

        bool forward = true;

        private Timer _timer = null!;
        private float _angle = 0.0f;

        private Timer _timer2 = null!;
        private Timer _timer3 = null!;

        float deltaTime = 0.0f;
        float lastFrame = 0.0f;

        private Stopwatch _stopwatch = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
            _stopwatch.Start();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            
            // Make sure that when the GLControl is resized or needs to be painted,
            // we update our projection matrix or re-render its contents, respectively.
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
                _angle += 0.5f;
                Render();
            };
            _timer.Interval = 17;   // 1000 ms per sec / 50 ms per frame = 20 FPS
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

            

            _timer2 = new Timer();
            _timer2.Tick += (sender, e) =>
            {
                if (forward)
                    _time += 8.5;
                if (!forward)
                    _time -= 8.5;
            };
            _timer2.Interval = 17;   // 1000 ms per sec / 50 ms per frame = 20 FPS
            _timer2.Start();

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(_vaoModel); // piramide

            _lightingShader.Use();
            var model = Matrix4.Identity * Matrix4.CreateTranslation((float)_time, 2.0f, 0);

            if (model.ExtractTranslation().X > 2.0f)
            {
                forward = false;
            }
            else if (model.ExtractTranslation().X < -2.0f)
            {
                forward = true;
            }


            //_lightingShader.SetMatrix4("model", Matrix4.Identity);
            _lightingShader.SetMatrix4("model", model);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", new Vector3(1.0f, 0.5f, 0.31f));
            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 18);

            GL.BindVertexArray(_vaoModel2); // octaedr

            _lightingShader.Use();

            _lightingShader.SetMatrix4("model", Matrix4.Identity * Matrix4.CreateTranslation(0, 1.0f, 0));
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            //_lightingShader.SetVector3("objectColor", new Vector3(0.4f, 0.6f, 0.31f));
            _lightingShader.SetVector3("objectColor", new Vector3(153.0f / 255.0f, 51f / 255f, 153f / 255f)); // Можно брать значения RGB 256
            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 24);

            GL.BindVertexArray(_vaoModel3); // cube

            _lightingShader.Use();

            _lightingShader.SetMatrix4("model", Matrix4.Identity);
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            //_lightingShader.SetVector3("objectColor", new Vector3(0.4f, 0.6f, 0.31f));
            _lightingShader.SetVector3("objectColor", new Vector3(51f / 255f, 153f / 255f, 255f / 255f));
            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            GL.BindVertexArray(_vaoModel4); // dodecahedron

            _lightingShader.Use();

            _lightingShader.SetMatrix4("model", Matrix4.Identity * Matrix4.CreateTranslation(-3.0f, -2.0f, 2.0f));
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            _lightingShader.SetVector3("objectColor", new Vector3(0.4f, 0.6f, 0.31f));
            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 108);

            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.BindVertexArray(_vaoModel5); // isocahedron

            _lightingShader.Use();

            _lightingShader.SetMatrix4("model", Matrix4.Identity * Matrix4.CreateTranslation(3.0f, -2.0f, 2.0f));
            _lightingShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lightingShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            //_lightingShader.SetVector3("objectColor", new Vector3(0.4f, 0.6f, 0.31f));
            _lightingShader.SetVector3("objectColor", new Vector3(173f / 255f, 173f / 255f, 173f / 255f));
            _lightingShader.SetVector3("lightColor", new Vector3(1.0f, 1.0f, 1.0f));
            _lightingShader.SetVector3("lightPos", _lightPos);
            _lightingShader.SetVector3("viewPos", _camera.Position);

            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);

            GL.DrawArrays(PrimitiveType.Triangles, 0, 60);

            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            GL.BindVertexArray(_vaoLamp);

            _lampShader.Use();

            Matrix4 lampMatrix = Matrix4.CreateScale(0.2f);
            lampMatrix = lampMatrix * Matrix4.CreateTranslation(_lightPos);

            _lampShader.SetMatrix4("model", lampMatrix);
            _lampShader.SetMatrix4("view", _camera.GetViewMatrix());
            _lampShader.SetMatrix4("projection", _camera.GetProjectionMatrix());

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);

            //SwapBuffers();

            GL.End();


            OpenTK.Input.KeyboardState input = Keyboard.GetState();

            if (input.IsKeyDown(Key.Escape))
            {
                Close();
            }

            const float cameraSpeed = 1.5f;
            const float sensitivity = 0.2f;
            //const float limiter = 0.001f;


            float deltaTime = (float)_stopwatch.ElapsedMilliseconds / 1000.0f;
            _stopwatch.Restart();
            //_timer3 = new Timer();
            //_timer3.Tick += (sender, e) =>
            //{
                
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
                //if (input.IsKeyDown((Key)Keys.LShiftKey))
                //{
                    //_camera.Position -= _camera.Up * cameraSpeed * (float)_timer3.Interval; // Down
                //}
            //};
            //_timer3.Interval = 17;   // 1000 ms per sec / 50 ms per frame = 20 FPS
            //_timer3.Start();

            

            //var mouse = MouseState;
            OpenTK.Input.MouseState mouse = Mouse.GetState();

            if (_firstMove)
            {
                _lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                var deltaX = mouse.X - _lastPos.X;
                var deltaY = mouse.Y - _lastPos.Y;
                _lastPos = new Vector2(mouse.X, mouse.Y);

                _camera.Yaw += deltaX * sensitivity;
                _camera.Pitch -= deltaY * sensitivity;
            }



                glControl1.SwapBuffers();
        }
    }
}
