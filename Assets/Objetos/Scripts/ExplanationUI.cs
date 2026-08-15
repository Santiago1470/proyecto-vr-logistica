using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExplanationUI : MonoBehaviour
{
    public static ExplanationUI Instance;

    [Header("Panel")]
    [SerializeField] private GameObject panel;

    [Header("Texto")]
    [SerializeField] private TMP_Text titleText;

    [Header("Botones")]
    [SerializeField] private Button continueButton;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button replayButton;

    private void Awake()
    {
        Instance = this;

        HidePanel();
    }

    // =====================================
    // CONTINUAR
    // =====================================
    public void ShowContinuePanel(PointOfInterest point)
    {
        panel.SetActive(true);

        float remaining = point.audioClip.length - point.savedTime;

        titleText.text =
            point.title +
            "\nFaltan " +
            FormatTime(remaining);

        continueButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        replayButton.gameObject.SetActive(false);
    }

    // =====================================
    // REPETIR
    // =====================================
    public void ShowReplayPanel()
    {
        panel.SetActive(true);

        titleText.text = "Explicación finalizada";

        continueButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        replayButton.gameObject.SetActive(true);
    }

    // =====================================
    // OCULTAR
    // =====================================
    public void HidePanel()
    {
        panel.SetActive(false);
    }

    // =====================================
    // BOTONES
    // =====================================
    public void OnContinue()
    {
        NPCManager.Instance.ContinueAudio();
    }

    public void OnRestart()
    {
        NPCManager.Instance.StartFromBeginning();
    }

    public void OnReplay()
    {
        NPCManager.Instance.StartFromBeginning();
    }

    // =====================================
    // FORMATO TIEMPO
    // =====================================
    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        return minutes.ToString("00") +
               ":" +
               seconds.ToString("00");
    }
}