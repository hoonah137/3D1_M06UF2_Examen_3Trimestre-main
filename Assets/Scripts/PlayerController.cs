using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable para la velocidad de movimiento
    public float playerSpeed = 5.5f;
    //Variable para la fuerza del salto
    public float jumpForce = 3f;

    //Variable para acceder al SpriteRenderer
    public SpriteRenderer spriteRenderer;
    //Variable para acceder al RigidBody2D
    private Rigidbody2D rBody;
    //Variable para acceder al GroundSensor
    private GroundSensor sensor;

    //Variable para almacenar el input de movimiento
    float horizontal;

    public Animator anim; 

    GameManager gameManager;
    SFXManager sfxManager;

    void Awake()
    {
        //Asignamos la variables del SpriteRender con el componente que tiene este objeto
        //Asignamos la variable del Rigidbody2D con el componente que tiene este objeto
        rBody = GetComponent<Rigidbody2D>();
        //Buscamos un Objeto por su nombre, cojemos el Componente GroundSensor de este objeto y lo asignamos a la variable
        sensor = GameObject.Find("GroundSensor").GetComponent<GroundSensor>();
        //Buscamos el objeto del GameManager y SFXManager lo asignamos a las variables
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        anim = GetComponent<Animator>();


        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameOver == false)
        {
            horizontal = Input.GetAxis("Horizontal");

            if(horizontal < 0)
            {
                
                anim.SetBool("IsRunning", true);
            }
            else if(horizontal > 0)
            {
                
                anim.SetBool("IsRunning", true);
            }

            else 
             { 
            anim.SetBool("IsRunning", false);

             }




            if(Input.GetButtonDown("Jump") && sensor.isGrounded)
            {
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("IsJumping", true);
            }
        }    
        
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(horizontal * playerSpeed, rBody.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Coin")
        {
            gameManager.AddCoin();
            sfxManager.CoinSound();
            Destroy(collider.gameObject);
        }
    }
}
