using UnityEngine;

public class TriggerEntradaPuerto : MonoBehaviour
{
    bool activado = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!activado && other.CompareTag("Player"))
        {
            activado = true;

            SistemaMisiones sistema = FindFirstObjectByType<SistemaMisiones>();

            if (sistema != null)
            {
                sistema.CompletarEntrada();
            }
        }
    }
}