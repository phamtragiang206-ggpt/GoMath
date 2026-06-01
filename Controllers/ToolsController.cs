using Microsoft.AspNetCore.Mvc;
using GoMath.Models;

namespace GoMath.Controllers
{
    public class ToolsController : Controller
    {

        public IActionResult Equation()
        {
            return View(new EquationViewModel());
        }

        [HttpPost]
        public IActionResult Equation(EquationViewModel model)
        {
            model.Steps = new List<string>();

            if (model.EquationType == "linear")
            {
                // ax + b = 0
                if (model.A == 0)
                {
                    model.Steps.Add($"Phương trình: {model.B} = 0");
                    model.Result = model.B == 0 ? "Phương trình có vô số nghiệm (0 = 0)" : "Phương trình vô nghiệm";
                }
                else
                {
                    model.Steps.Add($"Phương trình: {model.A}x + {model.B} = 0");
                    model.Steps.Add($"Chuyển vế: {model.A}x = {-model.B}");
                    double x = -model.B / model.A;
                    model.Steps.Add($"x = {-model.B} ÷ {model.A}");
                    model.Result = $"x = {Math.Round(x, 2)}";
                }
            }
            else
            {
                
                if (model.A == 0)
                {
                    model.Steps.Add("Hệ số a = 0, đây không phải phương trình bậc hai.");
                    model.Result = "Vui lòng nhập a ≠ 0";
                }
                else
                {
                    model.Steps.Add($"Phương trình: {model.A}x² + {model.B}x + {model.C} = 0");
                    double delta = model.B * model.B - 4 * model.A * model.C;
                    model.Steps.Add($"Δ = b² - 4ac = ({model.B})² - 4 × {model.A} × {model.C}");
                    model.Steps.Add($"Δ = {Math.Round(delta, 2)}");

                    if (delta < 0)
                    {
                        model.Result = "Phương trình vô nghiệm (Δ < 0)";
                    }
                    else if (delta == 0)
                    {
                        double x = -model.B / (2 * model.A);
                        model.Steps.Add($"Δ = 0 → Phương trình có nghiệm kép");
                        model.Steps.Add($"x = -b / (2a) = {-model.B} / {2 * model.A}");
                        model.Result = $"x₁ = x₂ = {Math.Round(x, 2)}";
                    }
                    else
                    {
                        double sqrtDelta = Math.Sqrt(delta);
                        double x1 = (-model.B + sqrtDelta) / (2 * model.A);
                        double x2 = (-model.B - sqrtDelta) / (2 * model.A);
                        model.Steps.Add($"√Δ = √{Math.Round(delta, 2)} ≈ {Math.Round(sqrtDelta, 4)}");
                        model.Steps.Add($"x₁ = (-b + √Δ) / (2a) = ({-model.B} + {Math.Round(sqrtDelta, 4)}) / {2 * model.A}");
                        model.Steps.Add($"x₂ = (-b - √Δ) / (2a) = ({-model.B} - {Math.Round(sqrtDelta, 4)}) / {2 * model.A}");
                        model.Result = $"x₁ = {Math.Round(x1, 2)}, x₂ = {Math.Round(x2, 2)}";
                    }
                }
            }
            return View(model);
        }

        
        public IActionResult Grade()
        {
            return View(new GradeViewModel());
        }

        [HttpPost]
        public IActionResult Grade(GradeViewModel model)
        {
            double avg = Math.Round((model.RegularScore * 1 + model.MidtermScore * 2 + model.FinalScore * 3) / 6.0, 2);
            model.Average = avg;
            model.Rank = avg switch
            {
                >= 8.0 => "Tốt",
                >= 6.5 => "Khá",
                >= 5.0 => "Đạt",
                _ => "Chưa đạt"
            };
            return View(model);
        }

        
        public IActionResult Prime()
        {
            return View(new PrimeViewModel());
        }

