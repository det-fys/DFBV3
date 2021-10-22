using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFBV3 {
    public class RozvrhInteraktivniStyl {
        public Pen ZvyrazneniOkraj = new Pen(Color.FromArgb(100, Color.Aqua), 2);
        public Brush ZvyrazneniVypln = new SolidBrush(Color.FromArgb(15, Color.Aqua));

        public int OdstupBubliny = 20;
        public int SipkaOdKraje = 30;
        public int RadiusSipky = 12;

        public Pen BublinaOkraj = new Pen(Color.FromArgb(255, 0, 140, 140), 2);
        public Brush BublinaVypln = new SolidBrush(Color.FromArgb(255, 40, 60, 60));
        //public Brush BublinaVypln = new SolidBrush(Color.FromArgb(255, 10, 80, 80));

        public Pen BublinaOddeleni = new Pen(Color.FromArgb(255, 0, 140, 140), 1);

        public Brush TextStetec = new SolidBrush(Color.FromArgb(255, 190, 235, 235));

        public int NadpisVyska = 23;
        public Font NadpisPismo = new Font("Segoe UI", 12, FontStyle.Bold);

        public int UcitelVyska = 18;
        public Font UcitelPismo = new Font("Segoe UI", 9, FontStyle.Bold);

        public int ZmenaVyska = 34;
        public Font ZmenaPismo = new Font("Segoe UI", 9, FontStyle.Bold | FontStyle.Italic);
        public Brush ZmenaStetecCH = new SolidBrush(Color.FromArgb(255, 230, 180, 180));
        public Brush ZmenaStetecA = new SolidBrush(Color.FromArgb(255, 180, 230, 180));

        public int TemaVyska = 60;
        public Font TemaPismo = new Font("Segoe UI", 10, FontStyle.Bold);
        public Brush TemaStetec = new SolidBrush(Color.FromArgb(255, 230, 230, 230));

    }


    class RozvrhInteraktivni {
        private PictureBox _pb;
        private List<Interaktivni<RozvrhRenderer.ZpracovanaHodina>> _oblasti;
        private Interaktivni<RozvrhRenderer.ZpracovanaHodina> posledniOblast = null;
        private RozvrhInteraktivniStyl styl;

        public RozvrhInteraktivni(PictureBox Cil, List<Interaktivni<RozvrhRenderer.ZpracovanaHodina>> Oblasti, RozvrhInteraktivniStyl Styl = null) {
            _pb = Cil;
            _oblasti = Oblasti;
        
            if (Styl == null) {
                styl = new RozvrhInteraktivniStyl();
            } else {
                styl = Styl;
            }
        }

        public void PohybKurzoru(Point pozice) {
            var aktOblast = ZiskatOblast(pozice);
            if (aktOblast == posledniOblast) return;
            if (aktOblast == null) {
                _pb.Cursor = Cursors.Default;
                Vycistit();
                return;
            }
            //_pb.Cursor = Cursors.Hand;
            _pb.Cursor = Cursors.Cross;
            Vyrendrovat(posledniOblast = aktOblast);
        }

        public void Vycistit() {
            _pb.Image = null;
            posledniOblast = null;
        }

        public void ZobrazitPodrobnosti() {
            /* if (posledniOblast == null) */ return;
            var h = posledniOblast.Hodnota;

            MessageBox.Show($"————————————————————————————\n{(h.Nazev != "" ? h.Nazev : h.Zkratka)}\n————————————————————————————\nVyučující: {h.Ucitel}\nTéma: {h.Tema}", "", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void Vyrendrovat(Interaktivni<RozvrhRenderer.ZpracovanaHodina> data) {
            var w = _pb.Width;
            var h = _pb.Height;

            Bitmap BMP = new Bitmap(w, h);
            Graphics BMPG = Graphics.FromImage(BMP);

            BMPG.DrawRectangle(styl.ZvyrazneniOkraj, data.Oblast);
            BMPG.FillRectangle(styl.ZvyrazneniVypln, data.Oblast);

            int EfNadpisVyska = 0;
            if (data.Hodnota.Nazev != null && data.Hodnota.Nazev != "") EfNadpisVyska = styl.NadpisVyska;

            int EfUcitelVyska = 0;
            if (data.Hodnota.Ucitel != null && data.Hodnota.Ucitel != "") EfUcitelVyska = styl.UcitelVyska;

            int EfZmenaVyska = 0;
            if (!string.IsNullOrEmpty(data.Hodnota.Zmena)) EfZmenaVyska = styl.ZmenaVyska;

            int EfTemaVyska = 0;
            if (data.Hodnota.Tema != null && data.Hodnota.Tema != "") EfTemaVyska = styl.TemaVyska;

            int OblastSirka = 250;
            int OblastVyska = EfNadpisVyska + EfUcitelVyska + EfZmenaVyska + EfTemaVyska;

            if (OblastVyska > 0) {

                var Oblast = new Rectangle(data.Oblast.X + (data.Oblast.Width / 2) - OblastSirka / 2, data.Oblast.Y - OblastVyska - styl.OdstupBubliny, OblastSirka, OblastVyska);

                if (Oblast.X + Oblast.Width > w) Oblast.X = w - Oblast.Width;
                if (Oblast.X < 0) Oblast.X = 0;

                var SipkaSpicka = new Point(data.Oblast.X + (data.Oblast.Width / 2), data.Oblast.Y + styl.SipkaOdKraje);

                int SipkaY = Oblast.Bottom;
                int SipkaYproti = Oblast.Top;
                if (Oblast.Y < 0) {
                    Oblast.Y = data.Oblast.Bottom + styl.OdstupBubliny;
                    SipkaY = Oblast.Top;
                    SipkaYproti = Oblast.Bottom;
                    SipkaSpicka.Y = data.Oblast.Bottom - styl.SipkaOdKraje;
                }

                int OblastStred = Oblast.Width / 2 + Oblast.X;

                var SipkaBod1 = new Point(OblastStred - styl.RadiusSipky, SipkaY);
                var SipkaBod2 = new Point(OblastStred + styl.RadiusSipky, SipkaY);

                var CestaBubliny = new Point[] {
                    new Point(Oblast.Left, SipkaYproti),
                    new Point(Oblast.Right, SipkaYproti),
                    new Point(Oblast.Right, SipkaY),
                    SipkaBod2,
                    SipkaSpicka,
                    SipkaBod1,
                    new Point(Oblast.Left, SipkaY)
                };


                //BMPG.FillRectangle(Brushes.Gray, Oblast);
                BMPG.FillPolygon(styl.BublinaVypln, CestaBubliny);
                BMPG.DrawPolygon(styl.BublinaOkraj, CestaBubliny);

                var OblastN = new Rectangle(Oblast.X, Oblast.Y, Oblast.Width, EfNadpisVyska);
                var OblastU = new Rectangle(Oblast.X, OblastN.Bottom, Oblast.Width, EfUcitelVyska);
                var OblastZ = new Rectangle(Oblast.X, OblastU.Bottom, Oblast.Width, EfZmenaVyska);
                var OblastT = new Rectangle(Oblast.X, OblastZ.Bottom, Oblast.Width, EfTemaVyska);

                RenderGlobal.NakreslitText(BMPG, OblastN, data.Hodnota.Nazev, styl.NadpisPismo, styl.TextStetec, ZarH.Stred, ZarV.Dole);
                RenderGlobal.NakreslitText(BMPG, OblastU, data.Hodnota.Ucitel, styl.UcitelPismo, styl.TextStetec, ZarH.Stred, ZarV.Nahore);

                if (EfZmenaVyska > 0)
                    BMPG.DrawString(data.Hodnota.Zmena, styl.ZmenaPismo, (data.Hodnota.Typ == RozvrhRenderer.TypHodiny.A) ? styl.ZmenaStetecA : styl.ZmenaStetecCH, OblastZ);

                if (EfTemaVyska > 0) {
                    //BMPG.DrawLine(styl.BublinaOddeleni, Oblast.Left, OblastT.Top, Oblast.Right, OblastT.Top);
                    BMPG.DrawString(data.Hodnota.Tema, styl.TemaPismo, styl.TemaStetec, OblastT);
                }

            }
            //BMPG.DrawString(data.Hodnota.Nazev, styl.NadpisPismo, styl.TextStetec, Oblast);



            _pb.BackColor = Color.Transparent;
            _pb.Image = BMP;
        }

        private Interaktivni<RozvrhRenderer.ZpracovanaHodina> ZiskatOblast(Point bod) {
            foreach(Interaktivni<RozvrhRenderer.ZpracovanaHodina> oblast in _oblasti) {
                if (oblast.Oblast.Contains(bod)) {
                    return oblast;
                }
            }
            return null;
        }

    }
}
