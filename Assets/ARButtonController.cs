using UnityEngine;

public class ARButtonController : MonoBehaviour
{
    public GameObject[] objects3D;

    public void TampilkanObject(int index)
    {
        foreach (var obj in objects3D)
            obj.SetActive(false);

        objects3D[index].SetActive(true);
    }
}