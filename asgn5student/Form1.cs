using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace asgn5v1
{
    /// <summary>
    /// Summary description for Transformer.
    /// </summary>
    public class Transformer : System.Windows.Forms.Form
    {
        private System.ComponentModel.IContainer components;
        //private bool GetNewData();

        // basic data for Transformer

        int numpts = 0;
        int numlines = 0;
        bool gooddata = false;
        double[,] vertices;
        double[,] scrnpts;
        double[,] ctrans = new double[4, 4];  //your main transformation matrix
        private System.Windows.Forms.ImageList tbimages;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.ToolBarButton transleftbtn;
        private System.Windows.Forms.ToolBarButton transrightbtn;
        private System.Windows.Forms.ToolBarButton transupbtn;
        private System.Windows.Forms.ToolBarButton transdownbtn;
        private System.Windows.Forms.ToolBarButton toolBarButton1;
        private System.Windows.Forms.ToolBarButton scaleupbtn;
        private System.Windows.Forms.ToolBarButton scaledownbtn;
        private System.Windows.Forms.ToolBarButton toolBarButton2;
        private System.Windows.Forms.ToolBarButton rotxby1btn;
        private System.Windows.Forms.ToolBarButton rotyby1btn;
        private System.Windows.Forms.ToolBarButton rotzby1btn;
        private System.Windows.Forms.ToolBarButton toolBarButton3;
        private System.Windows.Forms.ToolBarButton rotxbtn;
        private System.Windows.Forms.ToolBarButton rotybtn;
        private System.Windows.Forms.ToolBarButton rotzbtn;
        private System.Windows.Forms.ToolBarButton toolBarButton4;
        private System.Windows.Forms.ToolBarButton shearrightbtn;
        private System.Windows.Forms.ToolBarButton shearleftbtn;
        private System.Windows.Forms.ToolBarButton toolBarButton5;
        private System.Windows.Forms.ToolBarButton resetbtn;
        private System.Windows.Forms.ToolBarButton exitbtn;
        int[,] lines;
        double[] center;
        double[] origcenter = new double[3];
        double[,] origtrans = new double[4, 4];
        public Transformer()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            Text = "COMP 4560:  Assignment 5 (200830) (Your Name Here)";
            ResizeRedraw = true;
            BackColor = Color.Black;
            MenuItem miNewDat = new MenuItem("New &Data...",
                new EventHandler(MenuNewDataOnClick));
            MenuItem miExit = new MenuItem("E&xit",
                new EventHandler(MenuFileExitOnClick));
            MenuItem miDash = new MenuItem("-");
            MenuItem miFile = new MenuItem("&File",
                new MenuItem[] { miNewDat, miDash, miExit });
            MenuItem miAbout = new MenuItem("&About",
                new EventHandler(MenuAboutOnClick));
            Menu = new MainMenu(new MenuItem[] { miFile, miAbout });


        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transformer));
            this.tbimages = new System.Windows.Forms.ImageList(this.components);
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.transleftbtn = new System.Windows.Forms.ToolBarButton();
            this.transrightbtn = new System.Windows.Forms.ToolBarButton();
            this.transupbtn = new System.Windows.Forms.ToolBarButton();
            this.transdownbtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.scaleupbtn = new System.Windows.Forms.ToolBarButton();
            this.scaledownbtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.rotxby1btn = new System.Windows.Forms.ToolBarButton();
            this.rotyby1btn = new System.Windows.Forms.ToolBarButton();
            this.rotzby1btn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.rotxbtn = new System.Windows.Forms.ToolBarButton();
            this.rotybtn = new System.Windows.Forms.ToolBarButton();
            this.rotzbtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
            this.shearrightbtn = new System.Windows.Forms.ToolBarButton();
            this.shearleftbtn = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
            this.resetbtn = new System.Windows.Forms.ToolBarButton();
            this.exitbtn = new System.Windows.Forms.ToolBarButton();
            this.SuspendLayout();
            // 
            // tbimages
            // 
            this.tbimages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tbimages.ImageStream")));
            this.tbimages.TransparentColor = System.Drawing.Color.Transparent;
            this.tbimages.Images.SetKeyName(0, "");
            this.tbimages.Images.SetKeyName(1, "");
            this.tbimages.Images.SetKeyName(2, "");
            this.tbimages.Images.SetKeyName(3, "");
            this.tbimages.Images.SetKeyName(4, "");
            this.tbimages.Images.SetKeyName(5, "");
            this.tbimages.Images.SetKeyName(6, "");
            this.tbimages.Images.SetKeyName(7, "");
            this.tbimages.Images.SetKeyName(8, "");
            this.tbimages.Images.SetKeyName(9, "");
            this.tbimages.Images.SetKeyName(10, "");
            this.tbimages.Images.SetKeyName(11, "");
            this.tbimages.Images.SetKeyName(12, "");
            this.tbimages.Images.SetKeyName(13, "");
            this.tbimages.Images.SetKeyName(14, "");
            this.tbimages.Images.SetKeyName(15, "");
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.transleftbtn,
            this.transrightbtn,
            this.transupbtn,
            this.transdownbtn,
            this.toolBarButton1,
            this.scaleupbtn,
            this.scaledownbtn,
            this.toolBarButton2,
            this.rotxby1btn,
            this.rotyby1btn,
            this.rotzby1btn,
            this.toolBarButton3,
            this.rotxbtn,
            this.rotybtn,
            this.rotzbtn,
            this.toolBarButton4,
            this.shearrightbtn,
            this.shearleftbtn,
            this.toolBarButton5,
            this.resetbtn,
            this.exitbtn});
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.tbimages;
            this.toolBar1.Location = new System.Drawing.Point(484, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(24, 306);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // transleftbtn
            // 
            this.transleftbtn.ImageIndex = 1;
            this.transleftbtn.Name = "transleftbtn";
            this.transleftbtn.ToolTipText = "translate left";
            // 
            // transrightbtn
            // 
            this.transrightbtn.ImageIndex = 0;
            this.transrightbtn.Name = "transrightbtn";
            this.transrightbtn.ToolTipText = "translate right";
            // 
            // transupbtn
            // 
            this.transupbtn.ImageIndex = 2;
            this.transupbtn.Name = "transupbtn";
            this.transupbtn.ToolTipText = "translate up";
            // 
            // transdownbtn
            // 
            this.transdownbtn.ImageIndex = 3;
            this.transdownbtn.Name = "transdownbtn";
            this.transdownbtn.ToolTipText = "translate down";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // scaleupbtn
            // 
            this.scaleupbtn.ImageIndex = 4;
            this.scaleupbtn.Name = "scaleupbtn";
            this.scaleupbtn.ToolTipText = "scale up";
            // 
            // scaledownbtn
            // 
            this.scaledownbtn.ImageIndex = 5;
            this.scaledownbtn.Name = "scaledownbtn";
            this.scaledownbtn.ToolTipText = "scale down";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // rotxby1btn
            // 
            this.rotxby1btn.ImageIndex = 6;
            this.rotxby1btn.Name = "rotxby1btn";
            this.rotxby1btn.ToolTipText = "rotate about x by 1";
            // 
            // rotyby1btn
            // 
            this.rotyby1btn.ImageIndex = 7;
            this.rotyby1btn.Name = "rotyby1btn";
            this.rotyby1btn.ToolTipText = "rotate about y by 1";
            // 
            // rotzby1btn
            // 
            this.rotzby1btn.ImageIndex = 8;
            this.rotzby1btn.Name = "rotzby1btn";
            this.rotzby1btn.ToolTipText = "rotate about z by 1";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // rotxbtn
            // 
            this.rotxbtn.ImageIndex = 9;
            this.rotxbtn.Name = "rotxbtn";
            this.rotxbtn.ToolTipText = "rotate about x continuously";
            // 
            // rotybtn
            // 
            this.rotybtn.ImageIndex = 10;
            this.rotybtn.Name = "rotybtn";
            this.rotybtn.ToolTipText = "rotate about y continuously";
            // 
            // rotzbtn
            // 
            this.rotzbtn.ImageIndex = 11;
            this.rotzbtn.Name = "rotzbtn";
            this.rotzbtn.ToolTipText = "rotate about z continuously";
            // 
            // toolBarButton4
            // 
            this.toolBarButton4.Name = "toolBarButton4";
            this.toolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // shearrightbtn
            // 
            this.shearrightbtn.ImageIndex = 12;
            this.shearrightbtn.Name = "shearrightbtn";
            this.shearrightbtn.ToolTipText = "shear right";
            // 
            // shearleftbtn
            // 
            this.shearleftbtn.ImageIndex = 13;
            this.shearleftbtn.Name = "shearleftbtn";
            this.shearleftbtn.ToolTipText = "shear left";
            // 
            // toolBarButton5
            // 
            this.toolBarButton5.Name = "toolBarButton5";
            this.toolBarButton5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // resetbtn
            // 
            this.resetbtn.ImageIndex = 14;
            this.resetbtn.Name = "resetbtn";
            this.resetbtn.ToolTipText = "restore the initial image";
            // 
            // exitbtn
            // 
            this.exitbtn.ImageIndex = 15;
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.ToolTipText = "exit the program";
            // 
            // Transformer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(508, 306);
            this.Controls.Add(this.toolBar1);
            this.Name = "Transformer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Transformer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Transformer());
        }

        protected override void OnPaint(PaintEventArgs pea)
        {
            Graphics grfx = pea.Graphics;
            Pen pen = new Pen(Color.White, 3);
            double temp;
            int k;

            if (gooddata)
            {
                //create the screen coordinates:
                // scrnpts = vertices*ctrans

                for (int i = 0; i < numpts; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        temp = 0.0d;
                        for (k = 0; k < 4; k++)
                        {
                            temp += vertices[i, k] * ctrans[k, j];
                            //Debug.Write(vertices[i, k] + " " + ctrans[k, j] + "\n");
                        }
                        scrnpts[i, j] = temp;
                    }
                    //Debug.Write("\n");
                }

                //now draw the lines

                for (int i = 0; i < numlines; i++)
                {
                    grfx.DrawLine(pen,
                        (int)scrnpts[lines[i, 0], 0],
                        (int)scrnpts[lines[i, 0], 1],
                        (int)scrnpts[lines[i, 1], 0],
                        (int)scrnpts[lines[i, 1], 1]);
                }
            } // end of gooddata block	
        } // end of OnPaint

        void MenuNewDataOnClick(object obj, EventArgs ea)
        {
            //MessageBox.Show("New Data item clicked.");
            gooddata = GetNewData();
            RestoreInitialImage();
        }

        void MenuFileExitOnClick(object obj, EventArgs ea)
        {
            Close();
        }

        void MenuAboutOnClick(object obj, EventArgs ea)
        {
            AboutDialogBox dlg = new AboutDialogBox();
            dlg.ShowDialog();
        }

        void RestoreInitialImage()
        {
            Invalidate();
            ctrans = origtrans;
            center[0] = origcenter[0];
            center[1] = origcenter[1];
            center[2] = origcenter[2];
        } // end of RestoreInitialImage

        bool GetNewData()
        {
            string strinputfile, text;
            ArrayList coorddata = new ArrayList();
            ArrayList linesdata = new ArrayList();
            OpenFileDialog opendlg = new OpenFileDialog();
            opendlg.Title = "Choose File with Coordinates of Vertices";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                strinputfile = opendlg.FileName;
                FileInfo coordfile = new FileInfo(strinputfile);
                StreamReader reader = coordfile.OpenText();
                do
                {
                    text = reader.ReadLine();
                    //MessageBox.Show(text);
                    if (text != null) coorddata.Add(text);
                } while (text != null);
                reader.Close();
                DecodeCoords(coorddata);
            }
            else
            {
                MessageBox.Show("***Failed to Open Coordinates File***");
                return false;
            }

            opendlg.Title = "Choose File with Data Specifying Lines";
            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                strinputfile = opendlg.FileName;
                FileInfo linesfile = new FileInfo(strinputfile);
                StreamReader reader = linesfile.OpenText();
                do
                {
                    text = reader.ReadLine();
                    if (text != null) linesdata.Add(text);
                } while (text != null);
                reader.Close();
                DecodeLines(linesdata);
            }
            else
            {
                MessageBox.Show("***Failed to Open Line Data File***");
                return false;
            }
            scrnpts = new double[numpts, 4];
            setIdentity();  //initialize transformation matrix to identity
            return true;
        } // end of GetNewData

        void DecodeCoords(ArrayList coorddata)
        {
            //this may allocate slightly more rows that necessary
            vertices = new double[coorddata.Count, 4];
            numpts = 0;
            string[] text = null;
            for (int i = 0; i < coorddata.Count; i++)
            {
                text = coorddata[i].ToString().Split(' ', ',');
                vertices[numpts, 0] = double.Parse(text[0]);
                if (vertices[numpts, 0] < 0.0d) break;
                vertices[numpts, 1] = double.Parse(text[1]);
                vertices[numpts, 2] = double.Parse(text[2]);
                vertices[numpts, 3] = 1.0d;
                numpts++;
            }

        }// end of DecodeCoords

        void DecodeLines(ArrayList linesdata)
        {
            //this may allocate slightly more rows that necessary
            lines = new int[linesdata.Count, 2];
            numlines = 0;
            string[] text = null;
            for (int i = 0; i < linesdata.Count; i++)
            {
                text = linesdata[i].ToString().Split(' ', ',');
                lines[numlines, 0] = int.Parse(text[0]);
                if (lines[numlines, 0] < 0) break;
                lines[numlines, 1] = int.Parse(text[1]);
                numlines++;
            }
        } // end of DecodeLines

        void setIdentity()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    ctrans[i, j] = 0.0d;
                }
                ctrans[i, i] = 1.0d;
            }

            double height = Height / 2;
            double width = Width / 2;

            MinMax minMax = findMinMax(vertices);
            center = FindCenter(minMax);

            translate(-center[0], -center[1], -center[2]);

            double shapeWidth = minMax.maxX - minMax.minX;
            double shapeHeight = minMax.maxY - minMax.minY;
            double shapeDepth = minMax.maxZ - minMax.minZ;
            double ratio = height / shapeHeight;

            scale(ratio, ratio, ratio);

            translate(width, height, 0);
            origtrans = ctrans;

            origcenter[0] = center[0];
            origcenter[1] = center[1];
            origcenter[2] = center[2];
        }// end of setIdentity

        private void translate(double x, double y, double z)
        {
            double[,] translate =
                {
                    { 1,0,0,0},
                    { 0,1,0,0},
                    { 0,0,1,0},
                    { x,y,z,1}
                };

            center[0] += x;
            center[1] += y;
            center[2] += z;

            ctrans = matrixMultiplication(ctrans, translate, 4, 4);
        }

        private void scale(double scaleX, double scaleY, double scaleZ)
        {
            double[,] scale =
            {
                    { scaleX,0,0,0},
                    { 0,scaleY,0,0},
                    { 0,0,scaleZ,0},
                    { 0,0,0,1}
            };
            ctrans = matrixMultiplication(ctrans, scale, 4, 4);
        }

        private void RotateX(double rotateX)
        {
            double[,] rotation =
            {
                    { 1,0,0,0},
                    { 0,Math.Cos(rotateX),Math.Sin(rotateX),0},
                    { 0,-Math.Sin(rotateX),Math.Cos(rotateX),0},
                    { 0,0,0,1}
            };
            ctrans = matrixMultiplication(ctrans, rotation, 4, 4);
        }
        private void RotateY(double rotateY)
        {
            double[,] scale =
            {
                    { Math.Cos(rotateY),0,-Math.Sin(rotateY),0},
                    { 0,1,0,0},
                    { Math.Sin(rotateY),0,Math.Cos(rotateY),0},
                    { 0,0,0,1}
            };
            ctrans = matrixMultiplication(ctrans, scale, 4, 4);
        }
        private void RotateZ(double rotateZ)
        {
            double[,] scale =
            {
                    { Math.Cos(rotateZ),Math.Sin(rotateZ),0,0},
                    { -Math.Sin(rotateZ),Math.Cos(rotateZ),0,0},
                    { 0,0,0,0},
                    { 0,0,0,1}
            };
            ctrans = matrixMultiplication(ctrans, scale, 4, 4);
        }

        private void Shear(double shxy)
        {
            double[,] scale =
            {
                    { 1,shxy,0,0},
                    { 0,1,0,0},
                    { 0,0,1,0},
                    { 0,0,0,1}
            };
            ctrans = matrixMultiplication(ctrans, scale, 4, 4);
        }
        private double[] FindCenter(MinMax minMax)
        {

            double centerX = (minMax.minX + minMax.maxX) / 2;
            double centerY = (minMax.minY + minMax.maxY) / 2;
            double centerZ = (minMax.minZ + minMax.maxZ) / 2;
            double[] array = { centerX, centerY, centerZ };
            return array;
        }

        private MinMax findMinMax(double[,] V)
        {
            MinMax output = new MinMax();

            for (int i = 0; i < numpts; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (j == 0)
                    {
                        if (V[i, j] > output.maxX)
                        {
                            output.maxX = V[i, j];
                        }
                        if (V[i, j] < output.minX)
                        {
                            output.minX = V[i, j];
                        }
                    }
                    else if (j == 1)
                    {
                        if (V[i, j] > output.maxY)
                        {
                            output.maxY = V[i, j];
                        }
                        if (V[i, j] < output.minY)
                        {
                            output.minY = V[i, j];
                        }
                    }
                    else if (j == 2)
                    {
                        if (V[i, j] > output.maxZ)
                        {
                            output.maxZ = V[i, j];
                        }
                        if (V[i, j] < output.minZ)
                        {
                            output.minZ = V[i, j];
                        }
                    }
                }
            }

            return output;
        }


        private double[,] matrixMultiplication(double[,] matrix1, double[,] matrix2, int nrow, int ncol)
        {
            double temp;
            double[,] resultMatrix = new double[4, 4];
            for (int i = 0; i < nrow; i++)
            {
                for (int j = 0; j < ncol; j++)
                {
                    temp = 0.0d;
                    for (int k = 0; k < 4; k++)
                    {
                        temp += matrix1[i, k] * matrix2[k, j];
                        Debug.Write(matrix1[i, k] + " " + matrix2[k, j] + " \n");
                    }
                    resultMatrix[i, j] = temp;
                    //  Debug.Write(temp + " ");
                }
                Debug.Write("\n");
            }
            Debug.Write("\n");
            return resultMatrix;
        }

        private void Transformer_Load(object sender, System.EventArgs e)
        {

        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            if (e.Button == transleftbtn)
            {
                translate(-75, 0, 0);
                Refresh();
            }
            if (e.Button == transrightbtn)
            {
                translate(75, 0, 0);
                Refresh();
            }
            if (e.Button == transupbtn)
            {
                translate(0, -35, 0);
                Refresh();
            }

            if (e.Button == transdownbtn)
            {
                translate(0, 35, 0);
                Refresh();
            }
            if (e.Button == scaleupbtn)
            {
                double[] currentCenter = { center[0], center[1], center[2] };
                translate(-center[0], -center[1], -center[2]);
                scale(1.1, 1.1, 1.1);
                translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                Refresh();
            }
            if (e.Button == scaledownbtn)
            {
                double[] currentCenter = { center[0], center[1], center[2] };
                translate(-center[0], -center[1], -center[2]);
                scale(0.9, 0.9, 0.9);
                translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                Refresh();
            }
            if (e.Button == rotxby1btn)
            {
                double[] currentCenter = { center[0], center[1], center[2] };
                translate(-center[0], -center[1], -center[2]);
                RotateX(0.05);
                translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                Refresh();
            }
            if (e.Button == rotyby1btn)
            {
                double[] currentCenter = { center[0], center[1], center[2] };
                translate(-center[0], -center[1], -center[2]);
                RotateY(0.05);
                translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                Refresh();
            }
            if (e.Button == rotzby1btn)
            {
                double[] currentCenter = { center[0], center[1], center[2] };
                translate(-center[0], -center[1], -center[2]);
                RotateZ(0.05);
                translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                Refresh();
            }

            if (e.Button == rotxbtn)
            {

                while (true)
                {
                    double[] currentCenter = { center[0], center[1], center[2] };
                    translate(-center[0], -center[1], -center[2]);
                    RotateX(0.05);
                    translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                    Refresh();
                }
            }
            if (e.Button == rotybtn)
            {
                while (true)
                {
                    double[] currentCenter = { center[0], center[1], center[2] };
                    translate(-center[0], -center[1], -center[2]);
                    RotateY(0.05);
                    translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                    Refresh();
                }
            }

            if (e.Button == rotzbtn)
            {
                while (true)
                {
                    double[] currentCenter = { center[0], center[1], center[2] };
                    translate(-center[0], -center[1], -center[2]);
                    RotateZ(0.05);
                    translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                    Refresh();
                }
            }

            if (e.Button == shearleftbtn)
            {

                double[] currentCenter = { center[0], center[1], center[2] };
                translate(-center[0], -center[1], -center[2]);

                Shear(-0.1);
                translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                Refresh();
                Refresh();
            }

            if (e.Button == shearrightbtn)
            {

                double[] currentCenter = { center[0], center[1], center[2] };
                translate(-center[0], -center[1], -center[2]);

                Shear(0.1);
                translate(currentCenter[0], currentCenter[1], currentCenter[2]);
                Refresh();
                Refresh();
            }

            if (e.Button == resetbtn)
            {
                RestoreInitialImage();
            }

            if (e.Button == exitbtn)
            {
                Close();
            }
        }
    }
}
