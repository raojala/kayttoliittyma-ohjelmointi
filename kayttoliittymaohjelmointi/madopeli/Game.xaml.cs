using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace madopeli
{
    /// <summary>
    /// classic old snake game in wpf
    /// </summary>
    public enum Direction
    {
        Up,
        Right,
        Down,
        Left
    };

    public partial class Game : Window
    {
        //variables and consts
        private const int minimi = 10;
        private const int maxHeight = 380;
        private const int maxWidth = 620;
        private const int snakeWidth = 10;
        private int snakeLength = 5;
        private int easiness = 50; // timerin ajastin aika ms
        private int score = 0;
        private List<Point> bonusPoints = new List<Point>(); // omena kokoelma
        private const int bonusCount = 4;
        private Random rnd = new Random(); // pisteiden arvontaa varten.
        private List<Point> snakeParts = new List<Point>(); // kärmeen häntä
        private Point startingPoint = new Point(100, 100);
        private Point currentPosition = new Point();
        private Direction lastDirection = Direction.Right;
        private Direction currentDirection = Direction.Right; // alussa lähtee aina oikealle
        private DispatcherTimer timer;
        private bool isPause = false;
        


        public Game()
        {

            InitializeComponent();
            //tarvittavat alustukset
            timer = new DispatcherTimer();
            timer.Interval= new TimeSpan(0,0,0,0, easiness);
            timer.Tick += new EventHandler(timer_Tick);

            // määritellään ikkunalle tapahtumankäsittelijä näppäimistön kuuntelua varten
            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);

            // piirretään omenat ja käärme
            InitBonusPoints();
            PaintSnake(startingPoint);
            currentPosition = startingPoint;

            // start game
            timer.Start();
        }

        private void InitBonusPoints()
        {

            for (int n = 0; n < bonusCount; n++)
            {
                PaintBonus(n);
            }
        }

        private void PaintBonus(int index)
        {
            // arvotaan omenalle piste eli X ja Y koordinaatti
            Point point = new Point(rnd.Next(minimi, maxWidth), rnd.Next(minimi, maxHeight));

            Ellipse omena = new Ellipse();
            omena.Fill = Brushes.Red;
            omena.Width = snakeWidth;
            omena.Height = snakeWidth;

            Canvas.SetTop(omena,point.Y);
            Canvas.SetLeft(omena, point.X);
            paintCanvas.Children.Insert(index, omena);
            bonusPoints.Insert(index, point);


        }

        private void PaintSnake (Point currentpoint)
        {

            Rectangle snake = new Rectangle();
            snake.Fill = Brushes.Violet;
            snake.Width = snakeWidth;
            snake.Height = snakeWidth;

            Canvas.SetTop(snake, currentpoint.Y);
            Canvas.SetLeft(snake, currentpoint.X);

            int count = paintCanvas.Children.Count;

            paintCanvas.Children.Add(snake);
            snakeParts.Add(currentPosition);
            // rajoitetaan käärmeen pituutta
            // bonuscount < snakelength
            if (count > snakeLength)
            {
                paintCanvas.Children.RemoveAt(count-snakeLength+(bonusCount-1));
                snakeParts.RemoveAt(count-snakeLength);
            }


        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            // muutetaan suuntaa näppäimistön painalluksen mukaan
            // mutta ei sallita 180 asteen käännöstä
            switch (e.Key)
            {
                case Key.Up:
                    if (currentDirection != Direction.Down)
                    {
                        currentDirection = Direction.Up;
                    }
                    break;
                case Key.Down:
                    if (currentDirection != Direction.Up)
                    {
                        currentDirection = Direction.Down;
                    }
                    break;
                case Key.Left:
                    if (currentDirection != Direction.Right)
                    {
                        currentDirection = Direction.Left;
                    }
                    break;
                case Key.Right:
                    if (currentDirection != Direction.Left)
                    {
                        currentDirection = Direction.Right;
                    }
                    break;
                case Key.Escape:
                    if(timer.IsEnabled)
                    {
                        GameOver();
                    }
                    else if (isPause == false)
                    {
                        this.Close();
                    }
                    break;
                case Key.P:
                    if (timer.IsEnabled)
                    {
                        timer.Stop();
                        isPause = true;
                    }
                    else
                    {
                        timer.Start();
                        isPause = false;
                    }
                    break;
            }
            lastDirection = currentDirection;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            switch (currentDirection)
            {
                case Direction.Up:
                    currentPosition.Y -= snakeWidth;
                    break;
                case Direction.Right:
                    currentPosition.X += snakeWidth;
                    break;
                case Direction.Down:
                    currentPosition.Y += snakeWidth;
                    break;
                case Direction.Left:
                    currentPosition.X -= snakeWidth;
                    break;
                default:
                    break;
            }
            PaintSnake(currentPosition);

            // törmäystarkastelu
            //TT#1 tarkastetaan onko kanvaasilla 
            if (currentPosition.X > maxWidth || currentPosition.X < minimi ||
                currentPosition.Y > maxHeight || currentPosition.Y < minimi)
            {
                GameOver();
            }
            //TT#2 tarkistetaan ettei pure omaan häntäänsä
            for (int i = 0; i < snakeParts.Count - 3; i++)
            {
                Point p = new Point(snakeParts[i].X, snakeParts[i].Y);

                if ((Math.Abs(p.X - currentPosition.X) < snakeWidth) &&
                    (Math.Abs(p.Y - currentPosition.Y) < snakeWidth))
                {
                    GameOver();
                }
            }
            //TT#3 tarkistetaan osuuko omenaan
            int n = 0;
            foreach (Point point in bonusPoints)
            {
                if ((Math.Abs(point.X - currentPosition.X) < snakeWidth) && 
                    (Math.Abs(point.Y - currentPosition.Y) < snakeWidth))
                {
                    // syödään omena
                    score++;
                    this.Title = "SnakeWPF your score: " + score;
                    bonusPoints.RemoveAt(n);
                    paintCanvas.Children.RemoveAt(n);
                    PaintBonus(n);
                    snakeLength++;
                    // nopeutetaan peliä
                    if (easiness > 5)
                    {
                        easiness--;
                        timer.Interval = new TimeSpan(0,0,0,0, easiness);
                    }
                    break;
                }
                n++;
            }
            // TT#
            // tarkistetaan osuuko kärmeen kehoon
        }

        private void GameOver ()
        {
            timer.Stop();
            GameOverShow();
            //MessageBox.Show("Your Score: " + score, "Game Over");
            //this.Close();
        }
        private void GameOverShow()
        {
            txtMessage.Text = "Your score: " + score + "\npress esc to quit";
            paintCanvas.Children.Add(txtMessage);

            //animaatio joka siirtää canvasin
            var trs = new TranslateTransform();
            var anim = new DoubleAnimation(0, 620, TimeSpan.FromSeconds(15));
            trs.BeginAnimation(TranslateTransform.XProperty, anim);
            trs.BeginAnimation(TranslateTransform.YProperty, anim);
            paintCanvas.RenderTransform = trs;

        }
    }
}
