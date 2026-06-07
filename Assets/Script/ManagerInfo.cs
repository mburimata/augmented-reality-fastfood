using UnityEngine;

public class ManajerInfo : MonoBehaviour
{
    [Header("Masukkan 5 Panel Info UI-nya")]
    public GameObject infoBurger;
    public GameObject infoSoda;
    public GameObject infoFries;
    public GameObject infoChicken;
    public GameObject infoPizza;

    // Angka penanda: 0=kosong, 1=burger, 2=soda, 3=fries, 4=chicken, 5=pizza
    private int idMarkerAktif = 0; 

    // Fungsi yang dipanggil oleh masing-masing Image Target saat SCAN BERHASIL
    public void SetMarkerAktif(int id)
    {
        idMarkerAktif = id;
    }

    // Fungsi yang dipanggil oleh masing-masing Image Target saat SCAN HILANG
    public void SetMarkerHilang(int id)
    {
        if (idMarkerAktif == id)
        {
            idMarkerAktif = 0;
        }
        // Otomatis matikan semua panel kalau kertasnya dijauhkan
        MatikanSemuaPanel();
    }

    // Fungsi UTAMA untuk Tombol Info di bawah Canvas
    public void KlikTombolInfo()
    {
        if (idMarkerAktif == 1 && infoBurger != null) infoBurger.SetActive(!infoBurger.activeSelf);
        else if (idMarkerAktif == 2 && infoSoda != null) infoSoda.SetActive(!infoSoda.activeSelf);
        else if (idMarkerAktif == 3 && infoFries != null) infoFries.SetActive(!infoFries.activeSelf);
        else if (idMarkerAktif == 4 && infoChicken != null) infoChicken.SetActive(!infoChicken.activeSelf);
        else if (idMarkerAktif == 5 && infoPizza != null) infoPizza.SetActive(!infoPizza.activeSelf);
    }

    private void MatikanSemuaPanel()
    {
        if(infoBurger) infoBurger.SetActive(false);
        if(infoSoda) infoSoda.SetActive(false);
        if(infoFries) infoFries.SetActive(false);
        if(infoChicken) infoChicken.SetActive(false);
        if(infoPizza) infoPizza.SetActive(false);
    }
}