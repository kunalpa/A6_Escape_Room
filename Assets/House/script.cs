using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class MultiTextNumberController : MonoBehaviour
{
    public TMP_Text   resultDisplay;
    public TMP_Text   input1; // Reference to the second Text component
    public TMP_Text   input2; // Reference to the third Text component

    public Button increaseButton1; // Reference to the increase button
    public Button decreaseButton1; // Reference to the decrease button
    
    public Button increaseButton2;
    public Button decreaseButton2;
     public Transform door; // The door's Transform
    public Vector3 openPosition; // Target position or rotation when opened
    public Vector3 closedPosition; // Default position or rotation when closed
    public float openSpeed = 2.0f; // Speed of opening the door
    public bool isOpen = false; // Is the door currently open?

    private bool triggered = false; // Has the event occurred?


    private int result = 0; // Tracks the first number
    private int currentNumber2 = 0; // Tracks the second number
    private int currentNumber3 = 0; // Tracks the third number


    void Start()
    {
        // Initialize the displays
        Update();
    
        int num1 = UnityEngine.Random.Range(1,20);
        int num2 = UnityEngine.Random.Range(1,20);
        int goalNum =num1*num2;
        resultDisplay.text = Convert.ToString(goalNum);
        result = goalNum;

        // Attach click listeners to the buttons
        increaseButton1.onClick.AddListener(() => ChangeNumbers(1));
        decreaseButton1.onClick.AddListener(() => ChangeNumbers(-1));
        increaseButton2.onClick.AddListener(() => ChangeNumbers(1));
        decreaseButton2.onClick.AddListener(() => ChangeNumbers(-1));
    }
    

    // Method to change all numbers
    void ChangeNumbers(int amount)
    {
        if(currentNumber2+amount >=21){
            currentNumber2 = 0;
        }
        else if(currentNumber2 + amount <= 0){
            currentNumber2 = 20;
        }
        else{
            currentNumber2 += amount; // Example logic: increment at a different rate
        }
         if(currentNumber3+amount >=21){
            currentNumber3 = 0;
        }
        else if(currentNumber2 + amount <= 0){
            currentNumber3 = 20;
        }
        else{
            currentNumber3 += amount; // Example logic: increment at a different rate
        }

        Update();
    }

    // Update all number displays
    void Update()
    {
        input1.text = currentNumber2.ToString();
        input2.text = currentNumber3.ToString();
        if (currentNumber2 * currentNumber3 == result)
        {
            TriggerDoorEvent();
        }
        if (triggered)
        {
            // Smoothly move the door towards the open or closed position
            door.localPosition = Vector3.Lerp(door.localPosition, isOpen ? openPosition : closedPosition, Time.deltaTime * openSpeed);
        }
    
    }
    public void TriggerDoorEvent()
    {
        triggered = true;
        isOpen = !isOpen; // Toggle the state
    }
}
