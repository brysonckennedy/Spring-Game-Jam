using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    Rigidbody2D rb;
    public float force;

    SpringJoint2D spring;
    public float minDist;

    // Start is called before the first frame update
    void Start()
    {

        transform.DetachChildren();

        spring = transform.parent.GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {

            Launch();
        }
        else if(Input.GetMouseButton(1))
        {
            spring.enabled = false;
        }
        if(spring.enabled && ((Vector2)transform.parent.position - spring.connectedAnchor).magnitude<minDist) 
        {
            spring.enabled = false;
            print(spring.reactionForce);
        }

    }
    void Launch()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up);
        spring.connectedAnchor = hitinfo.point;
        spring.enabled = true;

        

        //rb.position = transform.position;
        //rb.isKinematic = false;
        ///rb.GetComponent<Hook>().checkCol = true; 
        //rb.AddForce(transform.up * force,ForceMode2D.Impulse);

        //rb.gameObject.SetActive(true);
        

    }
    
}
