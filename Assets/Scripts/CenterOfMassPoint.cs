using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassPoint : MonoBehaviour {

    [SerializeField]
    private Transform pelvisTracker;

    [SerializeField]
    private Transform hmd;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Convert the center of balance to meters
        Vector2 posn = CoPtoM(Wii.GetCenterOfBalance(0));


        Vector3 tposn = pelvisTracker.position;
        Vector3 hposn = hmd.position;

        // WBBposn.y is equal to 3D posn.z
        float newposnx = posn.x;
        float newposny = tposn.y;
        float newposnz = posn.y;

        // Add 17cm to Z position to accurately measure the center of mass as recommended
        // by sacral marker study.
        Vector3 new3Dposn = new Vector3(newposnx, newposny, newposnz);

        GetComponent<Transform>().position = new3Dposn; 

    }

    /// <summary>
    /// Converts COP ratio to be in terms of cm
    /// </summary>
    /// <param name="posn"> The current COB posn, not in terms of cm </param>
    /// <returns> The posn, in terms of cm </returns>
    public static Vector2 CoPtoCM(Vector2 posn)
    {
        return new Vector2(posn.x * 43.3f / 2f, posn.y * 23.6f / 2f);
    }

    /// <summary>
    /// Converts COP ratio to be in terms of meters
    /// </summary>
    /// <param name="posn"> The current COB posn, not in terms of meters </param>
    /// <returns> The posn, in terms of meters </returns>
    public static Vector2 CoPtoM(Vector2 posn)
    {
        return new Vector2(posn.x * 0.433f / 2f, posn.y * 0.236f / 2f);
    }
}
