using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float speed = 5;
    private float jumpForce = 10;
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
            animPersonagem.SetBool("run", false);
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
        SceneManager.LoadScene(6);
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
