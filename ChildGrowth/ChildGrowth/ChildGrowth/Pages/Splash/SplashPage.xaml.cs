
using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using ChildGrowth.Services;
using ChildGrowth.Statics;
using ChildGrowth.Pages.Base;
using ChildGrowth.ViewModels.Splash;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Xamarin;

namespace ChildGrowth.Pages.Splash
{
    public partial class SplashPage : SplashPageXaml
    {
        readonly IAuthenticationService _AuthenticationService;

        public SplashPage()
        {
            InitializeComponent();

            BindingContext = new SplashViewModel();
            _AuthenticationService = DependencyService.Get<IAuthenticationService>();

            SignInButton.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = 1,
                    Command = new Command(SignInButtonTapped)
                });

            SkipSignInButton.GestureRecognizers.Add(
                new TapGestureRecognizer()
                {
                    NumberOfTapsRequired = 1,
                    Command = new Command(SkipSignInButtonTapped)
                });
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            // fetch the demo credentials
            //await ViewModel.LoadDemoCredentials();

            // pause for a moment before animations
            await Task.Delay(App.AnimationSpeed);

            // Sequentially animate the login buttons. ScaleTo() makes them "grow" from a singularity to the full button size.
            await SignInButton.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
            await SkipSignInButton.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
        }

        async void SignInButtonTapped()
        {
            //NOTHING for now GG
        }


        async void SkipSignInButtonTapped()
        {
            //_AuthenticationService.BypassAuthentication();

            // Broadcast a message that we have sucessdully authenticated.
            // This is mostly just for Android. We need to trigger Android to call the SalesDashboardPage.OnAppearing() method,
            // because unlike iOS, Android does not call the OnAppearing() method each time that the Page actually appears on screen.
            //Send(this, MessagingServiceConstants.AUTHENTICATED);

            App.GoToRoot();
        }

    }

    /// <summary>
    /// This class definition just gives us a way to reference ModelBoundContentPage<T> in the XAML of this Page.
    /// </summary>
    public abstract class SplashPageXaml : ModelBoundContentPage<SplashViewModel>
    {
    }
}
