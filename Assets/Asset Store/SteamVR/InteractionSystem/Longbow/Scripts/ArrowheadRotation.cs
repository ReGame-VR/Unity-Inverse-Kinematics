using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class ArrowheadRotation : MonoBehaviour
	{
		//-------------------------------------------------
		void Start()
		{
			float randX = Random.Range( 0f, 180f );
			transform.localEulerAngles = new Vector3( randX, -90f, 90f );
		}
	}
}
