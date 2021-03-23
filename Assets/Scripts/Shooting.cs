using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float shootForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject GO = Instantiate(bullet, spawnPoint.position, Quaternion.identity);
            GO.GetComponent<Rigidbody2D>().AddForce(spawnPoint.up * shootForce*0.0001f, ForceMode2D.Impulse);
            GO.transform.rotation = spawnPoint.rotation;
        }
    }
}
