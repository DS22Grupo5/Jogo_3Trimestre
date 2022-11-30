using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitaners : MonoBehaviour
{
    public Sprite spriteNPC1;
    private SpriteRenderer spriteNitaner;
    public AudioSource audioNitanerAtingido;
    public Transform posicaoNitaner;
    public Animator anim;
    private bool andarNitaner = false;
    private bool direita = true;
    private bool esquerda = false;

    void Start()
    {
        spriteNitaner = GameObject.Find("Nitaner1").GetComponent<SpriteRenderer>();
        audioNitanerAtingido = GameObject.Find("Nitaner1").GetComponent<AudioSource>();
        anim = GameObject.Find("Nitaner1").GetComponent<Animator>();
    }

    void Update()
    {
        if(andarNitaner)
        {
            AndarNitaner();
        }
        else
        {
            NitanerParado();
        }
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == 6)
        {
            anim.SetBool("nitanerAtingido", true);
            audioNitanerAtingido.Play();
            spriteNitaner.sprite = spriteNPC1;
            andarNitaner = true;
        }
    }
    void AndarNitaner()
    {
        posicaoNitaner.rotation = Quaternion.Euler(0, 0, 0);
        posicaoNitaner.position = posicaoNitaner.position + (Vector3.right * 5 * Time.deltaTime);
    }
    void NitanerParado()
    {
        if(direita)
        {
            posicaoNitaner.position = posicaoNitaner.position + (Vector3.right * 5 * Time.deltaTime);
            if(posicaoNitaner.position.x >= 6.5)
            {
                esquerda = true;
                direita = false;
            }
            posicaoNitaner.rotation = Quaternion.Euler(0,0,0);
        }
        else if(esquerda)
        {
            posicaoNitaner.position = posicaoNitaner.position + (Vector3.left * 5 * Time.deltaTime);
            if(posicaoNitaner.position.x <= 2.2)
            {
                esquerda = false;
                direita = true;
            }
            posicaoNitaner.rotation = Quaternion.Euler(0,180,0);

        }
    }
}
