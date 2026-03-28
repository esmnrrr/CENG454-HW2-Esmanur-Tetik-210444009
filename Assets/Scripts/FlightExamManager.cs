using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionComplete = false;

    private void Start()
    {
        statusText.text = "Status: Safe";
        statusText.color = Color.green;
        missionText.text = "Take off and cross the corridor.";
        missionText.color = Color.white;
    }

    public void EnterDangerZone()
    {
        missionText.text = "Entered a Dangerous Zone!";
        missionText.color = Color.red;
        statusText.text = "Status: IN DANGER";
        statusText.color = Color.red;
    }

    public void ExitDangerZone()
    {
        threatCleared = true;

        missionText.text = "Threat Cleared! Proceed to Landing.";
        missionText.color = Color.yellow;
        statusText.text = "Status: Safe";
        statusText.color = Color.green;
    }
}