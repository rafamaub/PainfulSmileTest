using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    [SerializeField] private float maxHp = 100;
    float actualHp;
    [SerializeField] private GameObject effectOnDie;
    [SerializeField] private MainEvent onDieEvent;

    [Header("Sprite Damage Feedback")]
    [SerializeField] private SpriteRenderer flag;
    [SerializeField] private List<Sprite> destroyedFlags;
    [SerializeField] private SpriteRenderer ship;
    [SerializeField] private List<Sprite> destroyedShip;

    [Header("Health Bar")]
    [SerializeField] private Image healthBar;

    private void Awake()
    {
        actualHp = maxHp;

        UpdateSprites();
        UpdateUI();
    }



    public void Damage(float damagePoints)
    {
        actualHp -= damagePoints;

        UpdateSprites();
        UpdateUI();

        if(actualHp <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Instantiate(effectOnDie, transform.position, Quaternion.identity);
        if(onDieEvent)
        {
            onDieEvent.Occured();
        }
        Destroy(gameObject);
    }
    void UpdateUI()
    {
        float percentage = actualHp / maxHp;
        healthBar.fillAmount = percentage;
        healthBar.color = Color.Lerp(Color.red, Color.green, percentage);
    }
    void UpdateSprites()
    {
        float percentage = actualHp / maxHp;

        if(percentage > 0.7f)
        {
            flag.sprite = destroyedFlags[0];
            ship.sprite = destroyedShip[0];
        }
        else if(percentage > 0.4f)
        {
            flag.sprite = destroyedFlags[1];
            ship.sprite = destroyedShip[1];
        }
        else
        {
            flag.sprite = destroyedFlags[2];
            ship.sprite = destroyedShip[2];
        }
    }
}
