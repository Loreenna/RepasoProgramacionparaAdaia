using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PrayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;
    public Animator anim;
    public PlayableDirector director;
    public float speed = 5.5f;
    private float horizontal;
    public bool isGrounded;
    private Transform prayerTransform;  
    public float jumpForce = 10f;

    float dirX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    private void FixedUpdate() 
    {
        rb.velocity = new Vector2 (horizontal * speed, rb.velocity.y);
    }

        

    // Start is called before the first frame update
    void Start()
    {
        prayerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        Debug.Log(dirX);

        horizontal = Input.GetAxisRaw("Horizontal");     
        
        //Rotacion del personaje
        if(dirX ==-1)
        {
            anim.SetBool("Correr", true);
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(dirX == 1)
        {
            anim.SetBool("Correr", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            anim.SetBool("Correr", false);
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal == 0)
        {
            anim.SetBool("Correr", false);
        }
        else
        {
            anim.SetBool("Correr", true);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
       {
           rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           anim.SetBool("Saltar", true);
       }
    }

        //prayerTransform.position += new Vector3 (horizontal * speed * Time.deltaTime, 0, 0);
        //prayerTransform.position += new Vector3 (1, 0, 0) * horizontal * speed * Time.deltaTime;
        //prayerTransform.Translate(Vector3.right * horizontal * speed * Time.deltaTime, Space.World);
        


    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Cinematica")
        {
            director.Play();
        }

        if (other.gameObject.layer == 6)
        {
            Destroy(other.gameObject);
            GameManager.Instance.RestarVidas();
            //StartCoroutine(GameObject.Find("Main Camera").GetComponent<Shake>().CamaraShake(1f, 0.05f));
        }

        if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            GameManager.Instance.MeCojoAAdaia();
        }
    }
}