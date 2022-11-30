using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterInternalLab : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animPersonagem;
    Rigidbody2D rigidBodyPersonagem;
    Transform posicaoPersonagem;
    float speed = 5;
    float jumpForce = 5;
    bool jogarMinigame = false;
    GameObject textoTeclaH;

    void Start()
    {
        animPersonagem = GameObject.Find("Personagem").GetComponent<Animator>();
        posicaoPersonagem = GameObject.Find("Personagem").GetComponent<Transform>();
        rigidBodyPersonagem = GameObject.Find("Personagem").GetComponent<Rigidbody2D>();
        textoTeclaH = GameObject.Find("textoTeclaH");
        textoTeclaH.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Andar();
        Pular();

        if(posicaoPersonagem.position.x < 0.7 && posicaoPersonagem.position.x > 0.4)
        {
            jogarMinigame = true;
        }
        if(jogarMinigame)
        {
            textoTeclaH.SetActive(true);

            if(Input.GetKey(KeyCode.H))
            {
                jogarMinigame = false;
                SceneManager.LoadScene(3);
            }
        }
        
    }
    void Pular()
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
    void Andar()
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
}
