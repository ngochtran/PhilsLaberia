using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe Array", menuName = "Crafting Recipe Array/Add New Recipe")]
public class RecipeArray : ScriptableObject
{
    public Recipe[] recipesArray;
}
