using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerSpeedBoost : MonoBehaviour
{
    public float boostAmount = 20f;
    public float boostDuration = 5f;
    public TMP_Text speedStatusText;

    private Ballroll ballroll;
    private Coroutine boostRoutine;

    void Start()
    {
        ballroll = GetComponent<Ballroll>();

        if (speedStatusText != null)
        {
            speedStatusText.text = "Speed: Ready";
        }
    }

    public void ActivateSpeedBoost()
    {
        if (boostRoutine != null)
        {
            StopCoroutine(boostRoutine);
            ballroll.speed -= boostAmount;
        }

        boostRoutine = StartCoroutine(SpeedBoostRoutine());
    }

    private IEnumerator SpeedBoostRoutine()
    {
        ballroll.speed += boostAmount;
        Debug.Log("Speed boost activated");

        float timer = boostDuration;

        while (timer > 0)
        {
            if (speedStatusText != null)
            {
                speedStatusText.text = "Speed: " + timer.ToString("F1");
            }

            timer -= Time.deltaTime;
            yield return null;
        }

        ballroll.speed -= boostAmount;

        if (speedStatusText != null)
        {
            speedStatusText.text = "Speed: Ready";
        }

        Debug.Log("Speed boost ended");
    }
}