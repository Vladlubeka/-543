using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public class MainForm : Form
    {
        private Button startButton;
        private Timer timer;
        private int currentPointIndex;
        private Point[] linePoints;

        public MainForm()
        {
            startButton = new Button();
            startButton.Text = "Start";
            startButton.Location = new Point(10, 10);
            startButton.Click += StartButton_Click;

            timer = new Timer();
            timer.Interval = 50; // Интервал 50 миллисекунд
            timer.Tick += Timer_Tick;

            this.Controls.Add(startButton);
            this.Paint += MainForm_Paint;
            this.Size = new Size(800, 600);

            // Пример точки для рисования волнистой линии
            linePoints = GenerateWavePoints(800, 100, 10, 50);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            currentPointIndex = 0;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (currentPointIndex < linePoints.Length - 1)
            {
                currentPointIndex++;
                this.Invalidate(); // Перерисовываем форму
            }
            else
            {
                timer.Stop();
            }
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            if (currentPointIndex > 0)
            {
                e.Graphics.DrawLines(Pens.Black, linePoints[..(currentPointIndex + 1)]);
            }
        }

        private Point[] GenerateWavePoints(int width, int height, int amplitude, int frequency)
        {
            Point[] points = new Point[width];
            for (int i = 0; i < width; i++)
            {
                int y = (int)(height / 2 + amplitude * Math.Sin(2 * Math.PI * frequency * i / width));
                points[i] = new Point(i, y);
            }
            return points;
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(571, 436);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }
    }
}
