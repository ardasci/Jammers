using Selections;
using UnityEngine;

namespace Character
{
    public class CharacterSelections : MonoBehaviour
    {

        PlayerMovement playerMovement;
        [SerializeField] GameObject cart;

        // tags for unity level selection objects (update and fixedUpdate)
        private const string _update = "Update", _fixedUpdate = "FixedUpdate";
        private const string _groceryCart = "GroceryCart", _suprise = "Suprise";

        private void Start()
        {
            playerMovement = GetComponent<PlayerMovement>();
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
                    other.gameObject.SetActive(false);
                }
                else if (other.CompareTag(_suprise))        // TO-DO: plane, skateboard, donkey etc.
                {
                    Debug.Log("Suprise");
                }
            }
            else if (other.GetComponent<CourseraLevelSelections>())
            {

            }
        }
    }
}
