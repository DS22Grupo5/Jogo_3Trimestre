using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamLevel2 : MonoBehaviour
{
    Transform posicaoCamera;
    Transform posicaoPersonagem;
    Transform posicaoCarta;
    Transform posicaoCoracao1;
    Transform posicaoCoracao2;
    Transform posicaoCoracao3;
    Transform posicaoCoracao4;
    Transform posicaoCoracao5;
    Transform posicaoBarraMun;
    Transform posicaoGameOver;


    private float speed = 8;
    private bool moverCameraEsquerda = true;
    private bool moverCameraDireita = true;
    private bool moverCameraBaixo = true;
    public bool cartaDestruida = false;

    void Start()
    {
        posicaoCamera = GetComponent<Transform>();
        posicaoPersonagem = GameObject.Find("Personagem").GetComponent<Transform>();
        posicaoCarta = GameObject.Find("Folha").GetComponent<Transform>();
        posicaoCoracao1 = GameObject.Find("coracao").GetComponent<Transform>();
        posicaoCoracao2 = GameObject.Find("coracao1").GetComponent<Transform>();
        posicaoCoracao3 = GameObject.Find("coracao2").GetComponent<Transform>();
        posicaoCoracao4 = GameObject.Find("coracao3").GetComponent<Transform>();
        posicaoCoracao5 = GameObject.Find("coracao4").GetComponent<Transform>();
        posicaoBarraMun = GameObject.Find("barraMunicao").GetComponent<Transform>();
        posicaoGameOver = GameObject.Find("gameOver").GetComponent<Transform>();

    }

    void Update()
    {
        if(posicaoCamera.position.x < 0){
            moverCameraEsquerda = false;
        }
        else{
            moverCameraEsquerda = true;
        }
        if(posicaoCamera.position.x > 40){
            moverCameraDireita = false;
        }
        if(posicaoCamera.position.y < -5){
            moverCameraBaixo = false;
        }
        if(posicaoPersonagem.position.x < posicaoCamera.position.x - 5 && moverCameraEsquerda)
        {
            posicaoCamera.position = posicaoCamera.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao1.position = posicaoCoracao1.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao2.position = posicaoCoracao2.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao3.position = posicaoCoracao3.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao4.position = posicaoCoracao4.position + (Vector3.left * speed * Time.deltaTime);
            posicaoCoracao5.position = posicaoCoracao5.position + (Vector3.left * speed * Time.deltaTime);
            posicaoBarraMun.position = posicaoBarraMun.position + (Vector3.left * speed * Time.deltaTime);
            posicaoGameOver.position = posicaoGameOver.position + (Vector3.left * speed * Time.deltaTime);

            if(cartaDestruida == false){
                posicaoCarta.position = posicaoCarta.position + (Vector3.left * speed * Time.deltaTime);
            }
        }
        else if(posicaoPersonagem.position.x > posicaoCamera.position.x + 5 && moverCameraDireita)
        {
            posicaoCamera.position = posicaoCamera.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao1.position = posicaoCoracao1.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao2.position = posicaoCoracao2.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao3.position = posicaoCoracao3.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao4.position = posicaoCoracao4.position + (Vector3.right * speed * Time.deltaTime);
            posicaoCoracao5.position = posicaoCoracao5.position + (Vector3.right * speed * Time.deltaTime);
            posicaoBarraMun.position = posicaoBarraMun.position + (Vector3.right * speed * Time.deltaTime);
            posicaoGameOver.position = posicaoGameOver.position + (Vector3.right * speed * Time.deltaTime);

            if(cartaDestruida == false){
                posicaoCarta.position = posicaoCarta.position + (Vector3.right * speed * Time.deltaTime);
            }
        }
        if(posicaoPersonagem.position.y < -6 && moverCameraBaixo){
            posicaoCamera.position = posicaoCamera.position + (Vector3.down * speed * Time.deltaTime);
            posicaoCoracao1.position = posicaoCoracao1.position + (Vector3.down * speed * Time.deltaTime);
            posicaoCoracao2.position = posicaoCoracao2.position + (Vector3.down * speed * Time.deltaTime);
            posicaoCoracao3.position = posicaoCoracao3.position + (Vector3.down * speed * Time.deltaTime);
            posicaoCoracao4.position = posicaoCoracao4.position + (Vector3.down * speed * Time.deltaTime);
            posicaoCoracao5.position = posicaoCoracao5.position + (Vector3.down * speed * Time.deltaTime);
            posicaoBarraMun.position = posicaoBarraMun.position + (Vector3.down * speed * Time.deltaTime);
            posicaoGameOver.position = posicaoGameOver.position + (Vector3.down * speed * Time.deltaTime);

            if(cartaDestruida == false){
                posicaoCarta.position = posicaoCarta.position + (Vector3.down * speed * Time.deltaTime);
            }

        }
    }
}
