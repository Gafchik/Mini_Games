using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Games
{
    public partial class Form_main
    {
        private Panel panel_game;
        private List<Button> minefield;
        private PictureBox output;

        private Label top_lable;
        private PictureBox close;
        private int count_mine;
        private int count_field;
        private int count_open;
        private Random rand_sapp;

        private void Button_Sapper_Click(object sender, EventArgs e)
        {
            OFF_Main();

            #region выдиление памяти
            count_mine = 0;
            count_open = 0;
            rand_sapp = new Random();
            count_field = 100;
            minefield = new List<Button>();
            top_lable = new Label();
            output = new PictureBox();
            panel_game = new Panel();

            close = new PictureBox();
            close.Image = Image.FromFile($"{Directory.GetCurrentDirectory()}\\Img\\close.png");

            SuspendLayout();

            #endregion

            #region output

            output.Cursor = Cursors.Hand;
            output.Image = close.Image;
            output.SizeMode = PictureBoxSizeMode.StretchImage;
            output.Size = new Size(this.Size.Width / 5, this.Size.Width / 15);
            output.Location = new Point(this.Size.Width - (this.Size.Width / 3), (this.Size.Height / 2) + (this.Size.Height / 4) + (this.Size.Height / 15));
            output.Name = "output";
            output.TabIndex = 4;
            output.Click += Output_Click;

            #endregion


            #region top_panel

            top_lable.BackColor = Color.BlueViolet;
            top_lable.Location = new Point(0, 0);
            top_lable.Name = "top_panel";
            top_lable.Size = new Size(this.Size.Width, this.Size.Height / 5);
            top_lable.TabIndex = 0;
            top_lable.Text = $"Oткрытых полей = {count_open}\nСкрытых мин на карте = {count_mine}";
            top_lable.Font = new Font("Tobota", 20, FontStyle.Bold);
            top_lable.TextAlign = ContentAlignment.MiddleCenter;

            #endregion

            #region    panel_game

            panel_game.BackColor = Color.White;
            panel_game.Location = new Point(0, (this.Size.Height / 5) - 9);
            panel_game.Size = new Size(this.Size.Width, this.Size.Height - top_lable.Size.Height - close.Size.Height - (this.Size.Height / 7));
            panel_game.Name = "panel_game";
            panel_game.TabIndex = 2;

            #endregion





            #region   Form_main
            FormBorderStyle = FormBorderStyle.FixedDialog;
            BackColor = Color.BlueViolet;
            Controls.Add(output);
            Size = new Size(500, 500);
            Controls.Add(panel_game);
            Controls.Add(top_lable);
            ResumeLayout(false);

            #endregion


            #region minefield
            // добавление
            for (int i = 0; i < count_field; i++)
            {
                minefield.Add(new Button());
            }
            // в игровую панель
            minefield.ForEach(i => panel_game.Controls.Add(i));
            // размер
            minefield.ForEach(i => i.Size = new Size((panel_game.Size.Width / 10) - 2, (panel_game.Size.Height / 10)));
            // позиция
            for (int i = 0; i < minefield.Count; i++)
            {
                if (i == 0)
                    minefield[i].Location = new Point(0, 0);
                else
                {
                    if (i % 10 == 0)
                    {
                        minefield[i].Location = new Point(0, minefield[i - 1].Location.Y + minefield[i - 1].Size.Height);
                    }
                    else
                        minefield[i].Location = new Point(minefield[i - 1].Location.X + minefield[i - 1].Size.Width, minefield[i - 1].Location.Y);
                }
            }
            // подвязка на клик
            minefield.ForEach(i => i.Click += minefield_Click);
            // значение по умолчаниею
            minefield.ForEach(i => i.Name = "ok");
            // minefield.ForEach(i => i.Text = minefield.FindIndex(j => j.GetHashCode() == i.GetHashCode()).ToString() );
            // минирование
            for (int i = 0; i < minefield.Count / 5; i++)
            {
                minefield[rand_sapp.Next(0, minefield.Count - 1)].Name = "0";
            }
            count_mine = minefield.Count(i => i.Name == "0");
            #endregion

            minefield.ForEach(i => i.BackColor = Color.Gray);

        }



        private void minefield_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Name == "0")
            {

                for (int i = 0; i < count_field; i++)
                {
                    if (minefield[i].Name == "0")
                    {
                        minefield[i].Text = minefield[i].Name;
                        minefield[i].BackColor = Color.Red;
                    }
                }

                DialogResult dialog = MessageBox.Show("Бабах!\nТы все просрал, повторим ?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    BackColor = Color.White;
                    panel_game.Dispose();
                    output.Dispose();
                    top_lable.Dispose();
                    close.Dispose();
                    ON_Main();
                }
                else
                {
                    count_open = 0;
                    minefield.ForEach(i => i.BackColor = Color.Gray);
                    minefield.ForEach(i => i.Name = "ok");
                    minefield.ForEach(i => i.Text = "");
                    minefield.ForEach(i => i.Enabled = true);
                    for (int i = 0; i < minefield.Count / 5; i++)
                    {
                        minefield[rand_sapp.Next(0, minefield.Count - 1)].Name = "0";
                    }
                    count_mine = minefield.Count(i => i.Name == "0");

                }

            }
            else
            {
                ((Button)sender).Text = ((Button)sender).Name;
                ((Button)sender).Enabled = false;
                ((Button)sender).BackColor = Color.Green;
                count_open++;

                int cout_i_rand = rand_sapp.Next(3, 25);
                if (cout_i_rand >= minefield.Count(i => i.Enabled == true))
                    cout_i_rand = 0;

                for (int i = 0; i < cout_i_rand; i++)
                {
                    int temp_rand = rand_sapp.Next(0, 99);
                    if (minefield[temp_rand].Enabled == true)
                    {
                        if (minefield[temp_rand].Name == "0")
                        {
                            minefield[temp_rand].Text = minefield[temp_rand].Name;
                            minefield[temp_rand].BackColor = Color.Red;
                            count_open++;
                            count_mine--;
                        }
                        else
                        {
                            minefield[temp_rand].Text = minefield[temp_rand].Name;
                            minefield[temp_rand].BackColor = Color.Green;
                            count_open++;
                        }
                        minefield[temp_rand].Enabled = false;
                    }
                    else
                        i--;
                }
                top_lable.Text = $"Oткрытых полей = {count_open}\nСкрытых мин на карте = {count_mine}";
                if (count_open == 100 || count_mine == 0)
                {

                    DialogResult dialog = MessageBox.Show("ЛЯ ты молодец)\n повторим ?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialog == DialogResult.No)
                    {
                        FormBorderStyle = FormBorderStyle.Sizable;
                        BackColor = Color.White;
                        panel_game.Dispose();
                        output.Dispose();
                        top_lable.Dispose();
                        close.Dispose();
                        ON_Main();
                    }
                    else
                    {
                        count_open = 0;
                        minefield.ForEach(i => i.BackColor = Color.Gray);
                        minefield.ForEach(i => i.Name = "ok");
                        minefield.ForEach(i => i.Text = "");
                        minefield.ForEach(i => i.Enabled = true);
                        for (int i = 0; i < minefield.Count / 5; i++)
                        {
                            minefield[rand_sapp.Next(0, minefield.Count - 1)].Name = "0";
                        }
                        count_mine = minefield.Count(i => i.Name == "0");

                    }
                }
            }
            top_lable.Text = $"Oткрытых полей = {count_open}\nСкрытых мин на карте = {count_mine}";
        }

        private void Output_Click(object sender, EventArgs e)
        {

            BackColor = Color.White;
            panel_game.Dispose();
            output.Dispose();
            top_lable.Dispose();
            close.Dispose();
            ON_Main();
        }
    }
}