using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    public GameObject[] codeSquares; // Array of the first four squares
    public GameObject redSquare; // Red square for code submission
    public GameObject keyPrefab; // Reference to key prefab
    private int[] currentCode = new int[4]; // Tracks each square’s value
    private int[] correctCode = {1, 2, 3, 4}; // Set your correct code here
    public Player playerScript;

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
        TextMesh textMesh = codeSquares[index].GetComponent<TextMesh>();
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
            }
        }
        Debug.Log("Correct Code! Key Instantiated.");
        Vector3 keyPos = new Vector3(0, 0, 3); // Adjust position as needed
        Instantiate(keyPrefab, keyPos, Quaternion.identity);
        playerScript.AddToBackpack("codeKey");
    }
}
