using UnityEngine;
using TMPro;

public class FlightExamManager: MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;
    [SerializeField] private AudioSource escapeAudioSource;  // Task 3.3: Basarili kacis sesi

    private bool hasTakenOff = false;
    // TODO (Task 3-I): store whether the threat was cleared
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
        missionComplete = false;
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
        if (missionComplete) return;

        // TODO: mark the threat as cleared and refresh the HUD
        threatCleared = true;   // Tehdit yok

        if (statusText != null)
            statusText.text = "Status: Cleared!";
            statusText.color = Color.green;

        if (missionText != null)
            missionText.text = "Find the landing strip and land safely.";
            missionText.color = Color.yellow;

        // kacis basariliyse caliyorum
        if (escapeAudioSource != null)
            escapeAudioSource.Play();
    }

    // TODO (Task 3-J): handle failure, reset, or damage state
    // TODO (Task 3-K): update the HUD so the player understands
    public void FailMission()
    {
        missionComplete = true;
        threatCleared = false;

        if (statusText != null)
            statusText.text = "Status: CRASHED!";
            statusText.color = Color.red;

        if (missionText != null)
            missionText.text = "MISSION FAILED! You were hit by the missile. Restarting...";
            missionText.color = Color.red;
    }

    // respawn olunca ucak tekrar hareket edince yazilari ilk state e geri getiriyrm, HOCAM SIZ EKLE DEMEMISSINIZ AMA eklemek mantikli geldigi icin ekliyorum
    private void Update()
    {
        if (missionComplete && Input.anyKeyDown)    // kaza olduysa VE bir tusa basildiysa state i ilk haline cekiyorum cunku crashed yazisini tutmak istemiyorum
        {
            hasTakenOff = false;
            missionComplete = false;

            if (statusText != null)
            {
                statusText.text = "Status: Safe";
                statusText.color = Color.green;
            }

            if (missionText != null)
            {
                missionText.text = "Take off and cross the corridor.";
                missionText.color = Color.white;
            }
        }
    }

    // kalkis yapildigini kaydediyorum
    public void RegisterTakeoff()
    {
        // daha önce kalkýþ yapmadýysak ve kaza yapmadýysak
        if (!hasTakenOff && !missionComplete)
        {
            hasTakenOff = true;
            Debug.Log("Sýnav Baþladý: Uçak baþarýyla havalandý!");
        }
    }

    // (TASK 4.2)inis yapmaya calistigimizda kurallari kontrol ediyorum
    public void AttemptLanding()
    {
        if (missionComplete) return; // kaza oldu veya basarili olduysa bir sey yapmiyorum

        //  ucak havalandi mi VE missile temizlendi mi
        if (hasTakenOff && threatCleared)
        {
            missionComplete = true; // gorev tamam

            if (statusText != null)
            {
                statusText.text = "Status: SUCCESS";
                statusText.color = Color.green;
            }
            if (missionText != null)
            {
                missionText.text = "MISSION COMPLETE! Excellent flying.";
                missionText.color = Color.green;
            }
        }
        // havalandi AMA missile i atlatmadan inmeye calisti
        else if (hasTakenOff && !threatCleared)
        {
            if (missionText != null)
            {
                missionText.text = "Landing rejected! Clear the danger zone first.";
                missionText.color = Color.yellow;
            }
        }
    }

}