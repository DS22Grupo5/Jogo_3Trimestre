using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecarregarJogo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("RecarregarMenu", 75f);
    }

    void RecarregarMenu()
    {
        SceneManager.LoadScene(1);
    }
}
