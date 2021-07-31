using FluentValidation;

namespace OneInch.Api
{   
    public class SwapRequestValidator : AbstractValidator<SwapRequest>
    {
        public SwapRequestValidator() {
            
            RuleFor(request => request.fromTokenAddress).NotNull();

            RuleFor(request => request.toTokenAddress).NotNull();

            RuleFor(request => request.fromAddress).NotNull();
            
            RuleFor(request => request.amount).NotNull()
                                              .GreaterThan(0);
            
            RuleFor(request => request.slippage).NotNull()
                                    .GreaterThanOrEqualTo(0);
        }
    }
    
}