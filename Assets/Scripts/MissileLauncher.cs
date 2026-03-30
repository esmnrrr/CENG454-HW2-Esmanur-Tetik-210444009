using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;

    private GameObject activeMissile;

    public GameObject Launch(Transform target)
    {
        // TODO (Task 3-A): instantiate the missile at launchPoint 
        // Eðer sahnede zaten füzemiz varsa önce onu yok ediyorum (Ghost Missile engelleme)
        if (activeMissile != null) DestroyActiveMissile();

        // Füzeyi fýrlatma noktasýnda yaratýyoruz
        activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);

        // TODO (Task 3-B): give the missile its target 
        activeMissile.GetComponent<MissileHoming>().SetTarget(target);

        // TODO (Task 3-C): play launch audio and return the spawned missile 
        if (launchAudioSource != null)
        {
            launchAudioSource.Play(); // Fýrlatma sesini çal
        }

        return activeMissile; // Yaratýlan füzeyi geri döndür
    }

    public void DestroyActiveMissile()
    {
        // TODO (Task 3-D): destroy the current missile safely if one exists 
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }

        // fuze yoksa sesi durduruyorum
        if (launchAudioSource != null && launchAudioSource.isPlaying)
        {
            launchAudioSource.Stop();
        }

    }
}