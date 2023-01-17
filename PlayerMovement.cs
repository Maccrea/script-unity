using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //membuat variabel kecepatan, scaleX(Untuk merubah bentuk ketika berjalan), dan lompat
    public float kecepatan, scaleX, lompat;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;   
    }

    void jalan_kiri()
    {
        if(GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName("Idle"))
        {
            GetComponent<Animator> ().SetTrigger("jalan");
        }
        transform.localScale = new Vector3 (-scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate (Vector3.left*kecepatan*Time.fixedDeltaTime, Space.Self);
    }

    void jalan_kanan()
    {
        if(GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName("Idle"))
        {
            GetComponent<Animator> ().SetTrigger("jalan");
        }
        transform.localScale = new Vector3 (scaleX, transform.localScale.y, transform.localScale.z);
        transform.Translate (Vector3.right*kecepatan*Time.fixedDeltaTime, Space.Self);
    }

    void melompat()
    {
        GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, lompat);
        isJumping=true;
    }

    void berhenti()
    {
        GetComponent<Animator> ().SetTrigger ("berhenti");
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
       if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
      {
        melompat();
      }

      if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow))
      {
        berhenti ();
      }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
      if(other.gameObject.CompareTag("Ground"))
      {
        isJumping=false;
      }
    }
}