        [HttpPost]
        public IActionResult Prime(PrimeViewModel model)
        {
            long n = model.Number;
            if (n < 2)
            {
                model.IsPrime = false;
                model.Explanation = $"Số {n} không phải số nguyên tố vì số nguyên tố phải lớn hơn hoặc bằng 2.";
            }
            else if (n == 2)
            {
                model.IsPrime = true;
                model.Explanation = "Số 2 là số nguyên tố nhỏ nhất và duy nhất là số nguyên tố chẵn.";
            }
            else if (n % 2 == 0)
            {
                model.IsPrime = false;
                model.Explanation = $"Số {n} chia hết cho 2, nên không phải số nguyên tố.";
            }
            else
            {
                bool isPrime = true;
                long divisor = 0;
                for (long i = 3; i <= Math.Sqrt(n); i += 2)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        divisor = i;
                        break;
                    }
                }
                model.IsPrime = isPrime;
                if (isPrime)
                    model.Explanation = $"Số {n} là số nguyên tố vì không có ước số nào trong khoảng từ 2 đến √{n} ≈ {Math.Round(Math.Sqrt(n), 2)}.";
                else
                    model.Explanation = $"Số {n} không phải số nguyên tố vì {n} = {divisor} × {n / divisor}.";
            }
            return View(model);
        }

        public IActionResult Factorial()
        {
            return View(new FactorialViewModel());
        }

        [HttpPost]
        public IActionResult Factorial(FactorialViewModel model)
        {
            int n = model.Number;
            if (n < 0 || n > 20)
            {
                model.Result = "Vui lòng nhập số từ 0 đến 20";
                return View(model);
            }

            long result = 1;
            var parts = new List<string>();
            for (int i = n; i >= 1; i--)
            {
                result *= i;
                parts.Add(i.ToString());
            }

            model.Result = result.ToString("N0");
            if (n == 0)
                model.Expansion = "0! = 1 (quy ước)";
            else
                model.Expansion = $"{n}! = {string.Join(" × ", parts)} = {result:N0}";

            return View(model);
        }

       
        public IActionResult UnitConverter()
        {
            return View(new UnitConverterViewModel());
        }

        [HttpPost]
        public IActionResult UnitConverter(UnitConverterViewModel model)
        {
            var conversionFactors = new Dictionary<string, Dictionary<string, double>>
            {
                ["length"] = new() { ["mm"] = 0.001, ["cm"] = 0.01, ["m"] = 1.0, ["km"] = 1000.0 },
                ["mass"] = new() { ["g"] = 0.001, ["kg"] = 1.0, ["tấn"] = 1000.0 },
                ["area"] = new() { ["cm²"] = 0.0001, ["m²"] = 1.0, ["ha"] = 10000.0, ["km²"] = 1000000.0 },
                ["volume"] = new() { ["ml"] = 0.001, ["lít"] = 1.0, ["m³"] = 1000.0 },
                ["time"] = new() { ["giây"] = 1.0, ["phút"] = 60.0, ["giờ"] = 3600.0, ["ngày"] = 86400.0 }
            };

            if (conversionFactors.ContainsKey(model.Category) &&
                conversionFactors[model.Category].ContainsKey(model.FromUnit) &&
                conversionFactors[model.Category].ContainsKey(model.ToUnit))
            {
                double toBase = model.Value * conversionFactors[model.Category][model.FromUnit];
                double result = toBase / conversionFactors[model.Category][model.ToUnit];
                model.Result = Math.Round(result, 2);
                model.Formula = $"{model.Value} {model.FromUnit} = {Math.Round(result, 2)} {model.ToUnit}";
            }
            return View(model);
        }

       
        public IActionResult UtilityBill()
        {
            return View(new UtilityBillViewModel());
        }

        [HttpPost]
        public IActionResult UtilityBill(UtilityBillViewModel model)
        {
            double usage = model.EndIndex - model.StartIndex;
            if (usage < 0)
            {
                ModelState.AddModelError("", "Chỉ số cuối phải lớn hơn chỉ số đầu");
                return View(model);
            }

            model.Usage = usage;
            model.TierDetails = new List<BillTierDetail>();
            double total = 0;

            if (model.BillType == "electricity")
            {
               
                var tiers = new[]
                {
                    (name: "Bậc 1 (0–50 kWh)", max: 50.0, price: 1806.0),
                    (name: "Bậc 2 (51–100 kWh)", max: 50.0, price: 1866.0),
                    (name: "Bậc 3 (101–200 kWh)", max: 100.0, price: 2167.0),
                    (name: "Bậc 4 (201–300 kWh)", max: 100.0, price: 2729.0),
                    (name: "Bậc 5 (301–400 kWh)", max: 100.0, price: 3050.0),
                    (name: "Bậc 6 (>400 kWh)", max: double.MaxValue, price: 3151.0),
                };

                double remaining = usage;
                foreach (var tier in tiers)
                {
                    if (remaining <= 0) break;
                    double kwh = Math.Min(remaining, tier.max);
                    double sub = kwh * tier.price;
                    model.TierDetails.Add(new BillTierDetail
                    {
                        TierName = tier.name,
                        Kwh = Math.Round(kwh, 2),
                        UnitPrice = tier.price,
                        SubTotal = Math.Round(sub, 0)
                    });
                    total += sub;
                    remaining -= kwh;
                }
            }
            else 
            {
                var tiers = new[]
                {
                    (name: "Bậc 1 (0–10 m³)", max: 10.0, price: 5973.0),
                    (name: "Bậc 2 (11–20 m³)", max: 10.0, price: 7052.0),
                    (name: "Bậc 3 (21–30 m³)", max: 10.0, price: 8669.0),
                    (name: "Bậc 4 (>30 m³)", max: double.MaxValue, price: 15929.0),
                };

                double remaining = usage;
                foreach (var tier in tiers)
                {
                    if (remaining <= 0) break;
                    double m3 = Math.Min(remaining, tier.max);
                    double sub = m3 * tier.price;
                    model.TierDetails.Add(new BillTierDetail
                    {
                        TierName = tier.name,
                        Kwh = Math.Round(m3, 2),
                        UnitPrice = tier.price,
                        SubTotal = Math.Round(sub, 0)
                    });
                    total += sub;
                    remaining -= m3;
                }
            }

            double vat = total * 0.1;
            model.TotalCost = Math.Round(total + vat, 0);
            model.TierDetails.Add(new BillTierDetail
            {
                TierName = "VAT (10%)",
                Kwh = 0,
                UnitPrice = 0,
                SubTotal = Math.Round(vat, 0)
            });

            return View(model);
        }
    }
}
