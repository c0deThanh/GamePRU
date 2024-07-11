using System.Collections;
using UnityEngine;

public class AutoDeactivate : MonoBehaviour
{
    [SerializeField]
    private float deactivateTime = 10f; // Time in seconds before deactivating

    private void OnEnable()
    {
        // Start the coroutine to deactivate after the specified time
        StartCoroutine(DeactivateAfterTime());
    }

    private IEnumerator DeactivateAfterTime()
    {
        // Wait for the specified time
        yield return new WaitForSeconds(deactivateTime);

        // Deactivate the game object
        gameObject.SetActive(false);
    }
}
