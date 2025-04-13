// See https://aka.ms/new-console-template for more information
using System;
using tpmodul8_103022300004;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + config.SatuanSuhu + "");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool suhuValid = false;

        if (config.SatuanSuhu == "celcius")
        {
            suhuValid = suhu >= 36.5 && suhu <= 37.5;
        }
        else if (config.SatuanSuhu == "fahrenheit")
        {
            suhuValid = suhu >= 97.7 && suhu <= 99.5;
        }

        bool hariDemamValid = hariDemam <= config.BatasHariDemam;

        if (suhuValid && hariDemamValid)
        {
            Console.WriteLine(config.PesanDiterima);
        }
        else
        {
            Console.WriteLine(config.PesanDitolak);
        }

        // Contoh penggunaan method UbahSatuan
        config.UbahSatuan();
        Console.WriteLine("\nSetelah ubah satuan: " + config.SatuanSuhu);
    }
}

