using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    Transform posicaoPersonagem;

    void Start()
    {
        posicaoPersonagem = GameObject.Find("Personagem").GetComponent<Transform>();
    }

    void Update()
    {
        if(posicaoPersonagem.position.x <= -12)
        {
            SceneManager.LoadScene(9);
        }
    }
}
