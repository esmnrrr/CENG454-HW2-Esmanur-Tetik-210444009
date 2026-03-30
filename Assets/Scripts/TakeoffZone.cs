using UnityEngine;

public class TakeoffZone : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    // Ucagimiz bu kutudan cikis yaptiginda calisiyor
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (examManager != null) examManager.RegisterTakeoff();
        }
    }
}
