using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MakeTransition : MonoBehaviour
{
    bool faseIniciada = false;
    void Start()
    {
        faseIniciada = true;
    }
    void Update()
    {
        if(faseIniciada == true)
        {
            Invoke("ChamarFase2", 5f);
        }
    }
    void ChamarFase2()
    {
        SceneManager.LoadScene(10);
    }
}
