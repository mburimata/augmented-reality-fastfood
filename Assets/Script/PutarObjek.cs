using UnityEngine;

public class PutarObjek : MonoBehaviour
{
    private float kecepatanRotasi = 20f;
    private float kecepatanGeser = 0.005f;
    private float kecepatanZoom = 0.01f;

    void Update()
    {
        // ------------- MODUL 1 SENSOR JARI (UNTUK DI HP) -------------
        
        // 1. SATU JARI: Untuk Muter (Rotate) DAN Menggeser Posisi (Pan/Translate)
        if (Input.touchCount == 1)
        {
            Touch jari = Input.GetTouch(0);

            if (jari.phase == TouchPhase.Moved)
            {
                // Trik: Gunakan tombol UI atau area layar untuk membedakan geser/muter.
                // Secara default, geser satu jari di sini diset untuk ROTASI.
                float rotasiX = jari.deltaPosition.x * kecepatanRotasi * Time.deltaTime;
                float rotasiY = jari.deltaPosition.y * kecepatanRotasi * Time.deltaTime;

                transform.Rotate(Vector3.up, -rotasiX, Space.Self);
                transform.Rotate(Vector3.right, rotasiY, Space.World);
            }
        }
        
        // 2. DUA JARI: Untuk Zoom (Pinch Scale) DAN Geser Posisi Posisi (Dua jari geser bareng)
        else if (Input.touchCount == 2)
        {
            Touch jari1 = Input.GetTouch(0);
            Touch jari2 = Input.GetTouch(1);

            // LOGIKA A: Jika kedua jari bergerak searah -> Menggeser Posisi Asset (Translate)
            if (jari1.phase == TouchPhase.Moved && jari2.phase == TouchPhase.Moved)
            {
                Vector2 deltaJari1 = jari1.deltaPosition;
                Vector2 deltaJari2 = jari2.deltaPosition;

                // Cek apakah gerakannya searah (Geser Posisi)
                if (Vector2.Dot(deltaJari1.normalized, deltaJari2.normalized) > 0.7f)
                {
                    Vector3 pergeseran = new Vector3(deltaJari1.x, deltaJari1.y, 0) * kecepatanGeser;
                    transform.Translate(pergeseran, Space.World);
                    return; // Keluar biar gak tabrakan sama logika zoom
                }
            }

            // LOGIKA B: Jika jari mencubit/melebar -> Zoom In / Zoom Out (Scale)
            Vector2 posisiJari1Lama = jari1.position - jari1.deltaPosition;
            Vector2 posisiJari2Lama = jari2.position - jari2.deltaPosition;

            float jarakJariLama = (posisiJari1Lama - posisiJari2Lama).magnitude;
            float jarakJariSekarang = (jari1.position - jari2.position).magnitude;

            float selisihJarakJari = jarakJariSekarang - jarakJariLama;

            // Terapkan perubahan ukuran (Scale) secara proporsional di sumbu X, Y, Z
            float faktorSkala = selisihJarakJari * kecepatanZoom;
            Vector3 ukuranBaru = transform.localScale + new Vector3(faktorSkala, faktorSkala, faktorSkala);

            // Batasi ukuran biar gak kekecilan atau kegedean banget
            ukuranBaru = Vector3.Max(ukuranBaru, new Vector3(0.1f, 0.1f, 0.1f));
            ukuranBaru = Vector3.Min(ukuranBaru, new Vector3(3f, 3f, 3f));

            transform.localScale = ukuranBaru;
        }

       // ------------- MODUL 2 EMULATOR LAPTOP & TOUCHPAD -------------
        if (Input.touchCount == 0)
        {
            // 1. HANYA USAP JARI (Klik Kiri Biasa) = MUTER ASSET
            if (Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.LeftControl))
            {
                float mouseX = Input.GetAxis("Mouse X") * kecepatanRotasi * 15f * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * kecepatanRotasi * 15f * Time.deltaTime;
                transform.Rotate(Vector3.up, -mouseX, Space.Self);
                transform.Rotate(Vector3.right, mouseY, Space.World);
            }

            // 2. SAMBIL TEKAN SHIFT + USAP JARI = GESER POSISI ASSET (PAN)
            if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift))
            {
                float mouseX = Input.GetAxis("Mouse X") * kecepatanGeser * 15f;
                float mouseY = Input.GetAxis("Mouse Y") * kecepatanGeser * 15f;
                transform.Translate(new Vector3(mouseX, mouseY, 0), Space.World);
            }

            // 3. GESTUR DUA JARI USAP ATAS/BAWAH ATAU SCROLL MOUSE = UBAH UKURAN (SCALE)
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                // Angka 2f di bawah ini bisa kamu kecilkan jadi 0.5f jika ukuran burger mendadak terlalu raksasa
                float faktorSkala = scroll * 2f; 
                Vector3 ukuranBaru = transform.localScale + new Vector3(faktorSkala, faktorSkala, faktorSkala);
                
                // Batasi ukuran biar gak hilang atau kekecilan banget di laptop
                transform.localScale = Vector3.Max(ukuranBaru, new Vector3(0.1f, 0.1f, 0.1f));
            }
        }
    }
}