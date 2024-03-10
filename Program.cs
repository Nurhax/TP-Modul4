public class Kodepos
{
    public enum EnumKelurahan
    {
        Batununggal, Kujangsari, Mengger, Wates, Cijaura,
        Jatisari,Margasari,Sekejati,Kebonwaru,Maleer,Samoja
    }
    public static int getKodePos(EnumKelurahan inputKelurahan)
    {
        int[] KodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273};
        return KodePos[(int)inputKelurahan];
    }
}

public class DoorMachine
{
    public enum StatePintu {Terkunci, Terbuka};
    public enum Trigger {KunciPintu, BukaPintu};

    public StatePintu currentState = StatePintu.Terkunci;

    public class Transisi
    {
        public StatePintu stateAwal;
        public StatePintu stateAkhir;
        public Trigger triggerEvent;
        public Transisi(StatePintu stateAwal, StatePintu stateAkhir, Trigger trigger)
        {
            this.stateAwal = stateAwal;
            this.stateAkhir = stateAkhir;
            this.triggerEvent = trigger;
        }
    }
    Transisi[] Transisis =
    {
        new Transisi(StatePintu.Terkunci, StatePintu.Terbuka,Trigger.BukaPintu),
        new Transisi(StatePintu.Terbuka, StatePintu.Terkunci,Trigger.KunciPintu),
        new Transisi(StatePintu.Terkunci, StatePintu.Terkunci,Trigger.KunciPintu),
        new Transisi(StatePintu.Terbuka, StatePintu.Terbuka,Trigger.BukaPintu),

    };

    public StatePintu getNextState(StatePintu stateAwal,  Trigger trigger) 
    {
        StatePintu stateAkhir = stateAwal;
        for(int i = 0;  i < Transisis.Length; i++)
        {
            Transisi perubahan = Transisis[i];
            if(stateAwal == perubahan.stateAwal && trigger == perubahan.triggerEvent)
            {
                stateAkhir = perubahan.stateAkhir;
            }
        }
        return stateAkhir;
    }

    public void ActivateTrigger(Trigger triggerEvent)
    {
        currentState = getNextState(currentState, triggerEvent);

        Console.WriteLine("Saat ini pintu anda sedang:" + currentState);

    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Kodepos.EnumKelurahan kelurahan = Kodepos.EnumKelurahan.Cijaura;
        int kodePosKelurahan = Kodepos.getKodePos(kelurahan);
        Console.WriteLine("Kelurahan: " +  kelurahan);
        Console.WriteLine("Kodepos: " + kodePosKelurahan);

        DoorMachine Pintu = new DoorMachine();
        Console.WriteLine(Pintu.currentState);
        Pintu.ActivateTrigger(DoorMachine.Trigger.KunciPintu);
        Pintu.ActivateTrigger(DoorMachine.Trigger.BukaPintu);
    }
}