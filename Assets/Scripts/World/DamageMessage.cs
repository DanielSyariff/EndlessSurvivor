using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class DamageMessage : MonoBehaviour
{
    [SerializeField] float timeToLeave = 1.5f;
    float timer;

    private void OnEnable()
    {
        this.transform.localScale = Vector3.zero;
        timer = timeToLeave;
        this.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            gameObject.SetActive(false);
        }
    }
}
