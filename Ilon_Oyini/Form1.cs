namespace Ilon_Oyini
{
    public partial class Form1 : Form
    {
        private int rj, ri;
        private PictureBox Meva;
        private PictureBox[] ilon = new PictureBox[400];
        private Label labelScore;
        private int dirX, dirY;
        private int _width = 900;
        private int _height = 800;
        private int _sizeOfSides = 40;
        private int score = 0;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Ilon";
            this.Width = _width;
            this.Height= _height;
            dirX = 1;
            dirY = 0;
            labelScore= new Label();
            labelScore.Text = "Score: 0";
            labelScore.Location = new Point(810, 10);
            this.Controls.Add(labelScore);
            ilon[0] = new PictureBox();
            ilon[0].Location = new Point(201, 201);
            ilon[0].Size = new Size(_sizeOfSides-1, _sizeOfSides-1);
            ilon[0].BackColor = Color.Red;
            this.Controls.Add(ilon[0]);
            Meva = new PictureBox();
            Meva.BackColor = Color.Blue;
            Meva.Size = new Size(_sizeOfSides, _sizeOfSides);
            chiziq();
            Mevani();
            timer1.Tick += new EventHandler(_update);
            timer1.Interval = 200;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OKP);
        }
        private void Mevani()
        {
            Random r = new Random();
            ri = r.Next(0, _height - _sizeOfSides);
            int tempi = ri % _sizeOfSides;
            ri -= tempi;
            rj = r.Next(0, _height - _sizeOfSides);
            int tempj = rj % _sizeOfSides;
            rj -= tempj;
            ri++;
            rj++;
            Meva.Location = new Point(ri, rj);
            this.Controls.Add(Meva);
        }

        private void chegarlar()
        {
            if (ilon[0].Location.X < 0)
            {
                for(int i = 1; i <= score; i++)
                {
                    this.Controls.Remove(ilon[i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirX = 1;
            }
            if (ilon[0].Location.X > _height)
            {
                for (int i = 1; i <= score; i++)
                {
                    this.Controls.Remove(ilon[i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirX = -1;
            }
            if (ilon[0].Location.Y < 0)
            {
                for (int i = 1; i <= score; i++)
                {
                    this.Controls.Remove(ilon[i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirY = 1;
            }
            if (ilon[0].Location.Y > _width)
            {
                for (int i = 1; i <= score; i++)
                {
                    this.Controls.Remove(ilon[i]);
                }
                score = 0;
                labelScore.Text = "Score: " + score;
                dirY = -1;
            }
        }
        private void oziniyeyish()
        {
            for (int i = 1; i < score; i++)
            {
                if (ilon[0].Location == ilon[i].Location)
                {
                    for (int j = i; j <= score; j++)
                        this.Controls.Remove(ilon[j]);
                    score = score - (score - i + 1);
                    labelScore.Text = "Score: " + score;
                }
            }
        }
        private void MevaniYeyish()
        {
            if (ilon[0].Location.X == ri && ilon[0].Location.Y == rj)
            {
                labelScore.Text = "Score: " + ++score;
                ilon[score] = new PictureBox();
                ilon[score].Location = new Point(ilon[score - 1].Location.X + 40 * dirX, ilon[score - 1].Location.Y - 40 * dirY);
                ilon[score].Size = new Size(_sizeOfSides - 1, _sizeOfSides - 1);
                ilon[score].BackColor = Color.Red;
                this.Controls.Add(ilon[score]);
                Mevani();
            }
        }
        private void chiziq()
        {
            for(int i = 0; i < _width / _sizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, _sizeOfSides * i);
                pic.Size = new Size(_width - 100, 1);
                this.Controls.Add(pic);
            }
            for (int i = 0; i <= _height / _sizeOfSides; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(_sizeOfSides * i, 0);
                pic.Size = new Size(1, _width);
                this.Controls.Add(pic);
            }
        }
        private void ilonYurishi()
        {
            for (int i = score; i >= 1; i--)
            {
                ilon[i].Location = ilon[i - 1].Location;
            }
            ilon[0].Location = new Point(ilon[0].Location.X + dirX * _sizeOfSides, ilon[0].Location.Y + dirY * _sizeOfSides);
            oziniyeyish();
        }
        private void _update(Object myObject, EventArgs eventsArgs)
        {
            chegarlar();
            MevaniYeyish();
            ilonYurishi();
        }
        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString()) 
            {
                case "Right":
                    dirX = 1;
                    dirY = 0;
                    break;
                case "Left":
                    dirX = -1;
                    dirY = 0;
                    break;
                case "Up":
                    dirY = -1;
                    dirX = 0;
                    break;
                case "Down":
                    dirY = 1;
                    dirX = 0;
                    break;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}