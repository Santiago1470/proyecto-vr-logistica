using System.Collections;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    public static NPCManager Instance;

    [Header("Referencias")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;

    [Header("Animator")]
    [SerializeField] private string talkingParameter = "Talking";

    private PointOfInterest currentPoint;
    private Coroutine finishCoroutine;

    public PointOfInterest CurrentPoint => currentPoint;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    // =====================================================
    // ENTRAR A UN PUNTO
    // =====================================================
    public void EnterPoint(PointOfInterest point)
    {
        if (point == null)
            return;

        // Si ya estamos en el mismo punto
        if (currentPoint == point)
            return;

        Debug.Log($"[NPCManager] Entrando a {point.name}, npcPosition asignado: {point.npcPosition != null}");


        // Guardar el punto anterior
        SaveCurrentProgress();

        // Pausar audio anterior
        PauseAudio();

        currentPoint = point;
        Debug.Log($"[NPCManager] Posición asignada: {transform.position} — destino era: {point.npcPosition.position}");
        // Mover NPC
        transform.SetPositionAndRotation(
            point.npcPosition.position,
            point.npcPosition.rotation);
        Debug.Log($"[NPCManager] Posición asignada: {transform.position} — destino era: {point.npcPosition.position}");

        animator.SetBool(talkingParameter, false);
        // animator.speed = 0f;

        // Ocultar UI anterior
        ExplanationUI.Instance.HidePanel();

        // Ya terminó anteriormente
        if (point.completed)
        {
            ExplanationUI.Instance.ShowReplayPanel();
            return;
        }

        // Tiene progreso guardado
        if (point.savedTime > 0)
        {
            ExplanationUI.Instance.ShowContinuePanel(point);
            return;
        }

        // Nunca escuchado
        StartFromBeginning();
    }

    // =====================================================
    // SALIR DE UN PUNTO
    // =====================================================
    public void ExitPoint(PointOfInterest point)
    {
        if (currentPoint != point)
            return;

        SaveCurrentProgress();
        PauseAudio();

        if (finishCoroutine != null)
        {
            StopCoroutine(finishCoroutine);
            finishCoroutine = null;
        }

        animator.SetBool(talkingParameter, false);
        ExplanationUI.Instance.HidePanel();

        currentPoint = null;
    }

    // =====================================================
    // CONTINUAR
    // =====================================================
    public void ContinueAudio()
    {
        if (currentPoint == null)
            return;

        Play(currentPoint, currentPoint.savedTime);
    }

    // =====================================================
    // DESDE EL INICIO
    // =====================================================
    public void StartFromBeginning()
    {
        if (currentPoint == null)
            return;

        currentPoint.savedTime = 0;
        currentPoint.completed = false;

        Play(currentPoint, 0);
    }

    // =====================================================
    // PLAY
    // =====================================================
    private void Play(PointOfInterest point, float startTime)
    {
        ExplanationUI.Instance.HidePanel();

        audioSource.Stop();

        audioSource.clip = point.audioClip;

        audioSource.time = startTime;

        audioSource.Play();

        animator.SetBool(talkingParameter, true);
        // animator.speed = 1f;

        StartFinishCoroutine();
    }

    // =====================================================
    // PAUSA
    // =====================================================
    private void PauseAudio()
    {
        if (audioSource.isPlaying)
            audioSource.Pause();
    }

    // =====================================================
    // GUARDAR PROGRESO
    // =====================================================
    private void SaveCurrentProgress()
    {
        if (currentPoint == null)
            return;

        if (audioSource.clip == currentPoint.audioClip)
        {
            currentPoint.savedTime = audioSource.time;
        }
    }

    // =====================================================
    // DETECTAR FIN
    // =====================================================
    private void StartFinishCoroutine()
    {
        if (finishCoroutine != null)
            StopCoroutine(finishCoroutine);

        finishCoroutine = StartCoroutine(CheckFinished());
    }

    private IEnumerator CheckFinished()
    {
        while (audioSource.isPlaying)
            yield return null;

        bool reachedEnd = audioSource.clip != null &&
                           audioSource.time >= audioSource.clip.length - 0.05f;

        if (currentPoint != null && reachedEnd)
        {
            currentPoint.savedTime = 0;
            currentPoint.completed = true;

            animator.SetBool(talkingParameter, false);
            ExplanationUI.Instance.ShowReplayPanel();
        }
    }
}