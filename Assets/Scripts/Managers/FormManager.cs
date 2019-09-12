using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorShakeGame
{
	public class FormManager : MonoBehaviour
	{
		private void Awake()
		{
			StartCoroutine(Initialize());
		}

		private IEnumerator Initialize()
		{
			if (GameManager.Instance == null)
			{
				yield return null;

			}
			GameManager.Instance.InitializeMainForm();
		}
	}
}
