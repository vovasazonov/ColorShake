using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace ColorShakeGame
{
	/// <summary>
	/// All data of user, that need for game
	/// are keeping in this class.
	/// </summary>
	[Serializable]
	public class DataPlayer
	{
		private const string DataFile = "/playerInfoData.dat";
		private const string DataPath = "/saves";

		#region Data values.
		// Best score of user in the game.
		public int Score { get; set; }
		#endregion

		#region methods
		// Constructor
		public DataPlayer()
		{
			Score = 0;
		}

		/// <summary>
		/// Load the data from file.
		/// </summary>
		/// <returns>The data loaded is true.</returns>
		public static DataPlayer Load()
		{
			DataPlayer data = new DataPlayer();

			//Check if folder "saves" exists.
			if (File.Exists(Application.persistentDataPath + DataPath +DataFile))
			{
				BinaryFormatter bf = new BinaryFormatter();

				//Open file.
				FileStream file = File.Open(Application.persistentDataPath +
					DataPath + DataFile, FileMode.Open);

				try
				{
					//Convert information from file to DataPlayer type.
					data = (DataPlayer)bf.Deserialize(file);

					file.Close();

				}
				catch (Exception e)
				{
					Debug.Log(e.Message);

					file.Close();

					//Set defoult values and save in new file.
					data = new DataPlayer();
					Save(data);
				}
			}
			else
			{
				data = new DataPlayer();

				Save(data);
			}

			return data;
		}

		/// <summary>
		/// Save data to file.
		/// </summary>
		public static void Save(DataPlayer data)
		{
			BinaryFormatter bf = new BinaryFormatter();

			//Check if folder "saves" exists.
			if (!Directory.Exists(Application.persistentDataPath + DataPath))
				Directory.CreateDirectory(Application.persistentDataPath + DataPath);

			//Create file, all exist information will be delete.
			FileStream file = new FileStream(Application.persistentDataPath +
				DataPath + DataFile, FileMode.Create);

			bf.Serialize(file, data);

			file.Close();
		}
		#endregion
	}
}
