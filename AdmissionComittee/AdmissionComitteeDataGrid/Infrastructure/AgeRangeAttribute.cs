using System.ComponentModel.DataAnnotations;

/// <summary>
/// Класс валидации возраста
/// </summary>
public class AgeRangeAttribute : ValidationAttribute
{
    private readonly int min;
    private readonly int max;

    /// <summary>
    /// Конструктор атрибута
    /// </summary>
    public AgeRangeAttribute(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    /// <summary>
    /// Валидация возраста
    /// </summary>
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime birthDate)
        {
            var age = DateTime.Today.Year - birthDate.Year;
            if (birthDate.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (age < min || age > max)
            {
                return new ValidationResult(ErrorMessage, [validationContext.MemberName!]);
            }

            return ValidationResult.Success!;
        }

        return new ValidationResult("Некорректная дата.", [validationContext.MemberName!]);
    }
}
