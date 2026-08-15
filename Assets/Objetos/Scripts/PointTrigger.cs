using UnityEngine;

public class PointTrigger : MonoBehaviour
{
    [SerializeField] private PointOfInterest point;

    private void Reset()
    {
        // Si el script está en el mismo objeto que PointOfInterest,
        // lo asigna automáticamente.
        point = GetComponent<PointOfInterest>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        NPCManager.Instance.EnterPoint(point);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        NPCManager.Instance.ExitPoint(point);
    }
}