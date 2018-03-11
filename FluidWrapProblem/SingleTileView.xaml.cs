using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ReactiveUI;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FluidWrapProblem
{
	public sealed partial class SingleTileView : UserControl, IViewFor<SingleTileViewModel>
	{
		public SingleTileView()
		{
			this.InitializeComponent();

			this.OneWayBind(ViewModel, model => model.Width, view => view.Width);
			this.OneWayBind(ViewModel, model => model.Height, view => view.Height);

		}

		object IViewFor.ViewModel
		{
			get => ViewModel;
			set => ViewModel = (SingleTileViewModel) value;
		}

		public SingleTileViewModel ViewModel { get; set; }
	}
}
