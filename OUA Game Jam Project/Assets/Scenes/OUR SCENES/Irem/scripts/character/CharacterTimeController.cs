using Time;
using Collectables;
using UnityEngine;

namespace Character
{
    public class CharacterTimeController : MonoBehaviour
    {
        private Timer _timer;
        private TimeUpgrader _timeUpgrader;

        private void Start()
        {
            _timer = FindObjectOfType<Timer>();
            _timeUpgrader = FindObjectOfType<TimeUpgrader>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TimeUpgrader>())
            {
                _timer.CountdownIncreaser();
                _timer.DestroyClock(other.transform, other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<TimeUpgrader>())
            {
                _timer.SetDefaultTextColor();
            }
        }
    }
}
