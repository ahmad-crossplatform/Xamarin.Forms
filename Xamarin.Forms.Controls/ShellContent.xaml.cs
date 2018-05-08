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
	public partial class ShellContent : ContentPage
	{
		public ShellContent ()
		{
			InitializeComponent ();

			_pushButton.Clicked += PushClicked;
			_popButton.Clicked += PopClicked;
			_popToRootButton.Clicked += PopToRootClicked;
			_navButton.Clicked += NavClicked;
		}

		private async void NavClicked(object sender, EventArgs e)
		{
			var shell = Application.Current.MainPage as Shell;
			await shell.GoToAsync("app:///s/apps/movies/absgallery");
		}

		private async void PopToRootClicked(object sender, EventArgs e)
		{
			await Navigation.PopToRootAsync();
		}

		private async void PopClicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private async void PushClicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ShellContent());
		}
	}
}