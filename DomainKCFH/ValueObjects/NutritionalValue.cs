using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicioCatering.Domain.ValueObjects;

public class NutritionalValue
{
    public float Calories { get; }
    public float Proteins { get; }
    public float Carbohydrates { get; }
    public float Fats { get; }

    public NutritionalValue(float calories, float proteins, float carbohydrates, float fats)
    {
        if (calories < 0) throw new ArgumentException("Calories cannot be negative.");
        if (proteins < 0) throw new ArgumentException("Proteins cannot be negative.");
        if (carbohydrates < 0) throw new ArgumentException("Carbohydrates cannot be negative.");
        if (fats < 0) throw new ArgumentException("Fats cannot be negative.");

        Calories = calories;
        Proteins = proteins;
        Carbohydrates = carbohydrates;
        Fats = fats;
    }

    public static NutritionalValue Create(float calories, float proteins, float carbohydrates, float fats)
    {
        return new NutritionalValue(calories, proteins, carbohydrates, fats);
    }

    public NutritionalValue Add(NutritionalValue other)
    {
        return new NutritionalValue(
            Calories + other.Calories,
            Proteins + other.Proteins,
            Carbohydrates + other.Carbohydrates,
            Fats + other.Fats
        );
    }

    public override bool Equals(object? obj)
    {
        if (obj is not NutritionalValue other) return false;
        return Calories == other.Calories &&
               Proteins == other.Proteins &&
               Carbohydrates == other.Carbohydrates &&
               Fats == other.Fats;
    }

    public override int GetHashCode() =>
        HashCode.Combine(Calories, Proteins, Carbohydrates, Fats);
}
