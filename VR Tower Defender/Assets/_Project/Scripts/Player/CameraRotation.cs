using Game.Managers;
using UnityEngine;

namespace Game
{
	public class CameraRotation : Singleton<CameraRotation>
	{
		[SerializeField] private Transform cameraTransform;
		[SerializeField] private float rotSpeed;
		
		private void Update()
		{
			transform.eulerAngles += Time.deltaTime * rotSpeed * new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f);
		}
		
		public Transform GetCameraTransform() { return cameraTransform; }
	}
}