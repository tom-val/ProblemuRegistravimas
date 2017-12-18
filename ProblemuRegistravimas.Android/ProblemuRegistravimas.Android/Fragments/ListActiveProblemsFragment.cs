﻿using System;
using System.Collections.Generic;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using ProblemuRegistravimas.AndroidProject.Adapters;
using static Android.Support.V7.Widget.RecyclerView;
using Fragment = Android.Support.V4.App.Fragment;

namespace ProblemuRegistravimas.AndroidProject.Fragments
{
    public class ListActiveProblemsFragment : Fragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            RecyclerView recyclerView = (RecyclerView)inflater.Inflate(
                Resource.Layout.recycler_view, container, false);

            ContentAdapter adapter = new ContentAdapter();
            adapter.ItemClick += Adapter_ItemClick;
            recyclerView.SetAdapter(adapter);
            recyclerView.HasFixedSize = true;
            recyclerView.SetLayoutManager(new LinearLayoutManager(Activity));
            return recyclerView;
        }

        private void Adapter_ItemClick(object sender, Models.Problem e)
        {
            
        }
    }
}