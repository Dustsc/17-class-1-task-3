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

    public enum Cardcolor
    {
        square = 0,
        peach = 1,
        blossom = 2,
        spades = 3,
        joker = 4,
        none = 5,
    }

    public enum Digital
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

    public enum Kinds
    {
        flush = 5,
        straight = 4,
        point = 3,
        pair = 2,
        other = 1,
        none = 0,
    }

    public enum State
    {
        win = 0,
        draw = 1,
        lose = 2,
        none = 3,
    }

    public class Cards
    {
        public Cardcolor cardcolor;
        public Digital digital;
        
        public Cards()
        {
            cardcolor = Cardcolor.joker;
            digital = Digital.big;
        }

        public Cards(Cards t)
        {
            cardcolor = t.cardcolor;
            digital = t.digital;
        }

        public string Tostring()
        {
            string t = "";
            switch (cardcolor)
            {
                case Cardcolor.square:
                    t += "1";
                    break;
                case Cardcolor.peach:
                    t += "2";
                    break;
                case Cardcolor.blossom:
                    t += "3";
                    break;
                case Cardcolor.spades:
                    t += "4";
                    break;
                case Cardcolor.joker:
                    t += "5";
                    break;
                default:
                    t = "";
                    break;
            }
            switch (digital)
            {
                case Digital.big:
                    t += "2";
                    break;
                case Digital.small:
                    t += "1";
                    break;
                case Digital.one:
                    t += "0";
                    break;
                case Digital.two:
                    t += "2";
                    break;
                case Digital.three:
                    t += "3";
                    break;
                case Digital.four:
                    t += "4";
                    break;
                case Digital.five:
                    t += "5";
                    break;
                case Digital.six:
                    t += "6";
                    break;
                case Digital.seven:
                    t += "7";
                    break;
                case Digital.eight:
                    t += "8";
                    break;
                case Digital.nine:
                    t += "9";
                    break;
                case Digital.ten:
                    t += "10";
                    break;
                case Digital.eleven:
                    t += "J";
                    break;
                case Digital.twelve:
                    t += "Q";
                    break;
                case Digital.thirteen:
                    t += "K";
                    break;
                default:
                    t = "";
                    break;
            }
            if (t == "") return "";
            t += ".jpg";
            return t;
        }
    }

    public class Carddeck
    {
        private readonly List<Cards> allcard;
        private List<Cards> allcards;

        public Carddeck()
        {
            allcard = new List<Cards>();
            for(int i = 0; i < 4; i++ )
            {
                for(int j = 2; j < 15; j++ )
                {
                    Cards t = new Cards()
                    {
                        cardcolor = (Cardcolor)i,
                        digital = (Digital)j
                    };
                    allcard.Add(t);
                }
            }
            Shuffle();
        }

        public Cards Drawacard()
        {
            if (allcards.Count == 0)
            {
                Cards t = new Cards()
                {
                    cardcolor = Cardcolor.none,
                    digital = Digital.none
                };
                return t;
            }
            else
            {
                Cards t = new Cards(allcards[0]);
                allcards.RemoveAt(0);
                return t;
            }
        }

        public void Shuffle()
        {
            Random random = new Random();
            List<Cards> newList = new List<Cards>();
            foreach (Cards item in allcard)
            {
                newList.Insert(random.Next(newList.Count + 1), item);
            }
            allcards = newList;
        }
    }

    public class Player : IEquatable<Player>
    {
        public Cards c1, c2, c3;
        public Kinds t2;
        public int sum;
        public int t1;
        public State t4;

        public Player()
        {
            c1 = new Cards();
            c2 = new Cards();
            c3 = new Cards();
            t2 = Kinds.none;
            sum = 0;
            t1 = 0;
            t4 = State.none;
        }

        public void Getkinds()
        {
            if (c1.cardcolor == c2.cardcolor && c2.cardcolor == c3.cardcolor)
            {
                t2 = Kinds.flush;
            }
            else if((int)c1.digital+1 == (int)c2.digital && (int)c2.digital + 1 == (int)c3.digital)
            {
                t2 = Kinds.straight;
            }
            else if ((int)c1.digital + 1 == (int)c3.digital && (int)c3.digital + 1 == (int)c2.digital)
            {
                t2 = Kinds.straight;
            }
            else if ((int)c2.digital + 1 == (int)c1.digital && (int)c1.digital + 1 == (int)c3.digital)
            {
                t2 = Kinds.straight;
            }
            else if ((int)c2.digital + 1 == (int)c3.digital && (int)c3.digital + 1 == (int)c1.digital)
            {
                t2 = Kinds.straight;
            }
            else if ((int)c3.digital + 1 == (int)c1.digital && (int)c1.digital + 1 == (int)c1.digital)
            {
                t2 = Kinds.straight;
            }
            else if ((int)c3.digital + 1 == (int)c2.digital && (int)c2.digital + 1 == (int)c1.digital)
            {
                t2 = Kinds.straight;
            }
            else if ((int)c1.digital == (int)c2.digital && (int)c2.digital == (int)c3.digital)
            {
                t2 = Kinds.point;
            }
            else if((int)c1.digital == (int)c2.digital)
            {
                t2 = Kinds.pair;
            }
            else if ((int)c1.digital == (int)c3.digital)
            {
                t2 = Kinds.pair;
            }
            else if ((int)c3.digital == (int)c2.digital)
            {
                t2 = Kinds.pair;
            }
            else
            {
                t2 = Kinds.other;
            }
        }

        public void Getsum()
        {
            sum = (int)c1.digital + (int)c2.digital + (int)c3.digital;
        }

        public string Tostringkinds()
        {
            switch (t2)
            {
                case Kinds.flush:
                    return "同花";
                case Kinds.straight:
                    return "顺子";
                case Kinds.point:
                    return "同点";
                case Kinds.pair:
                    return "对子";
                case Kinds.other:
                    return "杂牌";
                case Kinds.none:
                default: return "无";
            }
        }
        public string Tostringstate()
        {
            switch (t4)
            {
                case State.win:
                    return "赢";
                case State.lose:
                    return "输";
                case State.draw:
                    return "平";
                case State.none:
                default: return "无";
            }
        }

        public static void Compare(Player a, Player b)
        {
            if (a == b)
            {
                a.t4 = State.draw;
                b.t4 = State.draw;
            }
            else
            {
                if (a > b)
                {
                    a.t4 = State.win;
                    b.t4 = State.lose;
                }
                else
                {
                    a.t4 = State.lose;
                    b.t4 = State.win;
                }
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Player);
        }

        public bool Equals(Player other)
        {
            return other != null &&
                   EqualityComparer<Cards>.Default.Equals(c1, other.c1) &&
                   EqualityComparer<Cards>.Default.Equals(c2, other.c2) &&
                   EqualityComparer<Cards>.Default.Equals(c3, other.c3) &&
                   t2 == other.t2 &&
                   sum == other.sum &&
                   t1 == other.t1 &&
                   t4 == other.t4;
        }

        public override int GetHashCode()
        {
            var hashCode = -1053643190;
            hashCode = hashCode * -1521134295 + EqualityComparer<Cards>.Default.GetHashCode(c1);
            hashCode = hashCode * -1521134295 + EqualityComparer<Cards>.Default.GetHashCode(c2);
            hashCode = hashCode * -1521134295 + EqualityComparer<Cards>.Default.GetHashCode(c3);
            hashCode = hashCode * -1521134295 + t2.GetHashCode();
            hashCode = hashCode * -1521134295 + sum.GetHashCode();
            hashCode = hashCode * -1521134295 + t1.GetHashCode();
            hashCode = hashCode * -1521134295 + t4.GetHashCode();
            return hashCode;
        }

        public static bool operator == (Player a, Player b)
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

        public static bool operator !=(Player a, Player b)
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

        public static bool operator <(Player a, Player b)
        {
            if ((int)a.t2 == (int)b.t2)
            {
                return ((int)a.sum < (int)b.sum);
            }
            return ((int)a.t2 < (int)b.t2);
        }

        public static bool operator >(Player a, Player b)
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

        private Player p1 = new Player(), p2 = new Player();
        private readonly Carddeck deck = new Carddeck();
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

        public Player P1 { get {return p1;} set { p1 = value;} }
        public Player P2 { get {return p2;} set { p2 = value;} }
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
                if (p1.c1.Tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p1.c1.Tostring();
            }
        }
        public string P2c1
        {
            get
            {
                if (p2.c1.Tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p2.c1.Tostring();
            }
        }
        public string P1c2
        {
            get
            {
                if (p1.c2.Tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p1.c2.Tostring();
            }
        }
        public string P2c2
        {
            get
            {
                if (p2.c2.Tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p2.c2.Tostring();
            }
        }
        public string P1c3
        {
            get
            {
                if (p1.c3.Tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p1.c3.Tostring();
            }
        }
        public string P2c3
        {
            get
            {
                if (p2.c3.Tostring() == "") return "";
                return System.AppDomain.CurrentDomain.BaseDirectory + @"Plugins\P114T5\Images\" + p2.c3.Tostring();
            }
        }
        public int P1t1{ get {return p1.t1;} set { p1.t1 = value;} }
        public int P2t1{ get {return p2.t1;} set { p1.t1 = value;} }
        public string P1t2{ get {return p1.Tostringkinds();} }
        public string P2t2{ get {return p2.Tostringkinds();} }
        public int P1t3{ get {return p1.sum;} }
        public int P2t3{ get {return p2.sum;} }
        public string P1t4 { get {return p1.Tostringstate();} }
        public string P2t4 { get {return p2.Tostringstate();} }
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
            P1 = new Player()
            {
                c1 = new Cards()
                {
                    cardcolor = Cardcolor.joker,
                    digital = Digital.big
                },
                c2 = new Cards()
                {
                    cardcolor = Cardcolor.joker,
                    digital = Digital.small
                },
                c3 = new Cards()
                {
                    cardcolor = Cardcolor.square,
                    digital = Digital.one
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
            P2 = new Player()
            {
                c1 = new Cards()
                {
                    cardcolor = Cardcolor.peach,
                    digital = Digital.one
                },
                c2 = new Cards()
                {
                    cardcolor = Cardcolor.spades,
                    digital = Digital.one
                },
                c3 = new Cards()
                {
                    cardcolor = Cardcolor.blossom,
                    digital = Digital.one
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

        public void Drawcard()
        {
            Log.InfoFormat("[P114T5] drawcard for {0} times.",timess);
            for(int i = 0; i < timess; i++ )
            {
				Log.InfoFormat("[P114T5] for {0}th time. ",i+1);
                deck.Shuffle();
                P1.c1 = deck.Drawacard();
                P1.c2 = deck.Drawacard();
                P1.c3 = deck.Drawacard();
                P2.c1 = deck.Drawacard();
                P2.c2 = deck.Drawacard();
                P2.c3 = deck.Drawacard();
                P1.Getkinds();
                P2.Getkinds();
                P1.Getsum();
                P2.Getsum();
                Player.Compare(p1, p2);
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
                if(P1.t2 == Kinds.flush)
                {
                    T1c1 += 1;
                    if((int)P1.t4 <= 1)
                    {
                        T1c2 += 1;
                    }
                }
                else if(P1.t2 == Kinds.straight)
                {
                    T2c1 += 1;
                    if ((int)P1.t4 <= 1)
                    {
                        T2c2 += 1;
                    }
                }
                else if (P1.t2 == Kinds.point)
                {
                    T3c1 += 1;
                    if ((int)P1.t4 <= 1)
                    {
                        T3c2 += 1;
                    }
                }
                else if (P1.t2 == Kinds.pair)
                {
                    T4c1 += 1;
                    if ((int)P1.t4 <= 1)
                    {
                        T4c2 += 1;
                    }
                }
                else if (P1.t2 == Kinds.other)
                {
                    T5c1 += 1;
                    if ((int)P1.t4 <= 1)
                    {
                        T5c2 += 1;
                    }
                }
                if (P2.t2 == Kinds.flush)
                {
                    T1c1 += 1;
                    if ((int)P2.t4 <= 1)
                    {
                        T1c2 += 1;
                    }
                }
                else if (P2.t2 == Kinds.straight)
                {
                    T2c1 += 1;
                    if ((int)P2.t4 <= 1)
                    {
                        T2c2 += 1;
                    }
                }
                else if (P2.t2 == Kinds.point)
                {
                    T3c1 += 1;
                    if ((int)P2.t4 <= 1)
                    {
                        T3c2 += 1;
                    }
                }
                else if (P2.t2 == Kinds.pair)
                {
                    T4c1 += 1;
                    if ((int)P2.t4 <= 1)
                    {
                        T4c2 += 1;
                    }
                }
                else if (P2.t2 == Kinds.other)
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

        public new event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
			if(propertyName!=null)
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
