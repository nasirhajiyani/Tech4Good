using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;




public class Test : MonoBehaviour
{
    public int iteration = 0;
    public int counter = 0;
    public string[] Checklist;
    public bool ToggleMenu = false;
    public bool CanMove = true;

    
    

    public GameObject secondCamera, thirdCamera, forthCamera;


    public Rigidbody2D rb;




    public TextMeshProUGUI checklistText1, checklistText2, checklistText3, checklistText4;


    //Interactable Objects 

    public GameObject interactableObject1, interactableObject2, interactableObject3, ToggleMenuObject;

    //Canvas Objects(CheckList)
    public GameObject checkedBox1, checkBox1, checkedBox2, checkBox2, checkedBox3, checkBox3, checkedBox4, checkBox4;


    public float speed;




    Vector2 moveInput;

    public Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ToggleMenuObject.SetActive(false);
        checkedBox1.SetActive(false);
        checkedBox2.SetActive(false);
        checkedBox3.SetActive(false);
        checkedBox4.SetActive(false);

        secondCamera.SetActive(false);
        thirdCamera.SetActive(false);
        forthCamera.SetActive(false);  

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (CanMove == true)
        {
            moveInput = context.ReadValue<Vector2>();
            rb.linearVelocity = moveInput * speed;
        }
        else
        {
            return;
        }
        
    }

    void Update()
    {
        //Animation for the Player, need to add a bool and animation for up and down movement.
        if (moveInput.x < 0)
        {
            animator.SetBool("Left", true);
            animator.SetBool("Right", false);
            animator.SetBool("Idle", false);
            //gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (moveInput.x > 0)
        {
            
            animator.SetBool("Right", true);
            animator.SetBool("Left", false);
            animator.SetBool("Idle", false);
            //gameObject.GetComponent<SpriteRenderer>().flipX = true;
            
        }
        else if (moveInput.x == 0)
        {
            
            animator.SetBool("Idle", true);
            animator.SetBool("Left", false);
            animator.SetBool("Right", false);
        }
        
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            ToggleMenu = !ToggleMenu;
            if (ToggleMenu)
            {
                CanMove = false;
                // Code to open the menu
                ToggleMenuObject.SetActive(true);
            }
            else
            {
                CanMove = true;
                // Code to close the menu
                ToggleMenuObject.SetActive(false);
            }
        }
    }

     void OnTriggerEnter2D(Collider2D collision)
    {
       
         if (collision.gameObject.tag == "Interactable")
        {   
            secondCamera.SetActive(true);
            if (interactableObject1.GetComponent<StateCheck>().isInteracting == false)
            {
                interactableObject1.GetComponent<StateCheck>().isInteracting = true;
                
                iteration = 1;
                print(Checklist[iteration]); 
                checklistText1.text = Checklist[iteration];
                
                checkedBox1.SetActive(true);
                checkBox1.SetActive(false);
                counter++;
            }
            //charges the first driver is he is found not following the proper procedure, after having a car breakdown
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            secondCamera.SetActive(false);
        }
    }


    

    void OnCollisionEnter2D(Collision2D collision)
    {
        //fix the addition for multiple objects with the same tag, maybe add a bool to check if the player has already interacted with the object
       
        if (collision.gameObject.tag == "Interactable2")
        {
            

            if (interactableObject2.GetComponent<StateCheck>().isInteracting == false)
            {

                interactableObject2.GetComponent<StateCheck>().isInteracting = true;
                
                iteration = 2;
                print(Checklist[iteration]);
                checklistText2.text = Checklist[iteration];
                checkedBox2.SetActive(true);
                checkBox2.SetActive(false);
                counter++;
            }
            

        }  


        if (collision.gameObject.tag == "Interactable1")
        {   
            thirdCamera.SetActive(true);
            
            if (interactableObject2.GetComponent<StateCheck>().isInteracting == false)
            {

                interactableObject3.GetComponent<StateCheck>().isInteracting = true;



                
                iteration = 3;
                print(Checklist[iteration]);
                checklistText3.text = Checklist[iteration];
                checkedBox3.SetActive(true);
                checkBox3.SetActive(false);
                counter++;
            }
        }

        
         
        if (collision.gameObject.tag == "Interactable3")
        {
            
            forthCamera.SetActive(true);
            iteration = 4;
            print(Checklist[iteration]);
            checklistText4.text = Checklist[iteration];
            checkedBox4.SetActive(true);
            checkBox4.SetActive(false);
            counter++;
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Interactable1")
        {
            thirdCamera.SetActive(false);
        }
        if (collision.gameObject.tag == "Interactable3")
        {
            forthCamera.SetActive(false);
        }
    }

    
   

    
   

   
}
