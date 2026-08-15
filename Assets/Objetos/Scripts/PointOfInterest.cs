using UnityEngine;

public class PointOfInterest : MonoBehaviour
{
    [Header("NPC")]
    public Transform npcPosition;

    [Header("Explicación")]
    public string title;

    public AudioClip audioClip;

    [HideInInspector]
    public float savedTime;

    [HideInInspector]
    public bool completed;
}