using System;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using ReactiveUI;
using Splat;
using Mediaplayer2.ViewModels;
using Mediaplayer2.Views;
using Microsoft.Extensions.DependencyInjection;
using Splat.Microsoft.Extensions.DependencyInjection;


namespace Mediaplayer2;

public static class Helper
{
    public static void Services()
    {
        var service = new ServiceCollection();
        service.AddSingleton<IScreen, MainWindowViewModel>();
        
        service.UseMicrosoftDependencyResolver();
        
        var services = service.BuildServiceProvider();

        Locator.CurrentMutable.InitializeSplat();
        Locator.CurrentMutable.InitializeReactiveUI();
        
        Locator.CurrentMutable.RegisterConstant(services);
        Locator.CurrentMutable.Register<IViewFor<MainPageViewModel>>(() => new MainPageView());
        Locator.CurrentMutable.Register<IViewFor<MusicPageViewModel>>(() => new MusicPageView());
        Locator.CurrentMutable.Register<IViewFor<VideoPageViewModel>>(() => new VideoPageView());
        Locator.CurrentMutable.Register<IViewFor<PlaylistPageViewModel>>(() => new PlaylistPageView());
        Locator.CurrentMutable.Register<IViewFor<SettingsPageViewModel>>(() => new SettingsPageView());
        Locator.CurrentMutable.Register<IViewFor<EditAudioViewModel>>(() => new EditAudioView());
        Locator.CurrentMutable.Register<IViewFor<EditVideoViewModel>>(() => new EditVideoView());
        Locator.CurrentMutable.Register<IViewFor<MusicFromListViewModel>>(() => new MusicFromListView());
        Locator.CurrentMutable.Register<IViewFor<EditPlaylistViewModel>>(() => new EditPlaylistView());
        
        RxApp.MainThreadScheduler = AvaloniaScheduler.Instance;
    }
}