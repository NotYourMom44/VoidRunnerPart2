using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerSlowTime : MonoBehaviour
{
    public bool slowTimeActive = false;
    public float slowDuration = 5f;
    public float slowScale = 0.5f;

    private Coroutine slowRoutine;

    public TMP_Text slowTimeStatusText;

    public void ActivateSlowTime()
    {
        if (slowRoutine != null)
        {
            StopCoroutine(slowRoutine);
        }

        slowRoutine = StartCoroutine(SlowTimeRoutine());
    }

    private IEnumerator SlowTimeRoutine()
    {
        slowTimeActive = true;
        Time.timeScale = slowScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        float timer = slowDuration;

        while (timer > 0)
        {
            if (slowTimeStatusText != null)
                slowTimeStatusText.text = "Slow Time: " + timer.ToString("F1");

            timer -= Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        slowTimeActive = false;

        if (slowTimeStatusText != null)
            slowTimeStatusText.text = "Slow Time: Ready";
    }
}
