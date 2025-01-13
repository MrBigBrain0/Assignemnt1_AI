using UnityEngine;
using UnityEngine.UI;

public class RobotBattery : MonoBehaviour
{
    [HideInInspector] public float batteryPercent = 1f;
    [SerializeField] private Image batteryPercentUI;

    void Update()
    {
        batteryPercentUI.fillAmount = batteryPercent;
    }
}
