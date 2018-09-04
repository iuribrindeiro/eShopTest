using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopTest.Domain.SeedWork.UnitOfWork;
using Microsoft.AspNetCore.Mvc.Filters;

namespace eShopTest.Presentation.Filters
{
    public class SuccessFilter : IResultFilter
    {
        private readonly IUnitOfWork _unitOfWork;

        public SuccessFilter(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public void OnResultExecuting(ResultExecutingContext context)
        {
            //nothing to do here...
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _unitOfWork.CommitTransaction();
        }
    }
}
