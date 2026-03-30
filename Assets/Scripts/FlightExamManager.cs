using UnityEngine;
using TMPro;

public class FlightExamManager: MonoBehaviour
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
        // TODO: update the mission state and HUD
        threatCleared = false;  // Tehdit tespit ediyoruz

        if (statusText != null)
            statusText.text = "Status: IN DANGER";
            statusText.color = Color.red;

        if (missionText != null)
            missionText.text = "Entered a Dangerous Zone!";
            missionText.color = Color.red;
    }

    public void ExitDangerZone()
    {
        // TODO: mark the threat as cleared and refresh the HUD
        threatCleared = true;   // Tehdit yok

        if (statusText != null)
            statusText.text = "Status: Cleared!";
            statusText.color = Color.green;

        if (missionText != null)
            missionText.text = "Find the landing strip and land safely.";
            missionText.color = Color.yellow;
    }
}
