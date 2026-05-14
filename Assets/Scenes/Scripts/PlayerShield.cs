using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerShield : MonoBehaviour
{
    public bool shieldActive = false;
    public float shieldDuration = 5f;
    public GameObject shieldVisual;

    private Coroutine shieldRoutine;

    public TMP_Text shieldStatusText;

    public void ActivateShield()
    {
        if (shieldRoutine != null)
        {
            StopCoroutine(shieldRoutine);
        }

        shieldRoutine = StartCoroutine(ShieldTimer());
    }

    private IEnumerator ShieldTimer()
    {
        shieldActive = true;

        if (shieldVisual != null)
            shieldVisual.SetActive(true);

        float timer = shieldDuration;

        while (timer > 0)
        {
            if (shieldStatusText != null)
                shieldStatusText.text = "Shield: " + timer.ToString("F1");

            timer -= Time.deltaTime;
            yield return null;
        }

        shieldActive = false;

        if (shieldVisual != null)
            shieldVisual.SetActive(false);

        if (shieldStatusText != null)
            shieldStatusText.text = "Shield: Ready";
    }
}
