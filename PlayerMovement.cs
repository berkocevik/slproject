using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    //animasyonlar ve fizikler i�in
    private Rigidbody2D rb2D;
    private Animator myanimator;
    private bool facingright = true;
  
    //de�i�tirilebilir ayarlar
    public float speed = 2.0f;
    public float horizMovement;//= 1 [Veya] -1[Veya] 0
    
    private void Start()
    {
        //oyuncuda bulunan oyun nesnelerinin tan�mlanmas�
        rb2D = GetComponent<Rigidbody2D>();
        myanimator = GetComponent<Animator>();
    }

    
   //fizikler i�in inputlar� kapsar
    private void Update()
    {
        //karakter taraf�ndan verilen y�nleri kontrol et
        horizMovement = Input.GetAxis("Horizontal");
    
    }
    
    
    
    //�al��an fizikleri kapsar
    private void FixedUpdate()
    {
        //karakteri sa� ve sola y�nlendir 
        rb2D.velocity = new Vector2(horizMovement*speed,rb2D.velocity.y);
        Flip(horizMovement);
        myanimator.SetFloat("speed", Mathf.Abs(horizMovement));


    }
    
    //d�n�� i�levi                                                                     //      &&  Ve            ! De�il          ||  Veya
    private void Flip (float horizontal)
    {
        if (horizontal < 0 && facingright || horizontal > 0 && !facingright)          //       += ekleme     ++ 1 ekleme      -= ��karma     /= b�lme      *= �arpma
        {
            facingright = !facingright;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }



    }
}

