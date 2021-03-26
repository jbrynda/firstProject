using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Kulecnik2._0
{
    public class Ball
    {
        public int ballWidth = 0;
        public int ballHeight = 0;
        public int ballPosX = 0;
        public int ballPosY = 0;
        public int moveStepX = 4;
        public int moveStepY = 4;
        public Color ballColor;
        private Random rand = new Random();
        public int randomMove;
        public void Pohyb(int sizeX, int sizeY)
        {
            ballPosX += moveStepX;
            if (ballPosX < 0 || ballPosX + ballWidth > sizeX)
            {
                moveStepX = -moveStepX;
                ballColor = DefineColor();
            }

            ballPosY += moveStepY;
            if (ballPosY < 0 || ballPosY + ballHeight > sizeY)
            {
                moveStepY = -moveStepY;
                ballColor = DefineColor();
            }
        }

        public void PohybX(int sizeX)
        {
            ballPosX += moveStepX;
            if (ballPosX < 0 || ballPosX + ballWidth > sizeX)
            {
                moveStepX = -moveStepX;
                ballColor = DefineColor();
            }
        }

        public void PohybY(int sizeY)
        {
            ballPosY += moveStepY;
            if (ballPosY < 0 || ballPosY + ballHeight > sizeY)
            {
                moveStepY = -moveStepY;
                ballColor = DefineColor();
            }
        }

        public Color DefineColor()
        {
            Color newColor = Color.FromArgb((byte)rand.Next(0, 256), (byte)rand.Next(0, 256), (byte)rand.Next(0, 256));
            return newColor;
        }
        public override string ToString()
        {
            return "Ball: " + ballHeight + " " + ballWidth + randomMove;        
        }
        public Ball(int ballWidth, int ballHeight, int ballPosX, int ballPosY)
        {
            this.ballWidth = ballWidth;
            this.ballHeight = ballWidth;
            this.ballPosX = ballPosX;
            this.ballPosY = ballPosY;
        }
    }
}
