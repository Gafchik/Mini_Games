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
        Panel panel_u;
        Panel panel_b;
        Panel panel_info;
        Panel panel_info_2;
        Button exit;
        List<Button> sea_u;
        List<Button> sea_b;

        private void Button_Sea_battle_Click(object sender, EventArgs e)
        {
            OFF_Main();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            panel_u = new Panel();
             panel_b = new Panel();
             panel_info = new Panel();
            panel_info_2 = new Panel();
            exit = new Button();
             sea_u = new List<Button>();
             sea_b = new List<Button>();


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
            exit.Size = new Size(this.Size.Width / 5, this.Size.Height / 10);


            //Point
            panel_u.Location = new Point(15, 15);
            panel_b.Location = new Point((this.Size.Width / 2)+15, 15);
            panel_info.Location = new Point(200, this.Size.Height  - (this.Size.Height / 5) );
            panel_info_2.Location = new Point(this.Size.Width-500, this.Size.Height  - (this.Size.Height / 5) );
           // exit.Location = new Point(this.Size.Width-500, this.Size.Height  - (this.Size.Height / 5) );
            //Color
            this.BackColor = Color.CadetBlue;
            panel_u.BackColor = Color.Aqua;
            panel_b.BackColor = Color.DarkBlue;
            panel_info.BackColor = Color.Green;
            panel_info_2.BackColor = Color.Red;
            exit.BackColor = Color.Blue;

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
            sea_u.ForEach(i => i.BackColor = Color.Gray);
            sea_b.ForEach(i => i.BackColor = Color.Gray);
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
                sea_u.ForEach(i => i.Click += sea_u_Click);
            sea_b.ForEach(i => i.Click += sea_u_Click);
            // значение по умолчаниею
            sea_u.ForEach(i => i.Name = "ok");
            sea_b.ForEach(i => i.Name = "ok");
            
            // корабли
           /* for (int i = 0; i < 10; i++)
            {
                sea_u[rand_sapp.Next(0, sea_u.Count - 1)].Name = "*";
                sea_b[rand_sapp.Next(0, sea_b.Count - 1)].Name = "*";
            } */
                  

          
        }
        private void sea_u_Click(object sender, System.EventArgs e)
        {

        }
    }
}
