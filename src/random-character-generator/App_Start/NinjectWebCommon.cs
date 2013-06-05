[assembly: WebActivator.PreApplicationStartMethod(typeof(random_character_generator.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(random_character_generator.App_Start.NinjectWebCommon), "Stop")]

namespace random_character_generator.App_Start
{
    using System;
    using System.IO;
    using System.Web;
    using System.Linq;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using random_character_generator.Services;
    using Raven.Client;
    using Raven.Client.Embedded;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        private static readonly IDocumentStore DocumentStore = new EmbeddableDocumentStore
        {

            DataDirectory = @"App_Data\RavenDb",
            UseEmbeddedHttpServer = true
        };
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDocumentStore>().ToMethod(x =>
            {
                DocumentStore.Initialize();

                using (var session = DocumentStore.OpenSession())
                {
                    if (!session.Query<Name>().Any())
                    {
                        var nameRows = from l in File.ReadLines(@"E:\!Code\the-character-forge\src\random-character-generator\FantasyNames.txt")
                                    let row = l.Split(new string[] { ",", " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(row => row)
                                    select row;
                        foreach (var group in nameRows)
                        {
                            foreach (var name in group)
                            {
                                session.Store(new Name() { FirstName = name });
                            }
                        }
                        session.SaveChanges();
                    }
                }

                return DocumentStore;
            }).InSingletonScope();

            kernel.Bind<IDocumentSession>().ToMethod(x =>
            {
                var store = x.Kernel.Get<IDocumentStore>();
                return store.OpenSession();
            }).InRequestScope();

            kernel.Bind<IDiceRoller>().To<DiceRoller>();
            kernel.Bind<IRandomNameGenerator>().To<RandomNameGenerator>();
            kernel.Bind<OriginStoryGenerator>().ToSelf();
            kernel.Bind<CharacterCreator>().ToSelf();
            kernel.Bind<Random>().ToMethod(x => new Random()).InSingletonScope();
        }        
    }
}
