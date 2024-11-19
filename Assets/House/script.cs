using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.ProBuilder.Shapes;

public class MultiTextNumberController : MonoBehaviour
{
    public TextMeshPro resultDisplay;
    public TextMeshPro equalsDisplay;
    public TextMeshPro multDisplay;
    public TextMeshPro input1;
    public TextMeshPro input2;
    public TextMeshPro welcomeText;
    public Button inc1;
    public Button inc2;
    public Button dec1;
    public Button dec2;
    public Transform door; // The door's Transform
    public Vector3 openPosition; // Target position or rotation when opened
    public Vector3 closedPosition; // Default position or rotation when closed
    public float openSpeed = 2.0f; // Speed of opening the door
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
        welcomeText.text = "Welcome to the First Puzzle".ToString();
        // input2.ForceMeshUpdate(true);
        yield return new WaitForSecondsRealtime(5);
        welcomeText.text = "Find the 2 factors of the number on the right".ToString();
        // input2.ForceMeshUpdate(true);
        yield return new WaitForSecondsRealtime(5);
        welcomeText.text = "Numbers range from 0-20. Good Luck!".ToString();
        // input2.ForceMeshUpdate(true);
        yield return new WaitForSecondsRealtime(5);
        welcomeText.text = "";
         yield return new WaitForSecondsRealtime(2);
        StartPuzzle();
    }
    void StartPuzzle(){    
        welcomeText.gameObject.SetActive(false);
        ActivateTextObjects();
        int num1 = UnityEngine.Random.Range(1,21);
        int num2 = UnityEngine.Random.Range(1,21);
        int goalNum =num1*num2;
        input2.text = "0".ToString();
        input1.text = "0".ToString();
        multDisplay.text = "X".ToString();
        equalsDisplay.text = "=".ToString();
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
            input2.gameObject.SetActive(true);
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
}

    void Update()
    {   Debug.Log(int.Parse(input1.text) * int.Parse(input2.text));
        if (int.Parse(input1.text) * int.Parse(input2.text) == result)
        {
            TriggerDoorEvent();
        }
        if (triggered)
        {
            Debug.Log("Door Open");
            door.localPosition = Vector3.Lerp(door.localPosition, isOpen ? openPosition : closedPosition, Time.deltaTime * openSpeed);
            DoorOpen doorScript = door.GetComponent<DoorOpen>();
            doorScript.Open();
        }    
    }
    public void TriggerDoorEvent()
    {
        triggered = true;
        isOpen = !isOpen; // Toggle the state
    }
}
