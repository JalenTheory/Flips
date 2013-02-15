using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class GameScript {

	public static Material[] RandomizeMaterial(Material[] mat)
    {
		List<KeyValuePair<int, Material>> list = new List<KeyValuePair<int, Material>>();
		foreach (Material m in mat)
		{
		    list.Add(new KeyValuePair<int, Material>(Random.Range(0,99999), m));
		}
		// Sort the list by the random number
		var sorted = from item in list
			     orderby item.Key
			     select item;
		// Allocate new string array
		Material[] result = new Material[mat.Length];
		// Copy values to array
		int index = 0;
		foreach (KeyValuePair<int, Material> pair in sorted)
		{
		    result[index] = pair.Value;
		    index++;
		}
		// Return copied array
		return result;
    }
}
