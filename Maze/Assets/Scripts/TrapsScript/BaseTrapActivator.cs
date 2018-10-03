using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrapActivator : MonoBehaviour {

    [SerializeField]
    private IntGameObjectEvent timerResponse;
    [SerializeField]
    private FloatIntGameObjectEvent addTimer;
    [SerializeField]
    private float timeActivation = -1;
    [SerializeField]
    private bool colisionActivation;
    [SerializeField]
    private bool triggerActivation;
    [SerializeField]
    private BaseTrap trapToActivate;

    private void OnEnable()
    {
        timerResponse.AddListener(TryActivateTrap);
    }

    private void OnDisable()
    {
        timerResponse.RemoveListener(TryActivateTrap);
    }

    private void Start()
    {
        if(timeActivation != -1)
        {
            addTimer.Invoke(timeActivation, 0, gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerActivation && collision.CompareTag("Enemy"))
            trapToActivate.ActivateTrap();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (colisionActivation && collision.gameObject.CompareTag("Enemy"))
            trapToActivate.ActivateTrap();
    }

    private void TryActivateTrap(int number, GameObject invokingGameObject)
    {
        if (invokingGameObject == gameObject)
            trapToActivate.ActivateTrap();
    }
}
