using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{

    internal Rigidbody2D rb;
    internal bool movementActivated;
    //bool hasAlreadyJumped = false; - unity says this is assigned but never used? temporarily commented it out to get rid of it in the console - MB 

    [SerializeField]
    internal float maxSpeed = 3.0f;

    [SerializeField]
    float acceleration = 9.0f;

    //private bool allDetached = false; - unity says this is assigned but never used? temporarily commented it out to get rid of it in the console - MB 
    private int numberofTotalObjects = 0;
    int counter = 0;


    [SerializeField]
    float jumpStrength;

    [SerializeField]
    float RampSpeed;

    [SerializeField]
    float SlowDownSpeed;

    Animator anim;

    [SerializeField]
    private Animator pageAnim;

    [SerializeField]
    private float rotationSpeed;

    private MaterialColor Mat;
    
    // Use this for initialization
    void Start()
    {
        movementActivated = false;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Mat = FindObjectOfType<MaterialColor>();
    }

    // Use this for physics related code
    void FixedUpdate()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        numberofTotalObjects = allObjects.Length;


        Scene scene = SceneManager.GetActiveScene();
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if (touch.phase == TouchPhase.Began)
        //    {
        //        Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //        RaycastHit raycastHit;
        //        if (Physics.Raycast(raycast, out raycastHit))
        //        {


        //            if (raycastHit.collider.tag == "Player")
        //            {
        //                movementActivated = true;
        //                anim.SetBool("isWalking", true);

        //            }

        //        }
        //    }

        //}

        if (movementActivated)
        {
            if (rb.velocity.magnitude <= maxSpeed)
            {
                rb.AddForce(new Vector2(1, 0) * acceleration);

            }
        }

        if (Input.GetKeyDown("m"))
        {
            movementActivated = true;
            acceleration = -9; 
            anim.SetBool("isWalking", true);
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ramp")
        {
            maxSpeed = RampSpeed;
        }

        else if (collision.gameObject.tag == "Slow")
        {
            acceleration = 0;
            maxSpeed = SlowDownSpeed;
            print("Slow");

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "JumpObject")
        {
            rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);

            print("Jumped");
        }

        //if (collision.gameObject.tag == "EndGoal")
        //{
        //    print("Reached End");           
        //    Mat.IsFading = true;
        //    this.gameObject.SetActive(false);
        //}
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("isJumping", false);
    }

    private void OnMouseDown()
    {
        movementActivated = true;
        acceleration = -9;
        anim.SetBool("isWalking", true);
    }

   public void RotatePlayerAround()
   {
        transform.rotation = new Quaternion(0, -180, 0, 0);

        acceleration = -(acceleration + 4);
        rb.AddForce(new Vector2(1, 0) * acceleration);

        anim.SetBool("isWalking", true);

    }

   public void RotatePlayeToOrigialPosition()
   {
        movementActivated = false;

        transform.rotation = new Quaternion(0, 0, 0, 0);

        anim.SetBool("isWalking", false);

        
    }

}
    

