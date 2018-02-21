using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.ManusVR.Scripts;

public class ManusGrabObject : MonoBehaviour
{

    /// <summary>
    /// Is this Manus grabber the right hand? Otherwise left hand.
    /// </summary>
    [SerializeField]
    private bool isRightHand = true;

    /// <summary>
    /// The enum that says which glove this is.
    /// </summary>
    private device_type_t deviceType;

    // The hand data script to get input from
    [SerializeField]
    private HandData handData;

    // Stores the GameObject that the trigger is currently colliding with, so you have the ability to grab the object.
    private GameObject collidingObject;
    // Serves as a reference to the GameObject that the player is currently grabbing.
    private GameObject objectInHand;

    void Awake()
    {
        if (isRightHand)
        {
            deviceType = device_type_t.GLOVE_RIGHT;
        }
        else
        {
            deviceType = device_type_t.GLOVE_LEFT;
        }
    }

    /// <summary>
    /// This method accepts a collider as a parameter and uses its GameObject as the collidingObject for grabbing and releasing.
    /// </summary>
    /// <param name="col"></param>The collider accepted
    private void SetCollidingObject(Collider col)
    {
        // Doesn’t make the GameObject a potential grab target if the player is already holding something or the object has no rigidbody.
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // Assigns the object as a potential grab target.
        collidingObject = col.gameObject;
    }

    // When the trigger collider enters another, this sets up the other collider as a potential grab target.
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // Ensures that the target is set when the player holds a controller over an object for a while. Without this, the collision may fail or become buggy.
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // When the collider exits an object, abandoning an ungrabbed target, this code removes its target by setting it to null.
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    // Grabs an object
    private void GrabObject()
    {
        // Move the GameObject inside the player’s hand and remove it from the collidingObject variable
        objectInHand = collidingObject;
        collidingObject = null;
        // Add a new joint that connects the controller to the object using the AddFixedJoint() method below.
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    // Make a new fixed joint, add it to the controller, and then set it up so it doesn’t break easily. Finally, you return it. 
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // Make sure there’s a fixed joint attached to the controller.
        if (GetComponent<FixedJoint>())
        {
            // Remove the connection to the object held by the joint and destroy the joint.
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            // Add the speed and rotation of the controller when the player releases the object, so the result is a realistic arc.
            objectInHand.GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = GetComponent<Rigidbody>().angularVelocity;
        }
        // Remove the reference to the formerly attached object.
        objectInHand = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (handData.HandClosed(deviceType))
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        if (handData.HandOpened(deviceType))
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }
}
