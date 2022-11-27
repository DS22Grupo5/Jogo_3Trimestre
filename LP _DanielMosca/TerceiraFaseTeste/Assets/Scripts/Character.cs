using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private GameObject gameManager;
    private bool suprimentoJogado = false;
    private bool pular = false;

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    void Update()
    {
        gameManager.GetComponent<GameManager>().Andar();
        if(pular == true)
        {
            gameManager.GetComponent<GameManager>().Pular();
            Invoke("SetarPuloFalse", 1f);
        }
    }

    void SetarPuloFalse()
    {
        pular = false;
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == 6)
        {
            gameManager.GetComponent<GameManager>().ExplodirCarro();
        }
        if(collisionInfo.gameObject.layer == 9)
        {
            gameManager.GetComponent<GameManager>().EntrarLoja();
        }
        if(collisionInfo.gameObject.layer == 7 && suprimentoJogado == false)
        {
            suprimentoJogado = true;
            gameManager.GetComponent<GameManager>().JogarSuprimento();
        }
        if(collisionInfo.gameObject.layer == 12)
        {
            gameManager.GetComponent<GameManager>().ColetarSuprimento(collisionInfo.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collisionInfo)
    {
        Debug.Log("Colidindo");
        if(collisionInfo.gameObject.layer == 11 || collisionInfo.gameObject.layer == 7 || collisionInfo.gameObject.layer == 6)
        {
            Debug.Log("Pular");
            pular = true;
        }
    }
}
