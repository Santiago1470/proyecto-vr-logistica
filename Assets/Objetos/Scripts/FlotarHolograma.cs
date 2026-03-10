using UnityEngine;

public class FlotarHolograma : MonoBehaviour
{
    float velocidad = 2f;
    float altura = 0.05f;

    Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        transform.position = posicionInicial + Vector3.up * Mathf.Sin(Time.time * velocidad) * altura;
    }
}