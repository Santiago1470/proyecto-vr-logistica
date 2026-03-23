using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform xrOrigin;

    void Start()
    {
        SpawnPoint[] puntos = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);

        foreach (SpawnPoint punto in puntos)
        {
            if (string.IsNullOrEmpty(SpawnManager.spawnPointName))
            {
                Debug.LogWarning("No spawn point definido, usando posición por defecto");
            }

            if (punto.spawnName == SpawnManager.spawnPointName)
            {
                xrOrigin.position = punto.transform.position;
                xrOrigin.rotation = punto.transform.rotation;
                break;
            }
        }
    }
}