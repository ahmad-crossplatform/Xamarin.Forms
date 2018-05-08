﻿using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Xamarin.Forms.Platform.iOS
{
	public class ShellTableViewController : UITableViewController
	{
		private readonly IShellContext _context;
		private readonly UIView _headerView;
		private readonly ShellTableViewSource _source;
		private double _headerMax = 200;
		private double _headerMin = 44;
		private double _headerSize = 200;
		private double _headerOffset = 0;

		public ShellTableViewController(IShellContext context, UIView headerView, Action<Element> onElementSelected)
		{
			_context = context;
			_headerView = headerView;
			_source = new ShellTableViewSource(context, onElementSelected);
			_source.ScrolledEvent += OnScrolled;
		}

		private void OnScrolled(object sender, UIScrollView e)
		{
			var headerBehavior = _context.Shell.FlyoutHeaderBehavior;

			switch (headerBehavior)
			{
				case FlyoutHeaderBehavior.Default:
				case FlyoutHeaderBehavior.Fixed:
					_headerSize = _headerMax;
					break;
				case FlyoutHeaderBehavior.Scroll:
					_headerSize = _headerMax;
					_headerOffset = -(_headerMax + e.ContentOffset.Y);
					break;
				case FlyoutHeaderBehavior.CollapseOnScroll:
					_headerSize = Math.Max(_headerMin, Math.Min(_headerMax, _headerMax - e.ContentOffset.Y - _headerMax));
					break;
			}

			LayoutParallax();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			
			TableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
			TableView.ContentInsetAdjustmentBehavior = UIScrollViewContentInsetAdjustmentBehavior.Never;
			TableView.ContentInset = new UIEdgeInsets((nfloat)_headerMax, 0, 0, 0);
			TableView.Source = _source;
		}

		public void LayoutParallax()
		{
			var parent = TableView.Superview;
			
			TableView.Frame = parent.Bounds;
			_headerView.Frame = new CGRect(0, _headerOffset, parent.Frame.Width, _headerSize);
		}
	}
}