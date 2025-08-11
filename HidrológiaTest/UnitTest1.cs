using static Hidrológia.Program;
using Hidrológia;

namespace HidrológiaTest
{
    public class Tests
    {

        Táj? táj = null;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void körökTest()
        {
            táj = beOlvas("input1.txt");
            körök(ref táj,10);
            Assert.That(táj.GetFöldek().First().név, Is.EqualTo("Bean"));
            Assert.That(táj.GetFöldek().First().km3, Is.EqualTo(85));
            Assert.That(táj.GetFöldek().First() is Tavas, Is.True);
            Assert.That(táj.GetFöldek().Last().név, Is.EqualTo("Teen"));
            Assert.That(táj.GetFöldek().Last().km3, Is.EqualTo(16));
            Assert.That(táj.GetFöldek().Last() is Zöld, Is.True);


            táj = beOlvas("input2.txt");
            körök(ref táj, 10);
            Assert.That(táj.GetFöldek().First().név, Is.EqualTo("Borsod"));
            Assert.That(táj.GetFöldek().First().km3, Is.EqualTo(0));
            Assert.That(táj.GetFöldek().First() is Puszta, Is.True);
            Assert.That(táj.GetFöldek().Last().név, Is.EqualTo("Borsod"));
            Assert.That(táj.GetFöldek().Last().km3, Is.EqualTo(0));
            Assert.That(táj.GetFöldek().Last() is Puszta, Is.True);
        }

        [Test]
        public void beOlvasTest()
        {
            //Üres fájlra hiba
            Assert.Throws<Exception>(() => { beOlvas("üres.txt"); });

            táj = beOlvas("input1.txt");
            Assert.That(táj.GetFöldek().Count(), Is.EqualTo(4));
            Assert.That(táj.atmoszféra.paraTartalom, Is.EqualTo(98));
            Assert.That(táj.atmoszféra.típus is Esős, Is.True);

            //Első föld helyes beolvasás
            Assert.That(táj.GetFöldek().First().név, Is.EqualTo("Bean"));
            Assert.That(táj.GetFöldek().First().km3, Is.EqualTo(86));
            Assert.That(táj.GetFöldek().First() is Tavas, Is.True);

            //Utolsó föld helyes beolvasása
            Assert.That(táj.GetFöldek().Last().név, Is.EqualTo("Teen"));
            Assert.That(táj.GetFöldek().Last().km3, Is.EqualTo(35));
            Assert.That(táj.GetFöldek().Last() is Zöld, Is.True);
        }

        [Test]
        public void körTest()
        {
            táj = beOlvas("input1.txt");

            táj.Kör();

            Assert.That(táj.atmoszféra.paraTartalom, Is.EqualTo(57));
            Assert.That(táj.atmoszféra.típus is Felhős, Is.True);

            Assert.That(táj.GetFöldek().First().km3, Is.EqualTo(101));
            Assert.That(táj.GetFöldek().First() is Tavas, Is.True);

            Assert.That(táj.GetFöldek().Last().km3, Is.EqualTo(33));
            Assert.That(táj.GetFöldek().Last() is Zöld, Is.True);


            táj.Kör();

            Assert.That(táj.atmoszféra.paraTartalom, Is.EqualTo(47));
            Assert.That(táj.atmoszféra.típus is Felhős, Is.True);

            Assert.That(táj.GetFöldek().First().km3, Is.EqualTo(98));
            Assert.That(táj.GetFöldek().First() is Tavas, Is.True);

            Assert.That(táj.GetFöldek().Last().km3, Is.EqualTo(31));
            Assert.That(táj.GetFöldek().Last() is Zöld, Is.True);

            táj = new Táj(new Atmoszféra(20));

            Assert.Throws<Exception>(() => { táj.Kör(); });
        }

        [Test]
        public void legVizesebbTest()
        {
            táj = beOlvas("input1.txt");

            FöldTerület max = táj.LegVizesebb();

            Assert.That(max, Is.EqualTo(táj.GetFöldek().First()));
            Assert.That(max.név, Is.EqualTo("Bean") );
            Assert.That(max is Tavas, Is.True);
            Assert.That(táj.GetFöldek().First().km3, Is.EqualTo(86));
            
            táj.Kör();

            max = táj.LegVizesebb();

            Assert.That(max, Is.EqualTo(táj.GetFöldek().First()));
            Assert.That(max.név, Is.EqualTo("Bean"));
            Assert.That(max.km3, Is.EqualTo(101));
            Assert.That(max is Tavas, Is.True);

            táj.Kör();

            max = táj.LegVizesebb();

            Assert.That(max, Is.EqualTo(táj.GetFöldek().First()));
            Assert.That(max.név, Is.EqualTo("Bean"));
            Assert.That(max.km3, Is.EqualTo(98));
            Assert.That(max is Tavas, Is.True);

            táj = new Táj(new Atmoszféra(20));

            Assert.Throws<Exception>(() => { táj.LegVizesebb();});
        }

