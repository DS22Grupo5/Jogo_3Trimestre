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

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        spriteCoracao1 = GameObject.Find("coracao1").GetComponent<SpriteRenderer>();
        spriteCoracao2 = GameObject.Find("coracao2").GetComponent<SpriteRenderer>();
        spriteCoracao3 = GameObject.Find("coracao3").GetComponent<SpriteRenderer>();
        spriteCoracao4 = GameObject.Find("coracao4").GetComponent<SpriteRenderer>();
        spriteCoracao5 = GameObject.Find("coracao5").GetComponent<SpriteRenderer>();

    }

    void Update()
    {
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

            case 14:
                Destroy(collisionInfo.gameObject);
                suprimentos++;
                PlayerPrefs.SetString("sardinha", "true");
                gameManager.GetComponent<GameManagerInternalShop>().AlterarTexto(3);
                break;
            
            case 15:
                Destroy(collisionInfo.gameObject);
                suprimentosEstragados++;
                PlayerPrefs.SetString("banana estragada", "true");
                gameManager.GetComponent<GameManagerInternalShop>().AlterarTexto(3);
                break;

            case 16:
                Destroy(collisionInfo.gameObject);
                suprimentos++;
                gameManager.GetComponent<GameManagerInternalShop>().AlterarTexto(3);
                break;

            case 17:
                Destroy(collisionInfo.gameObject);
                suprimentos++;
                gameManager.GetComponent<GameManagerInternalShop>().AlterarTexto(3);
                break;

            case 18:
                Destroy(collisionInfo.gameObject);
                suprimentos++;
                gameManager.GetComponent<GameManagerInternalShop>().AlterarTexto(3);
                break;
            
            case 19:
                Destroy(collisionInfo.gameObject);
                suprimentos++;
                gameManager.GetComponent<GameManagerInternalShop>().AlterarTexto(3);
                break;

            case 20:
                Destroy(collisionInfo.gameObject);
                suprimentos++;
                gameManager.GetComponent<GameManagerInternalShop>().AlterarTexto(3);
                break;

            case 21:
                Destroy(collisionInfo.gameObject);
                suprimentosEstragados++;
                gameManager.GetComponent<GameManagerInternalShop>().AlterarTexto(3);
                break;

            default:
                break;

        }
    }
}
