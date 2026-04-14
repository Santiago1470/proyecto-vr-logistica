using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportConfirm : MonoBehaviour
{
    public Transform xrOrigin;
    public Transform destino;

    public string sceneName;
    public string spawnPointNameDestino;

    public void Teleportar()
    {
        // CASO 1: cambiar de escena
        if (!string.IsNullOrEmpty(sceneName))
        {
            SpawnManager.spawnPointName = spawnPointNameDestino;
            SceneManager.LoadScene(sceneName);
        }
        // CASO 2: teletransporte dentro de la misma escena
        else if (destino != null)
        {
            xrOrigin.position = destino.position;
            xrOrigin.rotation = destino.rotation;
        }
    }
}