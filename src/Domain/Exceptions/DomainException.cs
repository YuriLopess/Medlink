using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DomainException : Exception
    {
        public DomainException(String message) : base(message) { }

        public DomainException(String message, Exception innerException) : base(message, innerException) { }
    }
}
