using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueControl : MonoBehaviour
{
    [Header("Components")]
    public GameObject dialogueObj;
    public Text speechText;
    

    [Header("Settings")]
    public float typingSpeed;

    public void Speech(string txt)
    {
        dialogueObj.SetActive(true);      
        speechText.text = txt;
    }
}
