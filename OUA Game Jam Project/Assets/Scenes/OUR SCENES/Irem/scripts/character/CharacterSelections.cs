using Time;
using Selections;
using UnityEngine;

namespace Character
{
    public class CharacterSelections : MonoBehaviour
    {

        [SerializeField] GameObject cart;
        
        private PlayerMovement playerMovement;
        private Timer timer;

        // tags for unity level selection objects (update and fixedUpdate)
        private const string _update = "Update", _fixedUpdate = "FixedUpdate";
        private const string _groceryCart = "GroceryCart", _suprise = "Suprise";
        private const string _private = "Private", _public = "Public";

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
            timer = FindObjectOfType<Timer>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<UnityLevelSelections>())
            {
                if (other.CompareTag(_update))
                {
                    playerMovement.speed += 2;
                }
                else if (other.CompareTag(_fixedUpdate))
                {
                    playerMovement.speed += 4;
                }
            }
            else if (other.GetComponent<GitLevelSelections>())
            {
                if (other.CompareTag(_groceryCart))
                {
                    cart.SetActive(true);
                    cart.GetComponent<BoxCollider>().enabled = false;
                    other.gameObject.SetActive(false);
                }
                else if (other.CompareTag(_suprise))        // TO-DO: plane, skateboard, donkey etc.
                {
                    //Debug.Log("Suprise");
                }
            }
            else if (other.GetComponent<CourseraLevelSelections>())
            {
                if (other.CompareTag(_private))
                {
                    timer.CountdownController(Color.red, -10f);
                }
                else if (other.CompareTag(_public))
                {
                    timer.CountdownController(Color.green, 10f);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.GetComponent<CourseraLevelSelections>())
            {
                if (other.CompareTag(_private))
                {
                    timer.SetDefaultTextColor();
                }
                else if (other.CompareTag(_public))
                {
                    timer.SetDefaultTextColor();
                }
            }
        }
    }
}
