using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem
{
	//-------------------------------------------------------------------------
	public class SpawnAndAttachToHand : MonoBehaviour
	{
		public Hand hand;
		public GameObject prefab;


		//-------------------------------------------------
		public void SpawnAndAttach( Hand passedInhand )
		{
			Hand handToUse = passedInhand;
			if ( passedInhand == null )
			{
				handToUse = hand;
			}

			if ( handToUse == null )
			{
				return;
			}

			GameObject prefabObject = Instantiate( prefab ) as GameObject;
			handToUse.AttachObject( prefabObject );
		}
	}
}
