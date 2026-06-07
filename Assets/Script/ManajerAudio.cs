using UnityEngine;

public class ManajerAudio : MonoBehaviour
{
    [Header("Masukkan Audio Source Masing-masing Makanan")]
    public AudioSource audioBurger;
    public AudioSource audioSoda;
    public AudioSource audioFries;
    public AudioSource audioChicken;
    public AudioSource audioPizza;

    private int idMarkerAktif = 0; 

    // Fungsi yang dipanggil oleh Image Target saat SCAN BERHASIL
    public void SetMarkerAktifAudio(int id)
    {
        idMarkerAktif = id;
    }

    // Fungsi yang dipanggil oleh Image Target saat SCAN HILANG
    public void SetMarkerHilangAudio(int id)
    {
        if (idMarkerAktif == id)
        {
            idMarkerAktif = 0;
        }
        MatikanSemuaAudio();
    }

    // Fungsi UTAMA untuk Tombol Audio (Speaker) di bawah Canvas
    public void KlikTombolAudio()
    {
        if (idMarkerAktif == 1 && audioBurger != null) EksekusiAudio(audioBurger);
        else if (idMarkerAktif == 2 && audioSoda != null) EksekusiAudio(audioSoda);
        else if (idMarkerAktif == 3 && audioFries != null) EksekusiAudio(audioFries);
        else if (idMarkerAktif == 4 && audioChicken != null) EksekusiAudio(audioChicken);
        else if (idMarkerAktif == 5 && audioPizza != null) EksekusiAudio(audioPizza);
    }

    private void EksekusiAudio(AudioSource targetAudio)
    {
        if (targetAudio.isPlaying)
        {
            targetAudio.Stop(); // Kalau lagi bunyi, diklik jadi mati
        }
        else
        {
            MatikanSemuaAudio(); // Matikan yang lain dulu biar gak balapan
            targetAudio.Play(); // Jalankan audio makanan aktif
        }
    }

    public void MatikanSemuaAudio()
    {
        if (audioBurger) audioBurger.Stop();
        if (audioSoda) audioSoda.Stop();
        if (audioFries) audioFries.Stop();
        if (audioChicken) audioChicken.Stop();
        if (audioPizza) audioPizza.Stop();
    }
}