using System;

using UIKit;

namespace PhoneApp
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }
		partial void VerifyButton_TouchUpInside(UIButton sender)
		{
			Validate();


		}

		async void Validate()
		{

			var client = new SALLab05.ServiceClient();

			var resulta = await client.ValidateAsync(“correo”, “pass”, this);
			var alert = UIAlertController.Create("Resultado", $"{resulta.Status}\n{resulta.FullName}\n{resulta.Token}", UIAlertControllerStyle.Alert);
			alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
			PresentViewController(alert, true, null);
		}


		public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var traslatenumber = string.Empty;

            traslatebutton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var traslator = new PhoneTranslator();
                traslatenumber = traslator.ToNumber(phonenumbertext.Text);
                if(string.IsNullOrEmpty(traslatenumber))
                {
                    Callbutton.SetTitle("Llamar",UIControlState.Normal);
                    Callbutton.Enabled = false;

                }
                else{
                    Callbutton.SetTitle($"Llamar al {traslatenumber}", UIControlState.Normal);
                    Callbutton.Enabled = true;


				}


            };
            Callbutton.TouchUpInside += (object sender, EventArgs e) =>
            {
                var URL = new Foundation.NSUrl($"tel:{traslatenumber}");
                if(!UIApplication.SharedApplication.OpenUrl(URL))
                {
                    var alert = UIAlertController.Create("No Soportado", "El esquema 'tel:' no es soportado en este dispositivo", UIAlertControllerStyle.Alert);
                    alert.AddAction(UIAlertAction.Create("OK",UIAlertActionStyle.Default,null));
                    PresentViewController(alert,true, null);                                               
                }
            };





			// Perform any additional setup after loading the view, typically from a nib.
		}

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
