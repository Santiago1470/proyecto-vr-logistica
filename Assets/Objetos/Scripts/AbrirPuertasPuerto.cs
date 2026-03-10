using UnityEngine;

public class AbrirPuertasPuerto : MonoBehaviour
{
    [Header("Puertas")]
    public Transform puertaIzquierda;
    public Transform puertaDerecha;

    [Header("Configuración")]
    public float velocidadRotacion = 120f;

    private Quaternion rotacionInicialIzq;
    private Quaternion rotacionInicialDer;

    private Quaternion rotacionAbiertaIzq;
    private Quaternion rotacionAbiertaDer;

    private bool abrirPuertas = false;
    private bool cerrarPuertas = false;

    void Start()
    {
        // Guardar rotaciones iniciales
        rotacionInicialIzq = puertaIzquierda.localRotation;
        rotacionInicialDer = puertaDerecha.localRotation;

        // Calcular rotaciones abiertas
        rotacionAbiertaIzq = rotacionInicialIzq * Quaternion.Euler(0, -90, 0);
        rotacionAbiertaDer = rotacionInicialDer * Quaternion.Euler(0, 90, 0);
    }

    void Update()
    {
        if (abrirPuertas)
        {
            puertaIzquierda.localRotation = Quaternion.RotateTowards(
                puertaIzquierda.localRotation,
                rotacionAbiertaIzq,
                velocidadRotacion * Time.deltaTime
            );

            puertaDerecha.localRotation = Quaternion.RotateTowards(
                puertaDerecha.localRotation,
                rotacionAbiertaDer,
                velocidadRotacion * Time.deltaTime
            );

            if (Quaternion.Angle(puertaIzquierda.localRotation, rotacionAbiertaIzq) < 0.5f &&
                Quaternion.Angle(puertaDerecha.localRotation, rotacionAbiertaDer) < 0.5f)
            {
                abrirPuertas = false;
                Debug.Log("Puertas completamente abiertas");
            }
        }

        if (cerrarPuertas)
        {
            puertaIzquierda.localRotation = Quaternion.RotateTowards(
                puertaIzquierda.localRotation,
                rotacionInicialIzq,
                velocidadRotacion * Time.deltaTime
            );

            puertaDerecha.localRotation = Quaternion.RotateTowards(
                puertaDerecha.localRotation,
                rotacionInicialDer,
                velocidadRotacion * Time.deltaTime
            );

            if (Quaternion.Angle(puertaIzquierda.localRotation, rotacionInicialIzq) < 0.5f &&
                Quaternion.Angle(puertaDerecha.localRotation, rotacionInicialDer) < 0.5f)
            {
                cerrarPuertas = false;
                Debug.Log("Puertas cerradas");
            }
        }
    }

    public void AbrirPuertas()
    {
        abrirPuertas = true;
        cerrarPuertas = false;
        Debug.Log("Abriendo puertas...");
    }

    public void CerrarPuertas()
    {
        cerrarPuertas = true;
        abrirPuertas = false;
        Debug.Log("Cerrando puertas...");
    }
}