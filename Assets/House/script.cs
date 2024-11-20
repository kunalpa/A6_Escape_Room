using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.ProBuilder.Shapes;
using System.Data.Common;

public class MultiTextNumberController : MonoBehaviour
{
    public TextMeshPro resultDisplay;
    public TextMeshPro equalsDisplay;
    public TextMeshPro multDisplay;
    public TextMeshPro addDisplay;
    public TextMeshPro input1;
    public TextMeshPro input2;
    public TextMeshPro input3;

    public TextMeshPro welcomeText;
    public Button inc1;
    public Button inc2;
    public Button dec1;
    public Button dec2;
    public Button inc3;
    public Button dec3;
    public Transform door;

    
    public bool isOpen = false; // Is the door currently open?

    private bool triggered = false; // Has the event occurred?


    private int result = 0; // Tracks the first number

    void Start()
    {
        StartCoroutine(IntroText());
    }

    IEnumerator IntroText()
    {
        DeactivateTextObjects();
        welcomeText.text = "Wake Up UNC Student!".ToString();
        // input2.ForceMeshUpdate(true);
        yield return new WaitForSecondsRealtime(6);
        welcomeText.text = "You have been teleported to this house for your final exam!".ToString();
        // input2.ForceMeshUpdate(true);
        yield return new WaitForSecondsRealtime(4);
        welcomeText.text = "To pass you must escape all 4 rooms of this house".ToString();
        // input2.ForceMeshUpdate(true);
        yield return new WaitForSecondsRealtime(4);
        welcomeText.text = "Each room has a puzzle you must complete which will open the door to the next room".ToString();
        yield return new WaitForSecondsRealtime(4);
        welcomeText.text = "The first puzzle has some math so I hope you studied!".ToString();
        yield return new WaitForSecondsRealtime(4);
        welcomeText.text = "Good Luck and Have Fun!".ToString();
        yield return new WaitForSecondsRealtime(3);
        welcomeText.text = "";
        StartPuzzle();
    }
    void StartPuzzle(){    
        welcomeText.gameObject.SetActive(false);
        ActivateTextObjects();
        int num1 = UnityEngine.Random.Range(9,0);
        int num2 = UnityEngine.Random.Range(0,9);
        int num3 = UnityEngine.Random.Range(0,9);
        int goalNum =num1*num2+num3;
        input2.text = "0".ToString();
        input1.text = "0".ToString();
        input3.text = "0".ToString();
        multDisplay.text = "X".ToString();
        equalsDisplay.text = "=".ToString();
        addDisplay.text = "+".ToString();
        resultDisplay.text = goalNum.ToString();
        // ForceUpdateText();
        result = goalNum;
        Update();
    }

    
    public void DeactivateTextObjects()
    {
        if (inc1 != null)
            inc1.gameObject.SetActive(false);

        if (inc2 != null)
            inc2.gameObject.SetActive(false);

        if (dec1 != null)
            dec1.gameObject.SetActive(false);

        if (dec2 != null)
            dec2.gameObject.SetActive(false);
        
        if (resultDisplay != null)
            resultDisplay.gameObject.SetActive(false);

        if (equalsDisplay != null)
            equalsDisplay.gameObject.SetActive(false);

        if (multDisplay != null)
            multDisplay.gameObject.SetActive(false);

        if (input1 != null)
            input1.gameObject.SetActive(false);
        if(input2 != null)
            input2.gameObject.SetActive(false);
        input3.gameObject.SetActive(false);
        dec3.gameObject.SetActive(false);
        inc3.gameObject.SetActive(false);
        addDisplay.gameObject.SetActive(false);
       

}
    public void ActivateTextObjects()
{
        if (inc1 != null)
            inc1.gameObject.SetActive(true);

        if (inc2 != null)
            inc2.gameObject.SetActive(true);

        if (dec1 != null)
            dec1.gameObject.SetActive(true);

        if (dec2 != null)
            dec2.gameObject.SetActive(true);
        
        if (resultDisplay != null)
            resultDisplay.gameObject.SetActive(true);

        if (equalsDisplay != null)
            equalsDisplay.gameObject.SetActive(true);

        if (multDisplay != null)
            multDisplay.gameObject.SetActive(true);

        if (input1 != null)
            input1.gameObject.SetActive(true);
        if(input2 != null)
            input2.gameObject.SetActive(true);
        input3.gameObject.SetActive(true);
        dec3.gameObject.SetActive(true);
        inc3.gameObject.SetActive(true);
        addDisplay.gameObject.SetActive(true);
}

    void Update()
    {   
        if(input1.text != null && input2.text != null && input3.text != null){
            int inputtedNum = int.Parse(input1.text) * int.Parse(input2.text) + int.Parse(input3.text);
            if (inputtedNum == result && result != 0)
            {
                TriggerDoorEvent();
            }
            if (triggered && isOpen == false)
            {
                Debug.Log("Door Open");
                DoorOpen doorScript = door.GetComponent<DoorOpen>();
                doorScript.Open();
            }    
        }
        
    }
    public void TriggerDoorEvent()
    {
        triggered = true;
        isOpen = !isOpen; // Toggle the state
    }
}
