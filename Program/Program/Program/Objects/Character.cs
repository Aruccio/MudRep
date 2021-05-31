using Program.Management;

namespace Program
{
    public class Character : IOdmienialny
    {
        public Character()
        {
        }

        public string Name { get; set; }
        public string Short { get; set; }

        public string Gender { get; set; }
        public bool Infight { get; set; }

        public int Sila { get; set; }
        public int Zrecznosc { get; set; }
        public int Wytrzymalosc { get; set; }
        public int Intelekt { get; set; }
        public int Odwaga { get; set; }

        public double HP { get; set; }

        public string[] SilaStr { get; set; } = new string[2] { "", "" };
        public string[] ZrecznoscStr { get; set; } = new string[2] { "", "" };
        public string[] WytrzymaloscStr { get; set; } = new string[2] { "", "" };
        public string[] IntelektStr { get; set; } = new string[2] { "", "" };
        public string[] OdwagaStr { get; set; } = new string[2] { "", "" };

        public Weapon WeaponInHand { get; set; }

        public void DoCech()
        {
            if (Gender == "mezczyzna")
            {
                //cechy glowne, mezczyzni

                //Sila
                if (Sila < 10) SilaStr[0] = "slabowity";
                else if (Sila < 20) SilaStr[0] = "watly";
                else if (Sila < 30) SilaStr[0] = "slaby";
                else if (Sila < 40) SilaStr[0] = "krzepki";
                else if (Sila < 50) SilaStr[0] = "5";
                else if (Sila < 60) SilaStr[0] = "6";
                else if (Sila < 70) SilaStr[0] = "mocny";
                else if (Sila < 80) SilaStr[0] = "silny";
                else if (Sila < 90) SilaStr[0] = "potezny";
                else if (Sila < 100) SilaStr[0] = "mocarny";
                else if (Sila < 110) SilaStr[0] = "epicko silny";
                else if (Sila < 120) SilaStr[0] = "legendarnie silny";
                else if (Sila < 130) SilaStr[0] = "nadludzko silny";
                else SilaStr[0] = "(cos poszlo nie tak!)";

                //Zrecznosc
                if (Zrecznosc < 10) ZrecznoscStr[0] = "niezgrabny";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "niezdarny";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "zgrabny";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "sprawny";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "sprezysty";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "gietki";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "zwinny";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "zreczny";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "gibki";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "akrobatyczny";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "epicko zreczny";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "legendarnie zreczny";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "nadludzko zreczny";
                else ZrecznoscStr[0] = "(cos poszlo nie tak!)";

                //Wytrzymalosc
                if (Wytrzymalosc < 10) WytrzymaloscStr[0] = "wiotki";
                else if (Wytrzymalosc < 20) WytrzymaloscStr[0] = "cherlawy";
                else if (Wytrzymalosc < 30) WytrzymaloscStr[0] = "mizerny";
                else if (Wytrzymalosc < 40) WytrzymaloscStr[0] = "tegi";
                else if (Wytrzymalosc < 50) WytrzymaloscStr[0] = "twardy";
                else if (Wytrzymalosc < 60) WytrzymaloscStr[0] = "postawny";
                else if (Wytrzymalosc < 70) WytrzymaloscStr[0] = "dobrze zbudowany";
                else if (Wytrzymalosc < 80) WytrzymaloscStr[0] = "wytrzymaly";
                else if (Wytrzymalosc < 90) WytrzymaloscStr[0] = "muskularny";
                else if (Wytrzymalosc < 100) WytrzymaloscStr[0] = "atletyczny";
                else if (Wytrzymalosc < 110) WytrzymaloscStr[0] = "epicko wytrzymaly";
                else if (Wytrzymalosc < 120) WytrzymaloscStr[0] = "legendarnie wytrzymaly";
                else if (Wytrzymalosc < 130) WytrzymaloscStr[0] = "nadludzko wytrzymaly";
                else WytrzymaloscStr[0] = "(cos poszlo nie tak!)";

                //Intelekt
                if (Intelekt < 10) IntelektStr[0] = "glupi";
                else if (Intelekt < 20) IntelektStr[0] = "niemadry";
                else if (Intelekt < 30) IntelektStr[0] = "rozumny";
                else if (Intelekt < 40) IntelektStr[0] = "zdolny";
                else if (Intelekt < 50) IntelektStr[0] = "sprytny";
                else if (Intelekt < 60) IntelektStr[0] = "pojetny";
                else if (Intelekt < 70) IntelektStr[0] = "bystry";
                else if (Intelekt < 80) IntelektStr[0] = "inteligentny";
                else if (Intelekt < 90) IntelektStr[0] = "blyskotliwy";
                else if (Intelekt < 100) IntelektStr[0] = "genialny";
                else if (Intelekt < 110) IntelektStr[0] = "epicko inteligentny";
                else if (Intelekt < 120) IntelektStr[0] = "legendarnie inteligentny";
                else if (Intelekt < 130) IntelektStr[0] = "nadludzko inteligentny";
                else IntelektStr[0] = "(cos poszlo nie tak!)";

                //Odwaga
                if (Odwaga < 10) OdwagaStr[0] = "plochliwy";
                else if (Odwaga < 20) OdwagaStr[0] = "strachliwy";
                else if (Odwaga < 20) OdwagaStr[0] = "lekliwy";
                else if (Odwaga < 20) OdwagaStr[0] = "zuchwaly";
                else if (Odwaga < 20) OdwagaStr[0] = "smialy";
                else if (Odwaga < 20) OdwagaStr[0] = "pewny siebie";
                else if (Odwaga < 20) OdwagaStr[0] = "dzielny";
                else if (Odwaga < 20) OdwagaStr[0] = "odwazny";
                else if (Odwaga < 20) OdwagaStr[0] = "nieugiety";
                else if (Odwaga < 20) OdwagaStr[0] = "heroiczny";
                else if (Odwaga < 20) OdwagaStr[0] = "epicko odwazny";
                else if (Odwaga < 20) OdwagaStr[0] = "legendarnie odwazny";
                else if (Odwaga < 20) OdwagaStr[0] = "nadludzko odwazny";
                else OdwagaStr[0] = "(cos poszlo nie tak!)";
            }
            else if (Gender == "kobieta")
            {
                //cechy glowne, kobiety

                //Sila
                if (Sila < 10) SilaStr[0] = "slabowita";
                else if (Sila < 20) SilaStr[0] = "watla";
                else if (Sila < 30) SilaStr[0] = "slaba";
                else if (Sila < 40) SilaStr[0] = "krzepka";
                else if (Sila < 50) SilaStr[0] = "5";
                else if (Sila < 60) SilaStr[0] = "6";
                else if (Sila < 70) SilaStr[0] = "mocna";
                else if (Sila < 80) SilaStr[0] = "silna";
                else if (Sila < 90) SilaStr[0] = "potezna";
                else if (Sila < 100) SilaStr[0] = "mocarna";
                else if (Sila < 110) SilaStr[0] = "epicko silna";
                else if (Sila < 120) SilaStr[0] = "legendarnie silna";
                else if (Sila < 130) SilaStr[0] = "nadludzko silna";
                else SilaStr[0] = "(cos poszlo nie tak!)";

                //Zrecznosc
                if (Zrecznosc < 10) ZrecznoscStr[0] = "niezgrabna";
                else if (Zrecznosc < 20) ZrecznoscStr[0] = "niezdarna";
                else if (Zrecznosc < 30) ZrecznoscStr[0] = "zgrabna";
                else if (Zrecznosc < 40) ZrecznoscStr[0] = "sprawna";
                else if (Zrecznosc < 50) ZrecznoscStr[0] = "sprezysta";
                else if (Zrecznosc < 60) ZrecznoscStr[0] = "gietka";
                else if (Zrecznosc < 70) ZrecznoscStr[0] = "zwinna";
                else if (Zrecznosc < 80) ZrecznoscStr[0] = "zreczna";
                else if (Zrecznosc < 90) ZrecznoscStr[0] = "gibka";
                else if (Zrecznosc < 100) ZrecznoscStr[0] = "akrobatyczna";
                else if (Zrecznosc < 110) ZrecznoscStr[0] = "epicko zreczna";
                else if (Zrecznosc < 120) ZrecznoscStr[0] = "legendarnie zreczna";
                else if (Zrecznosc < 130) ZrecznoscStr[0] = "nadludzko zreczna";
                else ZrecznoscStr[0] = "(cos poszlo nie tak!)";

                //Wytrzymalosc
                if (Wytrzymalosc < 10) WytrzymaloscStr[0] = "wiotka";
                else if (Wytrzymalosc < 20) WytrzymaloscStr[0] = "cherlawa";
                else if (Wytrzymalosc < 30) WytrzymaloscStr[0] = "mizerna";
                else if (Wytrzymalosc < 40) WytrzymaloscStr[0] = "tega";
                else if (Wytrzymalosc < 50) WytrzymaloscStr[0] = "twarda";
                else if (Wytrzymalosc < 60) WytrzymaloscStr[0] = "postawna";
                else if (Wytrzymalosc < 70) WytrzymaloscStr[0] = "dobrze zbudowana";
                else if (Wytrzymalosc < 80) WytrzymaloscStr[0] = "wytrzymala";
                else if (Wytrzymalosc < 90) WytrzymaloscStr[0] = "muskularna";
                else if (Wytrzymalosc < 100) WytrzymaloscStr[0] = "atletyczna";
                else if (Wytrzymalosc < 110) WytrzymaloscStr[0] = "epicko wytrzymala";
                else if (Wytrzymalosc < 120) WytrzymaloscStr[0] = "legendarnie wytrzymala";
                else if (Wytrzymalosc < 130) WytrzymaloscStr[0] = "nadludzko wytrzymala";
                else WytrzymaloscStr[0] = "(cos poszlo nie tak!)";

                //Intelekt
                if (Intelekt < 10) IntelektStr[0] = "glupia";
                else if (Intelekt < 20) IntelektStr[0] = "niemadra";
                else if (Intelekt < 30) IntelektStr[0] = "rozumna";
                else if (Intelekt < 40) IntelektStr[0] = "zdolna";
                else if (Intelekt < 50) IntelektStr[0] = "sprytna";
                else if (Intelekt < 60) IntelektStr[0] = "pojetna";
                else if (Intelekt < 70) IntelektStr[0] = "bystra";
                else if (Intelekt < 80) IntelektStr[0] = "inteligentna";
                else if (Intelekt < 90) IntelektStr[0] = "blyskotliwa";
                else if (Intelekt < 100) IntelektStr[0] = "genialna";
                else if (Intelekt < 110) IntelektStr[0] = "epicko inteligentna";
                else if (Intelekt < 120) IntelektStr[0] = "legendarnie inteligentna";
                else if (Intelekt < 130) IntelektStr[0] = "nadludzko inteligentna";
                else IntelektStr[0] = "(cos poszlo nie tak!)";

                //Odwaga
                if (Odwaga < 10) OdwagaStr[0] = "plochliwa";
                else if (Odwaga < 20) OdwagaStr[0] = "strachliwa";
                else if (Odwaga < 30) OdwagaStr[0] = "lekliwa";
                else if (Odwaga < 40) OdwagaStr[0] = "zuchwala";
                else if (Odwaga < 50) OdwagaStr[0] = "smiala";
                else if (Odwaga < 60) OdwagaStr[0] = "pewna siebie";
                else if (Odwaga < 70) OdwagaStr[0] = "dzielna";
                else if (Odwaga < 80) OdwagaStr[0] = "odwazna";
                else if (Odwaga < 90) OdwagaStr[0] = "nieugieta";
                else if (Odwaga < 100) OdwagaStr[0] = "heroiczna";
                else if (Odwaga < 110) OdwagaStr[0] = "epicko odwazna";
                else if (Odwaga < 120) OdwagaStr[0] = "legendarnie odwazna";
                else if (Odwaga < 130) OdwagaStr[0] = "nadludzko odwazna";
                else OdwagaStr[0] = "(cos poszlo nie tak!)";
            }

            switch (Sila % 10)
            {
                case 0: SilaStr[1] = "niemozliwie duzo"; break;
                case 1: SilaStr[1] = "ogromnie duzo"; break;
                case 2: SilaStr[1] = "bardzo duzo"; break;
                case 3: SilaStr[1] = "duzo"; break;
                case 4: SilaStr[1] = "troche"; break;
                case 5: SilaStr[1] = "malo"; break;
                case 6: SilaStr[1] = "bardzo malo"; break;
                case 7: SilaStr[1] = "niewiele"; break;
                case 8: SilaStr[1] = "bardzo niewiele"; break;
                case 9: SilaStr[1] = "minimalnie"; break;
            }
            switch (Zrecznosc % 10)
            {
                case 0: ZrecznoscStr[1] = "niemozliwie duzo"; break;
                case 1: ZrecznoscStr[1] = "ogromnie duzo"; break;
                case 2: ZrecznoscStr[1] = "bardzo duzo"; break;
                case 3: ZrecznoscStr[1] = "duzo"; break;
                case 4: ZrecznoscStr[1] = "troche"; break;
                case 5: ZrecznoscStr[1] = "malo"; break;
                case 6: ZrecznoscStr[1] = "bardzo malo"; break;
                case 7: ZrecznoscStr[1] = "niewiele"; break;
                case 8: ZrecznoscStr[1] = "bardzo niewiele"; break;
                case 9: ZrecznoscStr[1] = "minimalnie"; break;
            }
            switch (Wytrzymalosc % 10)
            {
                case 0: WytrzymaloscStr[1] = "niemozliwie duzo"; break;
                case 1: WytrzymaloscStr[1] = "ogromnie duzo"; break;
                case 2: WytrzymaloscStr[1] = "bardzo duzo"; break;
                case 3: WytrzymaloscStr[1] = "duzo"; break;
                case 4: WytrzymaloscStr[1] = "troche"; break;
                case 5: WytrzymaloscStr[1] = "malo"; break;
                case 6: WytrzymaloscStr[1] = "bardzo malo"; break;
                case 7: WytrzymaloscStr[1] = "niewiele"; break;
                case 8: WytrzymaloscStr[1] = "bardzo niewiele"; break;
                case 9: WytrzymaloscStr[1] = "minimalnie"; break;
            }
            switch (Intelekt % 10)
            {
                case 0: IntelektStr[1] = "niemozliwie duzo"; break;
                case 1: IntelektStr[1] = "ogromnie duzo"; break;
                case 2: IntelektStr[1] = "bardzo duzo"; break;
                case 3: IntelektStr[1] = "duzo"; break;
                case 4: IntelektStr[1] = "troche"; break;
                case 5: IntelektStr[1] = "malo"; break;
                case 6: IntelektStr[1] = "bardzo malo"; break;
                case 7: IntelektStr[1] = "niewiele"; break;
                case 8: IntelektStr[1] = "bardzo niewiele"; break;
                case 9: IntelektStr[1] = "minimalnie"; break;
            }
            switch (Odwaga % 10)
            {
                case 0: OdwagaStr[1] = "niemozliwie duzo"; break;
                case 1: OdwagaStr[1] = "ogromnie duzo"; break;
                case 2: OdwagaStr[1] = "bardzo duzo"; break;
                case 3: OdwagaStr[1] = "duzo"; break;
                case 4: OdwagaStr[1] = "troche"; break;
                case 5: OdwagaStr[1] = "malo"; break;
                case 6: OdwagaStr[1] = "bardzo malo"; break;
                case 7: OdwagaStr[1] = "niewiele"; break;
                case 8: OdwagaStr[1] = "bardzo niewiele"; break;
                case 9: OdwagaStr[1] = "minimalnie"; break;
            }
        }

        //  public Odmiana Odm
        //  { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Odmiana Odm { get; set; } = new Odmiana();
    }
}