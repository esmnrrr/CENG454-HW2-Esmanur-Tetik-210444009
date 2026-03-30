using UnityEngine;

public class LandingZone : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    // Ucagimiz bu kutuya giris yaptiginda calisiyor
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (examManager != null) examManager.AttemptLanding();
        }
    }
}
