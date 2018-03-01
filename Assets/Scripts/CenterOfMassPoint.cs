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
        Vector2 posn = Wii.GetCenterOfBalance(0) / 5f;


        Vector3 tposn = pelvisTracker.position;
        Vector3 hposn = hmd.position;

        // posn.y is equal to 3D posn.z
        Vector3 new3Dposn = new Vector3((hposn.x + tposn.x)/2 + posn.x, tposn.y, (hposn.z + tposn.z)/2 + posn.y);

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
}
