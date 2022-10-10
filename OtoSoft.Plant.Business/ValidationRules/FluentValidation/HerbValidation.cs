using FluentValidation;
using OtoSoft.Plant.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoSoft.Plant.Business.ValidationRules.FluentValidation
{
    public class HerbValidation:AbstractValidator<Herb>
    {
        public HerbValidation()
        {
            
        }
    }
}
