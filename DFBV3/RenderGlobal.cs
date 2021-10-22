using System.Drawing;

namespace DFBV3 {
    public enum ZarV {
        Nahore = -1,
        Stred = 0,
        Dole = 1
    }

    public enum ZarH {
        Vlevo = -1,
        Stred = 0,
        Vpravo = 1
    }

    public class DoubleBrush {
        public Brush Foreground;
        public Brush Background;
        public DoubleBrush(Brush background, Brush foreground) {
            Background = background;
            Foreground = foreground;
        }
    }

    public class Interaktivni<T> {
        public Rectangle Oblast;
        public T Hodnota;
        public Interaktivni() { }
        public Interaktivni(Rectangle Oblast, T Hodnota) {
            this.Oblast = Oblast;
            this.Hodnota = Hodnota;
        }
    }

    public static class RenderGlobal {
        public static Rectangle RectPadding(Rectangle Puvodni, int Padding) {
            return new Rectangle(Puvodni.X + Padding, Puvodni.Y + Padding, Puvodni.Width - Padding * 2, Puvodni.Height - Padding * 2);
        }

        public static Rectangle RectTrans(Rectangle Puvodni, int X = 0, int Y = 0, int W = 0, int H = 0) {
            return new Rectangle(Puvodni.X + X, Puvodni.Y + Y, Puvodni.Width + W, Puvodni.Height + H);
        }

        public static void NakreslitText(Graphics G, Rectangle Ctverec, string Text, Font Pismo, Brush Stetec, ZarH H, ZarV V, int WidthFix = 0) {
            var Velikost = G.MeasureString(Text, Pismo);
            Velikost.Width += WidthFix;
            float X = H == ZarH.Vlevo ? Ctverec.X : H == ZarH.Stred ? Ctverec.X + (Ctverec.Width / 2) - (Velikost.Width / 2) : Ctverec.X + Ctverec.Width - Velikost.Width;
            float Y = V == ZarV.Nahore ? Ctverec.Y : V == ZarV.Stred ? Ctverec.Y + (Ctverec.Height / 2) - (Velikost.Height / 2) : Ctverec.Y + Ctverec.Height - Velikost.Height;

            G.DrawString(Text, Pismo, Stetec, X, Y);
        }

        public static Image VyrendrovatNacitani(int w, int h, bool chyba = false) {
            var BMP = new Bitmap(w, h);
            var G = Graphics.FromImage(BMP);
            
            var Oblast = new Rectangle(0, 0, w, h);
            var pismo = new Font("Segoe UI", 24, FontStyle.Bold);
            int odstin = 130;
            var stetec = new SolidBrush(Color.FromArgb(255, odstin, odstin, odstin));

            NakreslitText(G, Oblast, !chyba ? "načítání..." : "chyba", pismo, stetec, ZarH.Stred, ZarV.Stred);

            return BMP;
        }
    }
}
