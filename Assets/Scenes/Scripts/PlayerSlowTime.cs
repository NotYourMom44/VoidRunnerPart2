using System.Collections;
using UnityEngine;

public class PlayerSlowTime : MonoBehaviour
{
    public bool slowTimeActive = false;
    public float slowDuration = 5f;
    public float slowScale = 0.5f;

    private Coroutine slowRoutine;

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

        Debug.Log("Slow time activated");

        yield return new WaitForSecondsRealtime(slowDuration);

        Time.timeScale = 1f;
        Time.fixedDeltaTime = 0.02f;
        slowTimeActive = false;

        Debug.Log("Slow time ended");
    }
}
