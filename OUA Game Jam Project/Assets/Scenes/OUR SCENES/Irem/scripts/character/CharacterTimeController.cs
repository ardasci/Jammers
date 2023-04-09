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
        private Animator animator;
        private PlayerMovement playerMovement;

        private const string _dance = "Dance";
        private const string _isDancing = "isDancing";

        private void Start()
        {
            _timer = FindObjectOfType<Timer>();
            animator = GetComponent<Animator>();
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<TimeUpgrader>())
            {
                _timer.SandGlassImgScaler();
                _timer.CountdownController(Color.green, 5f);
            }

            if (other.GetComponent<ObstacleController>())
            {
                // set fall anim
                // gameover
            }

            if (other.CompareTag(_dance))
            {
                animator.SetTrigger(_isDancing);
                playerMovement.speed = 0.01f;
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
