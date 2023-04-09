using TMPro;
using DG.Tweening;
using UnityEngine;

namespace Time
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] public TextMeshProUGUI timeText;
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
            CountdownCalculator();
        }

        public void SandGlassImgScaler()
        {
            //sandGlass.DOLocalRotate(new Vector3(0, 0, 360), 1f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
            sandGlass.DOPunchScale(Vector3.one * .2f, 1f, 10, 1f);
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

        public void CountdownController(Color _color, float value)
        {
            TextColorUpdater(timeText, _color);
            countdown += value;
            //timeText.gameObject.transform.DOScale(Vector3.one * 1.5f, 1f).SetLoops(2, LoopType.Yoyo);
        }

        public void TextColorUpdater(TextMeshProUGUI _text, Color _color)
        {
            _text.DOColor(_color, 1f);
        }

        public void SetDefaultTextColor()
        {
            timeText.DOColor(Color.white, 1f);
        }

        public void DestroyClock(Transform trans, GameObject gameObj)
        {
            trans.DOScale(0f, .2f).SetEase(Ease.InOutBack).OnComplete(() =>
                Destroy(gameObj)
                );
        }
    }
}
