using System.ComponentModel.DataAnnotations;

namespace CVGenerator.Core.Data.Entities
{
    /// <summary>
    /// Уровень владения иностранным языком
    /// </summary>
    public enum LanguageLevel
	{
		[Display(Name = "A1 Beginner")]
		Beginner = 1,

		[Display(Name = "A1 Elementary")]
		Elementary,

		[Display(Name = "A2 Pre-Intermediate")]
		PreIntermediate,

		[Display(Name = "B1 Intermediate")]
		Intermediate,

		[Display(Name = "B2 Upper-Intermediate")]
		UpperIntermediate,

		[Display(Name = "C1 Advanced")]
		Advanced,

		[Display(Name = "C2 Proficient")]
		Proficient
	}
}
