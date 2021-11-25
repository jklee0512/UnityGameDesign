using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI endTextObject;
    public GameObject finishObject;

    public Material originMat;
    public Material boostMat;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private float boost;
    
    private float gameTime = .0f;
    private float textDelay = .0f;
    private string currentText = "";
    private float defaultSpeed = 40.0f;

    Vector3 defaultMove;
    List<Collider> collist = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        boost = 0;

        setTimeText();
        setScoreText();
        endTextObject.text = "";
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            boost = 40.0f;
            RenderSettings.skybox = boostMat;
        } else if (Input.GetKeyUp("space"))
        {
            boost = 0.0f;
            RenderSettings.skybox = originMat;
        }
    }

    void FixedUpdate()
    {
        if (0<=gameTime && gameTime <= 2.5)
        {
            init();
            showGameReady();
        }
        else if (gameTime > 2.5)
        {
            run();
        }

        if (textDelay > 0)
        {
            endTextObject.text = currentText;
        }
        else
        {
            endTextObject.text = "";
        }

        setTimeText();
        gameTime += Time.deltaTime;
        textDelay -= Time.deltaTime;

    }

    void setTimeText()
    {
        timeText.text = "Time: " + ((int)gameTime).ToString() + "sec";
    }

    void setScoreText()
    {
        countText.text = "Score: " + count.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            collist.Add(other);
            count += 1;
            setScoreText();
        } 
        else if (other.gameObject.CompareTag("Quiz"))
        {
            string qz = other.name;
            if (qz == "Quiz1")
            {
                showText("Q1.Go to zero. \n1)sin90 2)cos90 3)tan90", 10f);
            }
            else if (qz == "Quiz2")
            {
                showText("count 10? \nfor i=0; i¡Â10; i++", 10);
            }
            else if (qz == "Quiz3")
            {
                showText("i = 8;\n" +
                    "while i < 11\n" +
                    "   i += 2\n" +
                    "i = ?", 10);
            }
        }
        else if (other.gameObject.CompareTag("Answer"))
        {
            string ans = other.name;
            if (ans == "Answer1_1" || ans == "Answer1_3")
            {
                showText("Wrong", 4f);
                startAgain();
            }
            else if (ans == "Answer1_2")
            {
                showText("Correct!", 4f);
            }
            if (ans == "Answer2_1")
            {
                showText("Wrong", 4f);
                defaultSpeed -= 10;
            }
            else if (ans == "Answer2_2")
            {
                showText("Correct!", 4f);
            }

            if (ans == "Answer3_2" || ans == "Answer3_3")
            {
                showText("Wrong", 4f);
                defaultSpeed -= 10;
            }
            else if (ans == "Answer3_1")
            {
                showText("Correct!", 4f);
                SceneManager.LoadScene(1);
            }
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            endTextObject.text = "Congratulation!";
            //SceneManager.LoadScene(1);
        } 
    }


    void init()
    {
        setTimeText();
        setScoreText();
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        foreach (Collider c in collist)
        {
            c.gameObject.SetActive(true);
        }
        collist.Clear();
        count = 0;
        endTextObject.text = "";
    }

    void startAgain()
    {
        gameTime = 0;
    }

    void run()
    {
        Vector3 leftRight = new Vector3(movementX, 0.0f, 0.0f);
        defaultMove = new Vector3(0.0f, 0.0f, defaultSpeed + boost);
        rb.velocity = (leftRight * speed + defaultMove);
    }

    void showGameReady()
    {
        if(gameTime <= 2)
        {
            endTextObject.text = (2 - (int)gameTime).ToString();
        } else if (gameTime < 2.3)
        {
            endTextObject.text = "Go!";
        } else
        {
            endTextObject.text = "";
        }
    }

    void showText(string t, float time)
    {
        currentText = t;
        textDelay = time;
    }
}
