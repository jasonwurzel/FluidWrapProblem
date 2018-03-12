using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using ReactiveUI;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FluidWrapProblem
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IViewFor<MainPageViewModel>
    {
        public MainPage()
        {
            this.InitializeComponent();

			ViewModel = new MainPageViewModel();


	        this.Button2x2.Events().Click.Subscribe(_ => ViewModel.TilingOptions = TilingOptions.Option2X2);
	        this.Button3x3.Events().Click.Subscribe(_ => ViewModel.TilingOptions = TilingOptions.Option3X3);

	        this.OneWayBind(ViewModel, model => model.GridItems, view => view.GridView.ItemsSource)
		        //.DisposeWith(disposable)
		        ;

	        Observable.FromEventPattern<SizeChangedEventHandler, SizeChangedEventArgs>(eh => GridView.SizeChanged += eh, eh => GridView.SizeChanged -= eh)
		        .Select(pattern => pattern.EventArgs.NewSize)
		        .BindTo(ViewModel, model => model.ViewDimensions)
		        //.DisposeWith(disposable)
		        ;



        }

	    object IViewFor.ViewModel
	    {
		    get => ViewModel;
		    set => ViewModel = (MainPageViewModel) value;
	    }

	    public MainPageViewModel ViewModel { get; set; }
    }
}
