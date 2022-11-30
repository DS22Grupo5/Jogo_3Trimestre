using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CarregarMenu", 5f);
    }

    private void CarregarMenu()
    {
        SceneManager.LoadScene(0);
    }
}
