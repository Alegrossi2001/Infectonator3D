using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private float bulletSpeed = 20f;
    private int gunDamage = 30;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.MovePosition(transform.position + transform.forward * bulletSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Zombie zombieToAttack = other.gameObject.GetComponent<Zombie>();
        if (zombieToAttack != null)
        {
            zombieToAttack.ReceiveDamage(gunDamage);
            Destroy(gameObject);
        }
    }
}
