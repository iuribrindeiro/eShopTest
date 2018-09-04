using System;
using System.Collections.Generic;
using System.Text;

namespace eShopTest.Domain.SeedWork.Exception
{
    public class EntityNotFoundException : AbstractException
    {
        public EntityNotFoundException() : base("The resource you was looking for no longer exists")
        {
        }
    }
}