        [Test]
        public void ParaModTest() {
            Atmoszféra a = new Atmoszféra(31);
            FöldTerület f = new Tavas("Cigány", 60);

            f.ParaMod(a);

            Assert.That(a.paraTartalom, Is.EqualTo(41));
            Assert.That(a.típus is Felhős, Is.True);

            a = new Atmoszféra(55);
            f.ParaMod(a);

            Assert.That(a.paraTartalom, Is.EqualTo(65));
            Assert.That(a.típus is Esős, Is.True);

            f.ParaMod(a);

            Assert.That(a.paraTartalom, Is.EqualTo(40));
            Assert.That(a.típus is Felhős, Is.True);

            a = new Atmoszféra(70);
            f = new Puszta("Cigány", 10);
            f.ParaMod(a);

            Assert.That(a.paraTartalom, Is.EqualTo(33));
            Assert.That(a.típus is Napos, Is.True);


        }

        [Test]
        public void VizModTest()
        {
            Típus t = Napos.Instance();
            FöldTerület f = new Tavas("Cigány",52);
            f = t.VizMod(f);

            Assert.That(f.km3, Is.EqualTo(42));
            Assert.That(f is Zöld, Is.True);

            f = new Zöld("Cigány", 17);
            t = Felhős.Instance();
            f = t.VizMod(f);

            Assert.That(f.km3, Is.EqualTo(15));
            Assert.That(f is Puszta, Is.True);

            t = Esős.Instance();
            f = t.VizMod(f);

            Assert.That(f.km3, Is.EqualTo(20));
            Assert.That(f is Zöld, Is.True);

            f = new Zöld("Cigány", 49);
            f = t.VizMod(f);

            Assert.That(f.km3, Is.EqualTo(59));
            Assert.That(f is Tavas, Is.True);

        }

        [Test]
        public void ParaValtTest()
        {
            Puszta p = new Puszta("Cig", 10);
            Zöld z = new Zöld("Cig", 30);
            Tavas t = new Tavas("Cig", 60);
            Atmoszféra a = new Atmoszféra(20);
            a.ParaValt(p);

            Assert.That(a.paraTartalom, Is.EqualTo(23));
            Assert.That(a.típus is Napos, Is.True);

            a.ParaValt(z);

            Assert.That(a.paraTartalom, Is.EqualTo(30));
            Assert.That(a.típus is Napos, Is.True);

            a.ParaValt(t);

            Assert.That(a.paraTartalom, Is.EqualTo(40));
            Assert.That(a.típus is Felhős, Is.True);

            a = new Atmoszféra(70);
            a.ParaValt(p);

            Assert.That(a.paraTartalom, Is.EqualTo(33));
            Assert.That(a.típus is Napos, Is.True);

            a = new Atmoszféra(70);
            a.ParaValt(z);

            Assert.That(a.paraTartalom, Is.EqualTo(37));
            Assert.That(a.típus is Napos, Is.True);

            a = new Atmoszféra(70);
            a.ParaValt(t);

            Assert.That(a.paraTartalom, Is.EqualTo(40));
            Assert.That(a.típus is Felhős, Is.True);
        }

        [Test]
        public void VizValtTest() {
            Napos n = Napos.Instance();
            Felhős f = Felhős.Instance();
            Esős e = Esős.Instance();
            FöldTerület f1 = new Puszta("Cig",10);

            f1.VizValt(n);
            Assert.That(f1.km3, Is.EqualTo(7));
            Assert.That(f1 is Puszta, Is.True);

            f1.VizValt(f);
            Assert.That(f1.km3, Is.EqualTo(6));
            Assert.That(f1 is Puszta, Is.True);

            f1.VizValt(e);
            Assert.That(f1.km3, Is.EqualTo(11));
            Assert.That(f1 is Puszta, Is.True);

            f1 = new Zöld("Cig", 25);
            f1.VizValt(n);
            Assert.That(f1.km3, Is.EqualTo(19));
            Assert.That(f1 is Zöld, Is.True);

            f1.VizValt(f);
            Assert.That(f1.km3, Is.EqualTo(17));
            Assert.That(f1 is Zöld, Is.True);

            f1.VizValt(e);
            Assert.That(f1.km3, Is.EqualTo(27));
            Assert.That(f1 is Zöld, Is.True);

            f1 = new Tavas("Cig", 70);
            f1.VizValt(n);
            Assert.That(f1.km3, Is.EqualTo(60));
            Assert.That(f1 is Tavas, Is.True);

            f1.VizValt(f);
            Assert.That(f1.km3, Is.EqualTo(57));
            Assert.That(f1 is Tavas, Is.True);

            f1.VizValt(e);
            Assert.That(f1.km3, Is.EqualTo(57+15));
            Assert.That(f1 is Tavas, Is.True);


        }

    }
}