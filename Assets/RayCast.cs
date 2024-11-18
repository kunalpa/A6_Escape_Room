using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Raycast : MonoBehaviour {

    void Start(){
        LineRenderer line = GetComponent<LineRenderer>();
        if(OVRInput.Get(OVRInput.Button.Any)){
            RaycastHit hit;
            Ray ray = new Ray(transform.position,transform.forward);
        
            if (Physics.Raycast(ray, out hit)) {
                if(hit.collider.tag == "UpButton" || hit.collider.tag == "DownButton"){
                    Button thisButton = hit.collider.GetComponent<Button>();
                    thisButton.onClick.Invoke();
                }
                line.SetPosition(0,transform.position); 
                line.SetPosition(1,hit.transform.position);


            }
        }

       
    }
}