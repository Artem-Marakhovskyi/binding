using Android.App;
using Android.OS;
using Android.Widget;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Helpers;
using System.Collections.Generic;
using BindingDemo.MvvmLight.Core;
using Android.Views;
using System.Linq;

namespace BindingDemo.MvvmLight.Droid
{
    [Activity(Label = "MVVM Light sample", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ActivityBase
    {
        private TextView _textView;
        private EditText _editText;
        private ListView _listView;
        private Button _clearButton;
        private Button _commandButton;
        private ViewModel _viewModel;
        private IList<Binding> _bindings = new List<Binding>();
        private ObservableAdapter<CollectionElement> _adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            _viewModel = new ViewModel();

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            FindViews();
            InitListView();

            ApplyBindings();
        }

        private void ApplyBindings()
        {
            //Without ConvertSourceToTarget binding failes, because binding doesn't know how to cast types
            // and doesn't know there is an implicit cast between types
            _bindings.Add(
                this.SetBinding(
                    () => _viewModel.Elements,
                    () => _adapter.DataSource)
                .ConvertSourceToTarget(e => e));

            // You can substitute code above to this code. Works pretty good
            //_adapter.DataSource = _viewModel.Elements;

            _bindings.Add(
                this.SetBinding(
                    () => _viewModel.Text,
                    () => _textView.Text));

            _bindings.Add(
                this.SetBinding(
                    () => _viewModel.Text,
                    () => _editText.Text,
                    BindingMode.TwoWay));

            _clearButton.SetCommand(_viewModel.ClearCommand);
            _commandButton.SetCommand(_viewModel.StartCollectionChangesCommand);
        }

        private void InitListView()
        {
            _adapter = new ObservableAdapter<CollectionElement>();
            _adapter.GetTemplateDelegate = TemplateDelegate;
            _listView.Adapter = _adapter;
        }

        private View TemplateDelegate(int idx, CollectionElement element, Android.Views.View view)
        {
            TextView returnView;
            if (view == null)
            {
                returnView = new TextView(this);
            }
            else
            {
                returnView = view as TextView;
            }

            returnView.Text = element.ToString();

            return returnView;
        }

        private void FindViews()
        {
            _textView = FindViewById<TextView>(Resource.Id.text_view);
            _editText = FindViewById<EditText>(Resource.Id.edit_text);
            _listView = FindViewById<ListView>(Resource.Id.list_view);
            _clearButton = FindViewById<Button>(Resource.Id.clear_button);
            _commandButton = FindViewById<Button>(Resource.Id.command_button);
        }
    }
}