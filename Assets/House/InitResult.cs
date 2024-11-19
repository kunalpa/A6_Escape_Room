using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InitResult : MonoBehaviour
{
    public TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        int num1 = UnityEngine.Random.Range(1,20);
        int num2 = UnityEngine.Random.Range(1,20);
        text.text = Convert.ToString(num1*num2);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
