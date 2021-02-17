using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Mini_Games
{
    public partial class Form_main
    {
        #region крестики нолики

        #region переменные для X_O
        private PictureBox picture_X;
        private PictureBox picture_Y;
        private PictureBox picture_None;
        private PictureBox picture_OK;
        private bool user_X_O = true;
        List<PictureBox> buttons_X_O;
        int count_buttons_X_O = 9;
        #endregion

        #region Выбор Игры крестики нолики
        private void Button_X_O_Click(object sender, System.EventArgs e)
        {
            OFF_Main();
            this.Text = "Игрок 1";

            #region создание кнопок
            buttons_X_O = new List<PictureBox>();
            for (int i = 0; i < count_buttons_X_O; i++)
                buttons_X_O.Add(new PictureBox());
            #endregion
            #region Размер кнопок
            buttons_X_O.ForEach(i => i.Size = new Size((this.Size.Width / 3) - 7, (this.Size.Height / 3) - 14));
            #endregion

            #region Кртинка по умолчанию
            picture_None = new PictureBox();
            picture_None.Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\None.png");
            buttons_X_O.ForEach(i => i.Image = picture_None.Image);
            #endregion         

            #region добавление кнопок в контрольку
            buttons_X_O.ForEach(i => this.Controls.Add(i));
            #endregion

            #region Позицыониолвание кнопок         
            for (int i = 0; i < buttons_X_O.Count; i++)
            {
                if (i == 0)
                    buttons_X_O[i].Location = new Point(0, 0);
                else
                {
                    if (buttons_X_O[i - 1].Location.X >= this.Size.Width - buttons_X_O[i - 1].Location.X)
                    {
                        buttons_X_O[i].Location = new Point(0, buttons_X_O[i - 1].Location.Y + buttons_X_O[i - 1].Size.Height);
                    }
                    else
                        buttons_X_O[i].Location = new Point(buttons_X_O[i - 1].Location.X + buttons_X_O[i - 1].Size.Width, buttons_X_O[i - 1].Location.Y);

                }
            }
            #endregion

            #region подвязка кнопок на клик
            buttons_X_O.ForEach(i => i.Click += buttons_X_O_Click);
            #endregion

            #region теги кнопок по умолчанию
            buttons_X_O.ForEach(i => i.Name = "None");
            #endregion

        }
        #region Ивент клик на кнопки X O
        private void buttons_X_O_Click(object sender, System.EventArgs e)
        {
            picture_X = new PictureBox();
            picture_Y = new PictureBox();
            picture_OK = new PictureBox();
            picture_X.Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\X.png");
            picture_Y.Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\0.png");
            picture_OK.Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");

            ((PictureBox)sender).Text = "";
            ((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;

            if (user_X_O)
            {
                this.Text = "Игрок 2";
                ((PictureBox)sender).Image = picture_X.Image;
                ((PictureBox)sender).Name = "X";
                user_X_O = false;

            }
            else
            {
                this.Text = "Игрок 1";
                ((PictureBox)sender).Image = picture_Y.Image;
                ((PictureBox)sender).Name = "0";
                user_X_O = true;
            }
             ((PictureBox)sender).Enabled = false;

            #region горизонталь Х
            if (buttons_X_O[0].Name == "X" && buttons_X_O[1].Name == "X" && buttons_X_O[2].Name == "X")
            {
                buttons_X_O[0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[2].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 1 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                ON_Main();
            }
            else if (buttons_X_O[3].Name == "X" && buttons_X_O[4].Name == "X" && buttons_X_O[5].Name == "X")
            {
                buttons_X_O[3].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[4].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[5].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 1 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (buttons_X_O[6].Name == "X" && buttons_X_O[7].Name == "X" && buttons_X_O[8].Name == "X")
            {
                buttons_X_O[6].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[7].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[8].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 1 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            #endregion
            #region вертикаль Х
            else if (buttons_X_O[0].Name == "X" && buttons_X_O[3].Name == "X" && buttons_X_O[6].Name == "X")
            {
                buttons_X_O[0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[3].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[6].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 1 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (buttons_X_O[1].Name == "X" && buttons_X_O[4].Name == "X" && buttons_X_O[7].Name == "X")
            {
                buttons_X_O[1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[4].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[7].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 1 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (buttons_X_O[2].Name == "X" && buttons_X_O[5].Name == "X" && buttons_X_O[8].Name == "X")
            {
                buttons_X_O[2].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[5].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[8].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 1 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            #endregion
            #region диагональ Х
            else if (buttons_X_O[0].Name == "X" && buttons_X_O[4].Name == "X" && buttons_X_O[8].Name == "X")
            {
                buttons_X_O[0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[4].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[8].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 1 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (buttons_X_O[2].Name == "X" && buttons_X_O[4].Name == "X" && buttons_X_O[6].Name == "X")
            {
                buttons_X_O[2].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[4].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[6].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 1 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            #endregion
            #region горизонталь 0
            else if (buttons_X_O[0].Name == "0" && buttons_X_O[1].Name == "0" && buttons_X_O[2].Name == "0")
            {
                buttons_X_O[0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[2].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 2 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (buttons_X_O[3].Name == "0" && buttons_X_O[4].Name == "0" && buttons_X_O[5].Name == "0")
            {
                buttons_X_O[3].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[4].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[5].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 2 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (buttons_X_O[6].Name == "0" && buttons_X_O[7].Name == "0" && buttons_X_O[8].Name == "0")
            {
                buttons_X_O[6].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[7].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[8].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 2 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            #endregion
            #region вертикаль 0
            else if (buttons_X_O[0].Name == "0" && buttons_X_O[3].Name == "0" && buttons_X_O[6].Name == "0")
            {
                buttons_X_O[0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[3].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[6].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 2 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (buttons_X_O[1].Name == "0" && buttons_X_O[4].Name == "0" && buttons_X_O[7].Name == "0")
            {
                buttons_X_O[1].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[4].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[7].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 2 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (buttons_X_O[2].Name == "0" && buttons_X_O[5].Name == "0" && buttons_X_O[8].Name == "0")
            {
                buttons_X_O[2].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[5].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[8].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 2 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            #endregion
            #region диагональ 0
            else if (buttons_X_O[0].Name == "0" && buttons_X_O[4].Name == "0" && buttons_X_O[8].Name == "0")
            {
                buttons_X_O[0].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[4].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[8].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 2 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (buttons_X_O[2].Name == "0" && buttons_X_O[4].Name == "0" && buttons_X_O[6].Name == "0")
            {
                buttons_X_O[2].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[4].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                buttons_X_O[6].Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\ok.png");
                MessageBox.Show("Игрок 2 победил", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }
            else if (!buttons_X_O.Exists(i => i.Name == "None"))
            {
                MessageBox.Show("НИЧИЯ !", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                buttons_X_O.ForEach(i => i.Dispose());
                buttons_X_O.Clear();
                ON_Main();
            }

            #endregion
        }
        #endregion
        #endregion

        #endregion
    }
}
