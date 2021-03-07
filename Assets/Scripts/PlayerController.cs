using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    Rigidbody rb;
     static int rotationSpeed=-4;
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;
    bool jumpCheck = false;

    bool firstClick = false;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();

        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*  if (!jumpCheck && firstClick)
          {
              if (Input.GetMouseButtonDown(0))
              {
                  rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
              }
             rb.velocity = speed * (rb.velocity.normalized);
          }

          if (!firstClick)
          {
              if (Input.GetMouseButtonDown(0))
              {
                  rb.useGravity = true;
                  rb.velocity = Vector3.forward * speed;
                  rb.velocity = speed * (rb.velocity.normalized);
                  firstClick = true;
              }

          }*/
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(0,0,1);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (Input.GetMouseButtonDown(0) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        transform.Rotate(0, rotationSpeed, 0 * Time.deltaTime); 

    }
    private void OnCollisionEnter(Collision collision)
    {
        jumpCheck = false;
        if (collision.gameObject.name == "Sauce" || collision.gameObject.name == "Inside")
        {
            GameManager.GoOver();
        }else if(collision.gameObject.name == "Finish")
        {
            if (LevelManager.CurrentLevel == PlayerPrefs.GetInt("UnlockedLevel"))
            {
                PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel") + 1);
            }
            GameManager.GoToLevel();
        }



    }

    private void OnCollisionExit(Collision other)
    {
        jumpCheck = true;
    }

    public static void PauceGame(bool pauced)
    {
        if (pauced)
        {
            rotationSpeed = 0;
        }
        else
        {
            rotationSpeed = -4;
        }
    }


}
