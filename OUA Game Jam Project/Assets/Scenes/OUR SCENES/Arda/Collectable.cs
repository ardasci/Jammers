using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public Stashable stashablePrefab;


    public Stashable Collect()
    {
        var stashable = Instantiate(stashablePrefab, null);
        stashable.transform.position = transform.position + Vector3.up * 0.2f;
        //stashable.transform.SetPositionAndRotation(transform.position + Vector3.up * 0.2f, Quaternion.Euler(-90f, 90f, 90f));
        GetComponent<Collider>().enabled = false;
        Destroy(gameObject, UnityEngine.Time.deltaTime);
        return stashable;
    }
}
