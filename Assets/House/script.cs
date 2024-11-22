using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
using Unity.VisualScripting;
using System.Collections;
using UnityEngine.ProBuilder.Shapes;
using System.Data.Common;
using Meta.WitAi;

public class MultiTextNumberController : MonoBehaviour
{
    public TextMeshPro resultDisplay;
    public TextMeshPro equalsDisplay;
    public TextMeshPro multDisplay;
    public TextMeshPro addDisplay;
    public TextMeshPro input1;
    public TextMeshPro input2;
    public TextMeshPro input3;
    public AudioSource source;
    public AudioClip openCLip;

    public TextMeshPro welcomeText;
    public Button inc1;
    public Button inc2;
    public Button dec1;
    public Button dec2;
    public Button inc3;
    public Button dec3;
    public Transform door;

    public ParticleSystem ps;
    public float openSpeed = 2.0f;
    private bool isOpen = false; // Is the door currently open?

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
        yield return new WaitForSecondsRealtime(4);
        welcomeText.text = "Professor Szafir has given you a suprise assignment before summer Break".ToString();
        // input2.ForceMeshUpdate(true);
        yield return new WaitForSecondsRealtime(6);
        welcomeText.text = "All doors to this house are locked until you complete the puzzle inside each room".ToString();
        yield return new WaitForSecondsRealtime(6);
        welcomeText.text = "You've been assigned 4 rooms to complete to pass the class".ToString();
        yield return new WaitForSecondsRealtime(6);
        welcomeText.text = "The first puzzle has some math so I hope you studied!".ToString();
        yield return new WaitForSecondsRealtime(5);
        welcomeText.text = "Your summer break awaits ahead so you better hurry!".ToString();
        yield return new WaitForSecondsRealtime(5);
        welcomeText.text = "Good Luck and Have Fun!".ToString();
        yield return new WaitForSecondsRealtime(3);
        welcomeText.text = "";
        StartPuzzle();
    }
    void StartPuzzle(){    
        welcomeText.gameObject.SetActive(false);
        ActivateTextObjects();
        int num1 = UnityEngine.Random.Range(1,9);
        int num2 = UnityEngine.Random.Range(1,9);
        int num3 = UnityEngine.Random.Range(1,9);
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
            Debug.Log(isOpen + " "+ triggered + " " + inputtedNum + " " + result);
            if (inputtedNum == result && result != 0 && isOpen == false)
            {
                TriggerDoorEvent();
            }
        }
        
    }
    public void Open(){
        StartCoroutine(DoorParticle());
    }
    IEnumerator DoorParticle(){
        Debug.Log("Open Door");
        // AudioSource audio = Instantiate(audioOriginal);
        Vector3 psPos = new Vector3(-2.0f,3.0f,36.0f);
        Quaternion rotation = Quaternion.Euler(270,0,0);
        Vector3 openPosition  = new Vector3(0, 0 ,0);
        ParticleSystem doorParticle = Instantiate(ps,psPos,rotation);
        door.localPosition = openPosition;
        doorParticle.Play();
        source.PlayOneShot(openCLip);
        yield return new WaitForSecondsRealtime(7);
        doorParticle.Stop();
        doorParticle.Clear();
    }
    public void TriggerDoorEvent()
    {
        triggered = true;
        isOpen = !isOpen; 
        Open();
    }
}
