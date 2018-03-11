using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace FluidWrapProblem
{
	public class MainPageViewModel : ReactiveObject
	{
		[Reactive]
		public double ItemsHeight { get; set; } = 200;

		[Reactive]
		public double ItemsWidth { get; set; } = 200;

		[Reactive]
		public bool IsComposing { get; set; } = true;

		[Reactive]
		public Orientation Orientation { get; set; } = Orientation.Horizontal;

		[Reactive]
		public Brush Background { get; set; }

		[Reactive]
		public Size ViewDimensions { get; set; }


		public ReactiveList<SingleTileViewModel> GridItems { get; set; } = new ReactiveList<SingleTileViewModel>();

		public MainPageViewModel()
		{
			GridItems.AddRange(new[]
			{
				new SingleTileViewModel(),
				new SingleTileViewModel(),
				new SingleTileViewModel(),
				new SingleTileViewModel(),
			});

			this.WhenAnyValue(model => model.ViewDimensions)
				//.ObserveOn(TaskPoolScheduler.Default)
				.Subscribe(size =>
				{
					var rows = 2;
					var columns = 2;

					//var width = 300;
					//var height = 300;

					var width = Math.Floor(size.Width / columns);
					var height = Math.Floor(size.Height / rows);

					ItemsWidth = width;
					ItemsHeight = height;


					foreach (var child in GridItems)
					{
						child.Width = width;
						child.Height = height;
					}

				});


		}
	}
}