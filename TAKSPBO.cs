

using System;
using System.Collections.Generic;

public class Orang
{
    public string Nama { get; set; }
    public int Umur { get; set; }

    public Orang(string nama, int umur)
    {
        Nama = nama;
        Umur = umur;
    }

    public virtual void Aktivitas()
    {
        Console.WriteLine($"{Nama} sedang beraktivitas di lingkungan rumah sakit.");
    }

    public virtual void InfoOrang()
    {
        Console.WriteLine($"Nama: {Nama}, Umur: {Umur} tahun");
    }
}
public class Pasien : Orang
{
    public string Keluhan { get; set; }

    public Pasien(string nama, int umur, string keluhan) : base(nama, umur)
    {
        Keluhan = keluhan;
    }

    public void CekKeluhan()
    {
        Console.WriteLine($"{Nama} memiliki keluhan: {Keluhan}");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{Nama} (Pasien) sedang menunggu panggilan pemeriksaan di ruang tunggu.");
    }
}
public class TenagaMedis : Orang
{
    public string Spesialisasi { get; set; }

    public TenagaMedis(string nama, int umur, string spesialisasi) : base(nama, umur)
    {
        Spesialisasi = spesialisasi;
    }

    public void CekSpesialis()
    {
        Console.WriteLine($"{Nama} memiliki spesialisasi bidang {Spesialisasi}");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{Nama} (Tenaga Medis) sedang bersiap melaksanakan tugas medis.");
    }
}

public class Dokter : TenagaMedis
{
    public Dokter(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi) { }

    public void Diagnosa()
    {
        Console.WriteLine($"Dr. {Nama} sedang mendiagnosa penyakit pasien.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"Dr. {Nama} sedang memeriksa rekam medis dan meresepkan obat untuk pasien.");
    }
}
public class Perawat : TenagaMedis
{
    public Perawat(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi) { }

    public void CekPasien()
    {
        Console.WriteLine($"Perawat {Nama} sedang mengecek kondisi tanda-tanda vital pasien.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"Perawat {Nama} sedang membantu perawatan harian pasien di bangsal.");
    }
}
public class PasienAnak : Pasien
{
    public PasienAnak(string nama, int umur, string keluhan) : base(nama, umur, keluhan) { }

    public void Menangis()
    {
        Console.WriteLine($"{Nama} (Pasien Anak) menangis karena takut disuntik.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{Nama} sedang bermain mainan edukatif di pojok anak.");
    }
}
public class PasienDewasa : Pasien
{
    public PasienDewasa(string nama, int umur, string keluhan) : base(nama, umur, keluhan) { }

    public void Konsultasi()
    {
        Console.WriteLine($"{Nama} (Pasien Dewasa) sedang berkonsultasi mengenai hasil laboratorium.");
    }

    public override void Aktivitas()
    {
        Console.WriteLine($"{Nama} sedang mengisi formulir administrasi rawat jalan.");
    }
}
public class RumahSakit
{
    public List<Orang> DaftarOrangList { get; set; } = new List<Orang>();

    public void TambahOrang(Orang orang)
    {
        DaftarOrangList.Add(orang);
    }
    public void DaftarOrang()
    {
        Console.WriteLine(" DAFTAR SELURUH ORANG DI RUMAH SAKIT ");
        foreach (var orang in DaftarOrangList)
        {
            orang.InfoOrang();
            orang.Aktivitas();
            Console.WriteLine("------------------------------------------");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {

        RumahSakit rs = new RumahSakit();

        Dokter dokter1 = new Dokter("Dr. Andi", 45, "Penyakit Dalam");
        Perawat perawat1 = new Perawat("Siti Aminah", 28, "ICU");
        PasienDewasa abelina = new PasienDewasa("Abelina", 20, "Demam Berdarah");

        rs.TambahOrang(dokter1);
        rs.TambahOrang(perawat1);
        rs.TambahOrang(abelina);

        rs.DaftarOrang();

        Console.WriteLine("\nDEMONSTRASI POLYMORPHISM");
        foreach (var o in rs.DaftarOrangList)
        {
            o.Aktivitas();
        }

  
        Console.WriteLine("\nPEMANGGILAN METHOD KHUSUS");
        dokter1.Diagnosa();
        perawat1.CekPasien();
        abelina.CekKeluhan();
        abelina.Konsultasi();

        Console.ReadLine();
    }
}