
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.InputSystem;




public class Test : MonoBehaviour
{
    public int i = 0;


    public Rigidbody2D rb;

    public GameObject interactableObject1, interactableObject2;

    public float speed;

    Vector2 moveInput;

    public Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        rb.linearVelocity = moveInput * speed;
    }

    void Update()
    {
        //Animation for the Player, need to add a bool and animation for up and down movement.
        if (moveInput.x < 0)
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Idle", false);
        }
        else if (moveInput.x > 0)
        {
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Idle", false);
        }
        else if (moveInput.x == 0)
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //fix the addition for multiple objects with the same tag, maybe add a bool to check if the player has already interacted with the object
        if (collision.gameObject.tag == "Interactable")
        {   
           if (interactableObject1.GetComponent<StateCheck>().isInteracting == false)
            {
                interactableObject1.GetComponent<StateCheck>().isInteracting = true;
                i++;
                Debug.Log(i);
                
                
            }
        }
        if (collision.gameObject.tag == "Interactable2")
        {

            if (interactableObject2.GetComponent<StateCheck>().isInteracting == false)
            {

                interactableObject2.GetComponent<StateCheck>().isInteracting = true;
                i++;
                Debug.Log(i);
            }
            
        }




    

        
    }

   /* if (!hasInteracted)
            {
                i++;
                Debug.Log (i);
                hasInteracted = true;
            }
            else {
                Debug.Log("Already interacted with this object.");
            }
            */
}
