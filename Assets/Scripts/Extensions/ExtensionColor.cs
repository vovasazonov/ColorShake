using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorShakeGame
{
	public static class ExtensionColor
	{
		/// <summary>
		/// Combine some amount of colors. 
		/// </summary>
		/// <param name="color">Extension class.</param>
		/// <param name="aColors">Colors that will combined.</param>
		/// <returns>Black for 0 colors, same color for 1 color, colors > 1 comined colors.</returns>
		public static Color CombineColors(this Color color, params Color[] aColors)
		{
			Color result = new Color(0, 0, 0, 0);
			foreach (Color c in aColors)
			{
				result += c;
			}
			result /= aColors.Length;
			return result;
		}
		
	}

}
