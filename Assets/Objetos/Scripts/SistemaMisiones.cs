using UnityEngine;
using TMPro;

public class SistemaMisiones : MonoBehaviour
{
    public TextMeshProUGUI misionCasco;
    public TextMeshProUGUI misionCredencial;
    public TextMeshProUGUI misionVerificar;
    public TextMeshProUGUI misionEntrar;

    public void CompletarCasco()
    {
        misionCasco.text = "☑ Ponerse casco de seguridad";
        misionCasco.color = Color.green;
    }

    public void CompletarCredencial()
    {
        misionCredencial.text = "☑ Tomar credencial de acceso";
        misionCredencial.color = Color.green;
    }

    public void CompletarVerificacion()
    {
        misionVerificar.text = "☑ Verificar credencial en la mesa";
        misionVerificar.color = Color.green;
    }

    public void CompletarEntrada()
    {
        misionEntrar.text = "☑ Ingresar al puerto";
        misionEntrar.color = Color.green;
    }
}