using TMPro;
using DG.Tweening;
using UnityEngine;

namespace Collectables
{
    public class Timer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI timeText;
        [SerializeField] private Transform sandGlass;
        [SerializeField] private float _speed = .1f, _height = .5f;
        [SerializeField] private bool isGameStarted;

        private Vector3 _pos;

        public float countdown = 30f;
        private float _newY;
        private int countdownNumber;

        private void Start()
        {
            isGameStarted = true;
            _pos = transform.position;
        }

        private void Update()
        {
            ClockYoyoMovement();
            SandGlassImgRotator();
            CountdownCalculator();
        }

        private void ClockYoyoMovement()
        {
            _newY = (Mathf.Sin(Time.time * _speed) * _height + _pos.y) / 2;
            transform.position = new Vector3(_pos.x, _newY, _pos.z);
        }

        private void SandGlassImgRotator()
        {
            sandGlass.DOLocalRotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
        }

        private void CountdownCalculator()
        {
            if (isGameStarted)
            {
                countdown -= Time.deltaTime;

                if (countdown <= 5)
                {
                    //timeText.color = Color.red;
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
        }

        private void TextColorUpdater(TextMeshProUGUI _text, Color _color)
        {
            _text.color = _color;
        }

        public void SetDefaultTextColor()
        {
            timeText.color = Color.white;
        }
    }
}
