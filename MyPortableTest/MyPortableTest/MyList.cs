using System;
using System.Collections.ObjectModel;
using EventDay.Api.Client;
using MyPortableTest.Helpers;
using Xamarin.Forms;
using MyPortableTest.Interfaces;

namespace MyPortableTest
{

    public class MyList : ContentPage
    {
        private readonly ObservableCollection<string> _items = new ObservableCollection<string>();

        public MyList()
        {

            var list = new ListView { ItemsSource = AppSettings.EventState.Sessions };

            var button = new Button { Text = "Click me" };

            button.Clicked += (sender, e) => _items.Add(string.Empty);

            var stack = new StackLayout();

            stack.Children.Add(list);
            stack.Children.Add(button);

            var cell = new DataTemplate(typeof(TextCell));

            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(TextCell.DetailProperty, "Description");

            list.ItemTemplate = cell;


            list.ItemTapped += (sender, e) =>
            {
                if (list.SelectedItem == null) return;

                var page = new ContentPage();
                var sessionState = list.SelectedItem as SessionState;

                var label = new Label { Text = sessionState.Title };

                page.Content = label;

                Navigation.PushAsync(page);

                list.SelectedItem = null;
            };

            Content = stack;
        }
    }
}
