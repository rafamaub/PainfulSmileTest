using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private CannonBall ballPrefab;
    [SerializeField] private GameObject fireEffect;
    [Header("Shoot Stats")]
    bool canShoot = true;
    [SerializeField] private float frontReloadTime = 1f;
    bool canFrontShoot = true;
    [SerializeField] private float sideReloadTime = 2f;
    bool canSideShoot = true;
    [HideInInspector] public float reloadTimer;

    [Header("Cannon Positions")]
    [SerializeField] private Transform frontCannon;
    [SerializeField] private Transform[] sideCannons;

    [HideInInspector] public GameplayHud gameplayHud;


    private void Update()
    {
        if(reloadTimer > 0)
        {
            reloadTimer -= Time.deltaTime;
            if(reloadTimer <= 0)
            {
                FinishReloading();
            }
        }
    }
    public void ShootFrontCannon()
    {
        if(canShoot)
        {
            CannonBall ball = Instantiate(ballPrefab, frontCannon.transform.position, frontCannon.rotation);
            Instantiate(fireEffect, frontCannon.transform.position, frontCannon.rotation).transform.SetParent(frontCannon);
            Reload(frontReloadTime);
        }

    }

    public void ShootSideCannon()
    {
        if(canShoot)
        {
            foreach (Transform cannon in sideCannons)
            {
                CannonBall ball = Instantiate(ballPrefab, cannon.transform.position, cannon.rotation);
                Instantiate(fireEffect, cannon.transform.position, cannon.rotation).transform.SetParent(cannon);
            }

            Reload(sideReloadTime);
        }

    }

    void Reload(float reloadTime)
    {
        canShoot = false;
        reloadTimer = reloadTime;
        if(gameplayHud)
        {
            gameplayHud.UpdateReloading(this, reloadTime);
        }
        //Invoke("FinishReloading", reloadTime);
    }

    void FinishReloading()
    {
        reloadTimer = 0;
        if (gameplayHud)
        {
            gameplayHud.FinishReload();
        }
        canShoot = true;
    }
}
