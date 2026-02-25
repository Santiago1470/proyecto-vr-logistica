using UnityEngine;

public enum CategoriaContenedor
{
    General,
    Prioritario,
    Riesgo
}

[System.Serializable]
public class ContenedorData
{
    public string id;
    public CategoriaContenedor categoria;
    public string contenido;
    public int prioridad;
}