using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class BalloonHapticBump : MonoBehaviour
	{
		public GameObject physParent;

		//-------------------------------------------------
		void OnCollisionEnter( Collision other )
		{
			Balloon contactBalloon = other.collider.GetComponentInParent<Balloon>();
			if ( contactBalloon != null )
			{
				Hand hand = physParent.GetComponentInParent<Hand>();
				if ( hand != null )
				{
					hand.controller.TriggerHapticPulse( 500 );
				}
			}
		}
	}
}
