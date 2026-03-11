using UnityEngine;

public class TeleportConfirm : MonoBehaviour
{
    public Transform xrOrigin;
    public Transform destino;

    public void Teleportar()
    {
        xrOrigin.position = destino.position;
        xrOrigin.rotation = destino.rotation;
    }
}