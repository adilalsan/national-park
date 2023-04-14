using static System.Net.Mime.MediaTypeNames;

namespace milli_park
{
    class MilliPark
    {
        private string ad;
        public string Ad
        {
            get { return ad; }
        }
        private string il;
        public string Il
        {
            get { return il; }
        }
        private int yil;
        public int Yil
        {
            get { return yil; }
        }
        private int yuzolcumu;
        public int Yuzolcumu
        {
            get { return yuzolcumu; }
        }

        public MilliPark(string ad, string il, int yuzolcumu, int yil)
        {
            this.ad = ad;
            this.il = il;
            this.yil = yil;
            this.yuzolcumu = yuzolcumu;
        }
        public override string ToString()
        {
            return "Milli Parkın adı: "+ad+"\nBulunduğu il: "+il+"\nİlan yılı: "+yil+"\nYüzölçümü: "+yuzolcumu+" hektar\n";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List <List<MilliPark>> Parklar = new List<List<MilliPark>>();
            List<MilliPark> KucukMP = new List<MilliPark>();
            List<MilliPark> BuyukMP = new List<MilliPark>();
            Parklar.Add(KucukMP);
            Parklar.Add(BuyukMP);
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader(Environment.CurrentDirectory + @"\parklar.txt"))
                {
                    string line;
                    // Read and display lines from the file until the end of
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] ozellikler = line.Split(',');
                        MilliPark mp = new MilliPark(ozellikler[0], ozellikler[1], Convert.ToInt32(ozellikler[2]), Convert.ToInt32(ozellikler[3]));
                        if (mp.Yuzolcumu < 15000)
                        {
                            Parklar[0].Add(mp);
                        }
                        else
                        { 
                            Parklar[1].Add(mp); 
                        }
                        

                        
                    }
                }
            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            Yigit yigit = new Yigit(48);
            Kuyruk kuyruk = new Kuyruk(48);
            OncelikliKuyruk onceliklikuyruk = new OncelikliKuyruk(48);
            int [] toplamYuzolcumu= {0,0};
            for(int i=0;i<Parklar.Count;i++)
            {
                foreach (MilliPark mp in Parklar[i])
                {
                    yigit.push(mp);
                    kuyruk.insert(mp);
                    onceliklikuyruk.Enqueue(mp);
                    Console.WriteLine(mp.ToString());
                    toplamYuzolcumu[i] += mp.Yuzolcumu;

                }
            }
            Console.WriteLine("KÜÇÜK MİLLİ PARKLARIN TOPLAM YÜZÖLÇÜMÜ: " + toplamYuzolcumu[0]+" hektar");
            Console.WriteLine("BÜYÜK MİLLİ PARKLARIN TOPLAM YÜZÖLÇÜMÜ: " + toplamYuzolcumu[1]+" hektar");
            Console.WriteLine("---------YIĞITTAN YAZDIRMA---------");
            for(int i=0;i<48;i++)
            {
                Console.WriteLine(yigit.pop().ToString()); 
            }
            Console.WriteLine("---------KUYRUKTAN YAZDIRMA---------");
            for (int i = 0; i < 48; i++)
            {
                Console.WriteLine(kuyruk.remove().ToString());
            }
            Console.WriteLine("---------ÖNCELİKLİ KUYRUKTAN YAZDIRMA---------");
            for (int i = 0; i <48; i++)
            {
                Console.WriteLine(onceliklikuyruk.Dequeue().ToString());
            }
            
        }
    }
}