using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerBigBoss : MonoBehaviour
{
    public int vidaBigBoss;
    public Sprite spriteFrancis;
    public SpriteRenderer spriteRendererBoss;
    // Start is called before the first frame update
    void Start()
    {
        vidaBigBoss = 20;
        spriteRendererBoss = GameObject.Find("BossNitaner").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vidaBigBoss <= 0)
        {
            spriteRendererBoss.sprite = spriteFrancis;
            Invoke("ChamarVideoFinal", 2f);
        } 
    }

    void ChamarVideoFinal()
    {
        SceneManager.LoadScene(12);
    }
    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        if(collisionInfo.gameObject.layer == 3)
        {
            vidaBigBoss = vidaBigBoss - 1;
        }
    }
}
