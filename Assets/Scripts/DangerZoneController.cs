using UnityEngine;

public class DangerZoneController : MonoBehaviour
{
    // Yöneticimize (beyne) ulaþmak için bir referans
    [SerializeField] private FlightExamManager examManager;

    // Herhangi bir obje bu Trigger (görünmez küp) içine girdiðinde çalýþýr 
    private void OnTriggerEnter(Collider other)
    {
        // Giren obje bizim uçaðýmýz mý?
        if (other.CompareTag("Player"))
        {
            // Evet uçak! Yöneticideki o kýrmýzý yazýlarý çýkartan metodu çalýþtýr 
            examManager.EnterDangerZone();
            Debug.Log("Uçak tehlike bölgesine girdi!");
        }
    }

    // Obje Trigger'ýn içinden çýkýp gittiðinde çalýþýr
    private void OnTriggerExit(Collider other)
    {
        // Çýkan obje bizim uçaðýmýz mý? 
        if (other.CompareTag("Player"))
        {
            // Evet uçak kurtuldu! Yöneticideki yeþil "Threat Cleared" metodunu çalýþtýr
            examManager.ExitDangerZone();
            Debug.Log("Uçak tehlike bölgesinden çýktý!");
        }
    }
}