using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    [SerializeField] private float explosionDamage = 30f;
    [SerializeField] private ShipHealth myHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            ShipHealth hp = collision.transform.root.GetComponent<ShipHealth>();
            if (hp)
            {

                hp.Damage(explosionDamage);
            }

            if (myHealth)
            {
                myHealth.Die();
            }
        }
       

    }
}
