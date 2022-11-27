using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    private bool moveCameraRight = false;
    private bool moveCameraLeft = false;
    private float speed = 5;
    private float posicaoPersonagemX;
    private float posicaoCameraX;

    Transform posicaoPersonagem;

    Transform posicaoCoracao1;
    Transform posicaoCoracao2;
    Transform posicaoCoracao3;
    Transform posicaoCoracao4;
    Transform posicaoCoracao5;

    void Start()
    {
        posicaoPersonagem = GameObject.Find("Personagem").GetComponent<Transform>();
        posicaoCoracao1 = GameObject.Find("coracao1").GetComponent<Transform>();
        posicaoCoracao2 = GameObject.Find("coracao2").GetComponent<Transform>();
        posicaoCoracao3 = GameObject.Find("coracao3").GetComponent<Transform>();
        posicaoCoracao4 = GameObject.Find("coracao4").GetComponent<Transform>();
        posicaoCoracao5 = GameObject.Find("coracao5").GetComponent<Transform>();
    }
  
    void Update()
    {
        posicaoPersonagemX = posicaoPersonagem.position.x;
        posicaoCameraX = transform.position.x;
 
        if(posicaoPersonagemX >= posicaoCameraX + 3.87 && posicaoCameraX <= 6.31)
        {
            moveCameraRight = true;
            moveCameraLeft = false;
        }
        else if(posicaoPersonagemX <= posicaoCameraX - 3.87 && posicaoCameraX >= -6)
        {
            moveCameraLeft = true;
            moveCameraRight = false;
        }
        else
        {
            moveCameraRight = false;
            moveCameraLeft = false;
        }
        if(moveCameraRight)
        {
            MovimentarCameraDireita();
        }
        else if(moveCameraLeft)
        {
            MovimentarCameraEsquerda();
        }
    }
    void MovimentarCameraDireita()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao1.position = posicaoCoracao1.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao2.position = posicaoCoracao2.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao3.position = posicaoCoracao3.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao4.position = posicaoCoracao4.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao5.position = posicaoCoracao5.position + (Vector3.right * speed * Time.deltaTime);
        }
    }
    void MovimentarCameraEsquerda()
    {
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao1.position = posicaoCoracao1.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao2.position = posicaoCoracao2.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao3.position = posicaoCoracao3.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao4.position = posicaoCoracao4.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao5.position = posicaoCoracao5.position + (Vector3.left * speed * Time.deltaTime);
        }
    }

}
