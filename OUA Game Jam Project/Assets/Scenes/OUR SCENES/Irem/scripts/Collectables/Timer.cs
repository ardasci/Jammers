using TMPro;
using DG.Tweening;
using UnityEngine;

namespace Time
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private Transform sandGlass;
        [SerializeField] private float _speed = .1f, _height = .5f;
        [SerializeField] private bool isGameStarted;

        public float countdown = 30f;
        private int countdownNumber;

        private void Start()
        {
            isGameStarted = true;
        }

        private void Update()
        {
            SandGlassImgRotator();
            CountdownCalculator();
        }

        private void SandGlassImgRotator()
        {
            sandGlass.DOLocalRotate(new Vector3(0, 0, 360), 2f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
        }

        private void CountdownCalculator()
        {
            if (isGameStarted)
            {
                countdown -= UnityEngine.Time.deltaTime;

                if (countdown <= 5)
                {
                    TextColorUpdater(timeText, Color.red);
                }

                countdownNumber = (int)Mathf.Round(countdown);
                timeText.text = countdownNumber.ToString();
            }

            if (countdown <= 0)
            {
                enabled = false;
            }
        }

        public void CountdownIncreaser()
        {
            TextColorUpdater(timeText, Color.green);
            countdown += 5f;
            //timeText.gameObject.transform.DOScale(Vector3.one * 1.5f, 1f).SetLoops(2, LoopType.Yoyo);
        }

        private void TextColorUpdater(TextMeshProUGUI _text, Color _color)
        {
            _text.DOColor(_color, 1f);
        }

        public void SetDefaultTextColor()
        {
            timeText.DOColor(Color.white, 1f);
        }

        public void DestroyClock(Transform trans, GameObject gameObj)
        {
            trans.DOScale(0f, .3f).SetEase(Ease.InOutBack).OnComplete(() =>
                Destroy(gameObj)
                );
        }
    }
}
