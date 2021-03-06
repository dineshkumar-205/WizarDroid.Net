using Android.OS;
using Android.Widget;
using WizarDroid.NET;
using WizarDroid.NET.Persistence;

namespace WizarDroid.NET_Sample.Wizards
{
    /// <summary>
    /// Step1 of the FormWizard
    /// </summary>
    public class FormStep1 : WizardStep
    {
        [WizardState]
        public string FirstName;

        [WizardState]
        public string LastName;

        private EditText firstNameEt;
        private EditText lastNameEt;

        public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.form_step_1, container, false);

            this.StepExited += OnStepExited;

            firstNameEt = view.FindViewById<EditText>(Resource.Id.firstnameField);
            lastNameEt = view.FindViewById<EditText>(Resource.Id.lastnameField);

            firstNameEt.Text = FirstName;
            lastNameEt.Text = LastName;

            return view;
        }

        private void OnStepExited(StepExitCode exitCode)
        {
            if (exitCode == StepExitCode.ExitNext)
                BindDataFields();
        }

        void BindDataFields()
        {
            FirstName = firstNameEt.Text;
            LastName = lastNameEt.Text;
        }
    }
}