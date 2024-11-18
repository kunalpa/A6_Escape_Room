 using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRButtonClickHandler : MonoBehaviour
{
    private Button thisButton;
    public TextMeshPro label;
    public OVRInput.Button vrClickButton = OVRInput.Button.PrimaryIndexTrigger; // Default to the trigger button
    public Camera vrCamera; // Reference to the VR camera for raycasting

    void Start(){
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() => updateText(1));
    }

    void updateText(int amount){
        Debug.Log("Changing" + thisButton.tag);
        if(thisButton.tag == "UpButton"){
            int newInt = int.Parse(label.text) + amount;
            Debug.Log(newInt);
            if (newInt>=21){
                label.text = 0.ToString();
            }else{
                label.text = newInt.ToString();
            }

        }
        else if(thisButton.tag == "DownButton"){
            int newInt = int.Parse(label.text) - amount;
            Debug.Log(newInt);
            if (newInt<0){
                label.text = 0.ToString();
            }else{
                label.text = newInt.ToString();
            }
        }


    }

    void Update()
    {
        // Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);
        // RaycastHit hit;
        // Debug.DrawLine (transform.position, hit, Color.cyan);

        // // Check if the ray hits a collider
        // if (Physics.Raycast(ray, out hit))
        // {
        //     // Check if the hit object has a Unity UI Button component
        //     Button button = hit.collider.GetComponent<Button>();

        //     if (button != null && OVRInput.GetDown(vrClickButton))
        //     {
        //         button.onClick.Invoke();
        //         Debug.Log($"Button {button.name} clicked!");
        //     }
        // }       
    }
}
