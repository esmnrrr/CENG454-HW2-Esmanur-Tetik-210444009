using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    void Start()
    {
        // TODO (Task 3-G): cache GetComponent<Rigidbody>() into 'rb' 
    }

    private void OnTriggerEnter(Collider collision)
    {
        // TODO (Task 3-H): if the missile hits the aircraft, apply the chosen penalty 
    }
}

// Extend your FlightExamManager.cs from Task 2 
// TODO (Task 3-I): store whether the threat was cleared 
// TODO (Task 3-J): handle failure, reset, or damage state when the missile reaches the aircraft 
// TODO (Task 3-K): update the HUD so the player understands whether escape or landing is now allowed 