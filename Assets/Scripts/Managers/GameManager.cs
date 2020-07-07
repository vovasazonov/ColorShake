using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorShakeGame
{
	public class GameManager : MonoBehaviour
	{
		#region Values		
		public static GameManager Instance = null;			//Static instance of GameManager which allows it to be accessed by any other script.            

		// Tags on game objects.
		[SerializeField]
		private string _tagPiecesForm = "Piece Form";
		[SerializeField]
		private string _tagNeedForm = "Need Color";
		
		private bool _isChosed;								// Say if there was chosed first form of color.														
		private GameObject _firstPiece;                     // Piece with color that was chosed first.															
		private GameObject _needColor;						// Need color form, that need to get for get reward.											
		private List<GameObject> _pieces;                   // All pieces of main form.
		#endregion

		#region Unity's methods.
		//Awake is always called before any Start functions
		void Awake()
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
		}
		#endregion

		#region Public methods.
		/// <summary>
		/// Prepare values to game and a start it.
		/// </summary>
		public void StartGame()
		{
			if (Instance == null)
			{
				Debug.LogError("The instance GameManager is null!");
				return;
			}

			Instance.GenerateRandomColor();
		}

		public void InitializeMainForm()
		{
			_isChosed = false;

			_pieces = GetPiecesForm();
		}

		public void InitializeNeedColorForm()
		{
			_needColor = GameObject.FindGameObjectWithTag(_tagNeedForm);
		}

		/// <summary>
		/// Invoke when user click on piece form.
		/// </summary>
		/// <param name="gameObject">Piece that user clicked on.</param>
		public void ClickForm(GameObject gameObject)
		{
			// First piece chosed.
			if (!_isChosed)
			{
				_isChosed = true;
				_firstPiece = gameObject;

				return;
			}

			// Check if the piece is not the same like first.
			if (gameObject == _firstPiece)
			{
				return;
			}

			// Second piece chosed.
			_isChosed = false;

			// Combine two colors.
			Color c1 = _firstPiece.GetComponent<Renderer>().material.color;
			Color c2 = gameObject.GetComponent<Renderer>().material.color;
			Color shakedColor = Color.black.CombineColors(c1, c2);

			// Set to second piece combined color.
			gameObject.GetComponent<Renderer>().material.color = shakedColor;

			// Check combined color with color that need to get.
			if (_needColor.GetComponent<Renderer>().material.color == shakedColor)
			{
				SetReward(gameObject);
				GenerateRandomColor();
				IncreaseDifficult();
			}
			else
			{
				SetPanalty(gameObject);

				if (!CheckContainsColor())
				{
					GenerateRandomColor();
				}
			}

		}
		#endregion

		#region Private methods.
		/// <summary>
		/// Load all pieces of main form.
		/// </summary>
		/// <returns>Pieces form.</returns>
		private List<GameObject> GetPiecesForm()
		{
			return new List<GameObject>(GameObject.FindGameObjectsWithTag(_tagPiecesForm));
		}

		/// <summary>
		/// Check if there are colors that can be combined and
		/// get the need color.
		/// </summary>
		/// <returns>Result of searching.</returns>
		private bool CheckContainsColor()
		{
			for (int i = 0; i < _pieces.Count; i++)
			{
				for (int j = i; j < _pieces.Count; j++)
				{
					Color c1 = _pieces[i].GetComponent<Renderer>().material.color;
					Color c2 = _pieces[j].GetComponent<Renderer>().material.color;
					if (_needColor.GetComponent<Renderer>().material.color == Color.black.CombineColors(c1, c2))
					{
						return true;
					}
				}
			}

			return false;
		}

		/// <summary>
		/// Generate random color from list of pieces.
		/// </summary>
		private void GenerateRandomColor()
		{
			int num1 = UnityEngine.Random.Range(0, _pieces.Count);
			int num2 = 0;
			do
			{
				num2 = UnityEngine.Random.Range(0, _pieces.Count);
			}
			while (num1 == num2);

			_needColor.GetComponent<Renderer>().material.color =
				Color.black.CombineColors(_pieces[num1].GetComponent<Renderer>().material.color,
				_pieces[num2].GetComponent<Renderer>().material.color);
		}

		/// <summary>
		/// Set the reward and create effect of bad chose to piece.
		/// </summary>
		/// <param name="piece">Last shaked piece.</param>
		private void SetPanalty(GameObject piece)
		{

		}

		/// <summary>
		/// Set the reward and create effect of good chose to piece.
		/// </summary>
		/// <param name="piece">Last shaked piece.</param>
		private void SetReward(GameObject piece)
		{

		}

		/// <summary>
		/// Increase difficult of game.
		/// </summary>
		private void IncreaseDifficult()
		{

		}
		#endregion
	}
}
