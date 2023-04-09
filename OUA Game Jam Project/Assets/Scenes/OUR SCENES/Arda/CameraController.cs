using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // hedef transformu
    public float smoothTime = 0.3f; // kamera hareketinin yumuþaklýðý
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 targetPosition = target.position; // hedefin pozisyonunu al

        // kamera pozisyonunu hedefe göre ayarla
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // hedefe bakacak rotasyonu hesapla
        Vector3 lookDirection = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

        // kamera rotasyonunu yumuþak bir þekilde ayarla
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, smoothTime);
    }
    private void Update()
    {

    }
}