using HechoaMano.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechoaMano.Domain.Entities
{
    public sealed class SubFamily : Entity
    {
        public string Name { get; init; }
        private SubFamily(Guid id , string name):base(id) => Name = name;

        public static SubFamily Create(Guid id , string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            return new SubFamily(id, value);

        }
    }
}
