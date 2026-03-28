using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleGravity : MonoBehaviour
{
    public float gravity = -9.81f;
    float velocityY;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded && velocityY < 0)
        {
            velocityY = -2f; // mantiene pegado al suelo
        }

        velocityY += gravity * Time.deltaTime;

        Vector3 move = new Vector3(0, velocityY, 0);
        controller.Move(move * Time.deltaTime);
    }
}