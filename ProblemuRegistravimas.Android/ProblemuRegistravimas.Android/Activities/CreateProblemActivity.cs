﻿using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Widget;
using ProblemuRegistravimas.AndroidProject.Http;
using System.Runtime.Remoting.Contexts;
using Android.Views;
using Java.Lang;

namespace ProblemuRegistravimas.AndroidProject.Activities
{
    [Activity(Label = "Register problem")]
    public class CreateProblemActivity : Activity
    {
        private Spinner _priorityField;
        private EditText _titleField;
        private AutoCompleteTextView _locationField;
        private AutoCompleteTextView _userField;
        private IHttpService _httpService;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TODO Implement Dependency Injection
            _httpService = new HttpService();
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.CreateProblem);
            _priorityField = FindViewById<Spinner>(Resource.Id.priorityField);
            _titleField = FindViewById<EditText>(Resource.Id.titleField);
            _locationField = FindViewById<AutoCompleteTextView>(Resource.Id.locationField);
            _userField = FindViewById<AutoCompleteTextView>(Resource.Id.userField);
            _locationField.TextChanged += _locationField_TextChanged;

            _userField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, _httpService.GetUsers());
            _locationField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, new List<string>());
            _priorityField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, new List<string> { "Normal", "Critical", "Major"});

        }

        private void _locationField_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {
            if (e.Text.Count()>= 5)
            {
                _locationField.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleDropDownItem1Line, _httpService.GetLocationAutocompleteList(new string(e.Text.ToArray())));
            }
        }
    }

}