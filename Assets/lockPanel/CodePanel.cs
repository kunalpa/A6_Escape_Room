using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePanel : MonoBehaviour
{
    public GameObject[] codeSquares;
    public GameObject redSquare;
    public GameObject keyPrefab;
    private int[] currentCode = new int[4];
    private int[] correctCode = {1, 2, 3, 4};
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
                return;
            }
        }
        Vector3 keyPos = new Vector3(0, 0, 3);
        Instantiate(keyPrefab, keyPos, Quaternion.identity);
        playerScript.AddToBackpack("codeKey");
    }
}
