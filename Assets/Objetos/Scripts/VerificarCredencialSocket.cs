using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VerificarCredencialSocket : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;

    public GameObject canvasCorrecto;
    public GameObject canvasIncorrecto;

    // public AbrirPuertasPuerto scriptAbrirPuertas;

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

            // if(scriptAbrirPuertas != null){
            //     scriptAbrirPuertas.AbrirPuertas();
            // }
            FindFirstObjectByType<AbrirPuertasPuerto>().AbrirPuertas();
            FindFirstObjectByType<SistemaMisiones>().CompletarVerificacion();
        }else if (objeto.CompareTag("CredencialIncorrecta"))
        {
            canvasIncorrecto.SetActive(true);
            canvasCorrecto.SetActive(false);
        }
    }
}