using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ESIRT.Web.Features.Site
{
    class NewSiteValidator : AbstractValidator<ESIRT.Core.NewSite>
    {
        public NewSiteValidator()
        {            
            RuleFor(m => m.Name).NotNull().WithMessage("not null").MaximumLength(2).WithMessage("max length 2");
            RuleFor(m => m.Name).Equal("TP").WithMessage("Not equal to TP");            
        }
    }
}
