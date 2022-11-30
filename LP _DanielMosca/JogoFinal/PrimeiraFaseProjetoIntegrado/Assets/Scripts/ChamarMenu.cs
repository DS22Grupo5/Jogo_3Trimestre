using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamarMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("MudarCena", 35f);
    }

    void MudarCena()
    {
        SceneManager.LoadScene(1);
    }
}
