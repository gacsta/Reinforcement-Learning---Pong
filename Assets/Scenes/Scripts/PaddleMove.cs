using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PaddleMove : MonoBehaviour
{
    [Range(5, 30)]
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    private KeyCode upKey;
    [SerializeField]
    private KeyCode downKey;

    public Bola bola;

    //COLLISION POSITION VARIABLES
    private Collider2D paddleCollider;
    private float paddleMax;
    private float paddleMin;
    private float angleMin;
    private float angleMax;
    private Vector3 collisionPoint;


    //ANGLE MAP VARIABLES
    private float[] mappedAngle = new float[50];
    private float[] mappedPaddle = new float[50];

    //CLOSEST TO FUNCTION
    //COMPARES POINT TO ARRAY VALUES
    //FINDS REFLECTED ANGLE ACCORDING TO COLLSION POINT


    //IMPLEMENT .UNIFORM METHOD
    private float[] Arange(float start, float max, float step)

        //CHANGING MAX TO TOTAL MAY ALLOW FOR PRECISION CONTROL
        //TOTAL = PRECISION = NUMBER OF MAPPED SLICES ON PADDLE HITBOX
    {
        float[] array = new float[50];

        int count = 0;

        for (float i = start; i < max; i += step)
        {
            array[count] = i;

            count++;
           
        }

        return array;
    }

    //Returns new mapped array
    private (float[], float[]) AngleMapper(float paddleMin, float paddleMax, float angleMin, float angleMax)
    {

        //PRECISION
        float angleTotal = 50;

        float stepPaddle = (paddleMax - paddleMin)/ (angleTotal - 2);
        Debug.Log("STEP Paddle -->" + stepPaddle);

        float stepAngle = (angleMax - angleMin) / angleTotal - 2;
        Debug.Log("STEP Angle -->" + stepAngle);

        float[] paddleArray = Arange(paddleMin, paddleMax, stepPaddle);
        float[] angleArray = Arange(angleMin, angleMax, stepAngle);

        return (paddleArray, angleArray);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionPoint = collision.GetContact(0).point;

        //COMPARE COLLISION POINT TO MAPPED ARRAYS.
  
    }

    private void Start()
    {

        //Keeping track of collision site
        paddleCollider = GetComponent<Collider2D>();
        paddleMax = paddleCollider.bounds.max.y;
        paddleMin = paddleCollider.bounds.min.y;
        angleMax = 130;
        angleMin = -130;
        Debug.Log("maxpaddle -->" + paddleMax + "min paddle -->" + paddleMin);

        //MAPPED ARRAYS ANGLE - PADDLE LENGTH
        mappedPaddle = AngleMapper(paddleMin, paddleMax, angleMin, angleMax).Item1;
        mappedAngle = AngleMapper(paddleMin, paddleMax, angleMin, angleMax).Item2;
        
    }


    private void Update()
    {



        if (Input.GetKey(upKey))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime);

        }
        else if (Input.GetKey(downKey))
        {

            transform.position += new Vector3(0, -speed * Time.deltaTime);

        }
        if (transform.position.y > 4)
        {
            transform.position = new Vector3(transform.position.x, 4);
        }
        else if (transform.position.y < -4)
        {
            transform.position = new Vector3(transform.position.x, -4);

        }



    }
}
