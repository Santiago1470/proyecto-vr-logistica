using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportConfirm : MonoBehaviour
{
    // public Transform xrOrigin;
    // public Transform destino;

    public string sceneName;
    public string spawnPointNameDestino;

    public void CambiarEscena()
    {
        SpawnManager.spawnPointName = spawnPointNameDestino;
        SceneManager.LoadScene(sceneName);
    }

    public void Teleportar()
    {
        CambiarEscena();
        // xrOrigin.position = destino.position;
        // xrOrigin.rotation = destino.rotation;
    }
}