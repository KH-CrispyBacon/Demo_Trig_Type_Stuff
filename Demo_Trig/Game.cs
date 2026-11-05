// Include the namespace (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        int position = 0;
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Roller Coaster");
            Window.SetSize(400, 400);
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            //Making a Loop de loop
            Window.ClearBackground(Color.White);

            Vector2[] circlePoints = new Vector2[360+1];
            //Loop through angles in increments of 1
            for (int i = 0; i < circlePoints.Length; i++)
            {
                //goes from 90 to counter clockwise to -270
                int angleDegrees = 90 - i;
                float angleRadius = angleDegrees / 360f * MathF.Tau;
                //Calculate points on circle
                float x = MathF.Cos(angleRadius);
                float y = MathF.Sin(angleRadius);
                Vector2 point = new Vector2(x, y);
                Vector2 start = new Vector2(0, 175);
                Vector2 offset = new Vector2(i, 0);
                circlePoints[i] = point * 150 + start + offset;
            }

            Draw.LineSize = 5;
            Draw.LineColor = Color.Red;
            Draw.PolyLine(circlePoints);
            

            Draw.LineSize = 0;
            Draw.FillColor = Color.Black;
            Vector2 PointOnRollerCoaster = GetPointOnLoopedyLoop(position);
            Draw.Circle(PointOnRollerCoaster, 10);
            

            if (Input.IsKeyboardKeyDown(KeyboardKey.P))
            {
                position += 1;
            }

            if (Input.IsKeyboardKeyPressed(KeyboardKey.Space))
            {
                position = 0;
            }

        }

        Vector2 GetPointOnLoopedyLoop(int angleDeg)
        {
            //goes from 90 to counter clockwise to -270
            int angleDegrees = 90 - angleDeg;
            float angleRadius = angleDegrees / 360f * MathF.Tau;
            //Calculate points on circle
            float x = MathF.Cos(angleRadius);
            float y = MathF.Sin(angleRadius);
            Vector2 point = new Vector2(x, y);
            Vector2 start = new Vector2(0, 175);
            Vector2 offset = new Vector2(angleDeg, 0);
            Vector2 finalPoint = point * 150 + start + offset;

            return finalPoint;
        }
    }

    
        

          
       
            
        
 
}
