using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float objectTotal = 0;

    public Text countText;
    public Text winText;

    private int count;
    private Rigidbody2D rb2d;



    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= objectTotal)
        {
            winText.text = "You Win!";
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {           
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
            
                     
        }
    }




}
