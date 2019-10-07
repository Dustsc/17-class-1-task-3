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
using System.Collections.ObjectModel;
using System.ComponentModel;
using log4net;
using WpfApp1.Triton.Common;
using WpfApp1.Triton.Common.settings;
using Logger = WpfApp1.Triton.Common.LogUtilities.LogManagers;

namespace P114T5
{

    public enum cardcolor
    {
        square = 0,
        peach = 1,
        blossom = 2,
        spades = 3,
        joker = 4,
        none = 5,
    }

    public enum digital
    {
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9,
        ten = 10,
        eleven = 11,
        twelve = 12,
        thirteen = 13,
        one = 14,
        big = 16,
        small = 15,
        none = 0,
    }

    public enum kinds
    {
        flush = 5,
        straight = 4,
        point = 3,
        pair = 2,
        other = 1,
        none = 0,
    }

    public enum state
    {
        win = 0,
        draw = 1,
        lose = 2,
        none = 3,
    }

    public class cards
    {
        public cardcolor cardcolor;
        public digital digital;
        
        public cards()
        {
            cardcolor = cardcolor.joker;
            digital = digital.big;
        }

        public cards(cards t)
        {
            cardcolor = t.cardcolor;
            digital = t.digital;
        }

        public string tostring()
        {
            string t = "";
            switch (cardcolor)
            {
                case cardcolor.square:
                    t = t + "1";
                    break;
                case cardcolor.peach:
                    t = t + "2";
                    break;
                case cardcolor.blossom:
                    t = t + "3";
                    break;
                case cardcolor.spades:
                    t = t + "4";
                    break;
                case cardcolor.joker:
                    t = t + "5";
                    break;
                default:
                    t = "";
                    break;
            }
            switch (digital)
            {
                case digital.big:
                    t = t + "2";
                    break;
                case digital.small:
                    t = t + "1";
                    break;
                case digital.one:
                    t = t + "0";
                    break;
                case digital.two:
                    t = t + "2";
                    break;
                case digital.three:
                    t = t + "3";
                    break;
                case digital.four:
                    t = t + "4";
                    break;
                case digital.five:
                    t = t + "5";
                    break;
                case digital.six:
                    t = t + "6";
                    break;
                case digital.seven:
                    t = t + "7";
                    break;
                case digital.eight:
                    t = t + "8";
                    break;
                case digital.nine:
                    t = t + "9";
                    break;
                case digital.ten:
                    t = t + "10";
                    break;
                case digital.eleven:
                    t = t + "J";
                    break;
                case digital.twelve:
                    t = t + "Q";
                    break;
                case digital.thirteen:
                    t = t + "K";
                    break;
                default:
                    t = "";
                    break;
            }
            if (t == "") return "";
            t = t + ".jpg";
            return t;
        }
    }

    public class carddeck
    {
        private List<cards> allcard;
        private List<cards> allcards;

        public carddeck()
        {
            allcard = new List<cards>();
            for(int i = 0; i < 4; i++ )
            {
                for(int j = 2; j < 15; j++ )
                {
                    cards t = new cards()
                    {
                        cardcolor = (cardcolor)i,
                        digital = (digital)j
                    };
                    allcard.Add(t);
                }
            }
            shuffle();
        }

        public cards drawacard()
        {
            if (allcards.Count == 0)
            {
                cards t = new cards()
                {
                    cardcolor = cardcolor.none,
                    digital = digital.none
                };
                return t;
            }
            else
            {
                cards t = new cards(allcards[0]);
                allcards.RemoveAt(0);
                return t;
            }
        }

        public void shuffle()
        {
            Random random = new Random();
            List<cards> newList = new List<cards>();
            foreach (cards item in allcard)
            {
                newList.Insert(random.Next(newList.Count + 1), item);
            }
            allcards = newList;
        }
    }

    public class player
    {
        public cards c1, c2, c3;
        public kinds t2;
        public int sum;
        public int t1;
        public state t4;

        public player()
        {
            c1 = new cards();
            c2 = new cards();
            c3 = new cards();
            t2 = kinds.none;
            sum = 0;
            t1 = 0;
            t4 = state.none;
        }

