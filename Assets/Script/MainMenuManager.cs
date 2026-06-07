using UnityEngine;
using UnityEngine.SceneManagement; // Wajib untuk pindah scene

public class MainMenuManager : MonoBehaviour
{
    // --- AREA UI PANEL TOGGLE (UNTUK TOMBOL i) ---
    [Header("Setelan Panel Panduan")]
    public GameObject panelPanduan; 

    public void TogglePanelPanduan()
    {
        if (panelPanduan != null)
        {
            // Jika sedang terbuka -> ditutup. Jika sedang tertutup -> dibuka.
            bool statusSekarang = panelPanduan.activeSelf;
            panelPanduan.SetActive(!statusSekarang);
            Debug.Log("Status Panel Panduan diubah menjadi: " + !statusSekarang);
        }
    }

    // --- AREA NAVIGASI SCENE ---
    
    // Fungsi untuk tombol Masuk
    public void MasukAplikasi()
    {
        SceneManager.LoadScene("AR");
    }

    // Fungsi untuk tombol Kembali
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Fungsi untuk tombol Keluar
    public void KeluarAplikasi()
    {
        Debug.Log("Aplikasi Keluar"); // Muncul di console saat testing
        Application.Quit(); // Hanya berfungsi setelah di-build ke Android
    }
}