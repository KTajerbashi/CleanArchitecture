using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Library.Validators
{
    public static class CustomValidator
    {
        public static IRuleBuilder<T, string?> StartAndEndControl<T>
            (this IRuleBuilder<T, string?> ruleBuilder, string? start = null, string? end = null)
            => ruleBuilder.Custom((input,Context) =>
            {
                if (start != null && input != null && !input.StartsWith(start))
                {
                    Context.AddFailure($"Must Start With {start}, But You Enter {input[0]}");
                }
                if (end != null && input != null && !input.EndsWith(end))
                {
                    Context.AddFailure($"Must Start With {start}, But You Enter {input[0]}");
                }
            });
    }
}
