using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;               // this is the part of the code that tells visual studio to comunicate with the unity engine
using UnityEngine.InputSystem;   //this is the part of the code that lets unity comunicate with the input system
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10; // this public float creates a float and makes it public. being public allows the value to be controlled by the unity editor. this one is going to control spe
    public TextMeshProUGUI CountText; // this line creates a special variable, a TextMeshProUGUI variable is spesifically designed to work with text, the variables name is count text

   private Rigidbody rb;  // private means that this script can not be accessed from the inspector or from other scripts. public would allow it to be accessed this way
    private int count; // this creates a private integer variable in this script. the variable will be used to hold a number and that number will be used to count how many PickUP cubes have been collected.
    private float movementX;
    private float movementY; 

    // Start is called before the first frame update  all of the code in the start function is called apon the first frame that the script is active
    void Start()
    {
        rb =GetComponent<Rigidbody>();  // this gives the rb variable information attached to the rigidbody component attached to this game object. (makes the variable = to the physics thing attached to the game object)
        count = 0;  // this line sets the starting value of the count variable. it starts at zero because there are zero cubes collected at the start
        SetCountText(); // set count text is here because it makes the count text display, it starts at zero so this will only display Count:
    }
    void OnMove(InputValue movementValue)  //the void part of this function (on move in this case) means that it wont return any values. (movement value captures the movement of the ball on the x and y axis) this data is stored in a vector2 variable
    {
        Vector2 movementVector =movementValue.Get<Vector2>(); // vector2 movementVector creates a variable, movementValue.getvector2 gets the vector2 data from the movment value in the InputValue void
        movementX = movementVector.x;   // i am pretty sure that these lines cause the movementx and y float respectivly to be = to their respective movment values
        movementY = movementVector.y;
    }

    void SetCountText() // this is a method, you are using a method to manage the count text function
    {
        CountText.text = "Count: " + count.ToString();    }  // CountText.text is the actual text displayed in game, this line of code says it should display, count: plus the string value of the count variable

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);  // the f after this value stands for float

        rb.AddForce(movement * speed);  // this causes the force to multiplied by the speed variable, it does this by adding force which is multiplied by the value of the speed variable
    }

    private void OnTriggerEnter(Collider other)   // on trigger enter means that the code in the void will happen when the trigger is entered (which means which means detected) the trigger is what is in the bracets, which in this case is a collider named other
    {
        if(other.gameObject.CompareTag("PickUp"))  // this line makes the that the code below it in the brackets only happens if the game object below it has the tag pick up.
        {
            other.gameObject.SetActive(false);  // this is the code that runs when the collider trigger is collected. it deactivates the game object by selecting set active, a property that determines if the game object is active to false making the fact that it is active untrue
            count = count + 1; // this line changes the value of the count variabke to the current value of count plus 1, essentially this just adds 1 to the current count each time a cube is picked up

            SetCountText(); // this makes the count text go up each time the count goes up
        }
         
    }
}




// here is where i am building a dictionary to avoid forgetting what stuff does

// public means that the value is acessable throughout other scripts in the program while or at least it is viewable in the editor.
// local means that it is only acessable through the script that it is written on

// string is a variable type that means its a word. i think its means like a string of numbers
// int is short for interger this is also a number
//floats. float is short for floating point. a floating point is a type of decimal value that is more spesific (more information needed here)

// void functions are methods that do not return a value. 

// vector2 stores data on the x and y axis, as the name suggests its only 2 axis's
// vector3 stores data on the x y and z ais, as the name suggests its 3 axises.
