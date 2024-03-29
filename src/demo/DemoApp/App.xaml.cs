﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Trappist.Wpf.Bedrock;
using Trappist.Wpf.Bedrock.Abstractions;

namespace DemoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : TrappistApplication
    {
        public App()
            : base("TestDemo")
        {
        }

        protected override void RegisterNavigationService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddNavigationService(configure => configure.UseFrameNavigationModel());
        }

        protected override void ConfigureServices(HostBuilderContext hostBuilderContext, IServiceCollection serviceCollection)
        {
        }

        protected override void RegisterForNavigation(INavigationRegistry navigationRegistry)
        {
            navigationRegistry.RegisterForNavigation<Views.Home>("/home");
            navigationRegistry.RegisterForNavigation<Views.NavigatedWith>("/nav/navigated");
        }

        protected override void AfterStartup(INavigation navigationService)
        {
            navigationService.Navigate<Views.Home>();
        }
    }
}
