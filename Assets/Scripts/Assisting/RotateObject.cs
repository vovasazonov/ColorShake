using UnityEngine;

namespace ColorShakeGame
{
	/// <summary>
	/// Rotate game objects or it parent when user drag gameobject.
	/// </summary>
	public class RotateObject : MonoBehaviour
	{
		[SerializeField]
		private bool _rotateParent;
		private const float _rotSpeed = 20;

		private void OnMouseDrag()
		{
			float rotX = Input.GetAxis("Mouse X") * _rotSpeed * Mathf.Deg2Rad;
			float rotY = Input.GetAxis("Mouse Y") * _rotSpeed * Mathf.Deg2Rad;

			if (_rotateParent)
			{
				try
				{
					transform.parent.RotateAround(Vector3.up, -rotX);
					transform.parent.RotateAround(Vector3.right, rotY);
				}
				catch (System.Exception)
				{
					Debug.LogError("There are not parent on object.");
				}
			}
			else
			{
				transform.RotateAround(Vector3.up, -rotX);
				transform.RotateAround(Vector3.right, rotY);
			}

		}

	}
	
}
