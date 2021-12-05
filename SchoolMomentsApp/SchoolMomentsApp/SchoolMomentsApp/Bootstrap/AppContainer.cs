

using Autofac;
using SchoolMomentsApp.Services;
using SchoolMomentsApp.ViewModels;
using System;

namespace SchoolMomentsApp.Bootstrap
{

    public class AppContainer 
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //ViewModels
            builder.RegisterType<LoginViewModel>();
            builder.RegisterType<MomentDetailViewModel>();
            builder.RegisterType<MomentOverviewViewModel>();
            builder.RegisterType<RegisterStudentForMomentViewModel>();
            builder.RegisterType<StudentsOverviewViewModel>();
            builder.RegisterType<StudentMainPageViewModel>();

            //services
            builder.RegisterType<LoginDataService>().As<ILoginDataService>();
            builder.RegisterType<MomentDataService>().As<IMomentDataService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterType<StudentDataService>().As<IStudentDataService>();
            builder.RegisterType<TeacherDataService>().As<ITeacherDataService>();
                       

            //General
            //builder.Register(c => Instance).As<IDependencyResolver>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

    }

}

