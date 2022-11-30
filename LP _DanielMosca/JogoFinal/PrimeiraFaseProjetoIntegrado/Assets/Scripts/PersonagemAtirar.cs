using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonagemAtirar : MonoBehaviour
{

    public float shootSpeed;
    public float shootTimer;

    public Sprite spriteAtirar;

    public AudioSource audioTiro;

    private bool isShooting;
    public int direcao;

    public Transform shootPos;
    public Animator animPersonagem;
    public GameObject bullet;
    public Sprite spriteHUD5;
    public Sprite spriteHUD4;
    public Sprite spriteHUD3;
    public Sprite spriteHUD2;
    public Sprite spriteHUD1;

    public GameObject textoRecarregar;

    public SpriteRenderer alterarSpriteHUD;
    private int tiros = 4;

    void Start()
    {
        isShooting = false;
        animPersonagem = GameObject.Find("Personagem").GetComponent<Animator>();
        alterarSpriteHUD = GameObject.Find("barraMunicao").GetComponent<SpriteRenderer>();
        textoRecarregar = GameObject.Find("Recarregar");
        audioTiro = GameObject.Find("Personagem").GetComponent<AudioSource>();
        textoRecarregar.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Space) && !isShooting && tiros > 0)
        {
            animPersonagem.SetBool("shoot", true);
            audioTiro.Play();
            switch(tiros)
            {
                case 4:
                    tiros = 3;
                    break;
                case 3:
                    tiros = 2;
                    break;
                case 2:
                    tiros = 1;
                    break;
                case 1:
                    tiros = 0;
                    break;
                
            }
            if(tiros <= 0)
            {
                textoRecarregar.SetActive(true);
            }

            Invoke("AtivarCoroutine", 0.5f);
        }
        if(Input.GetKey(KeyCode.R))
        {
            tiros = 4;
            textoRecarregar.SetActive(false);
        }
        OrganizarHUD();
    }
    void OrganizarHUD()
    {
        switch(tiros)
        {
            case 4:
                alterarSpriteHUD.sprite = spriteHUD5;
                break;

            case 3:
                alterarSpriteHUD.sprite = spriteHUD4;
                break;

            case 2:
                alterarSpriteHUD.sprite = spriteHUD3;
                break;

            case 1:
                alterarSpriteHUD.sprite = spriteHUD2;
                break;

            case 0:
                alterarSpriteHUD.sprite = spriteHUD1;
                break;
        }
    }
    void AtivarCoroutine(){
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        int direction()
        {
            if(transform.localScale.x < 0f)
            {
                return -1;
            }
            else{
                return +1;
            }
        }
        
        isShooting = true;
        GameObject newBullet = Instantiate(bullet, shootPos.position, Quaternion.identity);
        direcao = GameObject.Find("GameManager").GetComponent<GameManagerLevel2>().direcao;
        newBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(shootSpeed * direcao * Time.fixedDeltaTime, 0f);
        newBullet.transform.localScale = new Vector2(newBullet.transform.localScale.x * direcao, newBullet.transform.localScale.y);

        yield return new WaitForSeconds(shootTimer);
        isShooting = false;
        animPersonagem.SetBool("shoot", false);
    }
}
