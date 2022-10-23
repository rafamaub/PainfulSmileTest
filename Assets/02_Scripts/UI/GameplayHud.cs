using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameplayHud : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI pointsText;

    [Header("Images")]
    [SerializeField] private Image[] blackLoadingCannons;
    bool updatingReload;
    float maxTime;

    [HideInInspector] public GameController controller;
    CannonController playerCannons;

    public void UpdateReloading(CannonController player, float targetTime)
    {
        playerCannons = player;
        maxTime = targetTime;
        updatingReload = true;
    }

    public void FinishReload()
    {
        updatingReload = false;
        foreach (Image blacks in blackLoadingCannons)
        {
            blacks.fillAmount = 0f;

        }
    }
    void Update()
    {
        timeText.text = TimeSpan.FromSeconds(controller.gameSessionTime).ToString("mm\\:ss");
        pointsText.text = controller.points.ToString();

        if(updatingReload)
        {
            float percentage = playerCannons.reloadTimer / maxTime;
            foreach(Image blacks in blackLoadingCannons)
            {
                blacks.fillAmount = percentage;
                
            }
        }
    }
}
