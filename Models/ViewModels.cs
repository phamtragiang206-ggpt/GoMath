using System.ComponentModel.DataAnnotations;

namespace GoMath.Models
{
    // Equation Solver
    public class EquationViewModel
    {
        public string EquationType { get; set; } = "linear"; // linear or quadratic
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public string? Result { get; set; }
        public List<string> Steps { get; set; } = new();
    }

    // Grade Calculator
    public class GradeViewModel
    {
        [Range(0, 10, ErrorMessage = "Điểm phải từ 0 đến 10")]
        public double RegularScore { get; set; }

        [Range(0, 10, ErrorMessage = "Điểm phải từ 0 đến 10")]
        public double MidtermScore { get; set; }

        [Range(0, 10, ErrorMessage = "Điểm phải từ 0 đến 10")]
        public double FinalScore { get; set; }

        public double? Average { get; set; }
        public string? Rank { get; set; }
    }

    // Prime Number
    public class PrimeViewModel
    {
        public long Number { get; set; }
        public bool? IsPrime { get; set; }
        public string? Explanation { get; set; }
    }

    // Factorial
    public class FactorialViewModel
    {
        [Range(0, 20, ErrorMessage = "Số phải từ 0 đến 20")]
        public int Number { get; set; }
        public string? Result { get; set; }
        public string? Expansion { get; set; }
    }

    // Unit Converter
    public class UnitConverterViewModel
    {
        public string Category { get; set; } = "length";
        public double Value { get; set; }
        public string FromUnit { get; set; } = string.Empty;
        public string ToUnit { get; set; } = string.Empty;
        public double? Result { get; set; }
        public string? Formula { get; set; }
    }

    // Electricity/Water Bill
    public class UtilityBillViewModel
    {
        public string BillType { get; set; } = "electricity"; // electricity or water
        public double StartIndex { get; set; }
        public double EndIndex { get; set; }
        public double? Usage { get; set; }
        public double? TotalCost { get; set; }
        public List<BillTierDetail> TierDetails { get; set; } = new();
    }

    public class BillTierDetail
    {
        public string TierName { get; set; } = string.Empty;
        public double Kwh { get; set; }
        public double UnitPrice { get; set; }
        public double SubTotal { get; set; }
    }
}
