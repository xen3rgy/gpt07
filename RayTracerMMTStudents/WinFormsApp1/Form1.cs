using CUAS.MMT;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {

        double fov = 90.0; //vertical field of view
        Vector lookFrom = new Vector(0, 0, 0);   // Point camera is looking from (its center)
        Vector lookAt = new Vector(0, 0, -1);  // Point camera is looking at

        Vector vUp = new Vector(0, 1, 0);     // Camera-relative "up" direction

        Bitmap canvas; //canvas for drawing

        int cWidth = 0; //canvas width
        int cHeight = 0; //canvas height

        List<RTObject> scene = new List<RTObject>();

        static RayTracer rt = new RayTracer();

        Stopwatch sw = new Stopwatch();

        double anim_angle = 0;

        RTObject selected = null; //currently selected object

        int save_counter = 0;

        public Form1()
        {

            InitializeComponent();


            //-------------------------------------------------------------------------------------------------------------------------------------------------------
            //create default scene
            scene.Clear();

            //scene.Add(new Sphere(new Vector(0, 0, -1), 0.5f, new Material(new Vector(1, 0, 0), 10))); //red, at the back of the camera
            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "Sphere";
            scene[scene.Count - 1].AMesh = new Sphere(scene[scene.Count - 1], new Vector(), 0.5f);
            scene[scene.Count - 1].Position = new Vector(0, 0, -1);
            //scene[scene.Count - 1].AMesh.Object = scene[scene.Count - 1];
            Material material_0 = new Material(scene[scene.Count - 1], new Vector(1, 0, 0), 10);
            //material_0.BaseMap = Utils.LoadImage("textures/checkerboard_red.bmp", ref material_0.BaseMapWidth, ref material_0.BaseMapHeight);
            //material_0.BaseMap = Utils.LoadImage("textures/640px-Equirectangular-projection.jpg",  ref material_0.BaseMapWidth, ref material_0.BaseMapHeight);
            material_0.BaseMap = Utils.LoadImage("textures/Teal-and-Gold-Marble-Texture-Wallpaper-for-Wall.jpg", ref material_0.BaseMapWidth, ref material_0.BaseMapHeight);
            //material_0.BaseMap = Utils.LoadImage("textures/fh_logo_512_no_alpha.bmp", ref material_0.BaseMapWidth, ref material_0.BaseMapHeight);

            material_0.Reflective = 0;
            scene[scene.Count - 1].AMaterial = material_0;



            //scene.Add(new Sphere(new Vector(-0.8, 0, -1.2), 0.5f, new Material(new Vector(0, 1, 0), 100))); //green
            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "Sphere";
            scene[scene.Count - 1].AMesh = new Sphere(scene[scene.Count - 1], new Vector(), 0.5f);
            scene[scene.Count - 1].Position = new Vector(-0.8, 0, -1.2);
            //scene[scene.Count - 1].AMesh.Object = scene[scene.Count - 1];
            Material material_1 = new Material(scene[scene.Count - 1], new Vector(0, 1, 0), 100);
            scene[scene.Count - 1].AMaterial = material_1;

            //scene.Add(new Sphere(new Vector(1, 0, -0.8), 0.5f, new Material(new Vector(0, 0, 1), 200))); //blue
            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "Sphere";
            scene[scene.Count - 1].AMesh = new Sphere(scene[scene.Count - 1], new Vector(), 0.5f);
            scene[scene.Count - 1].Position = new Vector(1, 0, -0.8);
            //scene[scene.Count - 1].AMesh.Object = scene[scene.Count - 1];
            Material material_2 = new Material(scene[scene.Count - 1], new Vector(0, 0, 1), 100);
            //material_2.BaseMap = Utils.LoadImage("textures/640px-Equirectangular-projection.jpg",  ref material_2.BaseMapWidth, ref material_2.BaseMapHeight);
            scene[scene.Count - 1].AMaterial = material_2;


            //scene.Add(new Sphere(new Vector(0, -5001, 0), 5000, new Material(new Vector(1, 1, 0)))); //yellow floor sphere
            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "Sphere";
            scene[scene.Count - 1].AMesh = new Sphere(scene[scene.Count - 1], new Vector(), 5000);
            scene[scene.Count - 1].Position = new Vector(0, -5001, 0);
            Material material_3 = new Material(scene[scene.Count - 1], new Vector(1, 1, 0), 100);
            //material_3.Reflective = 0;
            //material_3.BaseMap = Utils.LoadImage("textures/640px-Equirectangular-projection.jpg",  ref material_3.BaseMapWidth, ref material_3.BaseMapHeight);
            scene[scene.Count - 1].AMaterial = material_3;

            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "AmbientLight";
            scene[scene.Count - 1].ALight = new AmbientLight(scene[scene.Count - 1], 0.1, new Vector(1, 1, 1));
            scene[scene.Count - 1].Position = new Vector(0, 0, 0);

            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "PointLight";
            scene[scene.Count - 1].ALight = new PointLight(scene[scene.Count - 1], 0.5, new Vector(1, 1, 1));
            scene[scene.Count - 1].Position = new Vector(0, 1.5, 1);

            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "DirectionalLight";
            scene[scene.Count - 1].ALight = new DirectionalLight(scene[scene.Count - 1], 0.3, new Vector(1, 1, 1), new Vector(0, 4, 1));
            scene[scene.Count - 1].Position = new Vector(0, 0, -1);


            //populate tree view
            for (int i = 0; i < scene.Count; i++)
            {

                TreeNodeRT newNode = new TreeNodeRT(scene[i].Name, scene[i]);
                treeView1.Nodes.Add(newNode);

            }

            treeView1.SelectedNode = treeView1.Nodes[0];



            //-------------------------------------------------------------------------------------------------------------------------------------------------------
            //init ray tracer
            cWidth = pictureBox1.Size.Width;
            cHeight = pictureBox1.Size.Height;


            canvas = new Bitmap(cWidth, cHeight, PixelFormat.Format24bppRgb);


            textBox1.Text = "RayTracer MMT 0.01";

            Render();
            PostRender();


        }


        void PostRender()
        {

            pictureBox1.Image = canvas; //update vis.

            textBox1.Text = "Rendering and Display: " + sw.ElapsedMilliseconds.ToString() + " ms";

        }


        private void Render()
        {


            sw.Reset();
            sw.Start();

            rt.Init(cWidth, cHeight, lookFrom, lookAt, vUp, fov);

            rt.Render(scene);

            //byte[] buffer = rt.GetBuffer();

            //for (int y = 0; y < canvas.Height; y++)
            //{

            //    for (int x = 0; x < canvas.Width; x++)
            //    {

            //        canvas.SetPixel(x, y, Color.FromArgb(buffer[y * 3 * canvas.Width + 3 * x + 0], buffer[y * 3 * canvas.Width + 3 * x + 1], buffer[y * 3 * canvas.Width + 3 * x + 2]));

            //    }

            //}

            BitmapData bmpData = canvas.LockBits(new Rectangle(0, 0, canvas.Width, canvas.Height), ImageLockMode.WriteOnly, canvas.PixelFormat);

            //Copy the data from the byte array into BitmapData.Scan0
            Marshal.Copy(rt.GetBuffer(), 0, bmpData.Scan0, rt.GetBuffer().Length);

            canvas.UnlockBits(bmpData);

            sw.Stop();

        }


        //render button
        private void button1_Click(object sender, EventArgs e) //render button
        {

            //check input fields and update the renderer

            double inputFoV = 0;
            if (Utils.ParseStringDouble(textBoxFoV.Text, ref inputFoV))
            {
                fov = inputFoV;
            }

            textBoxFoV.Text = fov.ToString();


            Vector inputvUp = new Vector();

            if (Utils.ParseStringVector(textBoxLookUp.Text, ref inputvUp))
            {

                vUp = inputvUp;
            }

            textBoxLookUp.Text = vUp.X.ToString() + ' ' + vUp.Y.ToString() + ' ' + vUp.Z.ToString();


            Vector inputLookAt = new Vector();

            if (Utils.ParseStringVector(textBoxLookAt.Text, ref inputLookAt))
            {

                lookAt = inputLookAt;
            }

            textBoxLookAt.Text = lookAt.X.ToString() + ' ' + lookAt.Y.ToString() + ' ' + lookAt.Z.ToString();


            Vector inputLookFrom = new Vector();

            if (Utils.ParseStringVector(textBoxLookFrom.Text, ref inputLookFrom))
            {

                lookFrom = inputLookFrom;

            }

            textBoxLookFrom.Text = lookFrom.X.ToString() + ' ' + lookFrom.Y.ToString() + ' ' + lookFrom.Z.ToString();


            if (selected != null)
            {

                selected.Name = textBoxName.Text;

                Vector inputScale = new Vector();

                if (Utils.ParseStringVector(textBoxScale.Text, ref inputScale))
                {

                    selected.Scale = inputScale;

                }

                textBoxScale.Text = selected.Scale.X.ToString() + ' ' + selected.Scale.Y.ToString() + ' ' + selected.Scale.Z.ToString();


                Vector inputRotation = new Vector();

                if (Utils.ParseStringVector(textBoxPosition.Text, ref inputRotation))
                {

                    selected.Rotation = inputRotation;

                }

                textBoxRotation.Text = selected.Rotation.X.ToString() + ' ' + selected.Rotation.Y.ToString() + ' ' + selected.Rotation.Z.ToString();


                Vector inputPosition = new Vector();

                if (Utils.ParseStringVector(textBoxPosition.Text, ref inputPosition))
                {

                    selected.Position = inputPosition;

                }

                textBoxPosition.Text = selected.Position.X.ToString() + ' ' + selected.Position.Y.ToString() + ' ' + selected.Position.Z.ToString();



                var sphere = selected.AMesh as Sphere;
                if (sphere != null)
                {

                    double inputRadius = 0;
                    if (Utils.ParseStringDouble(textBoxRadius.Text, ref inputRadius))
                    {
                        sphere.Radius = inputRadius;
                    }

                }



                if (selected.AMaterial != null)
                {
                    Vector inputColor = new Vector();
                    if (Utils.ParseStringVector(textBoxColor.Text, ref inputColor))
                    {

                        /*selected.AMaterial?.SetColor(inputColor)*/;
                        selected.AMaterial.Color = inputColor;

                    }

                    double inputSpecular = 0;
                    if (Utils.ParseStringDouble(textBoxSpecular.Text, ref inputSpecular))
                    {
                        //selected.AMaterial?.SetSpecular(inputSpecular);
                        selected.AMaterial.Specular = inputSpecular;
                    }

                    double inputReflective = 0;
                    if (Utils.ParseStringDouble(textBoxReflective.Text, ref inputReflective))
                    {
                        //selected.AMaterial?.SetSpecular(inputSpecular);
                        selected.AMaterial.Reflective = inputReflective;
                    }

                }


                if (selected.ALight != null)
                {

                    Vector inputColor = new Vector();
                    if (Utils.ParseStringVector(textBoxLightColor.Text, ref inputColor))
                    {
                        selected.ALight.Color = inputColor;
                    }


                    double inputIntensity = 0;
                    if (Utils.ParseStringDouble(textBoxLightIntensity.Text, ref inputIntensity))
                    {
                        selected.ALight.Intensity = inputIntensity;
                    }



                    var light = selected.ALight as DirectionalLight;
                    if (light != null)
                    {

                        Vector inputDirection = new Vector();
                        if (Utils.ParseStringVector(textBoxLightDirection.Text, ref inputDirection))
                        {
                            light.Direction = inputDirection;
                        }

                    }


                }

            }

            Render();
            PostRender();

        }


        void UpdateSelectionVis()
        {

            if (selected != null)
            {

                //textBox1.Text = "Object: " + selected.Position.ToString();

                textBoxName.Text = selected.Name;
                textBoxPosition.Text = selected.Position.X.ToString() + ' ' + selected.Position.Y.ToString() + ' ' + selected.Position.Z.ToString();
                textBoxRotation.Text = selected.Rotation.X.ToString() + ' ' + selected.Rotation.Y.ToString() + ' ' + selected.Rotation.Z.ToString();
                textBoxScale.Text = selected.Scale.X.ToString() + ' ' + selected.Scale.Y.ToString() + ' ' + selected.Scale.Z.ToString();

                var sphere = selected.AMesh as Sphere;
                if (sphere != null)
                {
                    textBoxRadius.Text = sphere.Radius.ToString();
                }
                else
                {
                    textBoxRadius.Text = "";
                }


                if (selected.AMaterial != null)
                {
                    textBoxColor.Visible = true;
                    textBoxSpecular.Visible = true;

                    textBoxColor.Text = selected.AMaterial?.Color.X.ToString() + ' ' + selected.AMaterial?.Color.Y.ToString() + ' ' + selected.AMaterial?.Color.Z.ToString();
                    textBoxSpecular.Text = selected.AMaterial?.Specular.ToString();
                    textBoxReflective.Text = selected.AMaterial?.Reflective.ToString();
                }
                else
                {
                    textBoxColor.Visible = false;
                    textBoxSpecular.Visible = false;

                }

                if (selected.ALight != null)
                {
                    textBoxLightColor.Visible = true;
                    textBoxLightIntensity.Visible = true;
                    textBoxLightDirection.Visible = false;

                    textBoxLightColor.Text = selected.ALight?.Color.X.ToString() + ' ' + selected.ALight?.Color.Y.ToString() + ' ' + selected.ALight?.Color.Z.ToString();
                    textBoxLightIntensity.Text = selected.ALight?.Intensity.ToString();
       
                    var dr = selected.ALight as DirectionalLight;
                    if (dr != null)
                    {
                        textBoxLightDirection.Visible = true;
                        textBoxLightDirection.Text = dr.Direction.X.ToString() + ' ' + dr.Direction.Y.ToString() + ' ' + dr.Direction.Z.ToString();

                    }

                }
                else
                {
                    textBoxLightColor.Visible = false;
                    textBoxLightIntensity.Visible = false;
                    textBoxLightDirection.Visible = false;

                }


            }

        }


        //click on picture box
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Point mousePointerLocation = e.Location;
            //textBox1.Text = "Clicked: " + e.Location.ToString();

            selected = rt.GetObject(scene, e.Location);


            UpdateSelectionVis();

        }


        //object selection using tree view
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            //textBox1.Text = "treeView1_AfterSelect";

            textBoxLookUp.Text = vUp.X.ToString() + ' ' + vUp.Y.ToString() + ' ' + vUp.Z.ToString();
            textBoxLookAt.Text = lookAt.X.ToString() + ' ' + lookAt.Y.ToString() + ' ' + lookAt.Z.ToString();
            textBoxLookFrom.Text = lookFrom.X.ToString() + ' ' + lookFrom.Y.ToString() + ' ' + lookFrom.Z.ToString();

            textBoxFoV.Text =fov.ToString();


            TreeNodeRT node = (TreeNodeRT)e.Node;
            selected = node.Obj;

            UpdateSelectionVis();

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fn = "canvas_" + save_counter.ToString() + ".bmp";

            pictureBox1.Image.Save(fn, System.Drawing.Imaging.ImageFormat.Jpeg);

            textBox1.Text = "Saved rendering to file: " + fn;

            save_counter++;
        }


        private void AddSphere()
        {

            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "Sphere";
            scene[scene.Count - 1].AMesh = new Sphere(scene[scene.Count - 1], new Vector(), 0.5f);
            scene[scene.Count - 1].Position = new Vector(0, 0, -1);
            Material material_0 = new Material(scene[scene.Count - 1], new Vector(1, 1, 1), 10);
            scene[scene.Count - 1].AMaterial = material_0;

            TreeNodeRT newNode = new TreeNodeRT(scene[scene.Count - 1].Name, scene[scene.Count - 1]);
            treeView1.Nodes.Add(newNode);

            treeView1.SelectedNode = treeView1.Nodes[0];

            TreeNodeRT node = (TreeNodeRT)newNode;
            selected = node.Obj;

            UpdateSelectionVis();
            
            Render();
            PostRender();

        }


        private void AddLightSourcePoint()
        {

            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "PointLight";
            scene[scene.Count - 1].ALight = new PointLight(scene[scene.Count - 1], 0.5, new Vector(1, 1, 1));
            scene[scene.Count - 1].Position = new Vector(0, 0, -1);

            TreeNodeRT newNode = new TreeNodeRT(scene[scene.Count - 1].Name, scene[scene.Count - 1]);
            treeView1.Nodes.Add(newNode);

            treeView1.SelectedNode = treeView1.Nodes[0];

            TreeNodeRT node = (TreeNodeRT)newNode;
            selected = node.Obj;

            UpdateSelectionVis();
            
            Render();
            PostRender();


        }


        private void AddLightSourceDirectional()
        {

            scene.Add(new RTObject());
            scene[scene.Count - 1].Name = "DirectionalLight";
            scene[scene.Count - 1].ALight = new DirectionalLight(scene[scene.Count - 1], 0.3, new Vector(0, 0, 1), new Vector(0, 0, 1));
            scene[scene.Count - 1].Position = new Vector(0, 0, -1);

            TreeNodeRT newNode = new TreeNodeRT(scene[scene.Count - 1].Name, scene[scene.Count - 1]);
            treeView1.Nodes.Add(newNode);

            treeView1.SelectedNode = treeView1.Nodes[0];

            TreeNodeRT node = (TreeNodeRT)newNode;
            selected = node.Obj;

            UpdateSelectionVis();
            
            
            Render();

            PostRender();

        }


        private void DeleteObject()
        {

            if (selected != null)
            {

                for (int i = 0; i < treeView1.Nodes.Count; i++)
                {
                    var node = treeView1.Nodes[i] as TreeNodeRT;

                    if (node.Obj == selected)
                    {

                        scene.Remove(selected);
                        selected = null;
                        treeView1.Nodes.Remove(treeView1.Nodes[i]);


                        if (scene.Count > 0)
                        {

                            treeView1.SelectedNode = treeView1.Nodes[0];

                            var tmp = (treeView1.SelectedNode as TreeNodeRT);
                            selected = tmp.Obj;

                        }
                        UpdateSelectionVis();
                        
                        Render();
                        PostRender();

                        break;

                    }

                }

            }

        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DeleteObject();

        }


        private void sphereToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddSphere();

        }


        private void pointToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddLightSourcePoint();

        }


        private void directionalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            AddLightSourceDirectional();

        }

    }

}
