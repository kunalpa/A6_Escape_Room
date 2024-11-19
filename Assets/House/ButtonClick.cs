 using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class VRButtonClickHandler : MonoBehaviour
{
    private Button thisButton;
    public TextMeshPro label;
    // public OVRInput.Button vrClickButton = OVRInput.Button.PrimaryIndexTrigger; // Default to the trigger button
    // public Camera vrCamera; // Reference to the VR camera for raycasting
        void Start(){
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() => updateText(1));
    }

    void updateText(int amount){
        Debug.Log("Changing" + thisButton.tag);
        if(thisButton.tag == "UpButton"){
            int newInt = int.Parse(label.text) + amount;
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
    void Update(){
    //     if(OVRInput.GetDown(vrClickButton)){
    //         thisButton.onClick.Invoke();
    //     }

    }
   
    
}
