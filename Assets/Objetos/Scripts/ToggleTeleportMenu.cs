using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class ToggleTeleportMenu : MonoBehaviour
{
    public GameObject menu;

    private bool wasPressed = false;

    void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
        // TECLADO (para pruebas en PC)
        if (Keyboard.current != null && Keyboard.current.mKey.wasPressedThisFrame)
        {
            ToggleMenu();
        }

        // CONTROL VR (botón Y / A)
        bool pressed = XRButtonPressed(XRNode.LeftHand, UnityEngine.XR.CommonUsages.primaryButton);

        if (pressed && !wasPressed)
        {
            ToggleMenu();
        }

        wasPressed = pressed;
    }

    void ToggleMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }

    bool XRButtonPressed(XRNode node, InputFeatureUsage<bool> button)
    {
        UnityEngine.XR.InputDevice device = InputDevices.GetDeviceAtXRNode(node);

        if (device.isValid)
        {
            bool value = false;
            if (device.TryGetFeatureValue(button, out value))
            {
                return value;
            }
        }

        return false;
    }
}