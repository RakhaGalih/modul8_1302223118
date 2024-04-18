using System.Numerics;
using modul8_1302223118;
using static modul8_1302223118.BankTransferConfig;

internal class Program
{
    public static void Main(string[] args)
    {
        ConfigController controller = new ConfigController();
        int biayaTransfer;
        string confirmation;
        if (controller.config.lang == "en")
        {
            Console.Write($"Please insert the amount of money to transfer: ");
        }
        else
        {
            Console.Write($"Masukkan jumlah uang yang akan di-transfer: ");
        }
        int uangTransfer = int.Parse(Console.ReadLine());
        if (uangTransfer > controller.config.transfer.threshold)
        {
            biayaTransfer = controller.config.transfer.high_fee;
        } else
        {
            biayaTransfer = controller.config.transfer.low_fee;
        }
        if (controller.config.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {biayaTransfer} \nTotal amount = {biayaTransfer + uangTransfer}");
        }
        else
        {
            Console.WriteLine($"\"Biaya transfer = {biayaTransfer} \nTotal biaya = {biayaTransfer + uangTransfer}");
        }
        if (controller.config.lang == "en")
        {
            Console.WriteLine($"Please select tranfer method: ");
        }
        else
        {
            Console.WriteLine($"Pilih metode tranfer: ");
        }
        for (int i = 0; i < controller.config.methods.Length; i++)
        {
            Console.WriteLine($"{i} {controller.config.methods[i]}");
        }
        if (controller.config.lang == "en")
        {
            Console.Write($"Please type {controller.config.confirmation.en} to confirm the transaction: ");
            confirmation = Console.ReadLine();
            if (confirmation == controller.config.confirmation.en)
            {
                Console.Write($"The transfer is completed!");
            } else
            {
                Console.Write($"Transfer is cancelled");
            }
        }
        else
        {
            confirmation = Console.ReadLine();
            if (confirmation == controller.config.confirmation.id)
            {
                Console.Write($"Proses transfer berhasil!");
            } else
            {
                Console.Write($"Transfer dibatalkan");
            }
            Console.Write($"Ketik {controller.config.confirmation.id} untuk mengkonfirmasi transaksi: ");
        }
    }
}