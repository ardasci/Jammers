using Selections;
using UnityEngine;

namespace Character
{
    public class CharacterSelections : MonoBehaviour
    {
        // tags for unity level selection objects (update and fixedUpdate)
        private const string _update = "Update", _fixedUpdate = "FixedUpdate";
        private const string _groceryCart = "GroceryCart", _suprise = "Suprise";

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<UnityLevelSelections>())
            {
                if (other.CompareTag(_update))
                {
                    Debug.Log("Update");
                }
                else if (other.CompareTag(_fixedUpdate))
                {
                    Debug.Log("FixedUpdate");
                }
            }
            else if (other.GetComponent<GitLevelSelections>())
            {
                if (other.CompareTag(_groceryCart))
                {
                    Debug.Log("GroceryCart");
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
