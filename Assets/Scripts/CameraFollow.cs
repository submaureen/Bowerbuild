using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // the object to follow
    public GameObject followObject;

    // how much the object can move before the camera starts following eg |<--o-->| if o is the object and | are how far it can move
    public Vector2 followOffset;

    // the size of the focused camera
    public Vector2 threshold;

    public float speed = 3;

    private Rigidbody2D followRigid;

    public bool shouldFollow;

    // Start is called before the first frame update
    void Start()
    {
        threshold = calculateThreshold();
        followRigid =  followObject.GetComponent<Rigidbody2D>();
        
    }

    private Vector3 calculateThreshold() {
        // Where on the screen is the camera rendered in pixel coordinates.
        Rect aspect = Camera.main.pixelRect;

        // Camera's half-size when in orthographic mode used to  calculate the height and width of the screen's boundary box.
        // orthographic size is like when you look at a prism and see a triangle. ur parallel to the line of sight or whatever
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
        t.x -= followOffset.x;
        t.y -= followOffset.y;
        return t;
    }

    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    // the like... boundary of the camera in a way where u can see it !
    // this is why we are using Vector3. Gizmos.DrawWireCube needs a vector3
    // the camera uses a vector3 also, that's kinda important
    /// </summary>
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 border = calculateThreshold ();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }

    // Update is called once per frame
    // fixed update is physics based means it only updates when ya moving ! 
    void FixedUpdate()
    {

        // the thing you wanna follow
        Vector2 follow = followObject.transform.position;

        if (followObject.transform.position.x > 107 || followObject.transform.position.x < -25) {
            shouldFollow = false;
        }
        else {shouldFollow = true;}
        // distance between our object and center of the x - axis
        // vector2.right is shorthand for writing Vector2(1, 0) multiplied by the y of the camera's location
        // basically ur scaling it up or down
        float xDifference = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
        float yDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);

        // the camera's position! because it uses vector3

        // if the distance between our object and the center x axis is GREATER than the threshold that we have defined
        // u better change the position of camera to our object!!

        if (shouldFollow) {
            Vector3 newPosition = transform.position;
            if ((Mathf.Abs(xDifference) >= threshold.x))
            {
                newPosition.x = follow.x;
            }


            if (Mathf.Abs(yDifference) >= threshold.y)
            {
                newPosition.y = follow.y;
            }

            // if (followObject.GetComponent<Inventory>().value == 15)
            // {
            //     newPosition.z -= 1;
            // }
            float moveSpeed = followRigid.velocity.magnitude > speed ? followRigid.velocity.magnitude : speed;
            transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
        }

    }
}
