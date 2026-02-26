using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ContenedorManagerVR : MonoBehaviour
{
    [Header("UI")]
    public TMP_Dropdown dropdown;
    public TextMeshProUGUI nombreText;
    public TextMeshProUGUI contenidoText;
    public TextMeshProUGUI prioridadText;
    public TextMeshProUGUI resultadoText;

    [Header("Panel Resultados")]
    public GameObject panelResultados; // 🔹 Panel que contiene resultadoText

    [Header("Render Camara")]
    public Camera camaraBarco;
    public RawImage imagenCamara;

    [Header("Contenedores en escena")]
    public List<ContenedorVisual> contenedoresVisuales;

    private List<ContenedorData> contenedoresData = new List<ContenedorData>();
    private ContenedorData contenedorActual;

    private float tiempoTotal = 0f;
    private float costoTotal = 0f;
    private float satisfaccion = 100f;

    private string[] posiblesContenidos =
    {
        "Electrodomésticos",
        "Textiles",
        "Repuestos automotrices",
        "Medicamentos",
        "Alimentos procesados",
        "Equipos electrónicos"
    };

    void Start()
    {
        GenerarContenedores();
        ConfigurarDropdown();

        camaraBarco.gameObject.SetActive(false);
        imagenCamara.enabled = false;

        // 🔹 Ocultar panel de resultados al inicio
        if (panelResultados != null)
            panelResultados.SetActive(false);
    }

    void GenerarContenedores()
    {
        contenedoresData.Clear();

        contenedoresData.Add(CrearContenedor("C-001", CategoriaContenedor.General));
        contenedoresData.Add(CrearContenedor("C-002", CategoriaContenedor.General));
        contenedoresData.Add(CrearContenedor("C-003", CategoriaContenedor.Prioritario));
        contenedoresData.Add(CrearContenedor("C-004", CategoriaContenedor.Prioritario));
        contenedoresData.Add(CrearContenedor("C-005", CategoriaContenedor.Riesgo));
    }

    ContenedorData CrearContenedor(string id, CategoriaContenedor categoria)
    {
        ContenedorData c = new ContenedorData();
        c.id = id;
        c.categoria = categoria;
        c.contenido = posiblesContenidos[Random.Range(0, posiblesContenidos.Length)];

        switch (categoria)
        {
            case CategoriaContenedor.General:
                c.prioridad = Random.Range(1, 3);
                break;

            case CategoriaContenedor.Prioritario:
                c.prioridad = Random.Range(4, 6);
                break;

            case CategoriaContenedor.Riesgo:
                c.prioridad = Random.Range(3, 6);
                break;
        }

        return c;
    }

    void ConfigurarDropdown()
    {
        dropdown.ClearOptions();

        List<string> opciones = new List<string>();
        foreach (var c in contenedoresData)
        {
            opciones.Add(c.id);
        }

        dropdown.AddOptions(opciones);
        dropdown.onValueChanged.AddListener(SeleccionarContenedor);

        // Seleccionar el primero automáticamente
        SeleccionarContenedor(0);
    }

    public void SeleccionarContenedor(int index)
    {
        contenedorActual = contenedoresData[index];

        nombreText.text = contenedorActual.id;
        contenidoText.text = contenedorActual.contenido;
        prioridadText.text = contenedorActual.prioridad.ToString();

        // Activar cámara e imagen
        camaraBarco.gameObject.SetActive(true);
        imagenCamara.enabled = true;

        // Restaurar colores
        foreach (var visual in contenedoresVisuales)
            visual.RestaurarColor();

        // Iluminar seleccionado
        if (index < contenedoresVisuales.Count)
            contenedoresVisuales[index].Iluminar();
    }

    // 🔴 BOTÓN DESCARGA INMEDIATA
    public void DescargaInmediata()
    {
        if (contenedorActual == null) return;

        tiempoTotal += 1f;
        costoTotal += 300f;

        if (contenedorActual.prioridad >= 4)
            satisfaccion += 5f;
        else
            satisfaccion -= 5f;

        ActualizarResultado("Descarga inmediata aplicada");
    }

    // 🟢 BOTÓN TURNO ESTÁNDAR
    public void TurnoEstandar()
    {
        if (contenedorActual == null) return;

        tiempoTotal += 2f;
        costoTotal += 150f;

        if (contenedorActual.prioridad >= 4)
            satisfaccion -= 10f;
        else
            satisfaccion += 2f;

        ActualizarResultado("Turno estándar aplicado");
    }

    void ActualizarResultado(string accion)
    {
        resultadoText.text =
            accion +
            "\nTiempo total: " + tiempoTotal +
            "\nCosto total: $" + costoTotal +
            "\nSatisfacción: " + satisfaccion;

        // 🔹 Activar panel cuando haya resultado
        if (panelResultados != null && !panelResultados.activeSelf)
            panelResultados.SetActive(true);
    }

    // 🔹 BOTÓN CERRAR PANEL
    public void CerrarPanelResultados()
    {
        if (panelResultados != null)
            panelResultados.SetActive(false);
    }
}