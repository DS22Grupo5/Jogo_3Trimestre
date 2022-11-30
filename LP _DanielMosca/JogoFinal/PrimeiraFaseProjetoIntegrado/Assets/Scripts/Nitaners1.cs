using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nitaners1 : MonoBehaviour
{
    public Sprite spriteNPC1;
    public AudioSource audioNitanerAtingido;
    private SpriteRenderer spriteNitaner;
    public Transform posicaoNitaner;
    public Animator anim;
    public Rigidbody2D rigidBodyNitaner;
    private bool andarNitaner = false;

    private bool direita = true;
    private bool esquerda = false;
    private bool pular = true;


    void Start()
    {
        spriteNitaner = GameObject.Find("Nitaner2").GetComponent<SpriteRenderer>();
        anim = GameObject.Find("Nitaner2").GetComponent<Animator>();
        audioNitanerAtingido = GameObject.Find("Nitaner1").GetComponent<AudioSource>();
        rigidBodyNitaner = GameObject.Find("Nitaner2").GetComponent<Rigidbody2D>();
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
            andarNitaner = true;
            audioNitanerAtingido.Play();
            anim.SetBool("nitaner1Atingido", true);
        }
    }
    void AndarNitaner()
    {
        posicaoNitaner.rotation = Quaternion.Euler(0, 0, 0);
        posicaoNitaner.position = posicaoNitaner.position + (Vector3.right * 5 * Time.deltaTime);
        if(posicaoNitaner.position.x >= 0 && pular)
        {
            rigidBodyNitaner.AddForce(new Vector2(0f, 2), ForceMode2D.Impulse);
            Invoke("SetarPuloFalse", 0.1f);
        }
    }
    void NitanerParado()
    {   
        if(direita)
        {
            posicaoNitaner.position = posicaoNitaner.position + (Vector3.right * 2 * Time.deltaTime);
            if(posicaoNitaner.position.x >= 0)
            {
                esquerda = true;
                direita = false;
            }
            posicaoNitaner.rotation = Quaternion.Euler(0,0,0);
        }
        else if(esquerda)
        {
            posicaoNitaner.position = posicaoNitaner.position + (Vector3.left * 2 * Time.deltaTime);
            if(posicaoNitaner.position.x <= -3)
            {
                esquerda = false;
                direita = true;
            }
            posicaoNitaner.rotation = Quaternion.Euler(0,180,0);
        }
    }
    void SetarPuloFalse()
    {
        pular = false;
    }
}
