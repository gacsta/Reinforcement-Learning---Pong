using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour

{
  
    public float dirAngle;
    private Vector3 dir;
    public float speed;
    private Vector3 reflectedDir;
    private Vector3 contactPoint;
    
  

    public int RandomExcept(int min, int max, int except)
    {
        //Improve this function by allowing multiple intervals exceptions
        int random = Random.Range(min, max);
        if (random >= except) random = (random + 1) % max;
      
        return random;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        dir = new Vector3(speed * Mathf.Cos(dirAngle) * Time.deltaTime, speed * Mathf.Sin(dirAngle) * Time.deltaTime);
        Vector3 wallAngle = collision.GetContact(0).normal;
        reflectedDir = Vector3.Reflect(dir, wallAngle);

        dirAngle = Mathf.Atan2(reflectedDir.y, reflectedDir.x);

    }

    private void Start()
    {
        dirAngle = Random.Range(1, 360) * Random.Range(-1, 1) * Mathf.Deg2Rad;    
        speed = RandomExcept(8, 17, 0);
    
}
   
    // Update is called once per frame
    void Update()
    {


        if ((transform.position.y > 4.742)  || (transform.position.y < -4.742))
        {
            //dir = 360 * Mathf.Deg2Rad - dir;
            dirAngle *= -1;
            transform.position += new Vector3(speed * Mathf.Cos(dirAngle) * Time.deltaTime, speed * Mathf.Sin(dirAngle) * Time.deltaTime);

           
        }
        else
        {
            transform.position += new Vector3(speed * Mathf.Cos(dirAngle) * Time.deltaTime, speed * Mathf.Sin(dirAngle) * Time.deltaTime);
        }
    }
}
