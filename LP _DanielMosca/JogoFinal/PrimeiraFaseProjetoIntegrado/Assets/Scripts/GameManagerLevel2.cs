using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLevel2 : MonoBehaviour
{
    Transform posicaoPersonagem;
    public Sprite spriteAtirar;
    public Sprite spriteInicial;
    public AudioSource audioPulo;
    private float jumpForce = 2;
    public int direcao;
    SpriteRenderer spriteRendererPersonagem;
    Animator animPersonagem;
    Rigidbody2D rigidBodyPersonagem;

    void Start()
    {
        posicaoPersonagem = GameObject.Find("Personagem").GetComponent<Transform>();
        spriteRendererPersonagem = GameObject.Find("Personagem").GetComponent<SpriteRenderer>();
        animPersonagem = GameObject.Find("Personagem").GetComponent<Animator>();
        rigidBodyPersonagem = GameObject.Find("Personagem").GetComponent<Rigidbody2D>();
        audioPulo = GameObject.Find("GameManager").GetComponent<AudioSource>();

    }
    
    public void Andar()
    {
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            posicaoPersonagem.position = posicaoPersonagem.position + (Vector3.right * 5 * Time.deltaTime);
            posicaoPersonagem.rotation = Quaternion.Euler(0, 0, 0);
            direcao = 1;
            animPersonagem.SetBool("run", true);
        }
        else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.LeftArrow))
        {
            posicaoPersonagem.position = posicaoPersonagem.position + (Vector3.left * 5 * Time.deltaTime);
            posicaoPersonagem.rotation = Quaternion.Euler(0, 180, 0);
            direcao = -1;
            animPersonagem.SetBool("run", true);
        }
        else
        {
            animPersonagem.SetBool("run", false);
        }
    }
    public void Pular()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rigidBodyPersonagem.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            audioPulo.Play();
        }
    }
    public void VerificarBorda()
    {
        if(posicaoPersonagem.position.x >= 47)
        {
            SceneManager.LoadScene(11);
        }
    }
}
