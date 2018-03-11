using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;

namespace FluidWrapProblem
{
	public class SingleTileViewModel : ReactiveObject
	{

		public SingleTileViewModel()
		{
			this.WhenAnyValue(model => model.Width).Subscribe(w => { });
		}
		// dummy
		[Reactive]
		public double Width { get; set; }

		[Reactive]
		public double Height { get; set; }
	}
}