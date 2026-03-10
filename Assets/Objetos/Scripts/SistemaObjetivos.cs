using UnityEngine;
using TMPro;

public class SistemaObjetivos : MonoBehaviour
{
    public TextMeshProUGUI textoObjetivo;

    public void ObjetivoCasco()
    {
        textoObjetivo.text = "Recoge el casco de seguridad.";
    }

    public void ObjetivoCredencial()
    {
        textoObjetivo.text = "Toma una credencial.";
    }

    public void ObjetivoMesa()
    {
        textoObjetivo.text = "Coloca la credencial en la mesa de verificación.";
    }

    public void ObjetivoEntrarPuerto()
    {
        textoObjetivo.text = "Accede al puerto. Las puertas están abiertas.";
    }
}