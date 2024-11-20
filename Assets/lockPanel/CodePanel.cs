using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    public GameObject[] codeSquares;
    public GameObject redSquare; 
    public GameObject keyPrefab; 
    private int[] currentCode = new int[4];
    private int[] correctCode = {1, 9, 5, 7};
    public Player playerScript;
    public GameObject door;

    void Start()
    {
        for (int i = 0; i < currentCode.Length; i++)
        {
            currentCode[i] = 0;
        }
    }

    public void HandleSquareHit(GameObject square)
    {
        if (IsCodeSquare(square, out int index))
        {
            IncrementSquare(index);
        }
        else if (square == redSquare)
        {
            CheckCode();
        }
    }

    private bool IsCodeSquare(GameObject obj, out int index)
    {
        index = System.Array.IndexOf(codeSquares, obj);
        return index >= 0;
    }

    private void IncrementSquare(int index)
    {
        currentCode[index] = (currentCode[index] + 1) % 10;
        TextMeshPro textMesh = codeSquares[index].GetComponent<TextMeshPro>();
        if (textMesh != null)
        {
            textMesh.text = currentCode[index].ToString();
        }
    }

    private void CheckCode()
    {
        for (int i = 0; i < currentCode.Length; i++)
        {
            if (currentCode[i] != correctCode[i])
            {
                Debug.Log("Incorrect Code");
                return;
            } else {
                Destroy(door);
                StartCoroutine(playerScript.generateKey("panelKey"));
            }
        }
    }
}
