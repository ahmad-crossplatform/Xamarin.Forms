﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShellTest : Shell
	{
		public ShellTest ()
		{
			Routing.RegisterRoute("absgallery", typeof(AbsoluteLayoutGallery));
			InitializeComponent ();

			Navigating += OnNavigating;
		}

		bool allowPop = false;

		private void OnNavigating(object sender, ShellNavigatingEventArgs e)
		{
			if (allowPop = !allowPop)
				e.Cancel();
		}
	}
}