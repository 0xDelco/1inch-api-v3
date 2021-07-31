using FluentValidation;

namespace OneInch.Api
{   
    public class ApproveCalldataValidator : AbstractValidator<ApproveCalldataRequest>
    {
        public ApproveCalldataValidator() {
            
            RuleFor(request => request.tokenAddress).NotNull();
            
            RuleFor(x => x.amount)
                    .Null()
                    .When(x => x.infinity);
                    
            RuleFor(request => request.amount).NotNull();                            
        }
    }
}