        public void getkinds()
        {
            if (c1.cardcolor == c2.cardcolor && c2.cardcolor == c3.cardcolor)
            {
                t2 = kinds.flush;
            }
            else if((int)c1.digital+1 == (int)c2.digital && (int)c2.digital + 1 == (int)c3.digital)
            {
                t2 = kinds.straight;
            }
            else if ((int)c1.digital + 1 == (int)c3.digital && (int)c3.digital + 1 == (int)c2.digital)
            {
                t2 = kinds.straight;
            }
            else if ((int)c2.digital + 1 == (int)c1.digital && (int)c1.digital + 1 == (int)c3.digital)
            {
                t2 = kinds.straight;
            }
            else if ((int)c2.digital + 1 == (int)c3.digital && (int)c3.digital + 1 == (int)c1.digital)
            {
                t2 = kinds.straight;
            }
            else if ((int)c3.digital + 1 == (int)c1.digital && (int)c1.digital + 1 == (int)c1.digital)
            {
                t2 = kinds.straight;
            }
            else if ((int)c3.digital + 1 == (int)c2.digital && (int)c2.digital + 1 == (int)c1.digital)
            {
                t2 = kinds.straight;
            }
            else if ((int)c1.digital == (int)c2.digital && (int)c2.digital == (int)c3.digital)
            {
                t2 = kinds.point;
            }
            else if((int)c1.digital == (int)c2.digital)
            {
                t2 = kinds.pair;
            }
            else if ((int)c1.digital == (int)c3.digital)
            {
                t2 = kinds.pair;
            }
            else if ((int)c3.digital == (int)c2.digital)
            {
                t2 = kinds.pair;
            }
            else
            {
                t2 = kinds.other;
            }
        }

        public void getsum()
        {
            sum = (int)c1.digital + (int)c2.digital + (int)c3.digital;
        }

        public string tostringkinds()
        {
            switch (t2)
            {
                case kinds.flush:
                    return "同花";
                case kinds.straight:
                    return "顺子";
                case kinds.point:
                    return "同点";
                case kinds.pair:
                    return "对子";
                case kinds.other:
                    return "杂牌";
                case kinds.none:
                default: return "无";
            }
        }
        public string tostringstate()
        {
            switch (t4)
            {
                case state.win:
                    return "赢";
                case state.lose:
                    return "输";
                case state.draw:
                    return "平";
                case state.none:
                default: return "无";
            }
        }

        public static void compare(player a, player b)
        {
            if (a == b)
            {
                a.t4 = state.draw;
                b.t4 = state.draw;
            }
            else
            {
                if (a > b)
                {
                    a.t4 = state.win;
                    b.t4 = state.lose;
                }
                else
                {
                    a.t4 = state.lose;
                    b.t4 = state.win;
                }
            }
        }

