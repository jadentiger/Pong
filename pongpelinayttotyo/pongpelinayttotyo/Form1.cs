using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pongpelinayttotyo
{
    public partial class Form1 : Form
    {
        int ballXspeed = 4;
        int ballYspeed = 4;
        int speed = 5;
        Random rand = new Random();
        bool goDown, goUp;
        int computer_speed_chnage = 50;
        int playerScore = 0;
        int computerScore = 0;
        int playerSpeed = 20;
        int[] i = { 5, 11, 12, 14 };
        int[] j = { 10, 9, 11, 14, 15 };
        SoundPlayer scoreSound = new SoundPlayer("chime.wav");
        SoundPlayer backgroundMusicPlayer = new SoundPlayer("251461__joshuaempyre__arcade-music-loop.wav");

        public Form1()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(KeyIsDown);
            this.KeyUp += new KeyEventHandler(KeyIsUp);
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            ball.Top -= ballYspeed;
            ball.Left -= ballXspeed;

            this.Text = "Player Score: " + playerScore + " -- Computer Score: " + computerScore;

            if (ball.Top < 0 || ball.Bottom > this.ClientSize.Height)
            {
                ballYspeed = -ballYspeed;
            }

            if (ball.Left < -2)
            {
                ball.Left = 300;
                ballXspeed = -ballXspeed;
                if (ball.Bottom > 0 && ball.Top < this.ClientSize.Height)
                {
                    playerScore++;
                }
            }

            if (ball.Right > this.ClientSize.Width + 2)
            {
                ball.Left = 300;
                ballXspeed = -ballXspeed;
                if (ball.Bottom > 0 && ball.Top < this.ClientSize.Height)
                {
                    computerScore++;
                }
            }

            if (computer.Top <= 1)
            {
                computer.Top = 0;
            }
            else if (computer.Bottom >= this.ClientSize.Height)
            {
                computer.Top = this.ClientSize.Height - computer.Height;
            }

            if (ball.Top < computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top -= speed;
            }
            if (ball.Top > computer.Top + (computer.Height / 2) && ball.Left > 300)
            {
                computer.Top += speed;
            }

            computer_speed_chnage -= 1;

            if (computer_speed_chnage < 0)
            {
                speed = i[rand.Next(i.Length)];
                computer_speed_chnage = 50;
            }

            if (goDown && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += playerSpeed;
            }
            if (goUp && player.Top > 0)
            {
                player.Top -= playerSpeed;
            }

            CheckCollision(ball, player, player.Right + 5);
            CheckCollision(ball, computer, computer.Left - 35);

            if (computerScore > 4)
            {
                GameOver("You won!");
            }
            else if (playerScore > 4)
            {
                GameOver("You lost!");
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
        }

        private void CheckCollision(PictureBox PicOne, PictureBox PicTwo, int offset)
        {
            if (PicOne.Bounds.IntersectsWith(PicTwo.Bounds))
            {

                PicOne.Left = offset;

                int x = j[rand.Next(j.Length)];
                int y = j[rand.Next(j.Length)];

                if (ballXspeed < 0)
                {
                    ballXspeed = x;
                }
                else
                {
                    ballXspeed = -x;
                }

                if (ballYspeed < 0)
                {
                    ballYspeed = -y;
                }
                else
                {
                    ballYspeed = y;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            backgroundMusicPlayer.PlayLooping();
        }

        private void GameOver(string message)
        {
            scoreSound.Play();

            GameTimer.Stop();
            MessageBox.Show(message, "Game says: ");
            computerScore = 0;
            playerScore = 0;
            ballXspeed = ballYspeed = 4;
            computer_speed_chnage = 50;
            GameTimer.Start();

            backgroundMusicPlayer.PlayLooping();

        }
    }
}
