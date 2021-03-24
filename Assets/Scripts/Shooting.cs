using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform spawnPoint;
    public float shootForce;
    Transform bulletCollection;
    Transform usedBullets;
    // Update is called once per frame
    private void Start()
    {
        bulletCollection = new GameObject("Bullets").transform;
        usedBullets = new GameObject("Used Bullets").transform;
        for(int i = 0; i<20;i++)
        {
            Instantiate(bulletPrefab, bulletCollection);
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(bulletCollection.childCount>0)
            {
                Transform bullet = bulletCollection.GetChild(0);
                bullet.GetComponent<Rigidbody2D>().AddForce(spawnPoint.up * shootForce * 0.0001f, ForceMode2D.Impulse);
                bullet.rotation = spawnPoint.rotation;
                bullet.SetParent(usedBullets);
                bullet.position = spawnPoint.position;
            }
            else
            {
                Transform bullet = Instantiate(bulletPrefab, usedBullets).transform;
                bullet.position = spawnPoint.position;
                bullet.GetComponent<Rigidbody2D>().AddForce(spawnPoint.up * shootForce * 0.0001f, ForceMode2D.Impulse);
                bullet.rotation = spawnPoint.rotation;
            }
            
            
        }
    }
}
