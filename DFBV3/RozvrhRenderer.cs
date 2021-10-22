using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DFBV3 { 
    class RozvrhStyl {
        public Color Pozadi = Color.FromArgb(42, 44, 47);

        public float VyskaZahlaviHodiny = 60;
        public float SirkaZahlavniDne = 60;

        public bool OkrajeBunek = false;
        public Pen Okraje = new Pen(Brushes.Black, 2);

        public bool KreslitPozadi = false;

        public int BunkaPadding = 2;

        public int WidthFix = 0;

        public Brush BunkaVyplnZahlavi = new SolidBrush(Color.FromArgb(70, 72, 74));

        public Font ZahlaviHodinaCislo = new Font("Segoe UI", 12, FontStyle.Regular);
        public Font ZahlaviHodinaCas = new Font("Segoe UI", 8, FontStyle.Regular);
        public Brush ZahlaviHodinaF = new SolidBrush(Color.FromArgb(190, 190, 190));

        public Font ZahlaviDen = new Font("Segoe UI", 12, FontStyle.Regular);
        public Font ZahlaviDenDatum = new Font("Verdana", 8, FontStyle.Regular);
        public Brush ZahlaviDenF = new SolidBrush(Color.FromArgb(190, 190, 190));

        public Font HodinaZkr = new Font("Segoe UI", 13, FontStyle.Bold);
        public Font HodinaTr = new Font("Segoe UI", 8, FontStyle.Bold);
        public Font HodinaUc = new Font("Segoe UI", 9, FontStyle.Regular);

        public Brush HodinaF = new SolidBrush(Color.FromArgb(224, 224, 224));
        public Brush HodinaTrF = new SolidBrush(Color.FromArgb(224, 224, 224));
        public Brush BunkaVyplnHodina = new SolidBrush(Color.FromArgb(50, 52, 54));

        public Brush HodinaCHF = new SolidBrush(Color.FromArgb(255, 170, 170));
        public Brush HodinaCHTrF = new SolidBrush(Color.FromArgb(255, 170, 170));
        public Brush BunkaVyplnHodinaCH = new SolidBrush(Color.FromArgb(65, 52, 54));

        public Brush HodinaAF = new SolidBrush(Color.FromArgb(140, 255, 140));
        public Brush HodinaATrF = new SolidBrush(Color.FromArgb(140, 255, 140));
        public Brush BunkaVyplnHodinaA = new SolidBrush(Color.FromArgb(50, 65, 54));

        public Brush HodinaSvF = new SolidBrush(Color.FromArgb(140, 255, 255));
        public Brush HodinaSvTrF = new SolidBrush(Color.FromArgb(140, 255, 255));
        public Brush BunkaVyplnHodinaSv = new SolidBrush(Color.FromArgb(50, 65, 65));

        public Brush HodinaHdF = new SolidBrush(Color.FromArgb(255, 140, 255));
        public Brush HodinaHdTrF = new SolidBrush(Color.FromArgb(255, 140, 255));
        public Brush BunkaVyplnHodinaHd = new SolidBrush(Color.FromArgb(65, 50, 65));

        public Pen ZvyrazneniOkraj = Pens.Transparent; //new Pen(Color.FromArgb(120, Color.Yellow), 2);
        public Brush ZvyrazneniVypln = new SolidBrush(Color.FromArgb(30, Color.Yellow));
    }

    enum TypBunky {
        Roh, ZahlaviHodiny, ZahlaviDne, Hodina, HodinaX
    }

    static class RozvrhRenderer {
        public enum TypHodiny {
            Normalni, A, X, CH, Svatek, Prazdniny
        }

        public class ZpracovanaHodina {
            public string Nazev = "";
            public string Zkratka = "";
            public string Ucitel = "";
            public string Uc = "";
            public string Trida = "";
            public string Tr = "";
            public string Tema = "";
            public string Zmena = "";
            public TypHodiny Typ = TypHodiny.X;

            public ZpracovanaHodina(JObject Atom, JArray Predmety, JArray Ucitele, JArray Ucebny) {
                Tema = Atom.Value<string>("Theme");

                string PredmetID = Atom.Value<string>("SubjectId");
                if (PredmetID != null) {
                    JObject Predmet = PodleId(Predmety, PredmetID);
                    Zkratka = Predmet.Value<string>("Abbrev");
                    Nazev = Predmet.Value<string>("Name");
                }

                string UcitelID = Atom.Value<string>("TeacherId");
                if (UcitelID != null) {
                    JObject UcitelO = PodleId(Ucitele, UcitelID);
                    Uc = UcitelO.Value<string>("Abbrev");
                    Ucitel = UcitelO.Value<string>("Name");
                }

                string TridaID = Atom.Value<string>("RoomId");
                if (TridaID != null) {
                    JObject TridaO = PodleId(Ucebny, TridaID);
                    Tr = TridaO.Value<string>("Abbrev");
                    Trida = TridaO.Value<string>("Name");
                }

                JObject Change = Atom.Value<JObject>("Change");
                if (Change != null) {
                    Typ = TypHodiny.CH;
                    if (Change.Value<string>("ChangeType") == "Canceled") {
                        Typ = TypHodiny.A;
                    }

                    string TypeAbbrev = Change.Value<string>("TypeAbbrev");
                    if (TypeAbbrev != null)
                        Zkratka = TypeAbbrev;


                    if (TypeAbbrev == null || TypeAbbrev == "")
                        Typ = TypHodiny.CH;

                    string TypeName = Change.Value<string>("TypeName");
                    if (string.IsNullOrEmpty(Nazev) && !string.IsNullOrEmpty(TypeName))
                        Nazev = TypeName;

                    string ChangeDescription = Change.Value<string>("Description");
                    if (!string.IsNullOrEmpty(ChangeDescription))
                        Zmena = ChangeDescription;
                }
            }

            public ZpracovanaHodina() {

            }

            private JObject PodleId(JArray arr, string Id) {
                foreach(JObject Item in arr) {
                    if (Item.Value<string>("Id") == Id)
                        return Item;
                }
                return null;
            }
        }

        public class RozvrhRenderVysledek {
            private Image _Img;
            private List<Interaktivni<ZpracovanaHodina>> _Oblasti;
            public RozvrhRenderVysledek(Image Img, List<Interaktivni<ZpracovanaHodina>> Oblasti) {
                _Img = Img;
                _Oblasti = Oblasti;
            }

            public Image ziskatObrazek() {
                return _Img;
            }

            public List<Interaktivni<ZpracovanaHodina>> ziskatOblasti() {
                return _Oblasti;
            }
        }

        public static RozvrhRenderVysledek Vyrendrovat(dynamic data, int w, int h, RozvrhStyl Styl = null) {
            if (Styl == null)
                Styl = new RozvrhStyl();

            Bitmap BMP = new Bitmap(w, h);
            Graphics BMPG = Graphics.FromImage(BMP);

            var oblasti = new List<Interaktivni<ZpracovanaHodina>>();

            if (Styl.KreslitPozadi)
                BMPG.Clear(Styl.Pozadi);

            if (data == null)
                return new RozvrhRenderVysledek(RenderGlobal.VyrendrovatNacitani(w, h), oblasti);

            JArray Hours = data["Hours"];
            int nHours = Hours.Count;

            JArray Days = data["Days"];
            int nDays = Days.Count;

            JArray Subjects = data["Subjects"];
            JArray Teachers = data["Teachers"];
            JArray Rooms = data["Rooms"];

            var ES = new SizeF(Styl.SirkaZahlavniDne, Styl.VyskaZahlaviHodiny);
            var BS = new SizeF((w - ES.Width) / nHours, (h - ES.Height) / nDays);
            var HS = new SizeF(BS.Width, ES.Height);
            var DS = new SizeF(ES.Width, BS.Height);

            NakreslitBunku(BMPG, Styl, OblastBunky(ES, ES, -1, -1), TypBunky.Roh, null, ref oblasti);

            int PoradiH = 0;
            int PoradiD = 0;

            var Hodiny = new Dictionary<int, int> { };

            foreach (JObject Hour in Hours) {
                NakreslitBunku(BMPG, Styl, OblastBunky(ES, HS, PoradiH, -1), TypBunky.ZahlaviHodiny, Hour, ref oblasti);
                Hodiny.Add(Hour.Value<int>("Id"), PoradiH);
                PoradiH++;
            }

            foreach (JObject Day in Days) {
                NakreslitBunku(BMPG, Styl, OblastBunky(ES, DS, -1, PoradiD), TypBunky.ZahlaviDne, Day, ref oblasti);

                if (Day.Value<string>("DayType") == "Celebration") {
                    var sv = new ZpracovanaHodina();
                    sv.Zkratka = Day.Value<string>("DayDescription");
                    sv.Typ = TypHodiny.Svatek;
                    NakreslitBunku(BMPG, Styl, OblastBunky(ES, BS, 0, PoradiD, nHours), TypBunky.Hodina, null, ref oblasti, sv);
                    PoradiD++;
                    continue;
                }

                if (Day.Value<string>("DayType") == "Holiday") {
                    var hd = new ZpracovanaHodina();
                    hd.Zkratka = "Prázdniny";
                    hd.Typ = TypHodiny.Prazdniny;
                    NakreslitBunku(BMPG, Styl, OblastBunky(ES, BS, 0, PoradiD, nHours), TypBunky.Hodina, null, ref oblasti, hd);
                    PoradiD++;
                    continue;
                }

                var HoursDrawn = new List<int> { };

                List<JObject>[] HourStack = new List<JObject>[nHours];
                for (int i = 0; i < nHours; i++)
                    HourStack[i] = new List<JObject>();

                JArray Atoms = Day.Value<JArray>("Atoms");
                foreach (JObject Atom in Atoms)
                {
                    var HourId = Atom.Value<int>("HourId");
                    if (!Hodiny.ContainsKey(HourId))
                        continue;

                    PoradiH = Hodiny[HourId];
                    if (PoradiH >= nHours) continue;

                    HourStack[PoradiH].Add(Atom);
                    HoursDrawn.Add(PoradiH);
                }

                for (PoradiH = 0; PoradiH < nHours; PoradiH++)
                {
                    var Skupin = HourStack[PoradiH].Count;
                    for (int i = 0; i < Skupin; i++)
                    {
                        var Atom = HourStack[PoradiH][i];
                        NakreslitBunku(BMPG, Styl, CastBunky(OblastBunky(ES, BS, PoradiH, PoradiD), i, Skupin), TypBunky.Hodina, null, ref oblasti, new ZpracovanaHodina(Atom, Subjects, Teachers, Rooms));
                    }
                }


                //var HoursDrawn = new List<int> { };

                //JArray Atoms = Day.Value<JArray>("Atoms");
                //foreach (JObject Atom in Atoms) {
                //    var HourId = Atom.Value<int>("HourId");
                //    if (!Hodiny.ContainsKey(HourId))
                //        continue;

                //    PoradiH = Hodiny[HourId];
                //    HoursDrawn.Add(PoradiH);
                //    NakreslitBunku(BMPG, Styl, OblastBunky(ES, BS, PoradiH, PoradiD), TypBunky.Hodina, null, ref oblasti, new ZpracovanaHodina(Atom, Subjects, Teachers, Rooms));
                //}

                if (Styl.OkrajeBunek) {
                    for (PoradiH = 0; PoradiH <= nHours; PoradiH++) {
                        if (!HoursDrawn.Contains(PoradiH))
                        NakreslitBunku(BMPG, Styl, OblastBunky(ES, BS, PoradiH, PoradiD), TypBunky.HodinaX, null, ref oblasti, null);
                    }
                }

                PoradiD++;
            }

            return new RozvrhRenderVysledek(BMP, oblasti);        
        }

        private static void NakreslitBunku(Graphics G, RozvrhStyl Styl, Rectangle Oblast, TypBunky Typ, JObject Data, ref List<Interaktivni<ZpracovanaHodina>> oblasti, ZpracovanaHodina DataH = null) {
            Rectangle rectPadding = RenderGlobal.RectPadding(Oblast, Styl.BunkaPadding);


            switch (Typ) {
                case TypBunky.Roh:
                    G.FillRectangle(Styl.BunkaVyplnZahlavi, rectPadding);
                    break;

                case TypBunky.ZahlaviHodiny:
                    G.FillRectangle(Styl.BunkaVyplnZahlavi, rectPadding);
                    RenderGlobal.NakreslitText(G, Oblast, Data.Value<string>("BeginTime"), Styl.ZahlaviHodinaCas, Styl.ZahlaviHodinaF, ZarH.Vlevo, ZarV.Nahore);
                    RenderGlobal.NakreslitText(G, Oblast, Data.Value<string>("Caption"), Styl.ZahlaviHodinaCislo, Styl.ZahlaviHodinaF, ZarH.Stred, ZarV.Stred, Styl.WidthFix);
                    RenderGlobal.NakreslitText(G, Oblast, Data.Value<string>("EndTime"), Styl.ZahlaviHodinaCas, Styl.ZahlaviHodinaF, ZarH.Vpravo, ZarV.Dole);
                    break;

                case TypBunky.ZahlaviDne:
                    G.FillRectangle(Styl.BunkaVyplnZahlavi, rectPadding);
                    RenderGlobal.NakreslitText(G, RenderGlobal.RectTrans(Oblast, 0, -5), DenVTydnu(Data.Value<int>("DayOfWeek")), Styl.ZahlaviDen, Styl.ZahlaviDenF, ZarH.Stred, ZarV.Stred, Styl.WidthFix);
                    RenderGlobal.NakreslitText(G, RenderGlobal.RectTrans(Oblast, 0 , 15), KratkyDatum(Data.Value<string>("Date")), Styl.ZahlaviDenDatum, Styl.ZahlaviDenF, ZarH.Stred, ZarV.Stred, Styl.WidthFix);
                    break;

                case TypBunky.Hodina:
                    Brush Vypln = Styl.BunkaVyplnHodina;
                    Brush TextF = Styl.HodinaF;
                    Brush TextTrF = Styl.HodinaTrF;

                    if (DataH.Typ == TypHodiny.CH) {
                        Vypln = Styl.BunkaVyplnHodinaCH;
                        TextF = Styl.HodinaCHF;
                        TextTrF = Styl.HodinaCHTrF;
                    }

                    if (DataH.Typ == TypHodiny.A) {
                        Vypln = Styl.BunkaVyplnHodinaA;
                        TextF = Styl.HodinaAF;
                        TextTrF = Styl.HodinaATrF;
                    }

                    if (DataH.Typ == TypHodiny.Svatek) {
                        Vypln = Styl.BunkaVyplnHodinaSv;
                        TextF = Styl.HodinaSvF;
                        TextTrF = Styl.HodinaSvTrF;
                    }

                    if (DataH.Typ == TypHodiny.Prazdniny) {
                        Vypln = Styl.BunkaVyplnHodinaHd;
                        TextF = Styl.HodinaHdF;
                        TextTrF = Styl.HodinaHdTrF;
                    }

                    G.FillRectangle(Vypln, rectPadding);
                    RenderGlobal.NakreslitText(G, Oblast, DataH.Zkratka, Styl.HodinaZkr, TextF, ZarH.Stred, ZarV.Stred, Styl.WidthFix);
                    //NakreslitText(G, RectTrans(Oblast,1,1), DataH.Tr, Styl.HodinaTr, TextTrF, ZarH.Vlevo, ZarV.Nahore);
                    //NakreslitText(G, RectTrans(Oblast, 0, 30), DataH.Uc, Styl.HodinaUc, TextF, ZarH.Stred, ZarV.Stred);

                    RenderGlobal.NakreslitText(G, Oblast, DataH.Tr, Styl.HodinaTr, TextTrF, ZarH.Vpravo, ZarV.Nahore, Styl.WidthFix);
                    RenderGlobal.NakreslitText(G, Oblast, DataH.Uc, Styl.HodinaUc, TextF, ZarH.Stred, ZarV.Dole, Styl.WidthFix);

                    string zv = Properties.Settings.Default.Zvyraznit;

                    if (zv != "" && (Obsahuje(DataH.Nazev, zv) || Obsahuje(DataH.Tema, zv) || Obsahuje(DataH.Tr, zv) || Obsahuje(DataH.Trida, zv) || Obsahuje(DataH.Uc, zv) || Obsahuje(DataH.Ucitel, zv) || Obsahuje(DataH.Zkratka, zv) || Obsahuje(DataH.Zmena, zv))) {
                        G.FillRectangle(Styl.ZvyrazneniVypln, rectPadding);
                        G.DrawRectangle(Styl.ZvyrazneniOkraj, rectPadding);
                    }

                    oblasti.Add(new Interaktivni<ZpracovanaHodina>(rectPadding, DataH));

                    break;

                case TypBunky.HodinaX:
                    break;
            }

            if (Styl.OkrajeBunek) {
                G.DrawRectangle(Styl.Okraje, Oblast);
            }
        }

        private static bool Obsahuje(string v1, string v2) {
            if (v1 == null || v2 == null) return false;
            return v1.IndexOf(v2, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private static Rectangle OblastBunky(SizeF Skip, SizeF Velikost, int Hodina, int Den, int Hodin = 1) {
            Point PozVl = PoziceBunky(Skip, Velikost, Hodina, Den);
            Point PozNx = PoziceBunky(Skip, Velikost, Hodina + Hodin, Den + 1);

            return new Rectangle(PozVl.X, PozVl.Y, PozNx.X - PozVl.X, PozNx.Y - PozVl.Y);
        }

        private static Rectangle CastBunky(Rectangle r, int n, int pocet) {
            var vyska = (float)r.Height / pocet;
            return new Rectangle(r.X, r.Y + (int)(n * vyska), r.Width, (int)vyska);
        }

        private static Point PoziceBunky(SizeF Skip, SizeF Velikost, int Hodina, int Den) {
            return new Point((int)(Skip.Width + Velikost.Width * Hodina), (int)(Skip.Height + Velikost.Height * Den));
        }

        private static string DenVTydnu(int v) {
            return (new string[] { "", "Po", "Út", "St", "Čt", "Pá", "So", "Ne" })[v];
        }

        private static string KratkyDatum(string datum) {
            return DateTime.ParseExact(datum, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture).ToString("d. M.");
        }
    }
}
