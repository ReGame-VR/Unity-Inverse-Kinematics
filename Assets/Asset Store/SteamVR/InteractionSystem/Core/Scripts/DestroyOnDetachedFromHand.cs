using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	[RequireComponent( typeof( Interactable ) )]
	public class DestroyOnDetachedFromHand : MonoBehaviour
	{
		//-------------------------------------------------
		private void OnDetachedFromHand( Hand hand )
		{
			Destroy( gameObject );
		}
	}
}
