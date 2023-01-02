using AngleSharp.Common;
using Bunit;
using EMSuiteVisualConfigurator.Client.Components;
using EMSuiteVisualConfigurator.Client.Pages;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit.Abstractions;

namespace EMSuiteVisualConfiguratorTest
{
	public class EMSuiteConfigurationTest : TestContext
	{
		IRenderedComponent<EMSuiteConfiguration> comp;
		public EMSuiteConfigurationTest()
		{
			var context = new TestContext();
			context.JSInterop.SetupVoid("dragResize", _ => true);
			context.JSInterop.SetupVoid("dragAndDrop", _ => true);

			comp = context.RenderComponent<EMSuiteConfiguration>();
		}

		[Fact]
		public void AddSiteButtonTest()
		{
			var btn = comp.Find("button.add-site");

			IReadOnlyList<IRenderedComponent<SiteComponent>> comps = comp.FindComponents<SiteComponent>();
			Assert.Equal(1, comps.Count);

			btn.Click();

			comps = comp.FindComponents<SiteComponent>();
			Assert.Equal(2, comps.Count);
		}


		[Fact]
		public void SwitchSiteButtonTest()
		{
			var btn = comp.Find("button.add-site");
			btn.Click();
			btn.Click();

			var switchBtn = comp.FindAll("button.btn-secondary");
			switchBtn[2].Click();

			IReadOnlyList<IRenderedComponent<SiteComponent>> comps = comp.FindComponents<SiteComponent>();

			Assert.Equal("none", comps.GetItemByIndex(0).Instance.Display);
			Assert.Equal("inline", comps.GetItemByIndex(2).Instance.Display);
		}

		[Fact]
		public void DeleteLastSiteButtonTest()
		{
			var btn = comp.Find("button.add-site");
			btn.Click();
			btn.Click();
			int lastID = comp.FindComponents<SiteComponent>().Last().Instance.SiteId;

			var switchBtn = comp.FindAll("button.btn-danger");
			switchBtn[2].Click();

			IReadOnlyList<IRenderedComponent<SiteComponent>> comps = comp.FindComponents<SiteComponent>();
			Assert.Equal(2, comps.Count());
			Assert.NotEqual(lastID, comps.Last().Instance.SiteId);
		}

		[Fact]
		public void DeleteFirstSiteButtonTest()
		{
			var btn = comp.Find("button.add-site");
			btn.Click();
			btn.Click();
			int lastID = comp.FindComponents<SiteComponent>().Last().Instance.SiteId;

			var switchBtn = comp.FindAll("button.btn-danger");
			switchBtn[0].Click();

			IReadOnlyList<IRenderedComponent<SiteComponent>> comps = comp.FindComponents<SiteComponent>();
			Assert.Equal(2, comps.Count());
			Assert.Equal(lastID, comps.Last().Instance.SiteId);
		}

	}
}