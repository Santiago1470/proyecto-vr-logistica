using UnityEngine;

public class AbrirPuertasPuerto : MonoBehaviour
{
    public Transform puertaIzquierda;
    public Transform puertaDerecha;

    public float velocidad = 2f;

    private Quaternion rotacionInicialIzq;
    private Quaternion rotacionInicialDer;

    private Quaternion rotacionFinalIzq;
    private Quaternion rotacionFinalDer;

    private bool abrir = false;

    void Start()
    {
        rotacionInicialIzq = puertaIzquierda.localRotation;
        rotacionInicialDer = puertaDerecha.localRotation;

        rotacionFinalIzq = Quaternion.Euler(0, 0, -90);
        rotacionFinalDer = Quaternion.Euler(0, 0, 90);
    }

    void Update()
    {
        if (abrir)
        {
            puertaIzquierda.localRotation = Quaternion.Lerp(
                puertaIzquierda.localRotation,
                rotacionFinalIzq,
                Time.deltaTime * velocidad
            );

            puertaDerecha.localRotation = Quaternion.Lerp(
                puertaDerecha.localRotation,
                rotacionFinalDer,
                Time.deltaTime * velocidad
            );
        }
    }

    public void AbrirPuertas()
    {
        abrir = true;
    }
}