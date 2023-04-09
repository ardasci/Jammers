using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class Stashable : MonoBehaviour
{
    public void CollectStashable(Transform stashParent, float yLocalPosition, Action onCompleteCollect)
    {
        var completionRadius = .5f;
        var speed = 150f;
        var targetPos = stashParent.position + Vector3.up * yLocalPosition;
        Tweener tweener = transform.DOMove(targetPos, speed).SetSpeedBased(true);
        tweener.OnUpdate(delegate () {
            transform.LookAt(stashParent, Vector3.up);

            // if the tween isn't close enough to the target, set the end position to the target again
            if (Vector3.Distance(transform.position, targetPos) > completionRadius)
            {
                targetPos = stashParent.position + Vector3.up * yLocalPosition;
                tweener.ChangeEndValue(targetPos, true);
            }

        }).OnComplete(() => {
            transform.parent = stashParent;
            transform.localPosition = Vector3.up * yLocalPosition;
            transform.localRotation = Quaternion.Euler(0, 90f, 90f);
            onCompleteCollect?.Invoke();
        });
        //StartCoroutine(CollectCoroutine(stashParent, yLocalPosition, onCompleteCollect));
    }
  
  
}
