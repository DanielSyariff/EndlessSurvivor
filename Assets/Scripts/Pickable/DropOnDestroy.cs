using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropOnDestroy : MonoBehaviour
{
    [SerializeField] GameObject healthPickUp;

    [SerializeField] [Range(0f, 1f)] float chanceToDrop;

    private void OnDestroy()
    {
        if (Random.value < chanceToDrop)
        {
            Transform t = Instantiate(healthPickUp).transform;

            t.position = transform.position;
        }
    }
}
