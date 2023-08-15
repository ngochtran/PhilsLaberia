using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe/Create New Recipe")]
public class Recipe : ScriptableObject
{
    public string requiredIngredients;
    public Item resultingProduct;

}