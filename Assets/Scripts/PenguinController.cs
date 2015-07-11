using UnityEngine;
using System.Collections;

public class PenguinController : MonoBehaviour 
{
    bool grounded, slide;
    
    public Transform groundCheck;

    float jumpTime;
    [SerializeField]
    float jumpForce = 600f;
    float slideTime;
    [SerializeField]
    float slideDelay = 0.4f;
    Quaternion target;

    public float speed = 2.0f;    
    Animator anim;
    Vector2 origBoxColliderOff;
    Vector2 origBoxCollidSize;
    Vector2 changedBoxCollidOffset;
    Vector2 changedBoxCollidSize;

    Vector2 origCirColliderOff;
    Vector2 changedCirCollidOffset;


    void ChangeColliderTransform()
    {
        changedCirCollidOffset = new Vector2(-0.79f, -0.06f);
        changedBoxCollidOffset = new Vector2(0.02f, -0.10f);
        changedBoxCollidSize = new Vector2(1.151735f, 0.8388399f);
        GetComponent<CircleCollider2D>().offset = changedCirCollidOffset;
        GetComponent<CircleCollider2D>().radius = 0.35f;
        GetComponent<BoxCollider2D>().size = changedBoxCollidSize;
        GetComponent<BoxCollider2D>().offset = changedBoxCollidOffset;
    }
    void RevertColliderTransform()
    {
        GetComponent<CircleCollider2D>().offset = origCirColliderOff;
        GetComponent<BoxCollider2D>().size = origBoxCollidSize;
        GetComponent<BoxCollider2D>().offset = origBoxColliderOff;
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        target = new Quaternion();
    }

    void Awake()
    {
        origBoxColliderOff = GetComponent<BoxCollider2D>().offset;
        origBoxCollidSize = GetComponent<BoxCollider2D>().size;
        origCirColliderOff = GetComponent<CircleCollider2D>().offset;
    }
    void RaycastStuff()
    {
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 
                                                        << LayerMask.NameToLayer("Ground"));
        anim.SetBool("Ground", grounded);
        //Physics2D.IgnoreLayerCollision(8, 10);
    }

    void Movement()
    {
        anim.SetFloat("VerticalSpeed", GetComponent<Rigidbody2D>().velocity.y);
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        slideTime -= Time.deltaTime;
        if (slideTime <= 0f && slide)
        {
            anim.SetTrigger("SlideOff");
            slide = false;
            RevertColliderTransform();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded && !slide)
        {
            anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(transform.up * jumpForce);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)  && grounded && !slide)
        {
            anim.SetTrigger("SlideOn");
            slide = true;
            ChangeColliderTransform();
            slideTime = slideDelay;
        }
    }
    void FixedUpdate()
    {
        Movement();
        RaycastStuff();
    }
}
