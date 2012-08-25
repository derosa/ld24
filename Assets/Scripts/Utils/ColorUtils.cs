using UnityEngine;
using System.Collections;

public static class ColorUtils {

	public static Color RandomColor ()
	{
		float r = Mathf.Clamp01 (Random.value + 0.25f);
		float g = Mathf.Clamp01 (Random.value + 0.25f);
		float b = Mathf.Clamp01 (Random.value + 0.25f);
	
		return new Color (r, g, b, 1f);
	}
}
