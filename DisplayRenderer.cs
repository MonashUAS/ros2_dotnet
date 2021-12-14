using System;
using System.Collections.Generic;
using System.Text;
using SkiaSharp;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace GirbalPathfinding
{
    internal class MapRenderer
    {
        public DateTime lastUpdate;

        public MapRenderer()
        {
            lastUpdate = DateTime.Now; // updates the time 
        }

        public void render(ExecutiveController executiveController, Form form, PictureBox mainPictureBox)
        {
            TimeSpan updateTime = DateTime.Now - lastUpdate;//updates the time alappsed betwen the last update and current time
            lastUpdate = DateTime.Now; // updates the last time stamp

            SKImageInfo imageInfo = new SKImageInfo(form.Width, form.Height - 24);
            using (SKSurface surface = SKSurface.Create(imageInfo))
            {
                float nodeWidth = (float)surface.Canvas.DeviceClipBounds.Width / executiveController.getMapWidth(); 
                float nodeHeight = (float)surface.Canvas.DeviceClipBounds.Height / executiveController.getMapHeight(); //sets grid size for renderer

                SKCanvas canvas = surface.Canvas; 
                canvas.Clear(SKColors.LightCoral); 

                using (SKPaint paint = new SKPaint())
                {
                    paint.Color = SKColors.Cyan; //sets the new color
                    paint.IsAntialias = true;
                    //paint.StrokeWidth = 15;
                    paint.Style = SKPaintStyle.Fill;
                    paint.TextSize = 20;

                    //Draw statics
                    for (int i = 0; i < executiveController.getMapWidth(); i++)
                    {
                        for (int j = 0; j < executiveController.getMapHeight(); j++)
                        {
                            if (executiveController.staticObstacles[i, j] != 0)
                            {
                                canvas.DrawRect(i * nodeWidth, j * nodeHeight, nodeWidth, nodeHeight, paint);
                            }
                        }
                    }
                    ////Draw dynamics
                    //paint.Color = SKColors.DarkCyan;
                    //foreach (var obstacle in executiveController.dynamicObstacles)
                    //{
                    //    canvas.DrawCircle((float)obstacle.x * nodeWidth + nodeWidth / 2, (float)obstacle.y * nodeHeight + nodeHeight / 2, nodeWidth * (float)obstacle.radius, paint);
                    //}

                    //Draw lookahead region
                    paint.Color = SKColors.GreenYellow;
                    foreach (IPathPlannable pathPlanner in executiveController.pathPlanners)
                    {
                        //foreach (var state in pathplanner.lookaheadregion)
                        //{
                        //    if (pathplanner.lookaheadregion.contains(state))
                        //    {
                        //        canvas.drawrect(state.x * nodewidth, state.y * nodeheight, nodewidth, nodeheight, paint);
                        //    }
                        //}

                        //Draw path
                        paint.Color = SKColors.Purple;
                        foreach (var state in pathPlanner.path)
                        {
                            canvas.DrawRect(state.x * nodeWidth, state.y * nodeHeight, nodeWidth, nodeHeight, paint);
                        }

                        paint.Color = SKColors.Black;
                        paint.TextSize = 12;
                        //foreach (var state in pathPlanner.lookaheadRegion)
                        //{
                        //    //canvas.DrawText(state.time.ToString("G3"), state.x * nodeWidth, state.y * nodeHeight + nodeHeight / 2, paint);
                        //    //canvas.DrawText(state.cost_d.ToString("G3"), state.x * nodeWidth, state.y * nodeHeight + nodeHeight, paint);
                        //    //canvas.DrawText(state.headingDAv.ToString("G3"), state.x * nodeWidth, state.y * nodeHeight + nodeHeight, paint);
                        //}

                        //next state
                        paint.Color = SKColors.Orange;
                        if (pathPlanner.path.Count > 2)
                        {
                            var nextState =
                                pathPlanner.path[pathPlanner.path.Count - 2];

                            canvas.DrawRect(nextState.x * nodeWidth, nextState.y * nodeHeight, nodeWidth, nodeHeight, paint);
                            paint.Color = SKColors.Black;
                            //canvas.DrawText(nextState.headingAv.ToString("G3"), nextState.x * nodeWidth, nextState.y * nodeHeight + nodeHeight / 2, paint);
                        }
                    }

                    //Draw goal and start
                    //paint.Color = SKColors.White;
                    List<SKColor> colors = new List<SKColor>(new SKColor[] { SKColors.White, SKColors.Black, SKColors.Blue, SKColors.Gray });

                    for (int i = 0; i < executiveController.noOfAgents; i++)
                    {
                        paint.Color = colors[i];
                        canvas.DrawRect(executiveController.map.goalStates[i].x * nodeWidth, executiveController.map.goalStates[i].y * nodeHeight, nodeWidth, nodeHeight, paint);
                        canvas.DrawRect(executiveController.map.startStates[i].x * nodeWidth, executiveController.map.startStates[i].y * nodeHeight, nodeWidth, nodeHeight, paint);
                    }

                    paint.Color = SKColors.White;
                    paint.TextSize = 20;
                    canvas.DrawText(updateTime.TotalMilliseconds + " ms", (float)surface.Canvas.DeviceClipBounds.Width - 150, 40, paint);
                }

                using (SKImage image = surface.Snapshot())
                using (SKData data = image.Encode(SKEncodedImageFormat.Png, 100))
                using (MemoryStream mStream = new MemoryStream(data.ToArray()))
                {
                    Bitmap bm = new Bitmap(mStream, false);
                    mainPictureBox.Image = bm;
                }
            }
        }
    }
}
