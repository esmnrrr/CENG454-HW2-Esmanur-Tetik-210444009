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
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        // TODO (Task 3-H): if the missile hits the aircraft, apply the chosen penalty
        if (collision.CompareTag("Missile"))    // Carpan obje missile ise
        {
            // Task 3-J, 3-K : gorev basarisiz diyorum
            if (examManager != null) examManager.FailMission();

            // patlama sesini caliyorum
            if (hitAudioSource != null) hitAudioSource.Play();

            // carpan fuzeyi destroy ediyorum ki respawn olunca kaldigi yerden bana yonelmesin
            Destroy(collision.gameObject);

            // baslangic noktasina isinliyorum
            if (respawnPoint != null)
            {
                transform.position = respawnPoint.position;
                transform.rotation = respawnPoint.rotation;

                if (rb != null)
                {
                    rb.linearVelocity = Vector3.zero;
                    rb.angularVelocity = Vector3.zero;
                }
            }

         
        }
    }
}