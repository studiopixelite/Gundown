using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Animator anim;
    public float speed = 6f;
    private FixedJoystick joystick;

    private SpriteRenderer[] spriteRenderer;
    public SpriteRenderer gunRenderer;

    public Transform gunTransform;
    public Transform fireTransform;

    private Slider lifeBar;

    Vector3 movement;
    Animator animator;
    Rigidbody2D playerRigidbody;


    bool s = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        joystick = FindObjectOfType<FixedJoystick>();
        spriteRenderer = GetComponentsInChildren<SpriteRenderer>();
        lifeBar = FindObjectOfType<Slider>();
        //gunRenderer = spriteRenderer[0].GetComponentInChildren<SpriteRenderer>();
       // gunTransform = gunRenderer.GetComponentInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
       // float h = Input.GetAxis("Horizontal");
       // float v = Input.GetAxis("Vertical");

        float h = joystick.Horizontal;
        float v = joystick.Vertical;
        Animating(h, v);
        joystickMove(h, v);
        Flip(h, v);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Pirate")
        {
            lifeBar.value -= 0.5f;
        }
    }

    public void Shoot()
    {
        anim.Play("Shoot");
    }


    void joystickMove(float h, float v)
    {
        /* playerRigidbody = GetComponent<Rigidbody>();

         playerRigidbody.velocity = new Vector3(joystick.Horizontal * 100f, playerRigidbody.velocity.y, joystick.Vertical * 100f);*/
        movement.Set(h, v, 0);
        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Animating(float h, float v)
    {
        if(h != 0f || v != 0f)
        {
            anim.SetBool("IsWalking", true);
            // anim.Play("Moving");
            joystickMove(h, v);
        }

        else
        {
            anim.SetBool("IsWalking", false);
           // anim.Play("Moving");
        }
       
    }


    void Flip(float h, float v)
    {
        bool hpositive = h > 0;
        bool hnegative = h < 0;
       

        if (hpositive)
        {
            spriteRenderer[0].flipX = true;
            gunRenderer.flipX = true;
            if (s == true)
            {
                gunTransform.position = new Vector2(gunTransform.position.x + 1.8f, fireTransform.position.y);
                s = false;
            }
           
            spriteRenderer[1].flipX = true;
            spriteRenderer[2].flipX = true;
            spriteRenderer[3].flipX = true;
        }
        else if (hnegative)
        {
            spriteRenderer[0].flipX = false;
            gunRenderer.flipY = false;
            if (s == false)
            {
                gunTransform.position = new Vector2(gunTransform.position.x - 1.8f, fireTransform.position.y);
                s = true;
            }
            spriteRenderer[1].flipX = false;
            spriteRenderer[2].flipX = false;
            spriteRenderer[3].flipX = false;
        }
        
       
    }

}
