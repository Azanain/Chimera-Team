using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelActionsBall : MonoBehaviour
{
    [SerializeField] private GameObject panelPickUpBall;
    [SerializeField] private GameObject panelPutDownBall;
    [SerializeField] private GameObject barThrowball;
    [SerializeField] private Image imageProgressBar;

    [SerializeField] private float maxPowerPushBall;
    [SerializeField] private float maxTimerPushBall;
    
    private bool isCharging;

    private void Awake()
    {
        EventManager.ActivationPanelBallActionsEvent += ActivationPanelBallActions;
        EventManager.Mouse2PressedEvent += PushingBall;
    }
    /// <summary>
    /// панель поднятия мяча
    /// </summary>
    /// <param name="isPicked"></param>
    private void ActivationPanelBallActions(bool isPicked)
    {
        panelPickUpBall.SetActive(isPicked);
    }
    /// <summary>
    /// уравление корутиной заряжаня броска мяча
    /// </summary>
    /// <param name="isPressed"></param>
    private void PushingBall(bool isPressed)
    {
        if (isPressed && Arm.HaveBall)
        {
            ActivationSliderPushingBall(isPressed);
        }
        else if (!isPressed && Arm.HaveBall)
        {
            ActivationSliderPushingBall(isPressed);
        }
    }
    /// <summary>
    /// появление слайдера при зажатии мыши2
    /// </summary>
    /// <param name="isMouse2Pressed"></param>
    private void ActivationSliderPushingBall(bool charging)
    {
        if (charging && !isCharging)
        {
            isCharging = true;
            barThrowball.SetActive(charging);
            StartCoroutine(BallPushingCharge());
        }
        else if (!charging)
        {
            isCharging = false;
            barThrowball.SetActive(charging);
        }
    }
    /// <summary>
    ///  корутина заряжания броска мяча
    /// </summary>
    /// <returns></returns>
    private IEnumerator BallPushingCharge()
    {
        float power = 0;
        float plusPower = maxPowerPushBall / 100;
        imageProgressBar.fillAmount = 0;
        while (isCharging)
        {
            imageProgressBar.fillAmount = power / maxPowerPushBall;
            yield return new WaitForSeconds(.1f);
            power += plusPower;
        }
        if (!isCharging)
        {
            if (power < maxPowerPushBall)
            {
                imageProgressBar.fillAmount = power / maxPowerPushBall;
            }
            else if (power >= maxPowerPushBall)
            {
                imageProgressBar.fillAmount = 1;
                power = maxPowerPushBall;
            }
            EventManager.CheckPowerPushBall(power);
            StopCoroutine(BallPushingCharge());
        }
    }
    private void OnDestroy()
    {
        EventManager.ActivationPanelBallActionsEvent -= ActivationPanelBallActions;
        EventManager.Mouse2PressedEvent -= PushingBall;
    }
}
