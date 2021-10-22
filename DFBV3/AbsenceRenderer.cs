using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json.Linq;

namespace DFBV3 {
    using Properties;

    public class AbsenceStyl {
        public int SirkaDatum = 200;
        public int SirkaPredmet = 232;
        public int SirkaBunka = 32;

        public int VyskaZahlavi = 32;
        public int VyskaBunky = 32;

        public int BunkaMargin = 2;

        public Brush BunkaVyplnZahlavi = new SolidBrush(Color.FromArgb(70, 72, 74));
        public Brush BunkaVypln = new SolidBrush(Color.FromArgb(50, 52, 54));

        public Font Pismo = new Font("Segoe UI", 10, FontStyle.Bold);
        public Brush BunkaF = new SolidBrush(Color.FromArgb(224, 224, 224));

    }

    public enum ZobrazeniAbsence {
        Dny,
        Mesice,
        Predmety
    }

    public class RadekAbsence {
        public string Nadpis;

        // Datum/Mesic
        public int Unsolved;
        public int Ok;
        public int Missed;

        // Predmet
        public int LessonsCount;
        public int Base;

        // Spolecny
        public int Late;
        public int Soon;
        public int School;
        public int DistanceTeaching;

        public RadekAbsence(string nadpis, int unsolved, int ok, int missed, int late, int soon, int school, int distanceTeaching) {
            Nadpis = nadpis;
            Unsolved = unsolved;
            Ok = ok;
            Missed = missed;
            Late = late;
            Soon = soon;
            School = school;
            DistanceTeaching = distanceTeaching;
        }

        public RadekAbsence(string nadpis, int lessonsCount, int _base, int late, int soon, int school, int distanceTeaching) {
            Nadpis = nadpis;
            LessonsCount = lessonsCount;
            Base = _base;
            Late = late;
            Soon = soon;
            School = school;
            DistanceTeaching = distanceTeaching;
        }
    }

