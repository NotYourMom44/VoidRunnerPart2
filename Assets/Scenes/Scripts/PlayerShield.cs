using System.Collections;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    public bool shieldActive = false;
    public float shieldDuration = 5f;
    public GameObject shieldVisual;

    private Coroutine shieldRoutine;

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
        {
            shieldVisual.SetActive(true);
        }

        Debug.Log("Shield activated");

        yield return new WaitForSeconds(shieldDuration);

        shieldActive = false;

        if (shieldVisual != null)
        {
            shieldVisual.SetActive(false);
        }

        Debug.Log("Shield ended");
    }
}
