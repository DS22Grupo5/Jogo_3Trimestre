using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
    private int vidas = 5;
    public Sprite spriteCoracaoVazio;
    public AudioSource audioPerderVida;
    GameObject folha;
    GameObject gameOver;

    void Start()
    {
        folha = GameObject.Find("Folha");
        gameOver = GameObject.Find("gameOver");
        audioPerderVida = GameObject.Find("Background").GetComponent<AudioSource>();

        gameOver.SetActive(false);

        folha.SetActive(false);
    }
    void Update()
    {
        GameObject.Find("GameManager").GetComponent<GameManagerLevel2>().Andar();
        GameObject.Find("GameManager").GetComponent<GameManagerLevel2>().Pular();
        GameObject.Find("GameManager").GetComponent<GameManagerLevel2>().VerificarBorda();

        switch (vidas)
        {
            case 5:
                Debug.Log("vida cheia");
                break;
            case 4:
                GameObject.Find("coracao4").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                break;

            case 3:
                GameObject.Find("coracao4").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao3").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                break;

            case 2:
                GameObject.Find("coracao4").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao3").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao2").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                break;

            case 1:
                GameObject.Find("coracao4").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao3").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao2").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao1").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                break;

            case 0:
                GameObject.Find("coracao4").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao3").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao2").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao1").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                break;

            default:
                GameObject.Find("coracao4").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao3").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao2").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao1").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;
                GameObject.Find("coracao").GetComponent<SpriteRenderer>().sprite = spriteCoracaoVazio;

                gameOver.SetActive(true);
                Invoke("RecarregarCena", 2f);
                break;
        }
        
    }

    void RecarregarCena(){
        SceneManager.LoadScene(10);
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == 7)
        {
            folha.SetActive(true);
            Destroy(GameObject.Find("folhapadrao"));
            Invoke("DestruirCarta", 5f);
        }
        if(collisionInfo.gameObject.layer == 8)
        {
            vidas = vidas - 1;
            audioPerderVida.Play();
            StartCoroutine(DelayAction(1));
        }
    }
    void DestruirCarta()
    {
        GameObject.Find("Main Camera").GetComponent<MoveCamLevel2>().cartaDestruida = true;
        Destroy(folha);
    }
     
    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
 
    }
}
