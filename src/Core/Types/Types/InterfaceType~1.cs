using System;
using HotChocolate.Configuration;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;

namespace HotChocolate.Types
{
    public class InterfaceType<T>
        : InterfaceType
    {
        private Action<IInterfaceTypeDescriptor<T>> _configure;

        public InterfaceType()
        {
            _configure = Configure;
        }

        public InterfaceType(Action<IInterfaceTypeDescriptor<T>> configure)
        {
            _configure = configure
                ?? throw new ArgumentNullException(nameof(configure));
        }

        protected override InterfaceTypeDefinition CreateDefinition(
            IInitializationContext context)
        {
            var descriptor =
                InterfaceTypeDescriptor.New<T>(
                    DescriptorContext.Create(context.Services));
            _configure(descriptor);
            return descriptor.CreateDefinition();
        }

        protected virtual void Configure(IInterfaceTypeDescriptor<T> descriptor)
        {

        }

        protected sealed override void Configure(
            IInterfaceTypeDescriptor descriptor)
        {
            // TODO : resources
            throw new NotSupportedException();
        }
    }
}
