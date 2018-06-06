namespace AnalizadorJson
{
    partial class Ventana_Juego
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ventana_Juego));
            this.player = new System.Windows.Forms.PictureBox();
            this.HUD = new System.Windows.Forms.Panel();
            this.key = new System.Windows.Forms.Label();
            this.coins = new System.Windows.Forms.Label();
            this.bombs = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.room = new System.Windows.Forms.Label();
            this.vidas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.item = new System.Windows.Forms.PictureBox();
            this.BODY = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.HUD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.item)).BeginInit();
            this.BODY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Location = new System.Drawing.Point(0, 0);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(30, 30);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // HUD
            // 
            this.HUD.BackColor = System.Drawing.Color.Black;
            this.HUD.Controls.Add(this.key);
            this.HUD.Controls.Add(this.coins);
            this.HUD.Controls.Add(this.bombs);
            this.HUD.Controls.Add(this.pictureBox3);
            this.HUD.Controls.Add(this.pictureBox2);
            this.HUD.Controls.Add(this.pictureBox1);
            this.HUD.Controls.Add(this.room);
            this.HUD.Controls.Add(this.vidas);
            this.HUD.Controls.Add(this.label1);
            this.HUD.Controls.Add(this.item);
            this.HUD.Location = new System.Drawing.Point(-3, -2);
            this.HUD.Margin = new System.Windows.Forms.Padding(0);
            this.HUD.Name = "HUD";
            this.HUD.Size = new System.Drawing.Size(398, 71);
            this.HUD.TabIndex = 1;
            // 
            // key
            // 
            this.key.AutoSize = true;
            this.key.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.key.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.key.ForeColor = System.Drawing.Color.White;
            this.key.Location = new System.Drawing.Point(323, 40);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(0, 16);
            this.key.TabIndex = 9;
            // 
            // coins
            // 
            this.coins.AutoSize = true;
            this.coins.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.coins.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coins.ForeColor = System.Drawing.Color.White;
            this.coins.Location = new System.Drawing.Point(245, 40);
            this.coins.Name = "coins";
            this.coins.Size = new System.Drawing.Size(0, 16);
            this.coins.TabIndex = 8;
            // 
            // bombs
            // 
            this.bombs.AutoSize = true;
            this.bombs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bombs.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bombs.ForeColor = System.Drawing.Color.White;
            this.bombs.Location = new System.Drawing.Point(186, 40);
            this.bombs.Name = "bombs";
            this.bombs.Size = new System.Drawing.Size(0, 16);
            this.bombs.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(326, 4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(28, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(258, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(189, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // room
            // 
            this.room.AutoSize = true;
            this.room.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.room.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.room.ForeColor = System.Drawing.Color.White;
            this.room.Location = new System.Drawing.Point(26, 40);
            this.room.Name = "room";
            this.room.Size = new System.Drawing.Size(0, 16);
            this.room.TabIndex = 3;
            // 
            // vidas
            // 
            this.vidas.AutoSize = true;
            this.vidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.vidas.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vidas.ForeColor = System.Drawing.Color.White;
            this.vidas.Location = new System.Drawing.Point(76, 3);
            this.vidas.Name = "vidas";
            this.vidas.Size = new System.Drawing.Size(0, 16);
            this.vidas.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vidas: ";
            // 
            // item
            // 
            this.item.Location = new System.Drawing.Point(326, 3);
            this.item.Name = "item";
            this.item.Size = new System.Drawing.Size(72, 62);
            this.item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.item.TabIndex = 0;
            this.item.TabStop = false;
            // 
            // BODY
            // 
            this.BODY.Controls.Add(this.exit);
            this.BODY.Controls.Add(this.player);
            this.BODY.Location = new System.Drawing.Point(0, 66);
            this.BODY.Margin = new System.Windows.Forms.Padding(0);
            this.BODY.Name = "BODY";
            this.BODY.Size = new System.Drawing.Size(395, 208);
            this.BODY.TabIndex = 2;
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(182, 89);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(30, 30);
            this.exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.exit.TabIndex = 1;
            this.exit.TabStop = false;
            // 
            // Ventana_Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 273);
            this.Controls.Add(this.BODY);
            this.Controls.Add(this.HUD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Ventana_Juego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventana_Juego";
            this.Load += new System.EventHandler(this.Ventana_Juego_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ventana_Juego_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.HUD.ResumeLayout(false);
            this.HUD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.item)).EndInit();
            this.BODY.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.Panel HUD;
        private System.Windows.Forms.Panel BODY;
        private System.Windows.Forms.Label vidas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox item;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label room;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label key;
        private System.Windows.Forms.Label coins;
        private System.Windows.Forms.Label bombs;
        private System.Windows.Forms.PictureBox exit;
    }
}