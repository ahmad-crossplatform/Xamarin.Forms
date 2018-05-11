using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;
using System.Collections.ObjectModel;

#if UITEST
using Xamarin.UITest;
using NUnit.Framework;
#endif


namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 1872, "[Android] Fix Vector Drawables to work with pre api 21 ", PlatformAffected.Android)]
	public class Issue1872 : TestContentPage
	{
		protected override void Init()
		{
			 
			//Content = webView;
		}
	}
}
