using System.Collections.Generic;

namespace Matech.Common.Scaffolding.Service
{

    public class Rootobject
    {
        public IEnumerable<Recipe> recipes { get; set; } = new List<Recipe>();
    }

    public class Recipe
    {
        public bool vegetarian { get; set; }
        public bool vegan { get; set; }
        public bool glutenFree { get; set; }
        public bool dairyFree { get; set; }
        public bool veryHealthy { get; set; }
        public bool cheap { get; set; }
        public bool veryPopular { get; set; }
        public bool sustainable { get; set; }
        public int weightWatcherSmartPoints { get; set; }
        public string gaps { get; set; }
        public bool lowFodmap { get; set; }
        public int aggregateLikes { get; set; }
        public float spoonacularScore { get; set; }
        public float healthScore { get; set; }
        public string creditsText { get; set; }
        public string license { get; set; }
        public string sourceName { get; set; }
        public float pricePerServing { get; set; }
        public IEnumerable<Extendedingredient> extendedIngredients { get; set; } = new List<Extendedingredient>();
        public int id { get; set; }
        public string title { get; set; }
        public int readyInMinutes { get; set; }
        public int servings { get; set; }
        public string sourceUrl { get; set; }
        public string image { get; set; }
        public string imageType { get; set; }
        public string summary { get; set; }
        public IEnumerable<string> cuisines { get; set; } = new List<string>();
        public IEnumerable<string> dishTypes { get; set; } = new List<string>();
        public IEnumerable<string> diets { get; set; } = new List<string>();
        public IEnumerable<string> occasions { get; set; } = new List<string>();
        public string instructions { get; set; }
        public IEnumerable<Analyzedinstruction> analyzedInstructions { get; set; } = new List<Analyzedinstruction>();
        public object originalId { get; set; }
        public string spoonacularSourceUrl { get; set; }
        public int preparationMinutes { get; set; }
        public int cookingMinutes { get; set; }
    }

    public class Extendedingredient
    {
        public int id { get; set; }
        public string aisle { get; set; }
        public string image { get; set; }
        public string consistency { get; set; }
        public string name { get; set; }
        public string original { get; set; }
        public string originalString { get; set; }
        public string originalName { get; set; }
        public float amount { get; set; }
        public string unit { get; set; }
        public IEnumerable<string> meta { get; set; } = new List<string>();
        public IEnumerable<string> metaInformation { get; set; } = new List<string>();
        public Measures measures { get; set; }
    }

    public class Measures
    {
        public Us us { get; set; }
        public Metric metric { get; set; }
    }

    public class Us
    {
        public float amount { get; set; }
        public string unitShort { get; set; }
        public string unitLong { get; set; }
    }

    public class Metric
    {
        public float amount { get; set; }
        public string unitShort { get; set; }
        public string unitLong { get; set; }
    }

    public class Analyzedinstruction
    {
        public string name { get; set; }
        public IEnumerable<Step> steps { get; set; } = new List<Step>();
    }

    public class Step
    {
        public int number { get; set; }
        public string step { get; set; }
        public IEnumerable<Ingredient> ingredients { get; set; } = new List<Ingredient>();
        public IEnumerable<Equipment> equipment { get; set; } = new List<Equipment>();
        public Length length { get; set; }
    }

    public class Length
    {
        public int number { get; set; }
        public string unit { get; set; }
    }

    public class Ingredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
    }

    public class Equipment
    {
        public int id { get; set; }
        public string name { get; set; }
        public string localizedName { get; set; }
        public string image { get; set; }
        public Temperature temperature { get; set; }
    }

    public class Temperature
    {
        public float number { get; set; }
        public string unit { get; set; }
    }

}
