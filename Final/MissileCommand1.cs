//Kevin Ungerecht
//Missile Command for FINAL

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Final
{
    public partial class MissileCommand1 : Form
    {
        private int numMissiles = 30;
        private int missileLeft;
        private int numCities = 6;
        private int citiesLeft = 6;
        private bool speedIncrease = true;
        private int wave = 1;
        private bool drawn = false;
        private bool started = false;
        private int leftOrRight = 0;// 0 == left,  1 == right
        private Timer time1 = new Timer();//User shot missiles ticker
        private Timer time2 = new Timer();//Incoming enemy missiles ticker
        private int incomingTix = 0;
        private List<Missile> incoming = new List<Missile>();
        private List<Missile> incomingReserve = new List<Missile>();
        private List<PointF> buildings = new List<PointF>();
        private List<PointF> collisions = new List<PointF>();
        private List<Missile> missiles = new List<Missile>();
        private List<Missile> explosions = new List<Missile>();
        private List<string> scores = new List<string>();
        private bool rightAlive, leftAlive;
        private int insertIdx;
        private bool levelEnded = false;
       
        public MissileCommand1()
        {
            InitializeComponent();
            time1.Tick += new EventHandler( missileTick );
            time1.Interval = 30;
            time1.Enabled = false;
            time2.Tick += new EventHandler( incomingTick );
            time2.Enabled = false;
            buildings.Add(new PointF(200, 520));
            buildings.Add(new PointF(400, 520));

            bgmusic.Open(new Uri("underclocked.mp3",UriKind.Relative));
            bgmusic.MediaEnded += new EventHandler(music_ended);
            bgmusic.Play();
        }

        System.Windows.Media.MediaPlayer bgmusic = new System.Windows.Media.MediaPlayer();

        public void music_ended(object sender, EventArgs e) {
            bgmusic.Position = TimeSpan.Zero;
            bgmusic.Play();
        }

        public void missileTick(object sender, EventArgs e)//------------------------------------------------------Missiles shooting
        {

            if (incoming.Count == 0 && explosions.Count == 0)
            {//no more missiles end of level
                endLevel();
            }
            else if(started)
            {
                Pen p = new Pen(Color.DarkRed, 2);
                Graphics g = this.CreateGraphics();
                float x;
                float y;
                PointF pnt;
                foreach (Missile m in missiles)
                {
                    m.setTicks(m.getTicks() + 1);
                    x = (float)(m.getStart().X + ((m.getEnd().X - m.getStart().X) * (.05 * m.getTicks())));
                    y = (float)((m.getSlope() * x) + m.getB());
                    pnt = new PointF(x, y);
                    g.DrawLine(p, m.getStart(), pnt);
                    m.setStart(pnt);
                    if (pnt.X >= m.getEnd().X - 1 && pnt.X <= m.getEnd().X + 1 && pnt.Y >= m.getEnd().Y - 10 && pnt.Y <= m.getEnd().Y + 10)
                    {
                        eraseMissile(m);
                        explodeMissile(m);
                        missiles.Remove(m);
                        break;
                    }
                }
                foreach (Missile expl in explosions)
                {//un explode missiles animation
                    Brush br = new SolidBrush(Color.Black);
                    int w = 5 * expl.getTicks();
                    expl.setTicks(expl.getTicks() + 1);
                    g.FillEllipse(br, new Rectangle(Convert.ToInt32(expl.getEnd().X - 20), Convert.ToInt32(expl.getEnd().Y - 20), w, w));
                    g.FillEllipse(br, new Rectangle(Convert.ToInt32(expl.getEnd().X - 40), Convert.ToInt32(expl.getEnd().Y - 30), w, w));
                    if (expl.getTicks() > 10)
                    {
                        explosions.Remove(expl);
                        collisions.Remove(expl.getEnd());
                        break;
                    }
                    br.Dispose();
                }
                p.Dispose();
                g.Dispose();
            }

        }

        private void incomingTick(object sender, EventArgs e)
        {//--------------------------------------------------Missiles Incoming
            if (incoming.Count == 0 && explosions.Count == 0)
            {//no more missiles end of level
                endLevel();
            }
            else if (started)
            {
                Pen p = new Pen(Color.Lime, 1);
                Graphics g = this.CreateGraphics();
                float x;
                float y;
                PointF pnt;
                foreach (Missile m in incoming)
                {
                    m.setTicks(m.getTicks() + 1);
                    x = (float)(m.getStart().X + ((m.getEnd().X - m.getStart().X) * (0.00005 * m.getTicks())));
                    y = (float)((m.getSlope() * x) + m.getB());
                    pnt = new PointF(x, y);

                    if (y >= m.getEnd().Y - 40)
                    {
                        x = (float)(m.getStart().X + ((m.getEnd().X - m.getStart().X) * (.00025 * m.getTicks())));
                        y = (float)((m.getSlope() * x) + m.getB());
                        pnt = new PointF(x, y);
                        g.DrawLine(p, m.getStart(), pnt);
                    }
                    else
                    {
                        g.DrawLine(p, m.getStart(), pnt);
                    }

                    m.setStart(pnt);
                    float xEndOG = m.getEnd().X;
                    float yEndOG = m.getEnd().Y;
                    foreach (PointF c in collisions)
                    {
                        if (pnt.X >= c.X - 40 && pnt.X <= c.X + 30 && pnt.Y >= c.Y - 20 && pnt.Y <= c.Y + 30)
                        {//Collision detection in air
                            if (pnt.Y <= 500)
                            {
                                Score.Text = ((Convert.ToInt32(Score.Text) + 50)).ToString(); //add missile collison points 
                            }
                            m.setEnd(pnt);
                            collisions.Remove(c);
                            break;
                        }
                    }
                    if (pnt.X >= m.getEnd().X - 10 && pnt.X <= m.getEnd().X + 10 && pnt.Y >= m.getEnd().Y - 10 && pnt.Y <= m.getEnd().Y + 10)//end reached
                    {
                        eraseMissile(m);
                        explodeMissile(m);
                        incoming.Remove(m);
                        if (m.getEnd().X == xEndOG && m.getEnd().Y == yEndOG)
                        { //missile hit a building
                            if (m.getEnd().X != 200 && m.getEnd().X != 400)
                            {//missile hit a city
                                if (buildings.Remove(m.getEnd()))
                                {
                                    citiesLeft--;
                                }

                            }
                            else
                            {                                         //missile hit a tower
                                if (m.getEnd().X == 200)
                                {//left tower out
                                    leftAlive = false;
                                    if (rightAlive)
                                    {
                                        leftOrRight = 1;
                                    }
                                    else
                                    {
                                        leftOrRight = 3;
                                    }
                                }
                                else
                                {//right tower out
                                    rightAlive = false;
                                    if (leftAlive)
                                    {
                                        leftOrRight = 0;
                                    }
                                    else
                                    {
                                        leftOrRight = 3;
                                    }
                                }
                            }
                        }
                        break;
                    }
                }

                incomingTix++;
                if (incomingTix == 6)
                {//higher = more space between missiles
                    incomingTix = 0;
                    if (incomingReserve.Count > 0)
                    {
                        incoming.Add(incomingReserve[0]);
                        incomingReserve.Remove(incomingReserve[0]);
                    }
                }

                p.Dispose();
                g.Dispose();


            }
            else {
                incoming = new List<Missile>();
                explosions = new List<Missile>();
            }
        }

        private void eraseMissile(Missile m) {
            Pen p = new Pen(Color.Black, 4);
            Graphics g = CreateGraphics();
            g.DrawLine(p, m.getInitial(), m.getEnd());
            p.Dispose();
            g.Dispose();
        }

        System.Media.SoundPlayer sp = new System.Media.SoundPlayer("explode.wav");

        private void explodeMissile(Missile m) {
            sp.Play();
            Brush b = new SolidBrush(Color.Orange);
            Graphics g = CreateGraphics();
            g.FillEllipse(b, new Rectangle(Convert.ToInt32(m.getEnd().X - 40), Convert.ToInt32(m.getEnd().Y - 30), 50, 50));
            b = new SolidBrush(Color.Yellow);
            g.FillEllipse(b, new Rectangle(Convert.ToInt32(m.getEnd().X - 20), Convert.ToInt32(m.getEnd().Y - 20),40,40));
            m.setTicks(1);
            explosions.Add(m);
            collisions.Add(m.getEnd());
            b.Dispose();
            g.Dispose();

        }


        private void shootMissile(object sender, MouseEventArgs e)
        {
            if (started) {
                if (e.Y < 480 && e.Y > 50){//in bounds
                    if (missileLeft > 0)
                    {
                        PointF end = new PointF(e.X, e.Y);
                        if (leftOrRight == 0)
                        {//left - (200,510)
                            missiles.Add(new Missile(new Point(200, 510), end));
                            removeMissile();
                            if (rightAlive)
                            {
                                leftOrRight = 1;
                            }
                        }
                        else if (leftOrRight == 1)
                        {//right - (400, 510)
                            missiles.Add(new Missile(new Point(400, 510), end));
                            removeMissile();
                            if (leftAlive) {
                                leftOrRight = 0;
                            }
                        }
                        else {//towers are destroyed

                        }
                    }
                }
            }
            
               
        }

        private void removeMissile() {
            //remove a missile from storage
            if (numMissiles != 999)
            {
                Pen p = new Pen(Color.Cyan, 3);
                Graphics g = this.CreateGraphics();
                g.DrawLine(p, 150 + (7 * (missileLeft - 1)), 578, 150 + (7 * (missileLeft - 1)), 595);
                missileLeft--;
                p.Dispose();
                g.Dispose();
            }
        }

        private void MissileCommand1_Paint_1(object sender, PaintEventArgs e)
        {
            if (!drawn)
            {
                Brush b = new SolidBrush(Color.DarkTurquoise);
                Brush blk = new SolidBrush(Color.Black);
                Graphics g = this.CreateGraphics();
                g.FillRectangle(blk, new Rectangle(0,0,Width,Height));

                g.FillRectangle(b, new Rectangle(0, 550, 601, 100));//Bottom bar
                g.FillEllipse(b, new Rectangle(-20, 530, 40, 40));//
                g.FillEllipse(b, new Rectangle(-30, 535, 70, 50));//
                g.FillEllipse(b, new Rectangle(580, 530, 40, 40));//
                g.FillEllipse(b, new Rectangle(560, 535, 70, 50));//

                g.FillEllipse(b, new Rectangle(185, 530, 40, 40));//Left missile center --peak
                g.FillEllipse(b, new Rectangle(165, 535, 70, 50));// mound

                g.FillEllipse(b, new Rectangle(365, 535, 70, 50));//Right missile center -- mound
                g.FillEllipse(b, new Rectangle(375, 530, 40, 40));// peak

                b.Dispose();
                g.Dispose();
                blk.Dispose();
                this.drawn = true;
            }
        }

        private void drawBuildings() {
            Graphics g = this.CreateGraphics();
            drawTowers();
            //cities
            Brush b = new SolidBrush(Color.Gold);
            int[] points = {250, 320, 40, 110, 460, 530 };
            for (int i = 0; i < numCities; i++) {
                g.FillRectangle(b, new Rectangle(new Point(points[i], 545), new Size(30, 10)));
                g.FillRectangle(b, new Rectangle(new Point(points[i]+2, 535), new Size(4, 15)));
                g.FillRectangle(b, new Rectangle(new Point(points[i]+7, 530), new Size(6, 17)));
                g.FillRectangle(b, new Rectangle(new Point(points[i] + 13, 540), new Size(10, 15)));
                g.FillRectangle(b, new Rectangle(new Point(points[i] + 16, 535), new Size(5, 15)));
                g.FillRectangle(b, new Rectangle(new Point(points[i] + 26, 538), new Size(4, 15)));
                buildings.Add(new PointF(points[i]+13 ,530));
            }
            b.Dispose();
            g.Dispose(); 
        }

        private void drawTowers() {
            Brush b = new SolidBrush(Color.DarkTurquoise);
            Pen p = new Pen(Color.Snow, 3);//pen for borders
            p.Alignment = PenAlignment.Inset;
            Graphics g = this.CreateGraphics();

            g.FillEllipse(b, new Rectangle(185, 530, 40, 40));//Left missile center --peak
            g.FillEllipse(b, new Rectangle(165, 535, 70, 50));// mound

            g.FillEllipse(b, new Rectangle(365, 535, 70, 50));//Right missile center -- mound
            g.FillEllipse(b, new Rectangle(375, 530, 40, 40));// peak

            b = new SolidBrush(Color.SlateGray);
            //Missle tower left
            g.DrawLine(new Pen(Color.Red, 5), 200, 542, 200, 515);
            g.DrawLine(p, 192, 542, 200, 510);
            g.DrawLine(p, 208, 542, 200, 510);
            g.DrawLine(p, 192, 537, 208, 537);
            
            //Missle tower right
            g.DrawLine(new Pen(Color.Red, 5), 400, 542, 400, 515);
            g.DrawLine(p, 392, 542, 400, 510);
            g.DrawLine(p, 408, 542, 400, 510);
            g.DrawLine(p, 392, 537, 408, 537);
            
            b.Dispose();
            p.Dispose();
            g.Dispose();
        }

        private void drawMissiles() {
            if (numMissiles == 999)
            {//unlimited missiles
                label1.Text = "MISSILES:   UNLIMITED                               ";
            }
            else {
                Brush b = new SolidBrush(Color.Cyan);
                Pen p = new Pen(Color.Red, 3);
                Graphics g = this.CreateGraphics();
                g.FillRectangle(b, new Rectangle(115, 574, 470, 23));
                for (int i = 0; i < missileLeft; i++) {
                    g.DrawLine(p, 150 + (7*i), 578, 150 +(7*i), 595);
                }
                b.Dispose();
                p.Dispose();
                g.Dispose();
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            levelEnded = false;
            citiesLeft = numCities;
            titleLabel.Visible = false;
            Start.Visible = false;
            Start.Enabled = false;
            settingsButton.Visible = false;
            settingsButton.Enabled = false;
            toolStripStart.Enabled = false;
            toolStripPause.Enabled = true;
            toolStripReset.Enabled = true;
            hiScoreButt.Enabled = false;
            hiScoreButt.Visible = false;
            Level.Text = "LEVEL: 1";
            this.wave = 1;
            //Start the game on first level
            drawBuildings();
            beginLevel(this.wave);
        }

        private void beginLevel(int levelnum){
            levelEnded = false;
            this.leftAlive = true;
            this.rightAlive = true;
            this.leftOrRight = 0;
            this.missileLeft = numMissiles;
            drawMissiles();
            started = true;

            time1.Enabled = true;
            time1.Start();
            
            //incoming missiles speed
            if (speedIncrease)
            {
                time2.Interval = 55 - levelnum;
            }
            else {
                time2.Interval = 54;  
            }
            
            time2.Enabled = true;
            time2.Start();

            Random r = new Random();
            PointF begin;
            for (int i = 0; i < 5 + (levelnum * 5); i++) {//number of missiles
                begin = new PointF(r.Next(10, 591), 0);
                incomingReserve.Add(new Missile(begin, buildings[r.Next(0, citiesLeft + 2)]));
            }
            incoming.Add(incomingReserve[0]);//add first unique incoming missile
            incomingReserve.Remove(incomingReserve[0]);
        }

        private void endLevel() {
            if (!levelEnded)
            {
                levelEnded = true;
                started = false;
                time1.Stop();
                time1.Enabled = false;
                time2.Stop();
                time2.Enabled = false;
                toolStripPause.Enabled = false;

                int cityLeft = 0;
                foreach (PointF b in buildings)
                {
                    if (b.X != 200 && b.X != 400)
                    {
                        cityLeft++;
                    }
                }

                if (numMissiles == 999)
                {
                    Score.Text = (Convert.ToInt32(Score.Text) + ((cityLeft * 100) * wave)).ToString(); //add bonus for cities left
                }
                else
                {
                    Score.Text = (Convert.ToInt32(Score.Text) + ((cityLeft * 100) + (missileLeft * 20) * wave)).ToString(); //add bonus for cities and missiles left
                }

                if (cityLeft == 0)
                {
                    gameOver();
                }
                else
                {
                    nextLevel.Enabled = true;
                    nextLevel.Visible = true;
                }
            }
        }

        private void gameOver() {
            gameOverLabel.Visible = true;
            homeButton.Text = "MAIN MENU";
            homeButton.Visible = true;
            homeButton.Enabled = true;

            bool newScore = false;
            string[] split;
            int sc;
            readHiscores();
            int count = -1;
            if (scores.Count == 0)
            {
                newScore = true;
            }
            else
            {
                foreach (string s in scores)
                {
                    count++;
                    split = s.Split('>');
                    sc = Int32.Parse(split[1]);
                    if (Convert.ToInt32(this.Score.Text) > sc)
                    {
                        newScore = true;
                        break;
                    }
                }
            }
            if (newScore) {//new hi score
                nameLabel.Visible = true;
                enterName.Visible = true;
                enterName.Enabled = true;
                announcment.Visible = true;
                saveName.Visible = true;
                saveName.Enabled = true;
                insertIdx = count;
            }

        }

        private void toolStripStart_Click(object sender, EventArgs e)
        {
            Start_Click(sender, e);
        }

        private void toolStripPause_Click(object sender, EventArgs e)
        {
            if (toolStripPause.Text.Equals("Pause"))//Pause the game
            {
                toolStripPause.Text = "Unpause";
                toolStripPause.ToolTipText = "Unpause";
                time1.Stop();
                time2.Stop();
            }
            else { //Unpause the game
                toolStripPause.Text = "Pause";
                toolStripPause.ToolTipText = "Pause";
                time1.Start();
                time2.Start();
            }
        }

        private void toolStripReset_Click(object sender, EventArgs e) {

            toolStripReset.Enabled = false;
            toolStripPause.Enabled = false;
            toolStripStart.Enabled = true;
            Start.Visible = true;
            Start.Enabled = true;
            settingsButton.Visible = true;
            settingsButton.Enabled = true;
            hiScoreButt.Visible = true;
            hiScoreButt.Enabled = true;
            nextLevel.Enabled = false;
            nextLevel.Visible = false;
            gameOverLabel.Visible = false;
            titleLabel.Visible = true;
            nameLabel.Visible = false;
            enterName.Visible = false;
            enterName.Enabled = false;
            announcment.Visible = false;
            saveName.Enabled = false;
            saveName.Visible = false;

            //Stop timers
            time1.Stop();
            time2.Stop();

            //redraw map
            drawn = false;
            started = false;

            //reset lists
            incoming = new List<Missile>();
            incomingReserve = new List<Missile>();
            buildings = new List<PointF>();
            collisions = new List<PointF>();
            missiles = new List<Missile>();
            explosions = new List<Missile>();
            buildings.Add(new PointF(200, 520));
            buildings.Add(new PointF(400, 520));

            //extras
            incomingTix = 0;
            wave = 1;
            leftAlive = true;
            rightAlive = true;

            //texts
            Level.Text = "LEVEL: ";
            Score.Text = "0";

    }

        public Settings settings;

        private void settingsButton_Click(object sender, EventArgs e)
        {
            settings = new Settings();
            settings.isSaved = false;
            settings.ShowDialog();
            if (settings.isSaved) {
                this.numCities = settings.numCities;
                this.citiesLeft = numCities;
                this.numMissiles = settings.numMiss;
                this.speedIncrease = settings.speed;
            }
            settings.Close();
        }

        private void hiScoreButt_Click(object sender, EventArgs e)
        {
            titleLabel.Visible = false;
            Start.Visible = false;
            Start.Enabled = false;
            settingsButton.Visible = false;
            settingsButton.Enabled = false;
            toolStripStart.Enabled = false;
            hiScoreButt.Enabled = false;
            hiScoreButt.Visible = false;
            homeButton.Text = "BACK";
            homeButton.Visible = true;
            homeButton.Enabled = true;
            readHiscores();
            scoresList.Visible = true;
            for (int i = 0; i< scores.Count; i++) {
                scoresList.Text = scoresList.Text + (i+1) + ": " + scores.ElementAt(i)+"\n";
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            homeButton.Enabled = false;
            homeButton.Visible = false;
            toolStripReset_Click(sender, e);
            scoresList.Visible = false;
            scoresList.Text = "";
        }

        private void nextLevel_Click(object sender, EventArgs e)
        {
            nextLevel.Enabled = false;
            nextLevel.Visible = false;
            missileLeft = numMissiles;
            drawTowers();
            drawMissiles();
            this.wave++;
            Level.Text = "LEVEL: " + this.wave;
            beginLevel(wave);
            toolStripPause.Enabled = true;
        }

        private void saveName_Click(object sender, EventArgs e)
        {
            if (insertIdx > -1) {
                string s = enterName.Text + ">" + Score.Text;
                scores.Insert(insertIdx, s);
                if (scores.Count > 5) {
                    scores.RemoveAt(5);
                }
            }
            writeHiscores();
            saveName.Enabled = false;
            saveName.Visible = false;
            enterName.Enabled = false;
        }

        private void writeHiscores() {
            System.IO.StreamWriter sw = new System.IO.StreamWriter("scores.txt", false);
            foreach (string s in scores) {
                sw.WriteLine(s);
            }
            sw.Dispose();
        }

        private void readHiscores() {
            System.IO.StreamReader file = new System.IO.StreamReader("scores.txt");
            string line;
            scores = new List<string>();
            while ((line = file.ReadLine()) != null) {
                scores.Add(line);
            }
            file.Dispose();
        }
    }
}
