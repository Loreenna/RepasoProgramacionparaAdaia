using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeRepaso : MonoBehaviour
{
    private Rigidbody2D rBody;

    private Animator anim;

    private float horizontal;

    //velocidad personaje
    [SerializeField]private float speed = 3;
    //fuerza salto
    [SerializeField] private float jumpForce = 10;

    [SerializeField]bool isGrounded;

    [SerializeField]Transform groundSensor;

    [SerializeField]float sensorRadius;

    [SerializeField]LayerMask sensorLayer;

    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    //se ejecuta una vez por frame, depende de los FPS del juego
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("Correr", true);
        }
        else if (horizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("Correr", true);
        }
        else if(horizontal == 0)
        {
            anim.SetBool("Correr", false);
        }

        //crea un circulo en la posicion de un game object. Cuuando el circulo entre en contacto con la capa, sera true
        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, sensorLayer);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetBool("Saltar", true);
        }
    }

    //siempre se ejecuta la misma cantidad de veces por segundo, puede que sean 50 o 60, y con este se hacen los movimientos por fisicas
    void FixedUpdate()
    {
        //si en el para,etro ponemos 0, caera lento
        rBody.velocity = new Vector2(horizontal * speed, rBody.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 3)
        {
            anim.SetBool("Saltar", false);
        }
    }

    void OntriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Star")
        {
            RepasodelGameManager.Instance.LoadLevel(1);
        }
        else if(other.gameObject.tag == "moneda")
        {
            RepasodelGameManager.Instance.AddCoin(other.gameObject);
        }
    }
    //Hasta aqui arriba, el personaje ya se mueve

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundSensor.position, sensorRadius);
    }
    //Hasta aqui, el personaje se mueve y salta.
}
