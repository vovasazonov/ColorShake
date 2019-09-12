using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorShakeGame
{
	public class UIManager : MonoBehaviour
	{
		public void StartGame()
		{
			GameManager.Instance.StartGame();
		}
	}

}
