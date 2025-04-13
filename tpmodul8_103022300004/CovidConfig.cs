using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace tpmodul8_103022300004
{
    public class CovidConfig
    {
        public string SatuanSuhu { get; set; } = "celcius";
        public int BatasHariDemam { get; set; } = 14;
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public CovidConfig()
        {
            LoadConfig();
        }

        public void LoadConfig()
        {
            try
            {
                string jsonString = File.ReadAllText("covid_config.json");
                var config = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString);

                if (config != null)
                {
                    if (config.ContainsKey("satuan_suhu") && config["satuan_suhu"] == "CONFIG1") SatuanSuhu = "celcius";
                    if (config.ContainsKey("batas_hari_demam") && config["batas_hari_demam"] == "CONFIG2") BatasHariDemam = 14;
                    if (config.ContainsKey("pesan_ditolak") && config["pesan_ditolak"] == "CONFIG3") PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
                    if (config.ContainsKey("pesan_diterima") && config["pesan_diterima"] == "CONFIG4") PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Gagal memuat konfigurasi: " + ex.Message);
            }
        }

        public void UbahSatuan()
        {
            if (SatuanSuhu == "celcius")
                SatuanSuhu = "fahrenheit";
            else
                SatuanSuhu = "celcius";
        }
    }
}
