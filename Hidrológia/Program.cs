namespace Hidrológia
{
    public class Program
    {
        static void Main(string[] args)
        {

            Táj táj = beOlvas("input.txt");
            körök(ref táj, 10);
            FöldTerület vizes = táj.LegVizesebb();
            Console.WriteLine("Legvizesebb földterület:\n" + vizes);
        }

        public static void körök(ref Táj t, int n) {
            for (int i = 0; i < n; i++)
            {
                t.Kör();
                Kiír(t.GetFöldek());
            }
        }

        public static Táj beOlvas(String path) {
            StreamReader st = new StreamReader(path);
            String? line;
            int paraT;
            if (st.EndOfStream)
            {
                throw new Exception();
            }
            line = st.ReadLine();
            int.TryParse(line, out paraT);
            Atmoszféra a = new Atmoszféra(paraT);
            Táj táj = new Táj(a);

            while ((line = st.ReadLine()) != null)
            {
                String[] parts = line.Split(' ');
                String name = parts[0];
                String type = parts[1];
                int km3;
                int.TryParse(parts[2], out km3);
                if (type.Equals("p"))
                {
                    táj.Add(new Puszta(name, km3));
                }
                else if (type.Equals("z"))
                {
                    táj.Add(new Zöld(name, km3));
                }
                else if (type.Equals("t"))
                {
                    táj.Add(new Tavas(name, km3));
                }
            }
            return táj;
        }

        public static void Kiír(List<FöldTerület> fs) {
            foreach (var item in fs)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}