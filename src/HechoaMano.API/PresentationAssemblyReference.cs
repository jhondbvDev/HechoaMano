using HechoaMano.Application;
using System.Reflection;

namespace HechoaMano.API
{
    public class PresentationAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(PresentationAssemblyReference).Assembly;
    }
}
