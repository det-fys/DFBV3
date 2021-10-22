using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DFBV3 {
    public class ZnamkyStyl {
        public int VyskaPredmet = 64;
        public int VyskaZnamka = 42;

        public int Mezera = 30;
        public int Margin = 3;
        public int Padding = 0;

        public int DatumFix = 3;

        public bool Okraje = false;
        public Pen Okraj = new Pen(Brushes.Black, 2);

        public Brush ZahlaviVypln = new SolidBrush(Color.FromArgb(60, 62, 64));
        public Font ZahlaviPredmetPismo = new Font("Segoe UI", 13.0f, FontStyle.Bold);
        public Brush ZahlaviPredmetBarva = new SolidBrush(Color.FromArgb(190, 190, 190));
        public Font ZahlaviPrumerPismo = new Font("Segoe UI", 14.0f, FontStyle.Bold);
        public Brush ZahlaviPrumerBarva = new SolidBrush(Color.FromArgb(210, 210, 210));

        public Brush ZnamkaVypln = new SolidBrush(Color.FromArgb(50, 52, 54));
        public Font ZnamkaTextPismo = new Font("Segoe UI", 11.0f);
        public Font ZnamkaVahaPismo = new Font("Segoe UI", 9.0f);
        public Font ZnamkaZnamkaPismo = new Font("Segoe UI", 12.0f, FontStyle.Bold);

        public Brush ZnamkaBarva = new SolidBrush(Color.FromArgb(210, 210, 210));
        public Brush ZnamkaNovaBarva = new SolidBrush(Color.FromArgb(255, 140, 140));

        public Brush[] StupenVypln = {
            new SolidBrush(Color.FromArgb(50, 50, 80)), //modra
            new SolidBrush(Color.FromArgb(50, 80, 50)), //zelena
            new SolidBrush(Color.FromArgb(80, 80, 50)), //zluta
            new SolidBrush(Color.FromArgb(80, 60, 50)), //oranzova
            new SolidBrush(Color.FromArgb(80, 50, 50)), //cervena
        };

        public Brush[] StupenBarva = {
            //new SolidBrush(Color.FromArgb(100, 120, 255)), //modra
            new SolidBrush(Color.FromArgb(120, 160, 255)), //modra
            new SolidBrush(Color.FromArgb(120, 255, 120)), //zelena
            new SolidBrush(Color.FromArgb(255, 255, 120)), //zluta
            new SolidBrush(Color.FromArgb(255, 160, 120)), //oranzova
            new SolidBrush(Color.FromArgb(255, 120, 120)), //cervena
        };

        // Prumer 

        public Font PrumerPredmetPismo = new Font("Segoe UI", 14.0f, FontStyle.Bold);
        public Font PrumerPrumerPismo = new Font("Segoe UI", 12.0f, FontStyle.Bold);


        //public Brush 
    }

    public static class ZnamkyRenderer {
        enum TypProuzku { Zahlavi, Znamka }

        public class ZnamkyRenderResult {
            public Image Znamky;
            public Image Prumer;
            public ZnamkyRenderResult(Image znamky, Image prumer) {
                Znamky = znamky;
                Prumer = prumer;
            }
            public ZnamkyRenderResult() {
                Znamky = new Bitmap(1, 1);
                Prumer = Znamky;
            }
        }

        public static ZnamkyRenderResult Vyrendrovat(ZnamkyStyl Styl , dynamic data, int w, int wp, int hp) {
            if (data == null) { return new ZnamkyRenderResult(RenderGlobal.VyrendrovatNacitani(w, 50), RenderGlobal.VyrendrovatNacitani(wp, hp)); }

            int h = 0;
            int Y = 0;

            JArray Subjects = data["Subjects"];

            foreach (JObject Subject in Subjects) {
                var SubMarks = Subject.Value<JArray>("Marks");
                h += Styl.VyskaPredmet;
                foreach (JObject Mark in SubMarks) {
                    h += Styl.VyskaZnamka;
                }
                h += Styl.Mezera;
            }

            h += Styl.Padding * 2 + 1;


            Bitmap BMP = new Bitmap(w, h);
            Graphics BMPG = Graphics.FromImage(BMP);

            Bitmap BMPo = new Bitmap(w, h);
            Graphics BMPoG = Graphics.FromImage(BMP);


            foreach (JObject Subject in Subjects) {
                NakreslitProuzek(BMPG, BMPoG, Styl, new Rectangle(Styl.Padding, Y + Styl.Padding, w - Styl.Padding * 2, Styl.VyskaPredmet), TypProuzku.Zahlavi, Subject);
                Y += Styl.VyskaPredmet;

                var SubMarks = Subject.Value<JArray>("Marks");

                foreach(JObject Mark in SubMarks) {
                    NakreslitProuzek(BMPG, BMPoG, Styl, new Rectangle(Styl.Padding, Y + Styl.Padding, w - Styl.Padding * 2, Styl.VyskaZnamka), TypProuzku.Znamka, Mark);
                    Y += Styl.VyskaZnamka;
                }
                Y += Styl.Mezera;
            }

            // Prumer

            Bitmap BMPp = new Bitmap(wp, hp);
            Graphics BMPpG = Graphics.FromImage(BMPp);
            Bitmap BMPop = new Bitmap(wp, hp);
            Graphics BMPopG = Graphics.FromImage(BMPop);


            if (Subjects.Count > 0) {
                double sirka = wp / Subjects.Count;
                for (var i = 0; i < Subjects.Count; i++) {
                    var Subject = Subjects[i];
                    int x = (int) Math.Floor(i * sirka);

                    var AverageText = Subject.Value<string>("AverageText");
                    var SubjectAbbrev = Subject.Value<JObject>("Subject").Value<string>("Abbrev");

                    var BarvyP = BarvaPodlePrumeru(Styl, AverageText);

                    var Oblast = new Rectangle(x, 0, (int)Math.Floor(sirka), hp);
                    var OblastM = RenderGlobal.RectPadding(Oblast, Styl.Margin);

                    BMPopG.DrawRectangle(Styl.Okraj, OblastM);

                    Rectangle OblastH = RenderGlobal.RectTrans(OblastM, 0, 3, 0, -Oblast.Height / 2);
                    Rectangle OblastD = RenderGlobal.RectTrans(OblastH, 0, Oblast.Height / 2, 0, 0);

                    BMPpG.FillRectangle(BarvyP.Background, OblastM);

                    RenderGlobal.NakreslitText(BMPpG, OblastH, SubjectAbbrev, Styl.PrumerPredmetPismo, BarvyP.Foreground, ZarH.Stred, ZarV.Dole);
                    RenderGlobal.NakreslitText(BMPpG, OblastD, AverageText, Styl.PrumerPrumerPismo, BarvyP.Foreground, ZarH.Stred, ZarV.Nahore);

                }

                if (Styl.Okraje)
                    BMPpG.DrawImage(BMPop, 0, 0);

            }


            if (Styl.Okraje)
                BMPG.DrawImage(BMPo, 0, 0);

            return new ZnamkyRenderResult(BMP, BMPp);
        }

        private static void NakreslitProuzek(Graphics G, Graphics Go, ZnamkyStyl Styl, Rectangle Oblast, TypProuzku Typ, JObject Data) {
            Rectangle OblastM = RenderGlobal.RectPadding(Oblast, Styl.Margin);
            Rectangle OblastZ = RenderGlobal.RectTrans(OblastM, 0, 0, OblastM.Height - OblastM.Width, 0);
            Rectangle OblastT = RenderGlobal.RectTrans(OblastM, OblastM.Height + Styl.Margin * 2, 0, - Styl.Margin - OblastM.Height, 0);

            switch (Typ) {
                case TypProuzku.Zahlavi:
                    var AverageText = Data.Value<string>("AverageText");
                    var BarvyP = BarvaPodlePrumeru(Styl, AverageText);
                    G.FillRectangle(BarvyP.Background, OblastZ);
                    RenderGlobal.NakreslitText(G, OblastZ, AverageText, Styl.ZahlaviPrumerPismo, BarvyP.Foreground, ZarH.Stred, ZarV.Stred);

                    G.FillRectangle(Styl.ZahlaviVypln, OblastT);
                    RenderGlobal.NakreslitText(G, OblastT, "  " + Data.Value<JObject>("Subject").Value<string>("Name"), Styl.ZahlaviPredmetPismo, Styl.ZahlaviPredmetBarva, ZarH.Vlevo, ZarV.Stred);
                    break;

                case TypProuzku.Znamka:
                    var MarkText = Data.Value<string>("MarkText");
                    var Barvy = BarvaPodleZnamky(Styl, Data.Value<bool>("IsPoints") ? "-" : MarkText);
                    G.FillRectangle(Barvy.Background, OblastZ);
                    RenderGlobal.NakreslitText(G, OblastZ, MarkText, Styl.ZnamkaZnamkaPismo, Barvy.Foreground, ZarH.Stred, ZarV.Stred);


                    G.FillRectangle(Styl.ZnamkaVypln, OblastT);
                    Brush Barva = Data.Value<bool>("IsNew") ? Styl.ZnamkaNovaBarva : Styl.ZnamkaBarva;
                    RenderGlobal.NakreslitText(G, OblastT, " " + Data.Value<string>("Caption"), Styl.ZnamkaTextPismo, Barva, ZarH.Vlevo, ZarV.Stred);
                    RenderGlobal.NakreslitText(G, OblastT, Data.Value<string>("TypeNote") + " [" + Data.Value<int>("Weight").ToString() + "]", Styl.ZnamkaVahaPismo, Barva, ZarH.Vpravo, ZarV.Dole);
                    var Datum = Data.Value<string>("MarkDate");
                    try {
                        Datum = DateTime.ParseExact(Datum, "MM/dd/yyyy HH:mm:ss", new System.Globalization.CultureInfo("cs-CZ")).ToString("d. M. yyyy");
                    } catch {
                    }

                    RenderGlobal.NakreslitText(G, OblastT, Datum, Styl.ZnamkaVahaPismo, Barva, ZarH.Vpravo, ZarV.Nahore, Styl.DatumFix);

                    break;

                default:
                    break;
            }

            if (Styl.Okraje) {
                Go.DrawRectangle(Styl.Okraj, OblastM);
                Go.DrawRectangle(Styl.Okraj, OblastZ);
            }
        }

        static DoubleBrush BarvaPodleZnamky(ZnamkyStyl Styl, string Znamka) {
            switch (Znamka.Trim()) {
                case "1":
                    return BarvaPodleId(Styl, 0);

                case "1-":
                case "2":
                    return BarvaPodleId(Styl, 1);

                case "2-":
                case "3":
                    return BarvaPodleId(Styl, 2);

                case "3-":
                case "4":
                    return BarvaPodleId(Styl, 3);

                case "4-":
                case "5":
                    return BarvaPodleId(Styl, 4);

                default:
                    return new DoubleBrush(Styl.ZnamkaVypln, Styl.ZnamkaBarva);       
            }
        }

        static DoubleBrush BarvaPodlePrumeru(ZnamkyStyl Styl, string Prumer) {
            try {
                return BarvaPodleId(Styl, (int)Math.Floor(double.Parse(Prumer, new System.Globalization.CultureInfo("cs-CZ")) + 0.55) - 1);
            } catch {
                return new DoubleBrush(Styl.ZnamkaVypln, Styl.ZnamkaBarva);
            }
        }

        static DoubleBrush BarvaPodleId(ZnamkyStyl Styl, int id) {
            return new DoubleBrush(Styl.StupenVypln[id], Styl.StupenBarva[id]);
        }
    }
}
