using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
  //  private float speed = 5;
  //  private float jumpForce = 12;
    private bool carroExplodido = false;
    private Transform posicaoPersonagem;
    private Rigidbody2D rigidBodyPersonagem;
    private Animator animPersonagem;
    private GameObject objetoExplosao;
    private SpriteRenderer carro;
    public Sprite carroDestruido;
    public Transform posicaoLata;
    public TextMeshProUGUI textoDialogo;
    private int jogarLata;

 [Header("Ground Check")]
    public Transform groundCheck;               //objeto que serve como referência pra fazer checagem com o chão
    public float footOffest = 0.4f;             //distância até o pé do personagem
    public float groundDistance = 0.1f;         //distância com que faz a checagem com o chão
    public LayerMask groundLayer;               //máscara de camada do chão
    public bool onGround;                       //variável que identifica se jogador está no chão ou não

    [Header("Movement")]
    public float speed = 5;                     //velocidade de movimento do jogador
    public float jumpForce = 12;                //força do pulo
    public float horizontalJumpForce = 6;       //força do pulo na horizontal
    public float horizontal;                    //armazena o input no eixo da horizontal
    public bool jumpPressed;                    //identifica se o botão do pulo foi pressionado ou não
    public int direction = 1;                   //identifica a direção do jogador (1 direita, -1 esquerda)
    public bool canMove = true;                 //identifica se pode se movimentar ou não    

    [Header("Ladder")]
    public float climbSpeed = 3;                //velocidade de subida na escada
    public LayerMask ladderMask;                //máscara de camada da escada
    public float vertical;                      //armazena o input do eixo da vertical
    public bool climbing;                       //identifica se jogador está escalando a escada
    public float checkRadius = 0.3f;            //raio de checagem com a escada

    private bool clearInputs;                   //identifica quando pode fazer limpeza nos inputs
        
  //  private Rigidbody2D rb;                     //armazena rigidbody do jogador
  //  private Animator anim;                      //armazena animator do jogador
   // private Collider2D col;                     //armazena collider do jogador

    void Start()
    {
        posicaoPersonagem = GameObject.Find("Personagem").GetComponent<Transform>();
        rigidBodyPersonagem = GameObject.Find("Personagem").GetComponent<Rigidbody2D>();
        animPersonagem = GameObject.Find("Personagem").GetComponent<Animator>();
        objetoExplosao = GameObject.Find("Explosao");
        carro = GameObject.Find("Carro").GetComponent<SpriteRenderer>();
        posicaoLata = GameObject.Find("Sardinha").GetComponent<Transform>();

        objetoExplosao.SetActive(false);

        textoDialogo.text = "O apocalipse começou! Colete suprimentos para sobreviver em meio ao caos...";
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
    }
    public void Pular()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigidBodyPersonagem.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            
            animPersonagem.SetBool("jump", true);
          //  animPersonagem.SetBool("run", false);
        }
        else
        {
            animPersonagem.SetBool("jump", false);
        }
    }
    public void ExplodirCarro()
    {
        if(carroExplodido == false)
        {
            objetoExplosao.SetActive(true);
            carro.sprite = carroDestruido;
            carroExplodido = true;
            Invoke("FinalizarExplosao", 1f);
        }
    }
    private void FinalizarExplosao()
    {
        objetoExplosao.SetActive(false);
        textoDialogo.text = "Uma loja de conveniência? Hm, parece interessante, devem ter vários suprimentos lá...";
    }

    public void EntrarLoja()
    {
        SceneManager.LoadScene(1);
    }

    public void JogarSuprimento()
    {
        for(int jogarLata = 0; jogarLata <= 20; jogarLata++)
        {
            posicaoLata.position = posicaoLata.position + (Vector3.right * speed * Time.deltaTime);
        }
    }
    public void ColetarSuprimento(GameObject suprimento)
    {
        Destroy(suprimento);        
    }
}
