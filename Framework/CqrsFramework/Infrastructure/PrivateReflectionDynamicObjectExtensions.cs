using CqrsFramework.Domain;

namespace CqrsFramework.Infrastructure
{
    internal static class PrivateReflectionDynamicObjectExtensions
    {
        public static dynamic AsDynamic(this AggregateRoot o)
        {
            return new PrivateReflectionDynamicObject { RealObject = o };
        }
    }

    // internal static class PrivateReflectionDynamicObjectExtensions
    // {
    //     public static dynamic AsDynamic(this object o)
    //     {
    //         return PrivateReflectionDynamicObject.WrapObjectIfNeeded(o);
    //     }
    // }
}
