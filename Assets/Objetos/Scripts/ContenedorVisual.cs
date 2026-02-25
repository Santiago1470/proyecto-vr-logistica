using UnityEngine;

public class ContenedorVisual : MonoBehaviour
{
    private Renderer rend;
    private Color colorOriginal;

    void Awake()
    {
        rend = GetComponent<Renderer>();
        colorOriginal = rend.material.color;
    }

    public void Iluminar()
    {
        rend.material.color = Color.yellow;
    }

    public void RestaurarColor()
    {
        rend.material.color = colorOriginal;
    }
}