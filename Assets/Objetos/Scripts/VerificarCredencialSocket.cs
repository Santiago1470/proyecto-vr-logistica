using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VerificarCredencialSocket : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    public GameObject canvasCorrecto;
    public GameObject canvasIncorrecto;

    [Header("Canvas a desactivar cuando sea correcto")]
    public GameObject canvasADesactivar1;
    public GameObject canvasADesactivar2;

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnObjectPlaced);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnObjectPlaced);
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        GameObject objeto = args.interactableObject.transform.gameObject;

        if (objeto.CompareTag("CredencialCorrecta"))
        {
            canvasCorrecto.SetActive(true);
            canvasIncorrecto.SetActive(false);

            // Desactivar los otros canvas
            if(canvasADesactivar1 != null)
                canvasADesactivar1.SetActive(false);

            if(canvasADesactivar2 != null)
                canvasADesactivar2.SetActive(false);

            FindFirstObjectByType<AbrirPuertasPuerto>().AbrirPuertas();
            FindFirstObjectByType<SistemaMisiones>().CompletarVerificacion();
        }
        else if (objeto.CompareTag("CredencialIncorrecta"))
        {
            canvasIncorrecto.SetActive(true);
            canvasCorrecto.SetActive(false);
        }
    }
}