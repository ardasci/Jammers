using Time;
using Collectables;
using Obstacles;
using UnityEngine;

namespace Character
{
    // Character time and obstacle controller :)
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
                _timer.SandGlassImgScaler();
                _timer.CountdownIncreaser();
            }

            if (other.GetComponent<ObstacleController>())
            {
                // set fall anim
                // gameover
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<TimeUpgrader>())
            {
                _timer.SetDefaultTextColor();
                _timer.DestroyClock(other.transform, other.gameObject);
            }
        }
    }
}
