using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        transform.LookAt(cameraTransform);
    }
}