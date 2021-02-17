using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
namespace Mini_Games
{
    partial class Form_main
    {

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            #region Form_main
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.Size = new Size(500, 500);
            this.Name = "Form_main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();
            this.SizeChanged += Form_main_SizeChanged;
            #endregion

            #region new Memory

            this.main_lble = new Label();
            this.button_X_O = new Button();
            this.button_Sea_battle = new Button();
            this.button_Sapper = new Button();
            this.SuspendLayout();
            #endregion

            #region main_lble

            main_lble.BackColor = Color.Black;
            main_lble.Enabled = true;
            main_lble.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            main_lble.ForeColor = Color.Yellow;
            main_lble.Location = new Point(0, 0);
            main_lble.Name = "main_lble";
            main_lble.Size = new Size(this.Size.Width, (this.Size.Height / 4) - 10);
            main_lble.TabIndex = 0;
            main_lble.Text = "MINI GAMES";
            main_lble.TextAlign = ContentAlignment.MiddleCenter;

            #endregion

            #region button_X_O

            button_X_O.BackColor = Color.Yellow;
            button_X_O.Cursor = Cursors.Hand;
            button_X_O.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            button_X_O.Location = new Point(0, main_lble.Size.Height);
            button_X_O.Size = new Size(this.Size.Width, (this.Size.Height / 4) - 10);
            button_X_O.Name = "button_X_O";
            button_X_O.TabIndex = 1;
            button_X_O.Text = "X vs O";
            button_X_O.Click += Button_X_O_Click;
            button_X_O.MouseHover += Button_Main_MouseHover;
            button_X_O.MouseLeave += Button_Main_MouseLeave;

            #endregion

            #region button_Sea_battle

            button_Sea_battle.BackColor = Color.Yellow;
            button_Sea_battle.Cursor = Cursors.Hand;
            button_Sea_battle.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            button_Sea_battle.Location = new Point(0, main_lble.Size.Height + button_X_O.Size.Height);
            button_Sea_battle.Size = new Size(this.Size.Width, (this.Size.Height / 4) - 10);
            button_Sea_battle.Name = "button_Sea_battle";
            button_Sea_battle.TabIndex = 2;
            button_Sea_battle.Text = "Sea Battle";
            button_Sea_battle.MouseHover += Button_Main_MouseHover;
            button_Sea_battle.MouseLeave += Button_Main_MouseLeave;
            button_Sea_battle.Click += Button_Sea_battle_Click;

            #endregion

            #region button_Sapper

            button_Sapper.BackColor = Color.Yellow;
            button_Sapper.Cursor = Cursors.Hand;
            button_Sapper.Font = new Font("Microsoft Sans Serif", 40F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
            button_Sapper.Location = new Point(0, main_lble.Size.Height + button_X_O.Size.Height + button_Sea_battle.Size.Height);
            button_Sapper.Size = new Size(this.Size.Width, (this.Size.Height / 4) - 10);
            button_Sapper.Name = "button_Sapper";
            button_Sapper.TabIndex = 3;
            button_Sapper.Text = "Sapper";
            button_Sapper.MouseHover += Button_Main_MouseHover;
            button_Sapper.MouseLeave += Button_Main_MouseLeave;
            button_Sapper.Click += Button_Sapper_Click;

            #endregion

            #region Добавление в контрольку

            this.Controls.Add(button_Sapper);
            this.Controls.Add(button_Sea_battle);
            this.Controls.Add(button_X_O);
            this.Controls.Add(main_lble);

            #endregion

        }

      









        #region ивент изменения размера формы
        private void Form_main_SizeChanged(object sender, System.EventArgs e)
        {
            #region позиция Main
            main_lble.Size = new Size(this.Size.Width, (this.Size.Height / 4) - 10);

            button_X_O.Location = new Point(0, main_lble.Size.Height);
            button_X_O.Size = new Size(this.Size.Width, (this.Size.Height / 4) - 10);

            button_Sea_battle.Location = new Point(0, main_lble.Size.Height + button_X_O.Size.Height);
            button_Sea_battle.Size = new Size(this.Size.Width, (this.Size.Height / 4) - 10);

            button_Sapper.Location = new Point(0, main_lble.Size.Height + button_X_O.Size.Height + button_Sea_battle.Size.Height);
            button_Sapper.Size = new Size(this.Size.Width, (this.Size.Height / 4) - 10);



            #endregion

            #region позиция крестики нолики
            if (buttons_X_O != null)
            {
                buttons_X_O.ForEach(i => i.Size = new Size((this.Size.Width / 3) - 7, (this.Size.Height / 3) - 14));
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
            }

            #endregion
        }
        #endregion
        private void Button_Main_MouseLeave(object sender, System.EventArgs e)
        {
            ((Button)sender).BackColor = Color.Yellow;
        }

        private void Button_Main_MouseHover(object sender, System.EventArgs e)
        {
            ((Button)sender).BackColor = Color.Red;
        }
        private void OFF_Main()
        {
            button_Sapper.Visible = false;
            button_Sea_battle.Visible = false;
            button_X_O.Visible = false;
            main_lble.Visible = false;
        }
        private void ON_Main()
        {
            button_Sapper.Visible = true;
            button_Sea_battle.Visible = true;
            button_X_O.Visible = true;
            main_lble.Visible = true;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
        }

        #region переменные

        private Label main_lble;
        private Button button_X_O;
        private Button button_Sea_battle;
        private Button button_Sapper;

        #endregion

    }
}


