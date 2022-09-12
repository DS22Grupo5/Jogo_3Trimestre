using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D rig;
    public Animator anim;

    public Sprite new_sprite;
    public Sprite sprite_vazio;
    public Sprite sprite_texto_sair;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GameObject.Find("Dialogo").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement*Time.deltaTime*Speed;

         //DIREITA
        if(Input.GetAxis("Horizontal") > 0f)
        {
            anim.SetBool("charles_run", true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        //ESQUERDA
         if(Input.GetAxis("Horizontal") < 0f)
        {
            anim.SetBool("charles_run", true);
             transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        //PARADO
         if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("charles_run", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("charles_jump", true);
        }

        else
        {
            anim.SetBool("charles_jump", false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 9)
        {
            spriteRenderer.sprite = new_sprite;

        }

        if(collision.gameObject.layer == 10)
        {
            spriteRenderer.sprite = sprite_vazio;
        }
        if(collision.gameObject.layer == 11)
        {
            spriteRenderer.sprite = sprite_texto_sair;
        }
    }
}
