using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SkiaSharp;
using System.IO;
using System.Threading;

namespace GirbalPathfinding
{
    public partial class Form1 : Form
    {
        private MapRenderer mapRenderer;

        private ExecutiveController executiveController;

        private const int mapHeight = 50;
        private const int mapWidth = 100;

        private bool loopMovementFlag = false;

        //SETUP SYSTEM
        public Form1()
        {
            InitializeComponent();
            //Change here to required algorithm
            executiveController = new ExecutiveController(300);
            executiveController.initialisePlanner<ExampleAStar>();
            //

            mapRenderer = new MapRenderer();
            //this.WindowState = FormWindowState.Maximized;
            var rand = new Random();

            for (int i = 1; i < mapWidth - 1; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (rand.Next() % 30 == 1)
                    {
                        executiveController.staticObstacles.Add(new StaticObstacle(i, j));
                    }

                    //if (i == 10 && j > 10 && j < mapHeight - 10)
                    //{
                    //    executiveController.staticObstacles.Add(new StaticObstacle(i, j));
                    //}
                }
            }

            //executiveController.dynamicObstacles.Add(new DynamicObstacle() { x = 20, y = 60, heading = 5.6, estimate_h = 5.6, speed = 0.8, estimate_s = 0.8, radius = 4 });

            executiveController.setMapDimensions(mapWidth, mapHeight);

            //SET START AND END GOAL. Make sure these are set AFTER the obstacles
            executiveController.map.setGoal(new State() { x = 10, y = 10 });
            executiveController.map.startState = new State() { x = 30, y = 40 };

            mapRenderer.render(executiveController, this, mainPictureBox);

            //Events
            menuStrip1.Items.Add(toolStripMenuItem4);
            //Draw button
            toolStripMenuItem3.Click += ToolStripMenuItem3_Click;
            //start planning button
            toolStripMenuItem4.Click += ToolStripMenuItem4_Click;
            toolStripMenuItem5.Click += ToolStripMenuItem5_Click;
        }

        //*******************************************************
        //*******************************************************
        //*******************************************************
        //*******************************************************
        private void ToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            executiveController.planPath();
            executiveController.moveAlongPath();

            mapRenderer.render(executiveController, this, mainPictureBox);
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            loopMovementFlag = !loopMovementFlag;
            if (loopMovementFlag)
            {
                startMoving();
            }
        }

        private void startMoving()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                executiveController.planPath();
                mapRenderer.render(executiveController, this, mainPictureBox);
                executiveController.moveAlongPath();
                //Thread.Sleep(50);

                if (loopMovementFlag)
                {
                    startMoving();
                }
            }).Start();
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            executiveController.planPath();

            mapRenderer.render(executiveController, this, mainPictureBox);
            //executiveController.moveAlongPath();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            if (!loopMovementFlag)
                mapRenderer.render(executiveController, this, mainPictureBox);

            //Take out the trash cause we're leaving holes in memory
            GC.Collect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
