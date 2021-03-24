using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{

    public float force;

    SpringJoint2D spring;
    public float minDist;
    
    Transform graphics;
    Vector2 defaultPos;
    Quaternion defaultRot;
    // Start is called before the first frame update
    void Start()
    {
        graphics = transform.GetChild(0);
        defaultPos = graphics.localPosition;
        defaultRot = graphics.localRotation;
        spring = transform.parent.GetComponent<SpringJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {

            Launch();
        }
        
        if(spring.enabled && ((Vector2)transform.parent.position - spring.connectedAnchor).magnitude<minDist || Input.GetMouseButton(1)) 
        {
            spring.enabled = false;
            graphics.SetParent(transform);
            graphics.localPosition = defaultPos;
            graphics.localRotation = defaultRot;
            
        }

    }
    void Launch()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.up);
        if(hitinfo.collider != null)
        {
            spring.connectedAnchor = hitinfo.point;
            transform.DetachChildren();
            graphics.position = hitinfo.point;
            spring.enabled = true;
        }
        


    }
    
}
