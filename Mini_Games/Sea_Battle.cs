using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mini_Games
{
    public partial class Form_main
    {
        Panel panel_u;
        Panel panel_b;
        Label panel_info;
        Label panel_info_2;
        Button exit;
        List<Button> sea_u;
        List<Button> sea_b;
        Random rand_SA;
        int cout_u ;
        int cout_b;
        private void Button_Sea_battle_Click(object sender, EventArgs e)
        {
            OFF_Main();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            panel_u = new Panel();
             panel_b = new Panel();
             panel_info = new Label();
            panel_info_2 = new Label();
            exit = new Button();
             sea_u = new List<Button>();
             sea_b = new List<Button>();
            rand_SA = new Random();


            // controls
            this.Size = new Size(1200, 700);
            this.Controls.Add(panel_u);
            this.Controls.Add(panel_b);
            this.Controls.Add(panel_info);
            this.Controls.Add(panel_info_2);
            this.Controls.Add(exit);

            //size
            panel_u.Size = new Size((this.Size.Width / 2)-50, this.Size.Height / 2+200);
            panel_b.Size = new Size((this.Size.Width / 2) - 50, this.Size.Height / 2+200);
            panel_info.Size = new Size(this.Size.Width / 5, this.Size.Height / 10);
            panel_info_2.Size = new Size(this.Size.Width / 5, this.Size.Height / 10);
            exit.Size = new Size(this.Size.Width / 10, this.Size.Height / 10);


            //Point
            panel_u.Location = new Point(15, 15);
            panel_b.Location = new Point((this.Size.Width / 2)+15, 15);
            panel_info.Location = new Point(200, this.Size.Height  - (this.Size.Height / 5) );
            panel_info_2.Location = new Point(this.Size.Width-500, this.Size.Height  - (this.Size.Height / 5) );
            exit.Location = new Point(this.Size.Width-770, this.Size.Height  - (this.Size.Height / 5) );
            //Color
            this.BackColor = Color.CadetBlue;
            panel_u.BackColor = Color.Aqua;
            panel_b.BackColor = Color.DarkBlue;
            panel_info.BackColor = Color.Green;
            panel_info_2.BackColor = Color.Red;
            exit.BackColor = Color.Gray;

            exit.Text = "ВЫХОД";
            exit.Click += Exit_Click;


            // sea
            for (int i = 0; i < 100; i++)
            {
                sea_u.Add(new Button());
            }
            for (int i = 0; i < 100; i++)
            {
                sea_b.Add(new Button());
            }
            // в игровую панель
            sea_u.ForEach(i => panel_u.Controls.Add(i));
            sea_b.ForEach(i => panel_b.Controls.Add(i));
            // размер
            sea_u.ForEach(i => i.Size = new Size(50, 50));
            sea_b.ForEach(i => i.Size = new Size(50, 50));
            // color
            sea_u.ForEach(i => i.BackColor = Color.Silver);
            sea_b.ForEach(i => i.BackColor = Color.Silver);
            // позиция
            for (int i = 0; i < sea_u.Count; i++)
            {
                if (i == 0)
                {
                    sea_u[i].Location = new Point(65, 35);
                    sea_b[i].Location = new Point(65, 35);
                }
                else
                {
                    if (i % 10 == 0)
                    {
                        sea_u[i].Location = new Point(65, sea_u[i - 1].Location.Y + sea_u[i - 1].Size.Height);
                        sea_b[i].Location = new Point(65, sea_b[i - 1].Location.Y + sea_b[i - 1].Size.Height);
                    }
                    else
                    {
                        sea_u[i].Location = new Point(sea_u[i - 1].Location.X + sea_u[i - 1].Size.Width, sea_u[i - 1].Location.Y);
                        sea_b[i].Location = new Point(sea_b[i - 1].Location.X + sea_b[i - 1].Size.Width, sea_b[i - 1].Location.Y);
                    }
                }
            }



            // подвязка на клик
           // sea_u.ForEach(i => i.Click += sea_u_Click);
            sea_b.ForEach(i => i.Click += sea_b_Click);
            // значение по умолчаниею
            sea_u.ForEach(i => i.Name = "ok");
            sea_b.ForEach(i => i.Name = "ok");
            
            // корабли
            for (int i = 0; i < 10; i++)
            {
                int j = rand_SA.Next(0, 99);
                sea_u[j].Name = "000";
                sea_u[j].Text = sea_u[j].Name;
                sea_b[j].Name = "000";
                
            }


             cout_u = sea_u.Count(i => i.Name == "000");
            cout_b = sea_b.Count(i => i.Name == "000");
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.Sizable;
            BackColor = Color.White;
            panel_u.Dispose();
            panel_b.Dispose();
            panel_info.Dispose();
            panel_info_2.Dispose();
            exit.Dispose();
            sea_u.ForEach(i => i.Dispose());
            sea_b.ForEach(i => i.Dispose());
            ON_Main();
        }

        private void sea_b_Click(object sender, System.EventArgs e)
        {
            int j = rand_SA.Next(0, 99);
            int index = sea_b.IndexOf((sender as Button));
            if ((sender as Button).Name == "000")
            {

                sea_b[index].Name = "УБИТ";
                sea_b[index].Text = "УБИТ";
                sea_b[index].Enabled = false;             

            }
            else
            {
                sea_b[index].Text = "XXX\nXXX\nXXX";
                sea_b[index].Enabled = false;
            }

            while (!sea_u[j].Enabled)
            {
                j = rand_SA.Next(0, 99);
            }
            if (sea_u[j].Name=="000")
            {
                sea_u[j].Name = "УБИТ";
                sea_u[j].Text = "УБИТ";
                sea_u[j].Enabled = false;
            }
            else
            {
                sea_u[j].Text = "XXX\nXXX\nXXX";
                sea_u[j].Enabled = false;
            }
             cout_u = sea_u.Count(i => i.Name == "000");
            cout_b =  sea_b.Count(i => i.Name == "000");
            panel_info.Text = $"Твоих кораблей осталось {cout_u}";
            panel_info_2.Text = $"Кораблей бота осталось {cout_b}";
            if(cout_u==0 || cout_b == 0)
            {
                DialogResult dialog = MessageBox.Show(" Повторим ?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.No)
                {
                    FormBorderStyle = FormBorderStyle.Sizable;
                    BackColor = Color.White;
                    panel_u.Dispose();
                    panel_b.Dispose();
                    panel_info.Dispose();
                    panel_info_2.Dispose();
                    exit.Dispose();
                    sea_u.ForEach(i => i.Dispose());
                    sea_b.ForEach(i => i.Dispose());
                    ON_Main();
                }
                else
                {
                    count_open = 0;

                    sea_u.ForEach(i => i.Name = "ok");
                    sea_b.ForEach(i => i.Name = "ok");
                    sea_u.ForEach(i => i.Text = "");
                    sea_b.ForEach(i => i.Text = "");
                    sea_u.ForEach(i => i.Enabled = true);
                    sea_b.ForEach(i => i.Enabled = true);
                    for (int i = 0; i < 10; i++)
                    {
                        int q = rand_SA.Next(0, 99);
                        sea_u[q].Name = "000";
                        sea_u[q].Text = sea_u[q].Name;
                        sea_b[q].Name = "000";

                    }

                }
            }
        }
      
    }
}
