using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerInternalShop : MonoBehaviour
{
    private Transform posicaoNitaner;
    private float speed = 5;
    private float jumpForce = 10;
    private Animator animPersonagem;
    private Transform posicaoPersonagem;
    private Rigidbody2D rigidBodyPersonagem;
    public TextMeshProUGUI textoDialogo;
    private bool andarDireita = false;
    private bool andarEsquerda = true;
    private bool dialogoExibido = false;
    public GameObject porta;

    void Start()
    {
        posicaoNitaner = GameObject.Find("Nitaner").GetComponent<Transform>();
        animPersonagem = GameObject.Find("Personagem").GetComponent<Animator>();
        posicaoPersonagem = GameObject.Find("Personagem").GetComponent<Transform>();
        rigidBodyPersonagem = GameObject.Find("Personagem").GetComponent<Rigidbody2D>();

        porta.SetActive(false);

        AlterarTexto(1);
    }

    void Update()
    {
        AndarNitaner();
    }

    public void AtivarPorta()
    {
        porta.SetActive(true);
    }

    void AndarNitaner()
    {
        if(andarEsquerda == true){
            posicaoNitaner.position = posicaoNitaner.position + (Vector3.left * speed * Time.deltaTime);
            posicaoNitaner.rotation = Quaternion.Euler(0, 180, 0); 
            if(posicaoNitaner.position.x <= -13)
            {
                andarEsquerda = false;
                andarDireita = true;
            }
        }
        else if(andarDireita == true)
        {
            posicaoNitaner.position = posicaoNitaner.position + (Vector3.right * speed * Time.deltaTime);
            posicaoNitaner.rotation = Quaternion.Euler(0, 0, 0);
            if(posicaoNitaner.position.x >= -8)
            {
                andarDireita = false;
                andarEsquerda = true;
            }
        }
    }

    public void Andar()
    {
        if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            posicaoPersonagem.position = posicaoPersonagem.position + (Vector3.right * speed * Time.deltaTime);
            posicaoPersonagem.rotation = Quaternion.Euler(0, 0, 0);
            animPersonagem.SetBool("run", true);
        }
        else if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            posicaoPersonagem.position = posicaoPersonagem.position + (Vector3.left * speed * Time.deltaTime);
            posicaoPersonagem.rotation = Quaternion.Euler(0, 180, 0);
            animPersonagem.SetBool("run", true);
        }
        else
        {
            animPersonagem.SetBool("run", false);
        }
        if(posicaoPersonagem.position.x <= -6.34 && dialogoExibido == false)
        {
            AlterarTexto(2);
            dialogoExibido = true;
        }
    }
    private void RetornarTexto()
    {
        textoDialogo.text = "";
        dialogoExibido = true;
    }
    public void Pular()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigidBodyPersonagem.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animPersonagem.SetBool("jump", true);
            animPersonagem.SetBool("run", false);
        }
        else
        {
            animPersonagem.SetBool("jump", false);
        }
    }
    public void AlterarTexto(int moment)
    {
        Debug.Log("função acessada!");
        switch(moment)
        {
            case 1:
                textoDialogo.text = "O que são esses barulhos?? Parece ter alguém ali...";
                break;
            
            case 2:
                textoDialogo.text = "AHHHHH!! O que é isso??? Que criaturas são essas??";
                break;
            
            case 3:
                textoDialogo.text = "Olha, alguns suprimentos... Serão importantes para conseguirmos sobreviver...";
                break;
            default:
                Debug.Log("Nenhum...");
                break;
        }
    }
    
}
