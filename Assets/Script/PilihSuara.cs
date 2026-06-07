using UnityEngine;
using UnityEngine.UI; // Penting untuk mengontrol tombol

public class PilihSuara : MonoBehaviour
{
    [Header("Komponen Utama")]
    public AudioSource pemutarSuara; // Komponen untuk bunyi
    public Button tombolSpeaker;    // Tombol speaker yang mau diaktifkan

    private AudioClip kasetTerpilih; // Variabel penyimpan suara sementara

    void Start()
    {
        // Saat baru mulai, tombol speaker dimatikan dulu
        if(tombolSpeaker != null) tombolSpeaker.interactable = false;
    }

    // Fungsi untuk tombol makanan (Burger/Pizza/dll)
    public void PilihMakanan(AudioClip suaraMakanan)
    {
        kasetTerpilih = suaraMakanan;
        Debug.Log("Kaset makanan dimasukkan ke sistem!");
        
        // Menyalakan tombol speaker agar bisa diklik
        if(tombolSpeaker != null) tombolSpeaker.interactable = true;
    }

    // Fungsi untuk tombol Speaker
    public void PutarSuaraSekarang()
    {
        if (kasetTerpilih != null && pemutarSuara != null)
        {
            pemutarSuara.Stop(); // Stop suara sebelumnya jika ada
            pemutarSuara.clip = kasetTerpilih;
            pemutarSuara.Play();
            Debug.Log("Suara sedang berbunyi...");
        }
    }
}