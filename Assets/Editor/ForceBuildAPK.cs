#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System.IO;

public class ForceBuildAPK
{
    [MenuItem("PANDUAN LEVI/PAKSA BUILD APK")]
    public static void JalankanBuildManual()
    {
        // 1. Minta lokasi penyimpanan langsung ke Windows secara paksa
        string pathPilihan = EditorUtility.SaveFilePanel("Pilih Lokasi Simpan APK", "", "MenuJunkFood_Levi", "apk");
        
        if (string.IsNullOrEmpty(pathPilihan))
        {
            Debug.LogWarning("Build dibatalkan oleh user.");
            return;
        }

        // 2. Ambil paksa daftar scene yang aktif di Build Settings
        EditorBuildSettingsScene[] daftarScene = EditorBuildSettings.scenes;
        string[] scenePaths = new string[daftarScene.Length];
        for (int i = 0; i < daftarScene.Length; i++)
        {
            scenePaths[i] = daftarScene[i].path;
        }

        // 3. Eksekusi Build Bypass UI Build Profiles
        BuildPlayerOptions opsiBuild = new BuildPlayerOptions();
        opsiBuild.scenes = scenePaths;
        opsiBuild.locationPathName = pathPilihan;
        opsiBuild.target = BuildTarget.Android;
        opsiBuild.options = BuildOptions.None;

        Debug.Log("Memulai Proses Force Build APK...");
        BuildPipeline.BuildPlayer(opsiBuild);
        Debug.Log("Force Build SELESAI! Membuka folder...");
        
        // 4. Paksa Windows Explorer terbuka langsung menyorot filenya
        EditorUtility.RevealInFinder(pathPilihan);
    }
}
#endif