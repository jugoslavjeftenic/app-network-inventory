using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using NetworkInventory.Maui.Views;
using NetworkInventory.Plugins.DataStore.InMemory;
using NetworkInventory.UseCases;
using NetworkInventory.UseCases.Interfaces;
using NetworkInventory.UseCases.PluginInterfaces;

namespace NetworkInventory.Maui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.UseMauiApp<App>().UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<IDeviceRepository, DeviceInMemoryRepository>();
		builder.Services.AddSingleton<IViewDevicesUseCase, ViewDevicesUseCase>();
		builder.Services.AddSingleton<IViewDeviceUseCase, ViewDeviceUseCase>();
		builder.Services.AddTransient<IEditDeviceUseCase, EditDeviceUseCase>();

		builder.Services.AddSingleton<DevicesPage>();
		builder.Services.AddSingleton<EditDevicePage>();

		return builder.Build();
	}
}
