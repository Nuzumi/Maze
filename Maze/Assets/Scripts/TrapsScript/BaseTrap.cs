using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrap : MonoBehaviour {

    public List<BaseTrapComponent> trapComponents;

    protected List<GameObject> enemiesInTrapRange;

    private void Start()
    {
        enemiesInTrapRange = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !enemiesInTrapRange.Contains(collision.gameObject))
            enemiesInTrapRange.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            enemiesInTrapRange.Remove(collision.gameObject);
    }

    public void ActivateTrap()
    {
        foreach (var tc in trapComponents)
            tc.ActivateTrapComponent(enemiesInTrapRange);

        Destroy(gameObject);
    }
}
