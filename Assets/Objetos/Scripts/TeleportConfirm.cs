using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportConfirm : MonoBehaviour
{
    public Transform xrOrigin;
    public Transform xrCamera;
    public Transform destino;

    public string sceneName;
    public string spawnPointNameDestino;

    public void Teleportar()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SpawnManager.spawnPointName = spawnPointNameDestino;
            SceneManager.LoadScene(sceneName);
        }
        else if (destino != null)
        {
            TeleportarCorrectamente();
        }
    }

    void TeleportarCorrectamente()
    {
        Vector3 destinoPos = destino.position;
        Quaternion destinoRot = destino.rotation;

        // Rotar el XROrigin para que la cámara quede mirando hacia el destino
        float yawCamara = xrCamera.eulerAngles.y;
        float yawDestino = destinoRot.eulerAngles.y;
        float deltaYaw = yawDestino - yawCamara;
        xrOrigin.rotation = Quaternion.Euler(0f, xrOrigin.eulerAngles.y + deltaYaw, 0f);

        // Mover el XROrigin para que la cámara quede exactamente en el destino
        Vector3 cameraOffset = new Vector3(
            xrCamera.position.x - xrOrigin.position.x,
            0f,
            xrCamera.position.z - xrOrigin.position.z
        );
        xrOrigin.position = destinoPos - cameraOffset;
    }
}