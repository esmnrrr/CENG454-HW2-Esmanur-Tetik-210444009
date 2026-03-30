using UnityEngine;

public class MissileHoming : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float turnRate = 5f;

    private Transform target;   // takip edecegi ucagimiz

    public void SetTarget(Transform newTarget)
    {
        // TODO (Task 3-E): cache the aircraft transform 
        target = newTarget;
    }

    void Update()
    {
        // TODO (Task 3-F): rotate toward the target and move forward
        
        if (target == null) return;     // Hedef yoksa hiçbir þey yapma

        // Hedefin yönünü buluyorum
        Vector3 direction = (target.position - transform.position).normalized;

        // Missile i yavas yavas ucagima donduruyorum
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, turnRate * Time.deltaTime);

        // Missile i ilerletiyorum
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}