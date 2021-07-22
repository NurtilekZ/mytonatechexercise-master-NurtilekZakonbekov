using UnityEngine;

namespace PowerUp.Scripts
{
	[ExecuteInEditMode]
	public class ScaleParticles : MonoBehaviour {
		void Update () {
			GetComponent<ParticleSystem>().startSize = transform.lossyScale.magnitude;
		}
	}
}