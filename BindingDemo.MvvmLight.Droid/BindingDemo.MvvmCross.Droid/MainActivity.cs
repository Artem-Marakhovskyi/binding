﻿using Android.App;
using Android.OS;
using Android.Widget;
using System.Collections.Generic;
using Android.Views;
using BindingDemo.MvvmLight.Core;

namespace BindingDemo.MvvmLight.Droid
{
    [Activity(Label = "MVVM Cross sample", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ActivityBase
    {
        private TextView _textView;
        private EditText _editText;
        private ListView _listView;
        private Button _clearButton;
        private Button _commandButton;
        private ViewModel _viewModel;

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
            //Possible cast fault
            //_bindings.Add(
            //this.SetBinding(
            //() => _viewModel.Elements,
            //() => _adapter.DataSource));

            _adapter.DataSource = _viewModel.Elements;

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
                returnView = (view as TextView);
                returnView.Text = element.ToString();
            }

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