    public static class AbsenceRenderer {
        public static Image Vyrendrovat(JObject data, ZobrazeniAbsence zobrazeni, AbsenceStyl Styl = null) {
            if (Styl == null) Styl = new AbsenceStyl();

            var Radky = new List<RadekAbsence>();
            int BMPw, BMPh;

            if (zobrazeni == ZobrazeniAbsence.Predmety) {
                JArray AbsencesPerSubject = data.Value<JArray>("AbsencesPerSubject");

                foreach (var predmet in AbsencesPerSubject) {
                    var SubjectName = predmet.Value<string>("SubjectName");
                    var LessonsCount = predmet.Value<int>("LessonsCount");
                    var Base = predmet.Value<int>("Base");
                    var Late = predmet.Value<int>("Late");
                    var Soon = predmet.Value<int>("Soon");
                    var School = predmet.Value<int>("School");
                    var DistanceTeaching = predmet.Value<int>("DistanceTeaching");

                    Radky.Add(new RadekAbsence(SubjectName, LessonsCount, Base, Late, Soon, School, DistanceTeaching));
                }

                BMPw = Styl.SirkaPredmet + Styl.SirkaBunka * 6;

            } else {
                JArray AbsencesPerSubject = data.Value<JArray>("Absences");

                foreach (var absence in AbsencesPerSubject) {
                    var Datum = absence.Value<DateTime>("Date");
                    var Unsolved = absence.Value<int>("Unsolved");
                    var Ok = absence.Value<int>("Ok");
                    var Missed = absence.Value<int>("Missed");
                    var Late = absence.Value<int>("Late");
                    var Soon = absence.Value<int>("Soon");
                    var School = absence.Value<int>("School");
                    var DistanceTeaching = absence.Value<int>("DistanceTeaching");

                    if (zobrazeni == ZobrazeniAbsence.Dny) {
                        Radky.Add(new RadekAbsence(Datum.ToShortDateString(), Unsolved, Ok, Missed, Late, Soon, School, DistanceTeaching));
                    }
                    else {
                        PridatDoMesice(ref Radky, Datum, Unsolved, Ok, Missed, Late, Soon, School, DistanceTeaching);
                    }
                }

                BMPw = Styl.SirkaDatum + Styl.SirkaBunka * 7;
            }

            BMPh = Styl.VyskaZahlavi + Styl.VyskaBunky * Radky.Count;

            var BMP = new Bitmap(BMPw, BMPh);
            var BMPG = Graphics.FromImage(BMP);

            int x = 0;
            if (zobrazeni == ZobrazeniAbsence.Predmety) {
                NakreslitBunku(BMPG, Styl, new Rectangle(0, 0, Styl.SirkaPredmet, Styl.VyskaZahlavi), "předmět", true);
                NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaPredmet, 0, Styl.SirkaBunka, Styl.VyskaZahlavi), "celk.", true);
                NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaPredmet + Styl.SirkaBunka, 0, Styl.SirkaBunka, Styl.VyskaZahlavi), "abs.", true);
                x = Styl.SirkaPredmet + Styl.SirkaBunka * 2;
            } else {
                NakreslitBunku(BMPG, Styl, new Rectangle(0, 0, Styl.SirkaDatum, Styl.VyskaZahlavi), (zobrazeni == ZobrazeniAbsence.Dny) ? "datum" : "měsíc", true);
                NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaDatum, 0, Styl.SirkaBunka, Styl.VyskaZahlavi), null, true, Resources.AbsUnsolved);
                NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaDatum + Styl.SirkaBunka, 0, Styl.SirkaBunka, Styl.VyskaZahlavi), null, true, Resources.AbsOk);
                NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaDatum + Styl.SirkaBunka * 2, 0, Styl.SirkaBunka, Styl.VyskaZahlavi), null, true, Resources.AbsMissed);
                x = Styl.SirkaDatum + Styl.SirkaBunka * 3;
            }
            NakreslitBunku(BMPG, Styl, new Rectangle(x, 0, Styl.SirkaBunka, Styl.VyskaZahlavi), null, true, Resources.AbsLate);
            NakreslitBunku(BMPG, Styl, new Rectangle(x + Styl.SirkaBunka, 0, Styl.SirkaBunka, Styl.VyskaZahlavi), null, true, Resources.AbsSoon);
            NakreslitBunku(BMPG, Styl, new Rectangle(x + Styl.SirkaBunka * 2, 0, Styl.SirkaBunka, Styl.VyskaZahlavi), null, true, Resources.AbsSchool);
            NakreslitBunku(BMPG, Styl, new Rectangle(x + Styl.SirkaBunka * 3, 0, Styl.SirkaBunka, Styl.VyskaZahlavi), null, true, Resources.AbsDistanceTeaching);

            for (var i = 0; i < Radky.Count; i++) {
                x = 0;
                int y = Styl.VyskaZahlavi + i * Styl.VyskaBunky;
                var radek = Radky[i];
                if (zobrazeni == ZobrazeniAbsence.Predmety) {
                    NakreslitBunku(BMPG, Styl, new Rectangle(0, y, Styl.SirkaPredmet, Styl.VyskaBunky), radek.Nadpis, false);
                    NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaPredmet, y, Styl.SirkaBunka, Styl.VyskaBunky), radek.LessonsCount.ToString());
                    NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaPredmet + Styl.SirkaBunka, y, Styl.SirkaBunka, Styl.VyskaBunky), StrAbs(radek.Base));
                    x = Styl.SirkaPredmet + Styl.SirkaBunka * 2;
                } else {
                    NakreslitBunku(BMPG, Styl, new Rectangle(0, y, Styl.SirkaDatum, Styl.VyskaBunky), radek.Nadpis, false);
                    NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaDatum, y, Styl.SirkaBunka, Styl.VyskaBunky), StrAbs(radek.Unsolved));
                    NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaDatum + Styl.SirkaBunka, y, Styl.SirkaBunka, Styl.VyskaBunky), StrAbs(radek.Ok));
                    NakreslitBunku(BMPG, Styl, new Rectangle(Styl.SirkaDatum + Styl.SirkaBunka * 2, y, Styl.SirkaBunka, Styl.VyskaBunky), StrAbs(radek.Missed));
                    x = Styl.SirkaDatum + Styl.SirkaBunka * 3;
                }
                NakreslitBunku(BMPG, Styl, new Rectangle(x, y, Styl.SirkaBunka, Styl.VyskaBunky), StrAbs(radek.Late));
                NakreslitBunku(BMPG, Styl, new Rectangle(x + Styl.SirkaBunka, y, Styl.SirkaBunka, Styl.VyskaBunky), StrAbs(radek.Soon));
                NakreslitBunku(BMPG, Styl, new Rectangle(x + Styl.SirkaBunka * 2, y, Styl.SirkaBunka, Styl.VyskaBunky), StrAbs(radek.School));
                NakreslitBunku(BMPG, Styl, new Rectangle(x + Styl.SirkaBunka * 3, y, Styl.SirkaBunka, Styl.VyskaBunky), StrAbs(radek.DistanceTeaching));
            }



            return BMP;
        }

        static void NakreslitBunku(Graphics G, AbsenceStyl Styl, Rectangle Oblast, string Text, bool Zahlavi = false, Image Ikona = null) {
            var OblastP = RenderGlobal.RectPadding(Oblast, Styl.BunkaMargin);
            G.FillRectangle(Zahlavi ? Styl.BunkaVyplnZahlavi : Styl.BunkaVypln, OblastP);
            if (Text != null) RenderGlobal.NakreslitText(G, OblastP, Text, Styl.Pismo, Styl.BunkaF, ZarH.Stred, ZarV.Stred);
            if (Ikona != null) {
                var Pozice = new Point(Oblast.X + Oblast.Width / 2 - Ikona.Width / 2, Oblast.Y + Oblast.Height / 2 - Ikona.Height / 2);
                G.DrawImage(Ikona, Pozice);
            }
        }

        static string StrAbs(int a) {
            return (a == 0) ? "" : a.ToString();
        }

        static void PridatDoMesice(ref List<RadekAbsence> Radky, DateTime datum, int unsolved, int ok, int missed, int late, int soon, int school, int distanceTeaching) {
            string[] mesice = { "", "leden", "únor", "březen", "duben", "květen", "červen", "červenec", "srpen", "září", "říjen", "listopad", "prosinec"};
            string kategorie = mesice[datum.Month] + " " + datum.Year.ToString();
            for (int i = 0; i < Radky.Count; i++) {
                if (Radky[i].Nadpis == kategorie) {
                    Radky[i].Unsolved += unsolved;
                    Radky[i].Ok += ok;
                    Radky[i].Missed += missed;
                    Radky[i].Late += late;
                    Radky[i].Soon += soon;
                    Radky[i].School += school;
                    Radky[i].DistanceTeaching += distanceTeaching;
                    return;
                }
            }

            Radky.Add(new RadekAbsence(kategorie, unsolved, ok, missed, late, soon, school, distanceTeaching));
        }

    }
}
