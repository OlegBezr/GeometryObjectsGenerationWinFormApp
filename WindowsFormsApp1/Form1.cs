using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<AbstractPrimitive> Primitives;
        Bitmap bmp;
        Graphics graph;
        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        SolidBrush redBrush = new SolidBrush(Color.Red);

        public Form1()
        {
            InitializeComponent();

            Primitives = new List<AbstractPrimitive>();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);

            button1.Click += Button1Click;
            button2.Click += DemostrateLibrary;
        }

        private void DemostrateLibrary(object sender, EventArgs e) 
        {
            SetupTheField((int)numericUpDown1.Value);
            CleanDrawings();
            ShowObjectsInfo(Primitives);
            ShowObjectsIntersectionInfo(Primitives);
            DrawObjects(Primitives);
            ApplyDrawings();
        }

        private void SetupTheField(int addObjects = 5) {
            Field field = new Field();
            Random rand = new Random();
            Vector3 randVector = new Vector3();

            //Определенное наполнение
            CubePrimitive obj = new CubePrimitive(new Vector3(50, 50, -10), 100);
            RectanglePrimitive obj3 = new RectanglePrimitive(new Vector3(40, 120, 0), 60, 200);

            field.AddObject(obj);
            field.AddObject(obj3);

            //Рандомное наполнение
            for (int i = 0; i < addObjects; i++) {
                int choice = rand.Next(2);

                AbstractPrimitive new_obj = null;

                if (choice == 1) {
                    new_obj = new CubePrimitive(randVector.random(200, 601, 200, 601, 0, 40, rand), rand.Next(60, 400));
                }
                else {
                    new_obj = new RectanglePrimitive(randVector.random(200, 601, 200, 601, 0, 40, rand), rand.Next(40, 400), rand.Next(40, 400));
                }

                field.AddObject(new_obj);
            }

            Primitives = field.Primitives;
        }

        private void ShowObjectsInfo(List<AbstractPrimitive> Primitives) {
            string text1 = "Number of objects: " + Primitives.Count + "\n\n";
            for (int i = 0; i < Primitives.Count; i++) {
                AbstractPrimitive primitive = Primitives[i];
                Vector3 pos = primitive.pos;
                //To escape from dividing by two all the dimensions  
                Vector3 hSize = primitive.size / 2;

                string objText = "";
                if (primitive is CubePrimitive) {
                    objText = "Obj_" + (i + 1) + ": CUBE \n";
                }
                else {
                    objText = "Obj_" + (i + 1) + ": RECT \n";
                }

                string coordsText = "->coords: " + pos.x + ", " + pos.y + ", " + pos.z + "; \n";
                string sizeText = "->size: " + hSize.x * 2 + ", " + hSize.y * 2 + ", " + hSize.z * 2 + "; \n";

                text1 += objText + coordsText + sizeText;
            }
            label1.Text = text1;
        }

        private void ShowObjectsIntersectionInfo(List<AbstractPrimitive> Primitives) {
            //Вывод информации о пересечении объектов
            string text2 = "All current intersections: \n\n";
            for (int i = 0; i < Primitives.Count; i++) {
                for (int j = i + 1; j < Primitives.Count; j++) {
                    AbstractPrimitive obj1 = Primitives[i];
                    AbstractPrimitive obj2 = Primitives[j];

                    if (obj1.CheckIntersection(obj2)) {
                        text2 += "Obj_" + (i + 1) + " intersects " + "Obj_" + (j + 1) + "\n";
                        DrawIntersection(obj1, obj2);
                    }
                }
            }
            label2.Text = text2;
        }

        private void DrawIntersection(AbstractPrimitive obj1, AbstractPrimitive obj2) {
            Vector2 pos1 = obj1.pos.toV2();
            Vector2 hSize1 = (obj1.size / 2).toV2();
            Vector2 pos2 = obj2.pos.toV2();
            Vector2 hSize2 = (obj2.size / 2).toV2();

            List<Vector2> dotes = new List<Vector2>();
            dotes.Add(new Vector2(Math.Min(pos1.x + hSize1.x, pos2.x + hSize2.x), Math.Min(pos1.y + hSize1.y, pos2.y + hSize2.y)));
            dotes.Add(new Vector2(Math.Min(pos1.x + hSize1.x, pos2.x + hSize2.x), Math.Max(pos1.y - hSize1.y, pos2.y - hSize2.y)));
            dotes.Add(new Vector2(Math.Max(pos1.x - hSize1.x, pos2.x - hSize2.x), Math.Min(pos1.y + hSize1.y, pos2.y + hSize2.y)));
            dotes.Add(new Vector2(Math.Max(pos1.x - hSize1.x, pos2.x - hSize2.x), Math.Max(pos1.y - hSize1.y, pos2.y - hSize2.y)));

            foreach (Vector2 dote in dotes) {
                graph.FillRectangle(redBrush, (float)(dote.x - 3), (float)(dote.y - 3), 6, 6);
            }
        }

        private void DrawObjects(List<AbstractPrimitive> Primitives) {
            Random rand = new Random();

            for (int i = 0; i < Primitives.Count; i++) {
                AbstractPrimitive primitive = Primitives[i];
                Vector3 pos = primitive.pos;
                //To escape from dividing by two all the dimensions 
                Vector3 hSize = primitive.size / 2;

                Color randomColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                Pen pen = new Pen(randomColor);

                graph.DrawRectangle(pen, (float)(pos.x - hSize.x), (float)(pos.y - hSize.y), (float)hSize.x * 2, (float)hSize.y * 2);
                graph.DrawString((i + 1).ToString(), drawFont, drawBrush, (float)(pos.x - hSize.x), (float)(pos.y - hSize.y));
            }
        }

        private void ApplyDrawings() {
            pictureBox1.Image = bmp;
        }

        private void CleanDrawings() {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graph = Graphics.FromImage(bmp);
        }

        private void MoveCubes(List<AbstractPrimitive> Primitives) {
            Random rand = new Random();

            for (int i = 0; i < Primitives.Count; i++) {
                if (Primitives[i] is CubePrimitive) {
                    CubePrimitive obj = (CubePrimitive)Primitives[i];
                    obj.Move(rand);
                    Primitives[i] = obj;
                }
            }
        }

        private void Button1Click(object sender, System.EventArgs e) {
            CleanDrawings();
            MoveCubes(Primitives);
            ShowObjectsInfo(Primitives);
            ShowObjectsIntersectionInfo(Primitives);
            DrawObjects(Primitives);
            ApplyDrawings();
        }
    }
}