        public static bool operator == (player a, player b)
        {
            if ((int)a.t2 == (int)b.t2)
            {
                if ((int)a.sum == (int)b.sum)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(player a, player b)
        {
            if ((int)a.t2 == (int)b.t2)
            {
                if ((int)a.sum == (int)b.sum)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator <(player a, player b)
        {
            if ((int)a.t2 == (int)b.t2)
            {
                return ((int)a.sum < (int)b.sum);
            }
            return ((int)a.t2 < (int)b.t2);
        }

        public static bool operator >(player a, player b)
        {
            if ((int)a.t2 == (int)b.t2)
            {
                return ((int)a.sum > (int)b.sum);
            }
            return ((int)a.t2 > (int)b.t2);
        }
    }

    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class P114T5Settings : JsonSettings,INotifyPropertyChanged
    {
        private static readonly ILog Log = Logger.GetLoggerInstanceForType();
        private static P114T5Settings _instance;

        private player p1 = new player(), p2 = new player();
        private carddeck deck = new carddeck();
        private int timess=1;
        private int alltimes;
		public int t1c1,t1c2,t2c1,t2c2,t3c1,t3c2,t4c1,t4c2,t5c1,t5c2;

        public static P114T5Settings Instance
        {
            get { return _instance ?? (_instance = new P114T5Settings()); }
        }

        public P114T5Settings() : base(GetSettingsFilePath(Configuration.Instance.Name, string.Format("{0}.json", "P114T5")))
        {
        }

        public player P1 { get {return p1;} set { p1 = value;} }
        public player P2 { get {return p2;} set { p2 = value;} }
        public int T1c1 { get {return t1c1;} set { t1c1 = value;} }
        public int T1c2 { get {return t1c2;} set { t1c2 = value;} }
        public int T2c1 { get {return t2c1;} set { t2c1 = value;} }
        public int T2c2 { get {return t2c2;} set { t2c2 = value;} }
        public int T3c1 { get {return t1c1;} set { t3c1 = value;} }
        public int T3c2 { get {return t3c2;} set { t3c2 = value;} }
        public int T4c1 { get {return t4c1;} set { t4c1 = value;} }
        public int T4c2 { get {return t4c2;} set { t4c2 = value;} }
        public int T5c1 { get {return t5c1;} set { t5c1 = value;} }
        public int T5c2 { get {return t5c2;} set { t5c2 = value;} }
        public string P1c1
        {
            get
            {
                if (p1.c1.tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p1.c1.tostring();
            }
        }
        public string P2c1
        {
            get
            {
                if (p2.c1.tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p2.c1.tostring();
            }
        }
        public string P1c2
        {
            get
            {
                if (p1.c2.tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p1.c2.tostring();
            }
        }
        public string P2c2
        {
            get
            {
                if (p2.c2.tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p2.c2.tostring();
            }
        }
        public string P1c3
        {
            get
            {
                if (p1.c3.tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p1.c3.tostring();
            }
        }
        public string P2c3
        {
            get
            {
                if (p2.c3.tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p2.c3.tostring();
            }
        }
        public int P1t1{ get {return p1.t1;} set { p1.t1 = value;} }
        public int P2t1{ get {return p2.t1;} set { p1.t1 = value;} }
        public string P1t2{ get {return p1.tostringkinds();} }
        public string P2t2{ get {return p2.tostringkinds();} }
        public int P1t3{ get {return p1.sum;} }
        public int P2t3{ get {return p2.sum;} }
        public string P1t4 { get {return p1.tostringstate();} }
        public string P2t4 { get {return p2.tostringstate();} }
        public int Timess
        {
            get {return timess;}
            set
            {
                timess = value;
                if (timess <= 0)
                {
                    timess = 1;
                    Log.WarnFormat("[P114T5] Pay can't be less than 0.");
                }
            }
        }
        public int Alltimes { get {return alltimes;} set { alltimes = value;} }

        public void Reset()
        {
            Log.InfoFormat("[P114T5] Reset.");
            P1 = new player()
            {
                c1 = new cards()
                {
                    cardcolor = cardcolor.joker,
                    digital = digital.big
                },
                c2 = new cards()
                {
                    cardcolor = cardcolor.joker,
                    digital = digital.small
                },
                c3 = new cards()
                {
                    cardcolor = cardcolor.square,
                    digital = digital.one
                }
            };
            OnPropertyChanged("P1");
            OnPropertyChanged("P1c1");
            OnPropertyChanged("P1c2");
            OnPropertyChanged("P1c3");
            OnPropertyChanged("P1t1");
            OnPropertyChanged("P1t2");
            OnPropertyChanged("P1t3");
            OnPropertyChanged("P1t4");
            Alltimes = 0;
            OnPropertyChanged("Alltimes");
            P2 = new player()
            {
                c1 = new cards()
                {
                    cardcolor = cardcolor.peach,
                    digital = digital.one
                },
                c2 = new cards()
                {
                    cardcolor = cardcolor.spades,
                    digital = digital.one
                },
                c3 = new cards()
                {
                    cardcolor = cardcolor.blossom,
                    digital = digital.one
                }
            };
            OnPropertyChanged("P2");
            OnPropertyChanged("P2c1");
            OnPropertyChanged("P2c2");
            OnPropertyChanged("P2c3");
            OnPropertyChanged("P2t1");
            OnPropertyChanged("P2t2");
            OnPropertyChanged("P2t3");
            OnPropertyChanged("P2t4");
            Timess = 1;
            OnPropertyChanged("Timess");
			T1c1 = 0;
            OnPropertyChanged("T1c1");
			T1c2 = 0;
            OnPropertyChanged("T1c2");
			T2c1 = 0;
            OnPropertyChanged("T2c1");
			T2c2 = 0;
            OnPropertyChanged("T2c2");
			T3c1 = 0;
            OnPropertyChanged("T3c1");
			T3c2 = 0;
            OnPropertyChanged("T3c2");
			T4c1 = 0;
            OnPropertyChanged("T4c1");
			T4c2 = 0;
            OnPropertyChanged("T4c2");
			T5c1 = 0;
            OnPropertyChanged("T5c1");
			T5c2 = 0;
            OnPropertyChanged("T5c2");
        }

        public void drawcard()
        {
            Log.InfoFormat("[P114T5] drawcard for {0} times.",timess);
            for(int i = 0; i < timess; i++ )
            {
				Log.InfoFormat("[P114T5] for {0}th time. ",i+1);
                deck.shuffle();
                P1.c1 = deck.drawacard();
                P1.c2 = deck.drawacard();
                P1.c3 = deck.drawacard();
                P2.c1 = deck.drawacard();
                P2.c2 = deck.drawacard();
                P2.c3 = deck.drawacard();
                P1.getkinds();
                P2.getkinds();
                P1.getsum();
                P2.getsum();
                player.compare(p1, p2);
                if((int)P1.t4 <= 1)
                {
                    P1.t1 += 1;
                }
                if((int)P2.t4 <= 1)
                {
                    P2.t1 += 1;
                }
                OnPropertyChanged("P1");
                OnPropertyChanged("P1c1");
                OnPropertyChanged("P1c2");
                OnPropertyChanged("P1c3");
                OnPropertyChanged("P1t1");
                OnPropertyChanged("P1t2");
                OnPropertyChanged("P1t3");
                OnPropertyChanged("P1t4");
                OnPropertyChanged("P2");
                OnPropertyChanged("P2c1");
                OnPropertyChanged("P2c2");
                OnPropertyChanged("P2c3");
                OnPropertyChanged("P2t1");
                OnPropertyChanged("P2t2");
                OnPropertyChanged("P2t3");
                OnPropertyChanged("P2t4");
                Alltimes += 1;
				OnPropertyChanged("Alltimes");
                if(P1.t2 == kinds.flush)
                {
                    T1c1 += 1;
                    if((int)P1.t4 <= 1)
                    {
                        T1c2 += 1;
                    }
                }
                else if(P1.t2 == kinds.straight)
                {
                    T2c1 += 1;
                    if ((int)P1.t4 <= 1)
                    {
                        T2c2 += 1;
                    }
                }
                else if (P1.t2 == kinds.point)
                {
                    T3c1 += 1;
                    if ((int)P1.t4 <= 1)
                    {
                        T3c2 += 1;
                    }
                }
                else if (P1.t2 == kinds.pair)
                {
                    T4c1 += 1;
                    if ((int)P1.t4 <= 1)
                    {
                        T4c2 += 1;
                    }
                }
                else if (P1.t2 == kinds.other)
                {
                    T5c1 += 1;
                    if ((int)P1.t4 <= 1)
                    {
                        T5c2 += 1;
                    }
                }
                if (P2.t2 == kinds.flush)
                {
                    T1c1 += 1;
                    if ((int)P2.t4 <= 1)
                    {
                        T1c2 += 1;
                    }
                }
                else if (P2.t2 == kinds.straight)
                {
                    T2c1 += 1;
                    if ((int)P2.t4 <= 1)
                    {
                        T2c2 += 1;
                    }
                }
                else if (P2.t2 == kinds.point)
                {
                    T3c1 += 1;
                    if ((int)P2.t4 <= 1)
                    {
                        T3c2 += 1;
                    }
                }
                else if (P2.t2 == kinds.pair)
                {
                    T4c1 += 1;
                    if ((int)P2.t4 <= 1)
                    {
                        T4c2 += 1;
                    }
                }
                else if (P2.t2 == kinds.other)
                {
                    T5c1 += 1;
                    if ((int)P2.t4 <= 1)
                    {
                        T5c2 += 1;
                    }
                }
                OnPropertyChanged("T1c1");
				OnPropertyChanged("T1c2");
				OnPropertyChanged("T2c1");
				OnPropertyChanged("T2c2");
				OnPropertyChanged("T3c1");
				OnPropertyChanged("T3c2");
				OnPropertyChanged("T4c1");
				OnPropertyChanged("T4c2");
				OnPropertyChanged("T5c1");
				OnPropertyChanged("T5c2");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
