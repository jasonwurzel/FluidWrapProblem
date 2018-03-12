using System;
using System.Reactive;
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

		[Reactive]
		public TilingOptions TilingOptions { get; set; }


		public ReactiveList<SingleTileViewModel> GridItems { get; set; } = new ReactiveList<SingleTileViewModel>();

		public MainPageViewModel()
		{
			this.WhenAnyValue(model => model.ViewDimensions, model => model.TilingOptions)
				.Subscribe(sizeAndTiling =>
				{
					var size = sizeAndTiling.Item1;
					var tiling = sizeAndTiling.Item2;

					int rows = tiling == TilingOptions.Option2X2 ? 2 : 3;
					int columns = tiling == TilingOptions.Option2X2 ? 2 : 3;

					adjustSingleTileViewModelCount(rows, columns);

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

		private void adjustSingleTileViewModelCount(int rows, int columns)
		{
			while (GridItems.Count > rows * columns)
				GridItems.RemoveAt(GridItems.Count - 1);

			while (GridItems.Count < rows * columns)
				GridItems.Add(new SingleTileViewModel());
		}
	}

	public enum TilingOptions
	{
		Option2X2,
		Option3X3
	}
}