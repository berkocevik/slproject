using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //animasyonlar ve fizikler için
    private Rigidbody2D rb2D;
    private Animator myanimator;
    private bool facingright = true;
  
    //deðiþtirilebilir ayarlar
    public float speed = 2.0f;
    public float horizMovement;//= 1 [Veya] -1[Veya] 0
    
    private void Start()
    {
        //oyuncuda bulunan oyun nesnelerinin tanýmlanmasý
        rb2D = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
    }

    
   //fizikler için inputlarý kapsar
    private void Update()
    {
        //karakter tarafýndan verilen yönleri kontrol et
        horizMovement = Input.GetAxis("Horizontal");
    
    }
    
    
    
    //çalýþan fizikleri kapsar
    private void FixedUpdate()
    {
        //karakteri sað ve sola yönlendir 
        rb2D.velocity = new Vector2(horizMovement*speed,rb2D.velocity.y);
        Flip(horizMovement);
        myanimator.SetFloat("speed", Mathf.Abs(horizMovement));


    }
    
    //dönüþ iþlevi                                                                     //      &&  Ve            ! Deðil          ||  Veya
    private void Flip (float horizontal)
    {
        if (horizontal < 0 && facingright || horizontal > 0 && !facingright)          //       += ekleme     ++ 1 ekleme      -= çýkarma     /= bölme      *= çarpma
        {
            facingright = !facingright;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }



    }
}

