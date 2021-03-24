using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform bullets;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
        transform.SetParent(bullets);
        transform.localPosition = Vector2.zero;
        gameObject.SetActive(true);
        
    }
    private void OnEnable()
    {
        print("enabled");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
