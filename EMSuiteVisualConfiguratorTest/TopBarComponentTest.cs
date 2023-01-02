using AngleSharp.Common;
using AngleSharp.Css.Dom;
using Bunit;
using Castle.Components.DictionaryAdapter;
using EMSuiteVisualConfigurator.Client.Components;
using EMSuiteVisualConfigurator.Client.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using Microsoft.JSInterop;
using Moq;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace EMSuiteVisualConfiguratorTest
{
	public class TopBarComponentTest : TestContext
	{
		IRenderedComponent<EMSuiteConfiguration> comp;
		TestContext context;
		IRenderedComponent<IconMenuComponent> menu;
		DotNetObjectReference<IconMenuComponent>? menuRef;
		public TopBarComponentTest()
		{
			context = new TestContext();
			context.JSInterop.SetupVoid("dragResize", _ => true);
			context.JSInterop.SetupVoid("dragAndDrop", _ => true);
			context.JSInterop.Setup<Dictionary<int, int[]>>("GetZonesAndLoggersIds", _ => true).SetResult(new Dictionary<int, int[]>(){
				{ 1, new int[]{}},
				{ 2, new int[]{}}});
            comp = context.RenderComponent<EMSuiteConfiguration>();

			menu = comp.FindComponent<SiteComponent>().FindComponent<IconMenuComponent>();
			menuRef = DotNetObjectReference.Create(menu.Instance);
		}

		[Fact]
		public async void AddZonesToSiteTest()
		{
			IconMenuComponent.addItem("zone", menuRef);
			IconMenuComponent.addItem("zone", menuRef);

			TopBarComponent topBar = comp.FindComponent<SiteComponent>().FindComponent<TopBarComponent>().Instance;
			topBar.RemoveIconMenuItems();
			topBar.splitItems();
			await topBar.LinkAndAddZones(topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO);

			Assert.Equal(2, topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO.Sites[0].Zones.Count);
		}

		[Fact]
		public async void addLoggersToZones()
		{
            IconMenuComponent.addItem("sensor", menuRef);
            IconMenuComponent.addItem("sensor", menuRef);
            IconMenuComponent.addItem("sensor", menuRef);
            IconMenuComponent.addItem("zone", menuRef);
            IconMenuComponent.addItem("zone", menuRef);
			IconMenuComponent.addItem("accesspoint", menuRef);

			var sensors = menu.FindAll(".sensor");
            var zones = menu.FindAll(".zone");

			context.JSInterop.Setup<Dictionary<int, int[]>>("GetZonesAndLoggersIds", _ => true).SetResult(new Dictionary<int, int[]>()
			{
				{ int.Parse(zones[0].Id), new int[]{int.Parse(sensors[0].Id) }},
				{ int.Parse(zones[1].Id), new int[]{int.Parse(sensors[1].Id), int.Parse(sensors[2].Id) }}});

			TopBarComponent topBar = comp.FindComponent<SiteComponent>().FindComponent<TopBarComponent>().Instance;

            topBar.RemoveIconMenuItems();
            topBar.splitItems();

            await topBar.LinkAndAddZones(topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO);

			Assert.Single(topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO.Sites[0].Zones[0].Channels);
			Assert.Equal(2, topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO.Sites[0].Zones[1].Channels.Count);
        }
	}
}
