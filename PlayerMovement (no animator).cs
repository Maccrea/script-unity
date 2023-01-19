using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //membuat variabel kecepatan, scaleX(Untuk merubah bentuk ketika berjalan), dan lompat
    public float kecepatan, scaleX, lompat;
    private bool isJumping;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;  
        rb = GetComponent<Rigidbody2D>(); 
    }

    void jalan_kiri()
    {
        transform.localScale = new Vector3 (-scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate (Vector3.left*kecepatan*Time.fixedDeltaTime, Space.Self);
    }

    void jalan_kanan()
    {
        transform.localScale = new Vector3 (scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate (Vector3.right*kecepatan*Time.fixedDeltaTime, Space.Self);
    }

    void melompat()
    {
        GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, lompat);
        isJumping=true;
    }


    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey (KeyCode.LeftArrow))
      {
        jalan_kiri();
      }
      else if (Input.GetKey (KeyCode.RightArrow))
      {
        jalan_kanan();
      }
       if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y == 0)
      {
        melompat();
      }
    }

  
}