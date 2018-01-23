using Autofac;
using CarRental.Api;
using CarRental.ApplicationSettings;
using CarRental.RentalStorage;
using CarRental.UseCases;

namespace CarRental.Dependencies
{
    public class DependencyBuilder
    {
        private ContainerBuilder _builder;

        public DependencyBuilder Begin()
        {
            _builder = new ContainerBuilder();
            return this;
        }

        public DependencyBuilder WithProductionDependencies()
        {
            _builder.RegisterType<CarRentalApplication>();
            _builder.RegisterType<CarReturnController>();
            _builder.RegisterType<RentalRegistrationController>();

            _builder.RegisterType<ApplicationSettingsRepository.ApplicationSettingsRepository>()
                .As<IApplicationSettings>();

            _builder.RegisterType<RentalRepository.RentalRepository>()
                .As<IRentalStorage>();

            return this;
        }

        public DependencyBuilder WithMock<T>(T instanceType) where T : class
        {
            _builder.RegisterInstance(instanceType);
            return this;
        }

        public IContainer Build()
        {
            return _builder.Build();
        }
    }
}
