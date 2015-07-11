using UnityEngine;
using System.Collections;

public class EskimoAI : MonoBehaviour 
{
    bool grounded, interacted;

    public Transform groundCheck;
    public Transform triggerCheck;

    bool makeJump = false;
    [SerializeField]
    float jumpForce = 600f;

    public float speed = 2.0f;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    void RaycastStuff()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1
                                                        << LayerMask.NameToLayer("Ground"));
        interacted = Physics2D.Linecast(transform.position, triggerCheck.position, 1
                                                        << LayerMask.NameToLayer("Ground"));
        if (interacted) makeJump = true;
        anim.SetBool("Ground", grounded);
        //Physics2D.IgnoreLayerCollision(8, 10);
    }

    void Movement()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void Update()
    {
        if (makeJump)
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
            makeJump = false;
        }
    }

    void FixedUpdate()
    {
        Movement();
        RaycastStuff();
    }
}
