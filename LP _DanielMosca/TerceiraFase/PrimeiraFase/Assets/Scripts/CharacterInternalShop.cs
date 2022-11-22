using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInternalShop : MonoBehaviour
{
    private GameObject gameManager;
    private bool pular = false;
    public int suprimentos = 0;
    public int suprimentosEstragados = 0;
    private int vida = 5;
    public bool suprimentosColetados = false;
    public List<string> listaSuprimentos = new List<string>(20);
    public Sprite spriteCoracaoVazio;
    SpriteRenderer spriteCoracao1;
    SpriteRenderer spriteCoracao2;
    SpriteRenderer spriteCoracao3;
    SpriteRenderer spriteCoracao4;
    SpriteRenderer spriteCoracao5;

     
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

    private bool clearInputs;                   //identifica quando pode fazer limpeza nos inputs                    //variável que identifica se jogador está no chão ou não

    void Start()
    {

        //rb = GetComponent<Rigidbody2D>();       //referencia o rigidbody do jogador na variável
       // anim = GetComponent<Animator>();        //referencia o animator do jogador na variável
       // col = GetComponent<Collider2D>();       //referencia o collider do jogador na variável
        
        gameManager = GameObject.Find("GameManager");
        spriteCoracao1 = GameObject.Find("coracao1").GetComponent<SpriteRenderer>();
        spriteCoracao2 = GameObject.Find("coracao2").GetComponent<SpriteRenderer>();
        spriteCoracao3 = GameObject.Find("coracao3").GetComponent<SpriteRenderer>();
        spriteCoracao4 = GameObject.Find("coracao4").GetComponent<SpriteRenderer>();
        spriteCoracao5 = GameObject.Find("coracao5").GetComponent<SpriteRenderer>();

    }

    void Update()
    {
         CheckInputs();
        PhysicsCheck();      

        gameManager.GetComponent<GameManagerInternalShop>().Andar();
        if(pular == true)
        {
            gameManager.GetComponent<GameManagerInternalShop>().Pular();
            Invoke("SetarPuloFalse", 1f);
        }
        if(suprimentos == 6)
        {
            gameManager.GetComponent<GameManagerInternalShop>().AtivarPorta();
        }

    }

    void SetarPuloFalse()
    {
        pular = false;
    }

    void OnTriggerStay2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == 11 || collisionInfo.gameObject.layer == 7 || collisionInfo.gameObject.layer == 6)
        {
            pular = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {

        switch(collisionInfo.gameObject.layer)
        {
            case 8:
                vida = vida - 1;
                switch(vida)
                {
                    case 4:
                        spriteCoracao5.sprite = spriteCoracaoVazio;
                        break;

                    case 3:
                        spriteCoracao4.sprite = spriteCoracaoVazio;
                        break;
                
                    case 2:
                        spriteCoracao3.sprite = spriteCoracaoVazio;
                        break;

                    case 1:
                        spriteCoracao2.sprite = spriteCoracaoVazio;
                        break;

                    case 0:
                        spriteCoracao1.sprite = spriteCoracaoVazio;
                        SceneManager.LoadScene(3);
                        break;

                    default:
                        break;
                }
                break;

            case 9:
                SceneManager.LoadScene(2);
                break;

           

            default:
                break;

        }
    }

    void CheckInputs()
    {

        //Função que serve para checar os inputs

        //Limpa os inputs, faz o botão de pulo voltar para o valor padrão de falso
        if (clearInputs)
        {
            jumpPressed = false;
            clearInputs = false;
        }

       
        //Armazena se pulo foi pressionado
        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");

       
        //Armazena eixo da horizontal
        horizontal = Input.GetAxis("Horizontal");

        //Armazena eixo da vertical
        vertical = Input.GetAxis("Vertical");

    }

     void PhysicsCheck()
    {

        //Função que faz checagem com o chão

        //Assume que nochão está como falso
        onGround = false;      

        /*Dispara dois Raycasts, um na parte debaixo da esquerda e outro na parte debaixo da direita
         * Dessa forma tem uma precisão grande de quando jogador está no chão
         * O raycast é disparado numa função própria que retorna um raycasthit2D
         */

        RaycastHit2D leftFoot = Raycast(groundCheck.position + new Vector3(-footOffest, 0), Vector2.down, groundDistance, groundLayer);
        RaycastHit2D rightFoot = Raycast(groundCheck.position + new Vector3(footOffest, 0), Vector2.down, groundDistance, groundLayer);
    
        //Se uma das checagens for verdadeira, passa nochão para verdadeiro
        if(leftFoot || rightFoot)
        {
            onGround = true;
        }       

        //Atualiza parâmetro OnGround no Animator de acordo com o valor de OnGround
       // anim.SetBool("OnGround", onGround);
       

    }

    public RaycastHit2D Raycast(Vector2 origin, Vector2 rayDirection, float length, LayerMask mask, bool drawRay = true)
    {
        //Função que retorna um RaycastHit2D

        //Envia o raycast e salva o resultado na variável hit
        RaycastHit2D hit = Physics2D.Raycast(origin, rayDirection, length, mask);


        //Se quisermos mostrar o raycast em cena
        if (drawRay)
        {
            Color color = hit ? Color.red : Color.green;
            
            Debug.DrawRay(origin, rayDirection * length, color);
        }
        //determina a cor baseado se o raycast se colidiu ou não

        //Retorna o resultado do hit
        return hit;
    }
}