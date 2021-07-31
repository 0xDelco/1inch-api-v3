using FluentValidation;

namespace OneInch.Api
{
    public class QuoteRequestValidator : AbstractValidator<QuoteRequest>
    {
        public QuoteRequestValidator() {
            
            RuleFor(request => request.toTokenAddress).NotNull();

            RuleFor(request => request.fromTokenAddress).NotNull();
            
            RuleFor(request => request.amount).NotNull()
                                                .GreaterThan(0);
        }
    }
}