using System;
using System.Text.Json;
using static modul8_1302223118.BankTransferConfig;

namespace modul8_1302223118
{
    public class BankTransferConfig
    {
        public class Transfer
        {
            public int threshold { get; set; }
            public int low_fee { get; set; }
            public int high_fee { get; set; }
        }
        public class Confirmation
        {
            public string en { get; set; }
            public string id { get; set; }
        }
        public string lang { get; set; }
        public Transfer transfer = new Transfer();
        public string[] methods { get; set; }
        public Confirmation confirmation = new Confirmation();
    }

    public class ConfigController
    {
        public BankTransferConfig config;
        private const string filePath = "../../../bank_transfer_config.json";
        public ConfigController()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        public void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<BankTransferConfig?>(configJsonData);
        }
        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }
        public void SetDefault()
        {
            config = new BankTransferConfig();
            config.lang = "en";
            config.transfer.threshold = 25000000;
            config.transfer.low_fee = 6500;
            config.transfer.high_fee = 15000;
            config.methods = new string[4];
            config.methods[0] = "RTO(real-time)";
            config.methods[1] = "SKN";
            config.methods[2] = "RTGS";
            config.methods[3] = "BI FAST";
            config.confirmation.en = "yes";
            config.confirmation.id = "ya";
        }
    }
}


