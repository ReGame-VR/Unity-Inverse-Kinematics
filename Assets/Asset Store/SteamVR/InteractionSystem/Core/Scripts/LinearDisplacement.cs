using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class LinearDisplacement : MonoBehaviour
	{
		public Vector3 displacement;
		public LinearMapping linearMapping;

		private Vector3 initialPosition;

		//-------------------------------------------------
		void Start()
		{
			initialPosition = transform.localPosition;

			if ( linearMapping == null )
			{
				linearMapping = GetComponent<LinearMapping>();
			}
		}


		//-------------------------------------------------
		void Update()
		{
			if ( linearMapping )
			{
				transform.localPosition = initialPosition + linearMapping.value * displacement;
			}
		}
	}
}
