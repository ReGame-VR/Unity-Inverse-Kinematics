using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class HideOnHandFocusLost : MonoBehaviour
	{
		//-------------------------------------------------
		private void OnHandFocusLost( Hand hand )
		{
			gameObject.SetActive( false );
		}
	}
}
