// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Esmanur Tetik | Student ID: 210444009

using UnityEngine;

public class FlightController : MonoBehaviour
{

    [SerializeField] private float pitchSpeed = 45f;    // Pitch: Ucagin burun kismina gore hareket etmesidir, agirlik merkezi burun gibi dusunursek yukari asagi hareketi anlatiyor
    [SerializeField] private float yawSpeed = 45f;      // Yaw: Ucagin agirlik merkezinden dikey cizilen cizgiye gore saga sola hareket etmesidir
    [SerializeField] private float rollSpeed = 45f;     // Roll: Ucagin burundan kuyruga cizilen cizgiye gore saga sola hareket etmesidir, yani ucagin kendi ekseni etrafinda roll olmasi
    [SerializeField] private float thrustSpeed = 5f;    // Thrust: Ucagin ileri hareketi için hizi belirler

    private Rigidbody rb; // Rigidbody fiziksel hareketleri kontrol etmek icin kullanilir

    void Start()    // Start ilk frame de sadece bir kez cagrilir, burada Rigidbody bileþenini aliyorum
    {
        rb = GetComponent<Rigidbody>();     // Rigidbody bileþenini al
        rb.freezeRotation = true;           // Rigidbody i manuel olarak kontrol edecegim o yzdn otomatik olarak geleni durduruyorum
    }

    void Update()   // Update her frame de cagrilir, burada kullanicidan input alarak hareketi kontrol ediyorum
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        // Pitch yukari asagi hareketi temsil ettigi icin yukari asagi tuslarini atiyorum, Vector3.right ekseni etrafinda donus yapacak
        float pitchInput = Input.GetAxis("Vertical");   
        transform.Rotate(Vector3.right * pitchInput * pitchSpeed * Time.deltaTime);

        // Yaw sag sol hareketi temsil ettigi icin sag sol tuslarini atiyorum, Vector3.up ekseni etrafinda donus yapacak
        float yawInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * yawInput * yawSpeed * Time.deltaTime);

        // Roll ucagin kendi ekseni etrafinda donusu oldugu icin Q ve E tuslarini atiyorum, Vector3.forward ekseni etrafinda donus yapacak
        float rollInput = 0f;
        if (Input.GetKey(KeyCode.E)) rollInput = -1f; // Saða donme
        if (Input.GetKey(KeyCode.Q)) rollInput = 1f;  // Sola donme
        transform.Rotate(Vector3.forward * rollInput * rollSpeed * Time.deltaTime); // Roll hareketi ters yönde uygulanýr, bu yüzden E negatif, Q pozitif
    }

    private void HandleThrust()
    {
        // Thrust ileri hareketi temsil ettigi icin Space tusunu atiyorum, Vector3.forward ekseni boyunca hareket yapacak
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}
