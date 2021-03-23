using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleInfoDisplay : MonoBehaviour
{

    private Text text;
    [SerializeField]
    private Transform paddleTransform;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
       
    }
    // Update is called once per frame
    void Update()
    {
        text.text = $"{paddleTransform.position.y}";
        
           
    }
}
