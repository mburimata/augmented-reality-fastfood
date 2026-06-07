using UnityEngine;

public class ScreenOrientationManager : MonoBehaviour
{
    public enum TargetOrientation { Portrait, Landscape }
    public TargetOrientation target;

    void Awake()
    {
        if (target == TargetOrientation.Portrait)
        {
            Screen.orientation = ScreenOrientation.Portrait;
        }
        else
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
        }
    }
}