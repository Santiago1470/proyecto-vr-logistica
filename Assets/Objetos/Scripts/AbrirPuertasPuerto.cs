using UnityEngine;
using System.Collections;

public class AbrirPuertasPuerto : MonoBehaviour
{
    [Header("Puertas")]
    public Transform puertaIzquierda;
    public Transform puertaDerecha;

    [Header("Canvas")]
    public GameObject canvasCorrecto;
    public float tiempoMostrarCanvas = 3f;

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

        if(canvasCorrecto != null)
            canvasCorrecto.SetActive(false);
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

                StartCoroutine(MostrarCanvasTemporal());
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

    IEnumerator MostrarCanvasTemporal()
    {
        canvasCorrecto.SetActive(true);

        yield return new WaitForSeconds(tiempoMostrarCanvas);

        canvasCorrecto.SetActive(false);
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