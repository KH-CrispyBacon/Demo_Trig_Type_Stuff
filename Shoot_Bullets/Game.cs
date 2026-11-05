// Include the namespaces (code libraries) you need below.
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

        Vector2 target;

        Vector2 player;

        
        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Bullet Hell");
            Window.SetSize(400, 400);

            target = Window.Size / 2;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            player = Input.GetMousePosition();

            float radius = 20;

            //move target
            if (Input.IsMouseButtonDown(MouseButton.Left) == true)
            {
                target = Input.GetMousePosition();
            }


            //Shoot
            if (Input.IsKeyboardKeyDown(KeyboardKey.Space) == true)
            {
                //what is the angle to the target?
                Vector2 vectorFromPlayerToTarget = target - player;
                float y = vectorFromPlayerToTarget.Y;
                float x = vectorFromPlayerToTarget.X;
                // Radians!
                float angleFromPlayerToTarget = MathF.Atan2(y, x);

                float spreadRangeDegrees = 65;
                float spreadRangeRadians = spreadRangeDegrees / 360 * MathF.Tau;



                Draw.LineSize = 1;
                Draw.LineColor = Color.Blue;
                for (int i = 0; i < 9; i++)
                {
                    float percent = i / 8f;
                    float angle =
                        angleFromPlayerToTarget - spreadRangeDegrees / 2 + spreadRangeRadians * percent;

                    Vector2 direction = new Vector2(MathF.Cos(angle), MathF.Sin(angle));
                    Draw.Line(player, player + direction * 50);
                }



            }

            Draw.FillColor = Color.Black;
            Draw.LineColor = Color.Black;
            Draw.Circle(player, radius);

            Draw.LineSize = 3;
            Draw.LineColor = Color.Red;
            Draw.FillColor = new Color(0, 0, 0, 0);
            Draw.Circle(target, radius);
            Draw.Line(target - Vector2.UnitX * radius, target + Vector2.UnitX * radius);
            Draw.Line(target - Vector2.UnitY * radius, target + Vector2.UnitY * radius);// unitX is (1, 0) and UnitY is (0,1)
            Draw.Circle(target, 20);


        }
    }

}
