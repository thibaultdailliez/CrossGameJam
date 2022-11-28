using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    bool alive = true;

    Vector3 moveDirection;
    [SerializeField]
    TextMesh txtScore;
    [SerializeField] GameObject destructionFx;
    [SerializeField] GameObject fastFx;
    [SerializeField] GameObject Fx;
    [SerializeField] GameObject Normal;
    [SerializeField] GameObject Boost;
    [SerializeField] Camera Camera;
    CameraFollow camerafollow;




    public float speed = 5;
    public Rigidbody rb;
    [SerializeField]
    FixedJoystick joystick;

    [SerializeField]
    float moveSpeed = 0;

    [SerializeField]
    float speedMax = 0;

    [SerializeField]
    float acceleration = 0.1f;

    [SerializeField]
    float decceleration = 0.1f;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    Vector3 forwardMove;

    int score = 0;
    int nbOb = 0;
    bool FxSpeed = false;
    float timeLeft = 1.0f;

    
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        camerafollow = FindObjectOfType<CameraFollow>();
    }


    private void Start()
    {
        forwardMove = transform.forward * speed * Time.fixedDeltaTime;
    }

    private void Update()
    {

        if (joystick.Direction.magnitude > 0)
        {
            // Vecteur de direction de déplacement
            moveDirection = new Vector3(joystick.Direction.x, 0, 0).normalized;
            moveSpeed = Mathf.Lerp(moveSpeed, speedMax, acceleration) * joystick.Direction.magnitude;

            //Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;

           
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, decceleration);
            

        }
        
        if (nbOb == 10)
        {
           AddSpeed();
        }

        if (FxSpeed == true)
        {
            Debug.Log("TRUE");
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Debug.Log("TimerEnd");
                Fx.gameObject.SetActive(false);
                Boost.gameObject.SetActive(false);
                Normal.gameObject.SetActive(true);
                camerafollow.Normal();
                //camera.transform.position = new Vector3(0, 0, camera.transform.position.z - 5);
                FxSpeed = false;
                timeLeft = 1.0f;

            }
            
        }


        //if(transform.position.y < -5) {
        //    Die();
        //}
    }

    private void FixedUpdate()
    {

        //if (!alive) return;

        rb.velocity = moveDirection * moveSpeed;
        rb.MovePosition(rb.position + forwardMove );
    }

    public void Die (){
        
        enabled = false;
        alive = false;
        //restart
        Invoke("Restart", 2);
        speed = 10;
        nbOb = 0;
        
    }
    void Restart ()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        enabled = true;
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            
            GameObject explo = Instantiate(destructionFx);
            print("2");
            explo.transform.position = transform.position;

            Boost.gameObject.SetActive(false);
            Normal.gameObject.SetActive(false);
            gameObject.SetActive(false);

            


            Die();
        }
    }

    public void AddSpeed()
    {

        camerafollow.Speed();
        FxSpeed = true;
        Fx.gameObject.SetActive(true);
        Boost.gameObject.SetActive(true);
        Normal.gameObject.SetActive(false);
        //camera.transform.position = new Vector3(0, 0, camera.transform.position.z + 10) ; 


        nbOb = 0;
        speed = speed + 2;

        Debug.Log("SpeedBoost" + speed);
        Debug.Log("nbOb--" + nbOb);
        
        
    }


    
    public void AddScore()
    {
        nbOb++;
        score++;
        txtScore.text = score.ToString();
        
    }
    
}
