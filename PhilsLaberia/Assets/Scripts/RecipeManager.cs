using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RecipeManager : MonoBehaviour
{
    public Dictionary<string, Item> recipeDict = new Dictionary<string, Item> { };
    public RecipeArray myRecipeArray;

    private void Start()
    {
        populateRecipeDict(myRecipeArray);
    }

    public void populateRecipeDict(RecipeArray recipeArray)
    {
        foreach (Recipe recipe in recipeArray.recipesArray)
        {
            // Assuming that Recipe class contains a string field for recipeString and a reference to Item for the craftedItem
            if (!recipeDict.ContainsKey(recipe.requiredIngredients))
            {
                recipeDict.Add(recipe.requiredIngredients, recipe.resultingProduct);
            }
            else
            {
                Debug.LogWarning("Duplicate recipe found: " + recipe.requiredIngredients);
            }
        }
    }

    public string sortAndConcatenate(List<Item> craftingSet)
    {
        List<string> itemNames = craftingSet.Select(item => item.itemName).ToList();
        itemNames.Sort();

        return string.Join(", ", itemNames);
    }

    public Item retrieveCraftedItem(string recipeString)
    {
        if (recipeDict.TryGetValue(recipeString, out Item craftedItem))
        {
            return craftedItem; // Found the item associated with the recipe string
        }
        else
        {
            return null; // Recipe string not found in the dictionary
        }
    }

}
