using DG.Tweening;
using UnityEngine;

namespace Collectables
{
    public class TimeUpgrader : MonoBehaviour
    {
        private void Start()
        {
            ClockYoyoMovement();
        }

        private void ClockYoyoMovement()
        {
            transform.DOScale(Vector3.one / 1.5f, 1f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }
}
