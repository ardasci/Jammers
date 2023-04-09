using Collectables;
using UnityEngine;

namespace Character
{
    public class CharacterTimeController : MonoBehaviour
    {
        private Timer _timer;

        private void Start()
        {
            _timer = FindObjectOfType<Timer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Timer>())
            {
                _timer.CountdownIncreaser();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<Timer>())
            {
                _timer.SetDefaultTextColor();
            }
        }


    }
}
