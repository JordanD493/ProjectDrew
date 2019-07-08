using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Touch_Input : MonoBehaviour {

    [SerializeField]
    private Text Message;

    [SerializeField]
    private Text FPSMessage;

    public float deltaTime;

    Rigidbody rb;

    [SerializeField]
    private float Acceleration;

    [SerializeField]
    private GameObject Mutan;

    private int InstantiateNumber = 1;

    private void Start()
    {

     rb = GetComponent<Rigidbody>();
#if UNITY_EDITOR
        Message.text = "On Windows";
#endif

#if UNITY_IOS
        Message.text = "On IOS";
#endif

    }

#if UNITY_EDITOR
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("m"))
        {
            //rb.AddForce(new Vector3(0, 0, 1) * Acceleration);

             Instantiate(Mutan, new Vector3(Random.Range(-5, 1), 1.24f, Random.Range(-4.8f, 4.8f)), Quaternion.identity);

            InstantiateNumber += 1;

          

        }

        Message.text = InstantiateNumber.ToString();
        
    }

    //private void Update()
    //{
    //    deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    //    float fps = 1.0f / deltaTime;
    //    FPSMessage.text = Mathf.Ceil(fps).ToString();

    //}
#endif

#if UNITY_IOS
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                //Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                //RaycastHit raycastHit;
                //if (Physics.Raycast(raycast, out raycastHit))
                //{
                    //Message.text = "Something Got Hit";

                    //if (raycastHit.collider.tag == "Player")
                    //{
                        Instantiate(Mutan, new Vector3(Random.Range(-5, 1), 1.24f, Random.Range(-4.8f, 4.8f)), Quaternion.identity);
                        InstantiateNumber += 1;
                    //}

                }
            }
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        FPSMessage.text = Mathf.Ceil(fps).ToString();


        Message.text = InstantiateNumber.ToString();
    }

        
    }
#endif

    //private void OnMouseDown()
    //{
    //    Message.text = "Got Touched";

    //    rb.AddForce(new Vector3(0, 0, 1) * Acceleration);

    //}


