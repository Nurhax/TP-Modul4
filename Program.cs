public class kodepos
{
    public enum EnumKelurahan
    {
        Batununggal, Kujangsari, Mengger, Wates, Cijaura,
        Jatisari,Margasari,Sekejati,Kebonwaru,Maleer,Samoja
    }
    public static int getKodePos(EnumKelurahan inputKelurahan)
    {
        int[] kodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273};
        return kodePos[(int)inputKelurahan];
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        kodepos.EnumKelurahan kelurahan = kodepos.EnumKelurahan.Cijaura;
        int kodePosKelurahan = kodepos.getKodePos(kelurahan);
        Console.WriteLine("Kelurahan: " +  kelurahan);
        Console.WriteLine("Kodepos: " + kodePosKelurahan);
    }
}