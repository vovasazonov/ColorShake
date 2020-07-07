using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ColorShakeGame
{
	public class ManipulateForm : MonoBehaviour, IPointerUpHandler, IDragHandler
	{
		private bool _isDragging;

		#region Unity's methods
		public void OnPointerUp(PointerEventData eventData)
		{
			if (!_isDragging)
			{
				OnClickForm();
			}
			_isDragging = false;
		}

		public void OnDrag(PointerEventData eventData)
		{
			_isDragging = true;
		}
		#endregion

		private void OnClickForm()
		{
			GameManager.Instance.ClickForm(this.gameObject);
		}
	}
}
