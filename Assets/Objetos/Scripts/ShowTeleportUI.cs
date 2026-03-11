using UnityEngine;

public class ShowTeleportUI : MonoBehaviour
{
    public GameObject canvasUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvasUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvasUI.SetActive(false);
        }
    }
}