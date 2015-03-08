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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;




namespace WpfApplication1
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        int catch1 = 0;
        int yy = 0;
        int xx = 0;
        int bugi = 0;
        int bbx, bby;
        int Aibbx, Aibby;
        public Image Aibomb; 
        bool upw = false;
        bool downw = false;
        bool leftw = false;
        bool rightw = false;
        bool topF = false, downF = false, leftF = false, rightF = false;
        bool AitopF = false, AidownF = false, AileftF = false, AirightF = false;
        public Image AIimg;
        public int stats,stats1;
        public Image[,] imgArr = new Image[11, 13];
        public Image[,] imgBug = new Image[11,13];
        public Image[,] imgJuice = new Image[11, 13];
        bool topW=true, downW=true, leftW=true, rightW=true;
        bool AitopW = true, AidownW = true, AileftW = true, AirightW = true;
        enum status { empty = 1, brick, wall, bomb, character,bomb1,character1,bug1 };
        public int x=0,Aix=12;
        public int bx = 0,Aibx=12;
        public int by = 0,Aiby=10;
        public int y = 0,Aiy=10;
        public int flag = 0,Aiflag=0;
        public string url;
        public Image img1;
        checkMap mycheckmap = new checkMap();
        Bomb mybmb = new Bomb();
        Character myChar = new Character();
        Character1 mychar1 = new Character1();
        brick mybrick = new brick();
        control ctrl = new control();
        bug1 bugArr = new bug1();
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
       // Aibmb myAIbmb = new Aibmb();
        public MainWindow()
        {
            InitializeComponent();
            //url = "map.jpg";
           // img1.Source = new ImageSourceConverter().ConvertFromString(url) as ImageSource;
           // main.Children.Add(img1);
            
            
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            int i;
            int j;
            for (i = 0; i <= 12; i++)
            {
                for (j = 0; j <= 10; j++)
                {
                    if (i % 2 == 1 && j % 2 == 1)
                    {
                        stats = (int)status.wall;
                        mycheckmap.set(i, j, stats);
                    }
                    else
                    {
                        stats = (int)status.empty;
                        mycheckmap.set(i, j, stats);
                    }
                }
            }

            player.Stream = Properties.Resources.bgm1;
            try
            {
                player.Load();
                player.Play();
            }
            catch (System.IO.FileNotFoundException err)
            {
                MessageBox.Show("找不到音效檔 " + err.FileName);
            }
            
           
            myChar.init();
            mybmb.init();
          // mychar1.init();
           this.init();
          // myAIbmb.init();
         //  this.initbmb();
           
            // myChar.myimg.Margin.Top = 197;
            Thickness Aimarginthickness = new Thickness();
           Thickness marginthickness= new Thickness();
           Aimarginthickness.Left = 450;
           Aimarginthickness.Top = -450;
            marginthickness.Left =- 450;
            marginthickness.Top = 400;
            myChar.myimg.Margin = marginthickness;
        //    mychar1.AIimg.Margin = Aimarginthickness;
            this.AIimg.Margin = Aimarginthickness;
            stats = (int)status.character;
            stats1 = (int)status.character1;
            mycheckmap.set(x, y, stats);
            mycheckmap.set(Aix, Aiy, stats1);
            main.Children.Add(myChar.myimg);
      //      main.Children.Add(mychar1.AIimg);
           main.Children.Add(this.AIimg);
            
            addbrick();
          //  Aimarginthickness.Left = Aimarginthickness.Left - 75; ;
          //  this.AIimg.Margin = Aimarginthickness;
            Aitimer();
           // MessageBox.Show(Aix.ToString(),(Aiy-1).ToString());
            //MessageBox.Show(mycheckmap.Carray[Aiy - 1, Aix - 1].ToString());
        }

        private void addbrick()
        {
            int i, j;
            Thickness brickthickness = new Thickness();
           
            for (i = 0; i <= 10; i++)
            {
                for (j = 0; j <= 12; j++)
                {
                    if ((i % 2 == 1 && j % 2 == 1)||(i<=2&&j==0)||(j<=2&&i==0)||(i==10&&j>=10)||(j==12&&i>=8)) { }
                    else
                    {
                        mybrick.init();
                        brickthickness.Left = -450 + 75 * j;
                        brickthickness.Top = 435- 85 * i;
                        mybrick.brickimg.Margin = brickthickness;
                        stats = (int)status.brick;
                        mycheckmap.set(j, i, stats);
                     //  mybrick.brkarray[j, i] = mybrick;
                       mybrick.brickx = j;
                       mybrick.bricky = i;
                       imgArr[i,j ] = mybrick.brickimg;
                       
                        main.Children.Add(mybrick.brickimg);
                    }
                }
            }
        }


       public int catch3(int i)
         {
             if (i == 2)
             {
                 return 2;
             }
             else
             {
                 return 1;
                
             }
         }

        private void Window_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
           
            if (e.Key == Key.Space)
            {
                PlaceBomb(1);
            }
            if (e.Key == Key.Up)
            {
                upWard(1);
               
            }
            else if (e.Key == Key.Down)
            {
                downWard(1);  
            }
            else if (e.Key == Key.Left)
            {
                leftWard(1);
            }
            else if (e.Key == Key.Right)
            {
                rightWard(1);
            }

        }
        public void timers(int i)
        {
            
           Timer t = new System.Timers.Timer();//實例化Timer類，設置間隔時間為10000毫秒； 
           t.Interval = 2000;
         
           if (i == 1)
           {
               t.Elapsed += new System.Timers.ElapsedEventHandler(cleanbmb);//到達時間的時候執行事件； 
               
           }
           else if (i == 2)
           {
               detect(Aix, Aiy, 3);
               t.Elapsed += new System.Timers.ElapsedEventHandler(cleanbmb2);
           }
            t.AutoReset = false;//設置是執行一次（false）還是一直執行(true)； 
            t.Stop();
            t.Enabled = true;//是否執行System.Timers.Timer.Elapsed事件； 
        }

        public void timers2(int i,int bx,int by,bool top,bool down,bool left,bool right)
        {

            Timer t = new System.Timers.Timer();//實例化Timer類，設置間隔時間為10000毫秒； 
            t.Interval = 1000;

            if (i == 1)
            {
                topF = top;
                downF = down;
                leftF = left;
                rightF = right;
                bbx = bx;
                bby = by;
                t.Elapsed += new System.Timers.ElapsedEventHandler(cleanjuice);//到達時間的時候執行事件； 
                
            }
            else if (i == 2)
            {
                
                Aibbx = bx;
                Aibby = by;
                AitopF = top;
                AidownF = down;
                AileftF = left;
                AirightF = right;
                t.Elapsed += new System.Timers.ElapsedEventHandler(cleanjuice2);
            }
            t.AutoReset = false;//設置是執行一次（false）還是一直執行(true)； 
            t.Stop();
            t.Enabled = true;//是否執行System.Timers.Timer.Elapsed事件； 
        }

        private void cleanjuice2(object sender, ElapsedEventArgs e)
        {
             Action dele = delegate()
            {
                if (AitopF == true)
                {
                    main.Children.Remove(imgJuice[Aibby+1, Aibbx]);
                }
              
                if (AidownF == true)
                {
                    main.Children.Remove(imgJuice[Aibby - 1, Aibbx]);
                }
                if (AileftF == true)
                {
                    main.Children.Remove(imgJuice[Aibby , Aibbx-1]);
                }
                if (AirightF == true)
                {
                    main.Children.Remove(imgJuice[Aibby , Aibbx+1]);
                }
                AitopF = false;
                AidownF = false;
                AileftF = false;
                AirightF = false;
            };
             this.Dispatcher.BeginInvoke(dele);
        }

        private void cleanjuice(object sender, ElapsedEventArgs e)
        {
            Action dele = delegate()
            {
                if (topF == true)
                {
                    main.Children.Remove(imgJuice[bby+1, bbx]);
                }
              
                if (downF == true)
                {
                    main.Children.Remove(imgJuice[bby - 1, bbx]);
                }
                if (leftF == true)
                {
                    main.Children.Remove(imgJuice[bby , bbx-1]);
                }
                if (rightF == true)
                {
                    main.Children.Remove(imgJuice[bby , bbx+1]);
                }
                topF = false;
                downF = false;
                leftF = false;
                rightF = false;

            };
            this.Dispatcher.BeginInvoke(dele);
        }

        private void cleanbmb2(object sender, ElapsedEventArgs e)
        {
            BombBomb(Aibx, Aiby, 2);
        }

        private void cleanbmb(object sender, ElapsedEventArgs e)
        {
            BombBomb(bx, by,1);
            
        }

        public void upWard(int i)
        {
            if (i == 1)
            {
                myChar.back();
                Thickness marginthickness = myChar.myimg.Margin;
                if (marginthickness.Top == -450 || (x % 2 == 1 && y % 2 == 0) || (mycheckmap.Carray[y + 1, x] == 2) || (mycheckmap.Carray[y + 1, x] == 4)) { }
                
                else
                {
                    y += 1;
                    if (mycheckmap.Carray[y, x] == 8)
                    {
                        MessageBox.Show("你被害蟲咬死了Q_Q");
                        main.Children.Remove(myChar.myimg);
                        player.Stop();
                        this.Close();
                    }
                    stats = (int)status.character;
                    mycheckmap.set(x, y, stats);
                    if (mycheckmap.Carray[y - 1, x] != 4)
                    {
                        stats = (int)status.empty;
                        mycheckmap.set(x, y - 1, stats);
                    }
                    marginthickness.Top = marginthickness.Top - 85;
                    myChar.myimg.Margin = marginthickness;
                   
                }
            }
            else if (i == 2) 
            {


                //MessageBox.Show(Aix.ToString(),Aiy.ToString());

                    Action method = delegate()
                    {
                        this.back();
                        Thickness marginthickness1 = this.AIimg.Margin;
                        if (marginthickness1.Top == -450 || (Aix % 2 == 1 && Aiy % 2 == 0) || (mycheckmap.Carray[Aiy + 1, Aix] == 2) || (mycheckmap.Carray[Aiy + 1, Aix] == 4)) { }
                        else
                        {
                            Aiy += 1;
                            stats1 = (int)status.character1;
                            mycheckmap.set(Aix, Aiy, stats1);
                            if (mycheckmap.Carray[Aiy - 1, Aix] != 4)
                            {
                                stats1 = (int)status.empty;
                                mycheckmap.set(Aix, Aiy - 1, stats1);
                            }
                            marginthickness1.Top = marginthickness1.Top - 85;
                            this.AIimg.Margin = marginthickness1;
                        }
                    };
                    this.Dispatcher.BeginInvoke(method);
            }
        }
        public void downWard(int i)
        {
            if (i == 1)
            {
                myChar.front();
                Thickness marginthickness = myChar.myimg.Margin;
                if (marginthickness.Top == 400 || (x % 2 == 1 && y % 2 == 0) || (mycheckmap.Carray[y - 1, x] == 2) || (mycheckmap.Carray[y - 1, x] == 4)) { }
                else
                {
                    y -= 1;
                    if (mycheckmap.Carray[y, x] == 8)
                    {
                        MessageBox.Show("你被害蟲咬死了Q_Q");
                        main.Children.Remove(myChar.myimg);
                        player.Stop();
                        this.Close();
                    }
                    stats = (int)status.character;
                    mycheckmap.set(x, y, stats);
                    if (mycheckmap.Carray[y + 1, x] != 4)
                    {
                        stats = (int)status.empty;
                        mycheckmap.set(x, y + 1, stats);
                    }
                    marginthickness.Top = marginthickness.Top + 85;
                    myChar.myimg.Margin = marginthickness;
                }
            }
            else if (i == 2)
            {
               // MessageBox.Show(Aix.ToString(), Aiy.ToString());

                Action method = delegate()
                {
                    this.front();
                    Thickness marginthickness1 = this.AIimg.Margin;
                    if (marginthickness1.Top == 400 || (Aix % 2 == 1 && Aiy % 2 == 0) || (mycheckmap.Carray[Aiy - 1, Aix] == 2) || (mycheckmap.Carray[Aiy - 1, Aix] == 4)) { }
                    else
                    {
                        Aiy -= 1;
                        stats1 = (int)status.character1;
                        mycheckmap.set(Aix, Aiy, stats1);
                        if (mycheckmap.Carray[Aiy + 1, Aix] != 4)
                        {
                            stats1 = (int)status.empty;
                            mycheckmap.set(Aix, Aiy + 1, stats1);
                        }
                        marginthickness1.Top = marginthickness1.Top + 85;
                        this.AIimg.Margin = marginthickness1;
                    }
                };
                this.Dispatcher.BeginInvoke(method);
            }
        }

        public void rightWard(int i)
        {
            if (i == 1)
            {
                myChar.right();
                Thickness marginthickness = myChar.myimg.Margin;
                if (marginthickness.Left == 450 || (x % 2 == 0 && y % 2 == 1) || (mycheckmap.Carray[y, x + 1] == 2) || (mycheckmap.Carray[y, x + 1] == 4)) { }
                else
                {
                    x += 1;
                    if (mycheckmap.Carray[y, x] == 8)
                    {
                        MessageBox.Show("你被害蟲咬死了Q_Q");
                        main.Children.Remove(myChar.myimg);
                        player.Stop();
                        this.Close();
                    }
                    stats = (int)status.character;

                    mycheckmap.set(x, y, stats);
                    if (mycheckmap.Carray[y, x - 1] != 4)
                    {
                        stats = (int)status.empty;
                        mycheckmap.set(x - 1, y, stats);
                    }

                    marginthickness.Left = marginthickness.Left + 75;
                    myChar.myimg.Margin = marginthickness;
                }
            }
            else if (i == 2)
            {
               // MessageBox.Show(Aix.ToString(), Aiy.ToString());

                Action method = delegate()
                {
                    this.right();
                    Thickness marginthickness1 = this.AIimg.Margin;
                    if (marginthickness1.Left == 450 || (Aix % 2 == 0 && Aiy % 2 == 1) || (mycheckmap.Carray[Aiy, Aix + 1] == 2) || (mycheckmap.Carray[Aiy, Aix + 1] == 4)) { }
                    else
                    {
                        Aix += 1;
                        stats1 = (int)status.character1;
                        mycheckmap.set(Aix, Aiy, stats1);
                        if (mycheckmap.Carray[Aiy, Aix - 1] != 4)
                        {
                            stats1 = (int)status.empty;
                            mycheckmap.set(Aix - 1, Aiy, stats1);
                        }
                        marginthickness1.Left = marginthickness1.Left + 75; ;
                        this.AIimg.Margin = marginthickness1;
                    }
                };
                this.Dispatcher.BeginInvoke(method);
            }
        }
        public void leftWard(int i)
        {
            if (i == 1)
            {
                myChar.left();
                Thickness marginthickness = myChar.myimg.Margin;
                if (marginthickness.Left == -450 || (x % 2 == 0 && y % 2 == 1) || (mycheckmap.Carray[y, x - 1] == 2) || (mycheckmap.Carray[y, x - 1] == 4)) { }
                else
                {
                    x -= 1;
                    if (mycheckmap.Carray[y, x] == 8)
                    {
                        MessageBox.Show("你被害蟲咬死了Q_Q");
                        main.Children.Remove(myChar.myimg);
                        player.Stop();
                        this.Close();
                    }
                    stats = (int)status.character;
                    mycheckmap.set(x, y, stats);
                    if (mycheckmap.Carray[y, x + 1] != 4)
                    {
                        stats = (int)status.empty;
                        mycheckmap.set(x + 1, y, stats);
                    }
                    marginthickness.Left = marginthickness.Left - 75;
                    myChar.myimg.Margin = marginthickness;
                }
            }
            else if (i == 2)
            {
               // MessageBox.Show(Aix.ToString(), Aiy.ToString());

                Action method = delegate()
                {
                    this.left();
                    Thickness marginthickness1 =this.AIimg.Margin;

                    if (marginthickness1.Left == -450 || (Aix % 2 == 0 && Aiy % 2 == 1) || (mycheckmap.Carray[Aiy, Aix - 1] == 2) || (mycheckmap.Carray[Aiy, Aix - 1] == 4)) { }
                    else
                    {
                        Aix -= 1;
                        stats1 = (int)status.character1;
                        mycheckmap.set(Aix, Aiy, stats1);
                        if (mycheckmap.Carray[Aiy, Aix + 1] != 4)
                        {
                            stats1 = (int)status.empty;
                            mycheckmap.set(Aix + 1, Aiy, stats1);
                        }
                        marginthickness1.Left = marginthickness1.Left - 75; ;
                       this.AIimg.Margin = marginthickness1;
                    }
                };
                
                this.Dispatcher.BeginInvoke(method);
            }
        }
        public void PlaceBomb(int i)
        {
            if (i == 1)
            {
                if (flag == 1) { }
                else
                {
                    bx = x;
                    by = y;
                    Thickness marginthickness = myChar.myimg.Margin;
                    marginthickness.Top = marginthickness.Top + 40;
                    mybmb.bomb.Margin = marginthickness;
                    stats = (int)status.bomb;
                    mycheckmap.set(bx, by, stats);
                    main.Children.Add(mybmb.bomb);
                    flag = 1;
                    timers(1);

                }
            }
            else if (i == 2)
            {

                if (Aiflag == 1) { }
                else
                {
                    Action method = delegate()
                    {
                        Aibx = Aix;
                        Aiby = Aiy;
                        Thickness marginthickness1 = this.AIimg.Margin;
                        marginthickness1.Top = marginthickness1.Top + 40;
                        //marginthickness1.Left += 30;
                            this.initbmb();
                        
                       Aibomb.Margin = marginthickness1;
                        stats1 = (int)status.bomb1;
                        mycheckmap.set(Aibx, Aiby, stats1);
                        
                        main.Children.Add(Aibomb);
                       
                        Aiflag = 1;
                        timers(2);
                        
                   };
                    this.Dispatcher.BeginInvoke(method);

                }
            }
        }
        public void BombBomb(int bx, int by,int i)
        {
            if (i == 1)
            {
                Action methodDelegate = delegate()
                {
                    
                    main.Children.Remove(mybmb.bomb);
                    mycheckmap.Carray[by, bx] = 1;
                    if (mycheckmap.Carray[by, bx] == 5||(x==bx&&y==by))
                    {
                        MessageBox.Show("你掛了");
                        main.Children.Remove(myChar.myimg);
                        player.Stop();
                        this.Close();
                    }
                    else if (mycheckmap.Carray[by, bx] == 2)
                    {

                    }
                  
                    if (bx + 1 <= 12)
                    {
                        if (mycheckmap.Carray[by, bx + 1] == 5)
                        {
                            MessageBox.Show("你掛了");
                            main.Children.Remove(myChar.myimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[by, bx + 1] == 7)
                        {
                            MessageBox.Show("你贏了");
                            main.Children.Remove(this.AIimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[by, bx + 1] == 2 && bx + 1 <= 12)
                        {
                            rightW = false;
                            main.Children.Remove(imgArr[by, bx + 1]);
                            int a=ctrl.RandomNum();
                            if (a == 1)
                            {
                                bug1 bugg = new bug1();
                                bugg.init();

                                Thickness margin1 = new Thickness();
                                margin1 = getBrick(bx + 1, by);
                                imgBug[by,bx+1] = bugg.bugimg;
                               imgBug[by,bx+1].Margin = margin1;
                                main.Children.Add(imgBug[by,bx+1]);
                                stats = (int)status.bug1;
                                mycheckmap.set(bx + 1, by, stats);
                                bugi++;
                            }
                            else
                            {

                                stats = (int)status.empty;
                                mycheckmap.set(bx + 1, by, stats);
                            }
                            

                        }
                        else if (mycheckmap.Carray[by, bx + 1] == 8 && bx + 1 <= 12)
                        {
                            main.Children.Remove(imgBug[by, bx + 1]);
                            stats = (int)status.empty;
                            mycheckmap.set(bx+1, by , stats);
                        }
                        else { }
                    }
                    if (bx - 1 >= 0)
                    {
                        if (mycheckmap.Carray[by, bx - 1] == 5)
                        {
                            MessageBox.Show("你掛了");
                            main.Children.Remove(myChar.myimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[by, bx - 1] == 7)
                        {
                            MessageBox.Show("你贏了");
                            main.Children.Remove(this.AIimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[by, bx - 1] == 2 && bx - 1 >= 0)
                        {
                            leftW = false;
                            main.Children.Remove(imgArr[by, bx - 1]);
                            int a = ctrl.RandomNum();
                            if (a == 1)
                            {
                                Thickness margin1 = new Thickness();
                                margin1 = getBrick(bx - 1, by);
                                 bug1 bugg = new bug1();
                                bugg.init();

                               // Thickness margin1 = new Thickness();
                              //  margin1 = getBrick(bx + 1, by);
                                imgBug[by,bx-1] = bugg.bugimg;
                               imgBug[by,bx-1].Margin = margin1;
                               main.Children.Add(imgBug[by,bx-1]);
                                stats = (int)status.bug1;
                                mycheckmap.set(bx - 1, by, stats);
                                bugi++;
                            }
                            else
                            {
                                stats = (int)status.empty;
                                mycheckmap.set(bx - 1, by, stats);
                            }

                        }
                        else if (mycheckmap.Carray[by, bx - 1] == 8 && bx + 1 <= 12)
                        {
                            main.Children.Remove(imgBug[by, bx - 1]);
                            stats = (int)status.empty;
                            mycheckmap.set(bx-1, by , stats);
                        }
                        
                    }

                    if (by + 1 <= 10)
                    {
                        if (mycheckmap.Carray[by + 1, bx] == 5)
                        {
                            MessageBox.Show("你掛了");
                            main.Children.Remove(myChar.myimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[by + 1, bx] == 7)
                        {
                            MessageBox.Show("你贏了");
                            main.Children.Remove(this.AIimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[by + 1, bx] == 2)
                        {
                            topW = false;
                            main.Children.Remove(imgArr[by + 1, bx]);
                            int a = ctrl.RandomNum();
                            if (a == 1)
                            {
                                Thickness margin1 = new Thickness();
                                margin1 = getBrick(bx , by+1);
                                bug1 bugg = new bug1();
                                bugg.init();

                               // Thickness margin1 = new Thickness();
                              //  margin1 = getBrick(bx + 1, by);
                                imgBug[by+1,bx] = bugg.bugimg;
                               imgBug[by+1,bx].Margin = margin1;
                               main.Children.Add(imgBug[by+1,bx]);
                                stats = (int)status.bug1;
                                mycheckmap.set(bx , by+1, stats);
                                bugi++;
                            }
                            else
                            {
                                stats = (int)status.empty;
                                mycheckmap.set(bx , by+1, stats);
                            }

                        }
                        else if (mycheckmap.Carray[by+1, bx ] == 8 && bx + 1 <= 12)
                        {
                            main.Children.Remove(imgBug[by+1, bx ]);
                            stats = (int)status.empty;
                            mycheckmap.set(bx, by + 1, stats);
                        }
                        else
                        {
                        }
                    }
                    if (by - 1 >= 0)
                    {
                        if (mycheckmap.Carray[by - 1, bx] == 5 && by - 1 >= 0)
                        {
                            MessageBox.Show("你掛了");
                            main.Children.Remove(myChar.myimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[by - 1, bx] == 7)
                        {
                            MessageBox.Show("你贏了");
                            main.Children.Remove(this.AIimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[by - 1, bx] == 2 && by - 1 >= 0)
                        {
                            downW = false;
                            main.Children.Remove(imgArr[by - 1, bx]);
                            int a = ctrl.RandomNum();
                            if (a == 1)
                            {
                                Thickness margin1 = new Thickness();
                                margin1 = getBrick(bx, by - 1);
                                 bug1 bugg = new bug1();
                                bugg.init();

                               // Thickness margin1 = new Thickness();
                              //  margin1 = getBrick(bx + 1, by);
                                imgBug[by-1,bx] = bugg.bugimg;
                               imgBug[by-1,bx].Margin = margin1;
                               main.Children.Add(imgBug[by-1,bx]);
                                stats = (int)status.bug1;
                                mycheckmap.set(bx, by - 1, stats);
                                bugi++;
                            }
                            else
                            {
                                stats = (int)status.empty;
                                mycheckmap.set(bx, by - 1, stats);
                            }


                        }
                        else if (mycheckmap.Carray[by-1, bx ] == 8 && bx + 1 <= 12)
                        {
                            main.Children.Remove(imgBug[by-1, bx ]);
                            stats = (int)status.empty;
                            mycheckmap.set(bx, by - 1, stats);
                        }
                        
                    }
                    flag = 0;
                    Thickness margin2 = new Thickness();

                    if (topW == true && by + 1 <= 10 && mycheckmap.Carray[by+1, bx ] != 3)
                    {
                        topF = true;
                        juice hamiTop = new juice();
                        hamiTop.init(1);
                        margin2 = getBrick(bx, by + 1);
                        hamiTop.hamijuice.Margin = margin2;
                        imgJuice[by+1, bx ] = hamiTop.hamijuice;
                        main.Children.Add(hamiTop.hamijuice);
                        


                    }
                    if (leftW == true && bx - 1 >= 0 && mycheckmap.Carray[by, bx - 1] != 3)
                    {
                        leftF = true;
                        juice hamiTop = new juice();
                        hamiTop.init(1);
                        margin2 = getBrick(bx-1, by );
                        hamiTop.hamijuice.Margin = margin2;
                        imgJuice[by, bx - 1] = hamiTop.hamijuice;
                        main.Children.Add(hamiTop.hamijuice);
                       
                    }
                    if (rightW == true&&bx+1<=12&&mycheckmap.Carray[by,bx+1]!=3)
                    {
                        rightF = true;
                        juice hamiTop = new juice();
                        hamiTop.init(1);
                        margin2 = getBrick(bx+1, by );
                        hamiTop.hamijuice.Margin = margin2;
                        imgJuice[by, bx + 1] = hamiTop.hamijuice;
                        main.Children.Add(hamiTop.hamijuice);
                        
                    }

                    if (downW == true && by - 1 >= 0 && mycheckmap.Carray[by-1, bx ] != 3)
                    {
                       
                        downF = true;
                        juice hamiTop = new juice();
                        hamiTop.init(1);
                        margin2 = getBrick(bx, by-1  );
                        hamiTop.hamijuice.Margin = margin2;
                        imgJuice[by-1, bx ] = hamiTop.hamijuice;
                        main.Children.Add(hamiTop.hamijuice);
                        
                    }
                    timers2(1, bx, by, topF, downF, leftF, rightF);
                    downW = true;
                    rightW = true;
                    topW = true;
                    leftW = true;
                };
                this.Dispatcher.BeginInvoke(methodDelegate);
            }
            else if (i == 2)
            {
              
                Action methodDelegate1 = delegate()
                {
                    ugdBoard.Children.Remove(Aibomb);
                    main.Children.Remove(Aibomb);
                    mycheckmap.Carray[Aiby, Aibx] = 1;
                    if (mycheckmap.Carray[Aiby, Aibx] == 5 || (Aix == Aibx && Aiy == Aiby))
                    {
                        MessageBox.Show("你贏了");
                        main.Children.Remove(this.AIimg);
                        player.Stop();
                        this.Close();
                    }
                    else if (mycheckmap.Carray[Aiby, Aibx] == 2)
                    {

                    }
                    else
                    {
                    }
                    if (Aibx + 1 <= 12)
                    {
                        if (mycheckmap.Carray[Aiby, Aibx + 1] == 7)
                        {
                            MessageBox.Show("你贏了");
                            main.Children.Remove(this.AIimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[Aiby, Aibx + 1] == 5)
                        {
                            MessageBox.Show("你掛了");
                            main.Children.Remove(myChar.myimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[Aiby, Aibx + 1] == 2 && Aibx + 1 <= 12)
                        {
                            main.Children.Remove(Aibomb);
                            main.Children.Remove(imgArr[Aiby, Aibx + 1]);
                            stats1 = (int)status.empty;
                            mycheckmap.set(Aibx + 1, Aiby, stats1);


                        }
                        
                    }
                    if (Aibx - 1 >= 0)
                    {
                        if (mycheckmap.Carray[Aiby, Aibx - 1] == 5)
                        {
                            MessageBox.Show("你贏了");
                            main.Children.Remove(this.AIimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[Aiby, Aibx - 1] == 5)
                        {
                            MessageBox.Show("你掛了");
                            main.Children.Remove(myChar.myimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[Aiby, Aibx - 1] == 2 && Aibx - 1 >= 0)
                        {
                            main.Children.Remove(Aibomb);
                            main.Children.Remove(imgArr[Aiby, Aibx - 1]);
                            stats1 = (int)status.empty;
                            mycheckmap.set(Aibx - 1, Aiby, stats1);

                        }
                        else
                        {
                        }
                    }

                    if (Aiby + 1 <= 10)
                    {
                        if (mycheckmap.Carray[Aiby + 1, Aibx] == 5)
                        {
                            MessageBox.Show("你贏了");
                            main.Children.Remove(this.AIimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[Aiby+1, Aibx ] == 5)
                        {
                            MessageBox.Show("你掛了");
                            main.Children.Remove(myChar.myimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[Aiby + 1, Aibx] == 2)
                        {
                            main.Children.Remove(Aibomb);
                            main.Children.Remove(imgArr[Aiby + 1, Aibx]);
                            stats1 = (int)status.empty;
                            mycheckmap.set(Aibx, Aiby + 1, stats1);

                        }
                        else
                        {
                        }
                    }
                    if (Aiby - 1 >= 0)
                    {
                        if (mycheckmap.Carray[Aiby - 1, Aibx] == 5 && Aiby - 1 >= 0)
                        {
                            MessageBox.Show("你贏了");
                            main.Children.Remove(this.AIimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[Aiby-1, Aibx ] == 5)
                        {
                            MessageBox.Show("你掛了");
                            main.Children.Remove(myChar.myimg);
                            player.Stop();
                            this.Close();
                        }
                        else if (mycheckmap.Carray[Aiby - 1, Aibx] == 2 && Aiby - 1 >= 0)
                        {
                            main.Children.Remove(Aibomb);
                            main.Children.Remove(imgArr[Aiby - 1, Aibx]);
                            stats1 = (int)status.empty;
                            mycheckmap.set(Aibx, Aiby - 1, stats1);


                        }
                        else { }
                    }
                    Aiflag = 0;
                    xx = 0;
                    yy = 0;
                    Thickness margin2 = new Thickness();

                    if (AitopW == true && Aiby + 1 <= 10 && mycheckmap.Carray[Aiby + 1, Aibx] != 3)
                    {
                        AitopF = true;
                        juice orgTop = new juice();
                        orgTop.init(2);
                        margin2 = getBrick(Aibx, Aiby + 1);
                        orgTop.orgjuice.Margin = margin2;
                        imgJuice[Aiby + 1, Aibx] = orgTop.orgjuice;
                        main.Children.Add(orgTop.orgjuice);



                    }
                    if (AileftW == true && Aibx - 1 >= 0 && mycheckmap.Carray[Aiby, Aibx - 1] != 3)
                    {
                        AileftF = true;
                        juice orgTop = new juice();
                        orgTop.init(2);
                        margin2 = getBrick(Aibx-1, Aiby );
                        orgTop.orgjuice.Margin = margin2;
                        imgJuice[Aiby , Aibx-1] = orgTop.orgjuice;
                        main.Children.Add(orgTop.orgjuice);

                    }
                    if (AirightW == true && Aibx + 1 <= 12 && mycheckmap.Carray[Aiby, Aibx + 1] != 3)
                    {
                        AirightF = true;
                        juice orgTop = new juice();
                        orgTop.init(2);
                        margin2 = getBrick(Aibx+1, Aiby );
                        orgTop.orgjuice.Margin = margin2;
                        imgJuice[Aiby , Aibx+1] = orgTop.orgjuice;
                        main.Children.Add(orgTop.orgjuice);

                    }

                    if (AidownW == true && Aiby - 1 >= 0 && mycheckmap.Carray[Aiby - 1, Aibx] != 3)
                    {

                        AidownF = true;
                        juice orgTop = new juice();
                        orgTop.init(2);
                        margin2 = getBrick(Aibx, Aiby - 1);
                        orgTop.orgjuice.Margin = margin2;
                        imgJuice[Aiby - 1, Aibx] = orgTop.orgjuice;
                        main.Children.Add(orgTop.orgjuice);

                    }
                    timers2(2, Aibx, Aiby, AitopF, AidownF, AileftF, AirightF);
                    AidownW = true;
                    AirightW = true;
                    AitopW = true;
                    AileftW = true;
                };
                this.Dispatcher.BeginInvoke(methodDelegate1);
            }
        }
        public void Aitimer()
        {
            Timer Ait = new System.Timers.Timer();//實例化Timer類，設置間隔時間為10000毫秒； 
            Ait.Interval = 200;
            Ait.Enabled = true;//是否執行System.Timers.Timer.Elapsed事件； 
            Ait.Elapsed += new System.Timers.ElapsedEventHandler(controlAI);//到達時間的時候執行事件； 
            Ait.AutoReset = true;

            //t.AutoReset = false;//設置是執行一次（false）還是一直執行(true)； 
            // t.Stop();
        }

        public void controlAI(object sender, ElapsedEventArgs e)
        {
            int a;

            detect(Aix, Aiy, 2);

            a=ctrl.RandomNum();

            if (a == 1&&xx==0)
            {
                detect(Aix, Aiy,1);
                if (upw == true)
                {
                    upWard(2);
                    downw = false;
                    leftw = false;
                    upw = false;
                    rightw = false;
                }
            }
            else if (a == 2&&xx==0)
            {
                detect(Aix, Aiy,1);
              //  MessageBox.Show(downw.ToString());
                if (downw == true)
                {
                    downWard(2);
                    downw = false;
                    leftw = false;
                    upw = false;
                    rightw = false;
                }

            }
            else if (a == 3&&xx==0)
            {
                detect(Aix, Aiy,1);
               // MessageBox.Show(leftw.ToString());
                if (leftw == true)
                {
                    leftWard(2);
                    downw = false;
                    leftw = false;
                    upw = false;
                    rightw = false;
                }
            }
            else if (a == 4&&xx==0)
            {
                detect(Aix, Aiy,1);
                if (rightw == true)
                {
                    rightWard(2);
                    downw = false;
                    leftw = false;
                    upw = false;
                    rightw = false;
                }
            }
        }

        public void detect(int Aix, int Aiy,int i)
        {

            if (i == 1)
            {
                if (Aix > 0 && mycheckmap.Carray[Aiy, Aix - 1] == 1)
                {
                    leftw = true;

                }
                if (Aix < 12 && mycheckmap.Carray[Aiy, Aix + 1] == 1)
                {
                    rightw = true;
                }
                if (Aiy > 0 && mycheckmap.Carray[Aiy - 1, Aix] == 1)
                {
                    // MessageBox.Show("HI");
                    downw = true;
                }
                if (Aiy < 10 && mycheckmap.Carray[Aiy + 1, Aix] == 1)
                {
                    upw = true;
                }
            }
            else if (i == 2)
            {
                if (Aiy < 10)
                {
                    if (mycheckmap.Carray[Aiy + 1, Aix] == 2&&xx==0)
                    {
                        PlaceBomb(2);
                       // detect(Aix, Aiy, 3);
                        xx = 1;
                    }
                }
                if (Aiy > 0)
                {
                    if (mycheckmap.Carray[Aiy - 1, Aix] == 2&&xx==0)
                    {
                        PlaceBomb(2);
                      //  detect(Aix, Aiy, 3);
                        xx = 1;
                    }
                }
                if (Aix < 12)
                {
                    if (mycheckmap.Carray[Aiy, Aix + 1] == 2&&xx==0)
                    {
                        PlaceBomb(2);
                       // detect(Aix, Aiy, 3);
                        xx = 1;
                    }
                }
                if(Aix>0){
                    if(mycheckmap.Carray[Aiy,Aix-1]==2&&xx==0)
                    {
                        PlaceBomb(2);
                     //   detect(Aix, Aiy, 3);
                        xx = 1;
                    }
                }
               // if ((mycheckmap.Carray[Aiy + 1, Aix] == 2&&Aiy<10) || (mycheckmap.Carray[Aiy - 1, Aix] == 2&&Aiy>0) || (mycheckmap.Carray[Aiy, Aix + 1] == 2&&Aix<12) || (mycheckmap.Carray[Aiy, Aix - 1] == 2&&Aix>0))
              //  {
              //      PlaceBomb(2);
             //   }
            }
            else if (i == 3)
            {
                int flagg = 0;
                if (Aix > 0 && mycheckmap.Carray[Aiy, Aix - 1] == 1&&flagg==0)
                {
                    leftWard(2);
                    flagg = 1;
                    Aix -= 1;
                    if (yy == 0)
                    {
                        yy++;
                        detect(Aix, Aiy, 3);
                       
                    }

                }
                if (Aix < 12 && mycheckmap.Carray[Aiy, Aix + 1] == 1&&flagg==0)
                {
                    rightWard(2);
                    flagg = 1;
                    Aix += 1;
                    if (yy == 0)
                    {
                        yy++;
                        detect(Aix, Aiy, 3);
                      
                    }
                }
                if (Aiy > 0 && mycheckmap.Carray[Aiy - 1, Aix] == 1&&flagg==0)
                {
                    downWard(2);
                    flagg = 1;
                    Aiy -= 1;
                    if (yy == 0)
                    {
                        yy++;
                        detect(Aix, Aiy, 3);
                      
                    }
                }
                if (Aiy < 10 && mycheckmap.Carray[Aiy + 1, Aix] == 1&&flagg==0)
                {
                    upWard(2);
                    flagg = 1;
                    Aiy += 1;
                    if (yy == 0)
                    {
                        yy++;
                        detect(Aix, Aiy, 3);
                        
                    }
                }
            }
        }
      
        public void init()
        {
            AIimg = new Image();
            string packUri = "pack://application:,,,/橘子超人正面.png";
            AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
            AIimg.Width = 80;
            AIimg.BringIntoView();
            AIimg.Height = 80;


        }
        public void front()
        {
          //  string packUri = "C:\\Users\\Tim\\Documents\\Visual Studio 2012\\Projects\\WpfApplication1\\WpfApplication1\\橘子超人正面.png";
            Action method = delegate()
            {
                string packUri = "pack://application:,,,/橘子超人正面.png";
              
                AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                AIimg.Width = 80;
                AIimg.BringIntoView();
                AIimg.Height = 80;
            };
            this.Dispatcher.BeginInvoke(method);
        }
        public void back()
        {
           // string packUri = "C:\\Users\\Tim\\Documents\\Visual Studio 2012\\Projects\\WpfApplication1\\WpfApplication1\\橘子超人背面.png";
        //    Action method = delegate()
         //   {
            string packUri = "pack://application:,,,/橘子超人背面.png";
             
                AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                AIimg.Width = 80;
                AIimg.BringIntoView();
                AIimg.Height = 80;
         //   };
          //  this.Dispatcher.BeginInvoke(method);

        }
        public void left()
        {
           // string packUri = "C:\\Users\\Tim\\Documents\\Visual Studio 2012\\Projects\\WpfApplication1\\WpfApplication1\\橘子超人左.png";
            Action method = delegate()
            {
                string packUri = "pack://application:,,,/橘子超人右.png";
            
                AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                AIimg.Width = 100;
                AIimg.BringIntoView();
                AIimg.Height = 80;
            };
            this.Dispatcher.BeginInvoke(method);


        }
        public void right()
        {
          //  string packUri = "C:\\Users\\Tim\\Documents\\Visual Studio 2012\\Projects\\WpfApplication1\\WpfApplication1\\橘子超人右.png";
            Action method = delegate()
            {
                string packUri = "pack://application:,,,/橘子超人左.png";
              
                AIimg.Source = new ImageSourceConverter().ConvertFromString(packUri) as ImageSource;
                AIimg.Width = 100;
                AIimg.BringIntoView();
                AIimg.Height = 80;
            };
            this.Dispatcher.BeginInvoke(method);
        }
        public void initbmb()
        {
            Aibomb = new Image();

            string packUrl1 = "pack://application:,,,/BAI020233.png";
            // string packUrl = "C:\\Users\\Tim\\Documents\\Visual Studio 2012\\Projects\\WpfApplication1\\WpfApplication1\\E011.png";

            // bomb.Source = new ImageSourceConverter().ConvertFromString(packUrl) as ImageSource;
            Aibomb.Source = new ImageSourceConverter().ConvertFromString(packUrl1) as ImageSource;
            Aibomb.Width = 35;
            // Aibomb.BringIntoView();
            Aibomb.Height = 35;

        }
        public Thickness getBrick(int j, int i)
        {
            Thickness marginthick = new Thickness();
            marginthick.Left = -450 + 75 * j;
            marginthick.Top = 400 - 85 * i;
            return marginthick;
        }

        
        
    }
}
