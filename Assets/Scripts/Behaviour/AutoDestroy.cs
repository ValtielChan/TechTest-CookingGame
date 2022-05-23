using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    /// <summary>
    /// Time (in seconds) before the object destroy itself
    /// </summary>
    [SerializeField]
    private float destroyTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyAsync());
    }

    /// <summary>
    /// Destroy the object after a define amount of time
    /// </summary>
    /// <returns></returns>
    private IEnumerator DestroyAsync()
    {
        yield return new WaitForSeconds(destroyTime);

        Destroy(gameObject);
    }
}
