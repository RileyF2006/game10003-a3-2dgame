// Include code libraries you need below (use the namespace).
using System;
using System.Numerics;
using System.Runtime.CompilerServices;

// The namespace your code is in.
namespace Game10003
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Vector2 PlayerPosition;
        Vector2 Playerinput;
        Vector2 size;
        Vector2 BallPosition;
        Vector2 velocity;
        Vector2 BallSize;
        public static int score = 0;
        public static bool EndGame = false;
        public static bool WinGame = false;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Breakout");
            Window.ClearBackground(Color.Black);
            Window.SetSize(800, 600);
        }

        void GetPlayerInput()
        {
            Vector2 input = Vector2.Zero;

            if (Input.IsKeyboardKeyDown(KeyboardInput.Left) || Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                input.X -= 1;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.Right) || Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                input.X += 1;
            }

            Playerinput = input;
        }

        void DrawPaddle()
        {
            size = new Vector2(200, 30);
            Draw.FillColor = Color.White;
            Draw.Rectangle(PlayerPosition, size);
        }
        void DrawBall()
        {
            BallSize = new Vector2(50, 50);
            BallPosition = new Vector2(600 / 2, 300);
            velocity = new Vector2(200, 200);

            Draw.FillColor = Color.White;
            Draw.Circle(BallPosition + BallSize, BallSize.X / 4);
        }

        void MoveBall()
        {
            BallPosition += velocity * Time.DeltaTime;
        }
        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {

            float leftEdge = PlayerPosition.X;
            float rightEdge = PlayerPosition.X + size.X;

            bool isLeftOfWindow = leftEdge <= 0;
            bool isRightOfWindow = rightEdge >= Window.Width;


            if (isLeftOfWindow)
            {
                PlayerPosition.X = 0;
            }
            else if (isRightOfWindow)
            {
                PlayerPosition.X = 600;
            }
            Window.ClearBackground(Color.Black);

            GetPlayerInput();

            PlayerPosition.Y = 550;

            PlayerPosition += Playerinput * 200 * Time.DeltaTime;


            DrawPaddle();
            MoveBall();
            DrawBall();
        }
        }
    }

