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
		public TopBarComponentTest()
		{
			context = new TestContext();
			context.JSInterop.SetupVoid("dragResize", _ => true);
			context.JSInterop.SetupVoid("dragAndDrop", _ => true);
			context.JSInterop.Setup<Dictionary<int, int[]>>("GetZonesAndLoggersIds", _ => true).SetResult(new Dictionary<int, int[]>()
			{
				{ 1, new int[]{}},
				{ 2, new int[]{}}});
            comp = context.RenderComponent<EMSuiteConfiguration>();
		}

		[Fact]
		public async void AddZonesToSite()
		{
			IRenderedComponent<IconMenuComponent> menu = comp.FindComponent<SiteComponent>().FindComponent<IconMenuComponent>();
			DotNetObjectReference<IconMenuComponent>? menuRef = DotNetObjectReference.Create(menu.Instance);
			
			IconMenuComponent.addItem("zone", menuRef);
			IconMenuComponent.addItem("zone", menuRef);
			var zones = menu.FindAll(".zone");
			zones[0].SetAttribute("x", "90");
			zones[0].SetAttribute("y", "-210");
			zones[1].SetAttribute("x", "190");
			zones[1].SetAttribute("y", "-110");

			TopBarComponent topBar = comp.FindComponent<SiteComponent>().FindComponent<TopBarComponent>().Instance;
			topBar.RemoveIconMenuItems();
			topBar.splitItems();
			await topBar.LinkAndAddZones(topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO);

			Assert.Equal(2, topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO.Sites[0].Zones.Count);
		}

		[Fact]
		public async void addLoggersToZones()
		{
            //Get Object reference to iconmenu
            IRenderedComponent<IconMenuComponent> menu = comp.FindComponent<SiteComponent>().FindComponent<IconMenuComponent>();
            DotNetObjectReference<IconMenuComponent>? menuRef = DotNetObjectReference.Create(menu.Instance);

            IconMenuComponent.addItem("sensor", menuRef);
            IconMenuComponent.addItem("sensor", menuRef);
            IconMenuComponent.addItem("sensor", menuRef);
            IconMenuComponent.addItem("zone", menuRef);
            IconMenuComponent.addItem("zone", menuRef);
			IconMenuComponent.addItem("accesspoint", menuRef);

			var sensors = menu.FindAll(".sensor");
            var zones = menu.FindAll(".zone");

            sensors[0].SetAttribute("x", "150");
            sensors[0].SetAttribute("y", "50");

            sensors[1].SetAttribute("x", "450");
            sensors[1].SetAttribute("y", "50");

            sensors[2].SetAttribute("x", "450");
            sensors[2].SetAttribute("y", "50");

            zones[0].SetAttribute("x", "90");
            zones[0].SetAttribute("y", "-201");
			zones[0].SetAttribute("style", "width: 200px; height: 200px;");

            zones[1].SetAttribute("x", "390");
            zones[1].SetAttribute("y", "-205");
			zones[1].SetAttribute("style", "width: 200px; height: 200px;");


			context.JSInterop.Setup<Dictionary<int, int[]>>("GetZonesAndLoggersIds", _ => true).SetResult(new Dictionary<int, int[]>()
			{
				{ int.Parse(zones[0].Id), new int[]{int.Parse(sensors[0].Id) }},
				{ int.Parse(zones[1].Id), new int[]{int.Parse(sensors[1].Id), int.Parse(sensors[2].Id) }}});

			TopBarComponent topBar = comp.FindComponent<SiteComponent>().FindComponent<TopBarComponent>().Instance;

            topBar.RemoveIconMenuItems();
            topBar.splitItems();

            await topBar.LinkAndAddZones(topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO);

			Assert.Equal(1, topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO.Sites[0].Zones[0].Channels.Count);
			Assert.Equal(2, topBar.CreateEMSuiteConfigurationModel.ConfigurationDTO.Sites[0].Zones[1].Channels.Count);
        }
	}
}
