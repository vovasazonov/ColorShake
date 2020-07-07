using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorShakeGame
{
	/// <summary>
	/// Singlton pattern. All data of user from dataplayer.
	/// are keping here.
	/// </summary>
	public class DataPlayerManager : MonoBehaviour
	{
		// Singlton pattern.
		public static DataPlayerManager Instance = null;

		// Data information of user that keep infromation like money.
		public DataPlayer Data = new DataPlayer();

		private void Awake()
		{
			//Check if instance already exists
			if (Instance == null)
			{
				//if not, set instance to this
				Instance = this;
			}
			//If instance already exists and it's not this:
			else if (Instance != this)
			{
				//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy(gameObject);
			}
			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(gameObject);

			// Load data user.
			Instance.Data = DataPlayer.Load();
		}

	}
}

