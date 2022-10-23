using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRb;
    [SerializeField] private float ballSpeed;
    [SerializeField] private float ballDamage = 10f;

    private void Awake()
    {
        LaunchBall();
        Destroy(gameObject, 4f);
    }

    public void LaunchBall()
    {
        myRb.AddForce(transform.up * ballSpeed * 10f, ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShipHealth hp = collision.transform.root.GetComponent<ShipHealth>();
        if(hp)
        {
            hp.Damage(ballDamage);
        }

        Destroy(gameObject);
    }
}
