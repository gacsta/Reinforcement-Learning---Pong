using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Placar : MonoBehaviour
{
    // Start is called before the first frame update

    private int placar1 = 0;
    private int placar2 = 0;
    private Text placar;
    

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Transform bolaTransform;

    public Bola bola;
   
    void Start()
    {

        placar = GetComponent<Text>();
        placar.text = $"{placar1}";

    }

    // Update is called once per frame
    void Update()
    {

        if ((bolaTransform.position.x < -11.31) & (player.CompareTag("player1")))
        {
            placar1 += 1;
            placar.text = $"{placar1}";

            bolaTransform.position = new Vector2(0, 0);
            bola.dirAngle = Random.Range(1, 360) * Random.Range(-1, 1) * Mathf.Deg2Rad;
            bola.speed = bola.RandomExcept(8, 17, 0);


        }
        else if ((bolaTransform.position.x > 11.31) & (player.CompareTag("player2")))
        {
            placar2 += 1;
            placar.text = $"{placar2}";

            bolaTransform.position = new Vector2(0, 0);
            bola.dirAngle = Random.Range(1, 360) * Random.Range(-1, 1) * Mathf.Deg2Rad;
            bola.speed = bola.RandomExcept(8, 17, 0);
        }
        
        

    }
}
