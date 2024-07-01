namespace WindowsFormsApp7
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer timer;
        private int currentPointIndex;
        private System.Drawing.Point[] linePoints;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

         
            this.startButton.Location = new System.Drawing.Point(10, 10);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);

           
            this.timer.Interval = 50;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
        }

        private void startButton_Click(object sender, System.EventArgs e)
        {
            currentPointIndex = 0;
            timer.Start();
        }

        private void timer_Tick(object sender, System.EventArgs e)
        {
            if (currentPointIndex < linePoints.Length - 1)
            {
                currentPointIndex++;
                this.Invalidate(); 
            }
            else
            {
                timer.Stop();
            }
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (currentPointIndex > 0)
            {
                e.Graphics.DrawLines(System.Drawing.Pens.Black, linePoints[..(currentPointIndex + 1)]);
            }
        }

        private System.Drawing.Point[] GenerateWavePoints(int width, int height, int amplitude, int frequency)
        {
            System.Drawing.Point[] points = new System.Drawing.Point[width];
            for (int i = 0; i < width; i++)
            {
                int y = (int)(height / 2 + amplitude * System.Math.Sin(2 * System.Math.PI * frequency * i / width));
                points[i] = new System.Drawing.Point(i, y);
            }
            return points;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            linePoints = GenerateWavePoints(800, 100, 10, 50);
        }
    }
}

