using System;

namespace Code.Core.Dependencies
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    public class InjectAttribute : Attribute
    {
        
    }
}