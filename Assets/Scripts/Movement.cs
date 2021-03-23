using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    float xInput;
    float yInput;
    Rigidbody2D rb;
    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<Animator>().SetTrigger("hit");

            
        }


        
    }
    private void FixedUpdate()
    {
        Vector3 velocity = new Vector3(xInput * speed, yInput * speed, 0);
        Vector2 newPos = transform.position + velocity * Time.fixedDeltaTime;
        rb.MovePosition(newPos);

        Vector2 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - (Vector2)transform.position;
        float lookAngle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        Vector3 angle = new Vector3(0, 0, lookAngle - 90f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(angle), 0.2f);
    }
}
