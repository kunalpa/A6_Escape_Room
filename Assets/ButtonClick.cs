using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRButtonClickHandler : MonoBehaviour
{
    public OVRInput.Button vrClickButton = OVRInput.Button.PrimaryIndexTrigger; // Default to the trigger button
    public Camera vrCamera; // Reference to the VR camera for raycasting

    void Update()
    {
        // Perform a raycast from the center of the VR camera
        Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);
        RaycastHit hit;

        // Check if the ray hits a collider
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the hit object has a Unity UI Button component
            Button button = hit.collider.GetComponent<Button>();

            if (button != null && OVRInput.GetDown(vrClickButton))
            {
                // Simulate a button click
                button.onClick.Invoke();
                Debug.Log($"Button {button.name} clicked!");
            }
        }
    }
}
